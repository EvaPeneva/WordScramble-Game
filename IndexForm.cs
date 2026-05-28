namespace WordScrambleLanguageSwitch
{
    public partial class IndexForm : Form
    {
        // Name of the word file. This file is copied next to the .exe when the program runs.
        private const string WordsTextFile = "words.txt";
        private const string HighScoreFile = "highscore.txt"; // This file stores the best score.
        private const int WordLength = 5; // We use only 5-letter words, like the given words.txt file.
        private const int MaxWrongAttempts = 9; // After more than 9 wrong attempts, a new word is generated.
        private const int WinGoal = 10; // After 10 guessed words, a win message is shown.
        private const int HardModeSeconds = 30; // In hard mode there are 30 seconds for each word.

        // Random is used to choose a random word and to shuffle letters.
        private readonly Random random = new Random();

        // allWords stores all valid 5-letter words from words.txt.
        // wordList stores the words that are still available in the current game.
        // failedAttempts stores the player’s wrong guesses for the current word.
        private readonly List<string> allWords = new List<string>();
        private readonly List<string> wordList = new List<string>();
        private readonly List<string> failedAttempts = new List<string>();

        // Variables for the current state of the game.
        private int attempts = 0;
        private int guessedWords = 0;
        private int score = 0;
        private int highScore = 0;
        private int secondsLeft = HardModeSeconds;
        private bool hintUsed = false;
        private bool hardMode = false;
        private string currentWord = string.Empty;
        private string currentLanguage = "en";

        public IndexForm()
        {
            // InitializeComponent() creates the buttons, labels, and text boxes from the Designer file.
            InitializeComponent();
        }

        // This method runs as soon as the form opens.
        private void OnLoad(object sender, EventArgs e)
        {
            comboBoxLanguage.SelectedIndex = 0; // 0 = English
            comboBoxDifficulty.SelectedIndex = 0; // 0 = Easy
            comboBoxTheme.SelectedIndex = 0; // 0 = Light

            ApplyLanguage(); // Sets the texts in the selected language.
            ApplyTheme(); // Sets the colors for the selected theme.
            LoadHighScore(); // Loads the high score from highscore.txt if the file exists.
            GetAllWords(); // Loads the words from words.txt.
            StartNewGame(); // Starts a new game.
        }

        // Reads all words from words.txt and keeps only valid 5-letter words.
        private void GetAllWords()
        {
            // AppContext.BaseDirectory is the folder where the program starts from.
            string filePath = Path.Combine(AppContext.BaseDirectory, WordsTextFile);

            // If words.txt is missing, the game has no words to use.
            if (!File.Exists(filePath))
            {
                MessageBox.Show(T("fileMissing"), T("error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            // StreamReader reads the text file line by line.
            using (StreamReader reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    string word = reader.ReadLine(); // Each word is on a separate line.

                    if (!string.IsNullOrWhiteSpace(word))
                    {
                        word = word.Trim().ToLower();

                                                // Check: the word must be 5 letters, contain only letters, and not be duplicated.
                        if (word.Length == WordLength && word.All(char.IsLetter) && !allWords.Contains(word))
                        {
                            allWords.Add(word);
                        }
                    }
                }
            }
        }

        // Starts a new game: resets the current score and prepares the word list.
        private void StartNewGame()
        {
            gameTimer.Stop(); // Stops the timer if it was running.

            attempts = 0; // Wrong attempts for the current word.
            guessedWords = 0; // Number of guessed words in the current game.

                        // The current score always starts from 0 in a new game.
            // Only the High Score is saved after closing the program.
            score = 0;

            hintUsed = false;
            failedAttempts.Clear();
            wordList.Clear();
            wordList.AddRange(allWords);

            hardMode = comboBoxDifficulty.SelectedIndex == 1; // 1 = Hard mode with timer.

            textBoxInput.Enabled = true;
            buttonCheck.Enabled = true;
            buttonSkip.Enabled = true;
            buttonHint.Enabled = true;
            buttonShowAnswer.Enabled = true;

            GenerateNewWord();
            UpdateLabels();
            ShowMessage("newGame");
        }

        // Chooses a new random word from the remaining words.
        private void GenerateNewWord()
        {
            // If there are no words left, the game ends.
            if (wordList.Count == 0)
            {
                gameTimer.Stop(); // Stops the timer if it was running.
                labelScrambledWord.Text = T("finished");
                textBoxInput.Enabled = false;
                buttonCheck.Enabled = false;
                buttonSkip.Enabled = false;
                buttonHint.Enabled = false;
                buttonShowAnswer.Enabled = false;
                return;
            }

            int randomIndex = random.Next(wordList.Count); // Random index from the list.
            currentWord = wordList[randomIndex]; // This is the correct word for the current round.
            ResetRoundInfo();
        }

        // Resets the information for the new word/round.
        private void ResetRoundInfo()
        {
            attempts = 0; // Wrong attempts for the current word.
            hintUsed = false;
            failedAttempts.Clear();
            labelScrambledWord.Text = ScrambleWord(currentWord); // Shows the scrambled word on the screen.
            textBoxInput.Clear();
            UpdateLabels();
            StartTimerIfNeeded(); // Starts the timer only if the mode is Hard.
            ShowMessage("newWord");
        }

        // Shuffles the letters of the word using the Fisher-Yates algorithm.
        private string ScrambleWord(string word)
        {
            char[] letters = word.ToCharArray();

                        // Fisher-Yates: we go backwards and swap letters with random positions.
            for (int i = letters.Length - 1; i > 0; i--)
            {
                int randomPosition = random.Next(i + 1); // Random position from 0 to i.
                char oldLetter = letters[i]; // Temporarily stores the current letter.
                letters[i] = letters[randomPosition];
                letters[randomPosition] = oldLetter;
            }

            string scrambled = new string(letters);

                        // If the word accidentally stays the same, shuffle again.
            if (scrambled == word && word.Length > 1)
            {
                return ScrambleWord(word);
            }

            return scrambled;
        }

        // Runs when the Check button is clicked.
        private void ButtonCheckClick(object sender, EventArgs e)
        {
            CheckTheWord();
            UpdateLabels();
        }

        // Checks whether the user’s answer matches the correct word.
        private void CheckTheWord()
        {
            string input = textBoxInput.Text.Trim().ToLower(); // Gets the text from the input box and converts it to lowercase.

            // If the player has not typed anything, we do not count an attempt.
            if (string.IsNullOrEmpty(input))
            {
                ShowMessage("emptyInput");
                return;
            }

            // If the answer is correct, we run the successful attempt logic.
            if (input == currentWord)
            {
                SuccessfulAttempt();
            }
            else
            {
                UnsuccessfulAttempt(input);
            }
        }

        // Logic for a correctly guessed word.
        private void SuccessfulAttempt()
        {
            gameTimer.Stop(); // Stops the timer if it was running.
            guessedWords++;

                        // The scoring is simple and easy to explain:
            // - without Hint: +10 points
            // - with Hint: +5 points
            // Hard mode adds only a timer, but does not change the points.
            int points = hintUsed ? 5 : 10; // ?: is a short if: if hintUsed is true -> 5, otherwise -> 10.

            score += points;
            wordList.Remove(currentWord);
            SaveHighScoreIfNeeded(); // Checks if there is a new high score.
            UpdateLabels();

            // After 10 guessed words, a win message is shown.
            if (guessedWords == WinGoal)
            {
                MessageBox.Show(T("winMessage"), T("winTitle"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            ShowMessage("correct");
            GenerateNewWord();
        }

        // Logic for a wrong answer.
        private void UnsuccessfulAttempt(string input)
        {
            attempts++; // Increases the number of wrong attempts.
            failedAttempts.Add(input); // Adds the wrong answer to the list.

            // If the wrong attempts become more than 9, a new word is generated automatically.
            if (attempts > MaxWrongAttempts)
            {
                ShowMessage("tooManyAttempts");
                GenerateNewWord();
            }
            else
            {
                ShowMessage("wrong");
            }
        }

        // Updates all numbers and fields on the screen.
        private void UpdateLabels()
        {
            labelAttemptsValue.Text = attempts.ToString();
            labelGuessedWordsValue.Text = guessedWords.ToString();
            labelScoreValue.Text = score.ToString();
            labelHighScoreValue.Text = highScore.ToString();
            textBoxFailedAttempts.Text = string.Join(Environment.NewLine, failedAttempts); // Shows the wrong guesses on separate lines.
            textBoxInput.Focus();
        }

        // Skip gives a new word without points.
        private void ButtonSkipClick(object sender, EventArgs e)
        {
            ShowMessage("skipped");
            GenerateNewWord();
        }

        // New Game restarts the current game but keeps the High Score.
        private void ButtonNewGameClick(object sender, EventArgs e)
        {
            StartNewGame(); // Starts a new game.
        }

        // Hint shows the first and last letter.
        private void ButtonHintClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentWord))
            {
                return;
            }

            hintUsed = true;

                        // The hint shows the first and last letter.
            // Example: water -> w _ _ _ r
            string hint = currentWord[0].ToString();
            for (int i = 1; i < currentWord.Length - 1; i++)
            {
                hint += " _";
            }
            hint += " " + currentWord[currentWord.Length - 1];

            labelMessage.Text = T("hint") + " " + hint + " " + T("hintPenalty");
        }

        // Show Answer displays the correct word but gives no points.
        private void ButtonShowAnswerClick(object sender, EventArgs e)
        {
            gameTimer.Stop(); // Stops the timer if it was running.
            MessageBox.Show(T("answer") + " " + currentWord, T("answerTitle"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            GenerateNewWord();
        }

        // Allows the player to press Enter instead of the Check button.
        private void TextBoxInputKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ButtonCheckClick(sender, e);
                e.SuppressKeyPress = true;
            }
        }

        // Runs when the user changes the language.
        private void ComboBoxLanguageSelectedIndexChanged(object sender, EventArgs e)
        {
            currentLanguage = comboBoxLanguage.SelectedIndex == 1 ? "bg" : "en";
            ApplyLanguage(); // Sets the texts in the selected language.
            UpdateTimerLabel();
        }

        // Runs when the user changes the difficulty.
        private void ComboBoxDifficultySelectedIndexChanged(object sender, EventArgs e)
        {
            hardMode = comboBoxDifficulty.SelectedIndex == 1; // 1 = Hard mode with timer.
            UpdateTimerLabel();
            labelMessage.Text = T("difficultyChanged");
        }

        // Runs when the user changes the theme.
        private void ComboBoxThemeSelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyTheme(); // Sets the colors for the selected theme.
        }

        // This method runs every second when the timer is active.
        private void GameTimerTick(object sender, EventArgs e)
        {
            secondsLeft--;
            UpdateTimerLabel();

            if (secondsLeft <= 0)
            {
                gameTimer.Stop(); // Stops the timer if it was running.
                ShowMessage("timeUp");
                GenerateNewWord();
            }
        }

        // Starts the timer only in Hard mode. In Easy mode there is no timer.
        private void StartTimerIfNeeded()
        {
            gameTimer.Stop(); // Stops the timer if it was running.
            secondsLeft = HardModeSeconds;

            if (hardMode)
            {
                gameTimer.Start();
            }

            UpdateTimerLabel();
        }

        // Updates the timer text on the screen.
        private void UpdateTimerLabel()
        {
            if (hardMode)
            {
                labelTimer.Text = T("time") + " " + secondsLeft.ToString();
            }
            else
            {
                labelTimer.Text = T("time") + " " + T("noTimer");
            }
        }

        // Loads the High Score from highscore.txt.
        private void LoadHighScore()
        {
            string filePath = Path.Combine(AppContext.BaseDirectory, HighScoreFile);

            if (File.Exists(filePath))
            {
                string text = File.ReadAllText(filePath);
                int.TryParse(text, out highScore);
            }
        }

        // Saves a new High Score if the current Score is higher.
        private void SaveHighScoreIfNeeded()
        {
            if (score > highScore)
            {
                highScore = score;
                string filePath = Path.Combine(AppContext.BaseDirectory, HighScoreFile);
                File.WriteAllText(filePath, highScore.ToString());
            }
        }

        private void ApplyLanguage()
        {
                        // This method changes the visible texts when the language is switched.
            int selectedDifficulty = hardMode ? 1 : 0;
            int selectedTheme = comboBoxTheme.SelectedIndex;
            if (selectedTheme < 0)
            {
                selectedTheme = 0;
            }

            Text = T("title");
            labelTitle.Text = T("title");
            labelAttempts.Text = T("attempts");
            labelGuessedWords.Text = T("guessedWords");
            labelScore.Text = T("score");
            labelHighScore.Text = T("highScore");
            labelFailedAttempts.Text = T("failedAttempts");
            labelDifficulty.Text = T("difficulty");
            labelTheme.Text = T("theme");
            labelLanguage.Text = T("language");
            buttonCheck.Text = T("check");
            buttonSkip.Text = T("skip");
            buttonHint.Text = T("hintButton");
            buttonShowAnswer.Text = T("showAnswer");
            buttonNewGame.Text = T("newGameButton");

            comboBoxDifficulty.Items.Clear();
            comboBoxDifficulty.Items.Add(T("easy"));
            comboBoxDifficulty.Items.Add(T("hard"));
            comboBoxDifficulty.SelectedIndex = selectedDifficulty;
            hardMode = selectedDifficulty == 1;

            comboBoxTheme.Items.Clear();
            comboBoxTheme.Items.Add(T("light"));
            comboBoxTheme.Items.Add(T("dark"));
            comboBoxTheme.SelectedIndex = selectedTheme;
        }

        // Changes the form colors between Light and Dark themes.
        private void ApplyTheme()
        {
            bool dark = comboBoxTheme.SelectedIndex == 1;

            Color background = dark ? Color.FromArgb(35, 35, 45) : Color.FromArgb(245, 245, 255);
            Color text = dark ? Color.WhiteSmoke : Color.Black;
            Color box = dark ? Color.FromArgb(65, 65, 75) : Color.FromArgb(225, 215, 215);
            Color button = dark ? Color.FromArgb(0, 100, 110) : Color.Teal;

            BackColor = background;

            foreach (Control control in Controls)
            {
                if (control is Label)
                {
                    control.ForeColor = text;
                }
                if (control is Button buttonControl)
                {
                    buttonControl.BackColor = button;
                    buttonControl.ForeColor = Color.White;
                }
            }

            labelMessage.ForeColor = dark ? Color.LightCyan : Color.Teal;
            labelAttemptsValue.BackColor = button;
            labelGuessedWordsValue.BackColor = button;
            labelScoreValue.BackColor = button;
            labelHighScoreValue.BackColor = button;
            textBoxFailedAttempts.BackColor = box;
            textBoxFailedAttempts.ForeColor = text;
            textBoxInput.BackColor = dark ? Color.FromArgb(55, 55, 65) : Color.White;
            textBoxInput.ForeColor = text;
        }

        // Shows a message using a key from the T() method.
        private void ShowMessage(string key)
        {
            labelMessage.Text = T(key);
        }

        // T means Translation. It returns English or Bulgarian text by a given key.
        private string T(string key)
        {
            if (currentLanguage == "bg")
            {
                switch (key)
                {
                    case "title": return "Разбъркани думи";
                    case "attempts": return "Опити:";
                    case "guessedWords": return "Познати:";
                    case "score": return "Точки:";
                    case "highScore": return "Рекорд:";
                    case "failedAttempts": return "Грешни опити:";
                    case "difficulty": return "Трудност:";
                    case "theme": return "Тема:";
                    case "language": return "Език:";
                    case "time": return "Време:";
                    case "noTimer": return "без таймер";
                    case "check": return "Провери";
                    case "skip": return "Пропусни";
                    case "hintButton": return "Жокер";
                    case "showAnswer": return "Покажи";
                    case "newGameButton": return "Нова игра";
                    case "easy": return "Лесно";
                    case "hard": return "Трудно";
                    case "light": return "Светла";
                    case "dark": return "Тъмна";
                    case "newGame": return "Нова игра! Избери трудност и започни.";
                    case "newWord": return "Нова дума! Успех!";
                    case "correct": return "Браво! Позна думата.";
                    case "wrong": return "Грешно. Опитай пак.";
                    case "emptyInput": return "Моля, напиши отговор.";
                    case "tooManyAttempts": return "Повече от 9 грешни опита. Давам нова дума.";
                    case "skipped": return "Думата е пропусната.";
                    case "hint": return "Жокер:";
                    case "hintPenalty": return "(по-малко точки)";
                    case "answer": return "Правилната дума е:";
                    case "answerTitle": return "Отговор";
                    case "finished": return "Всички думи са познати!";
                    case "fileMissing": return "Файлът words.txt не е намерен.";
                    case "error": return "Грешка";
                    case "winTitle": return "Победа!";
                    case "winMessage": return "Ти позна 10 думи! Страхотна работа!";
                    case "timeUp": return "Времето изтече! Давам нова дума.";
                    case "difficultyChanged": return "Натисни Нова игра, за да започнеш с избраната трудност.";
                }
            }

            switch (key)
            {
                case "title": return "Word Scramble";
                case "attempts": return "Attempts:";
                case "guessedWords": return "Guessed:";
                case "score": return "Score:";
                case "highScore": return "High score:";
                case "failedAttempts": return "Failed attempts:";
                case "difficulty": return "Difficulty:";
                case "theme": return "Theme:";
                case "language": return "Language:";
                case "time": return "Time:";
                case "noTimer": return "no timer";
                case "check": return "Check";
                case "skip": return "Skip";
                case "hintButton": return "Hint";
                case "showAnswer": return "Show";
                case "newGameButton": return "New Game";
                case "easy": return "Easy";
                case "hard": return "Hard";
                case "light": return "Light";
                case "dark": return "Dark";
                case "newGame": return "New game! Choose difficulty and start playing.";
                case "newWord": return "New word! Good luck!";
                case "correct": return "Great! You guessed the word.";
                case "wrong": return "Wrong. Try again.";
                case "emptyInput": return "Please type an answer.";
                case "tooManyAttempts": return "More than 9 wrong attempts. A new word is shown.";
                case "skipped": return "The word was skipped.";
                case "hint": return "Hint:";
                case "hintPenalty": return "(less points)";
                case "answer": return "The correct word is:";
                case "answerTitle": return "Answer";
                case "finished": return "All words are guessed!";
                case "fileMissing": return "The words.txt file was not found.";
                case "error": return "Error";
                case "winTitle": return "You won!";
                case "winMessage": return "You guessed 10 words! Great job!";
                case "timeUp": return "Time is up! A new word is shown.";
                case "difficultyChanged": return "Press New Game to start with the selected difficulty.";
            }

            return key;
        }
    }
}
