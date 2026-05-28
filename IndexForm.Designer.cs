namespace WordScrambleLanguageSwitch
{
    partial class IndexForm
    {
        private System.ComponentModel.IContainer components = null;

        private Label labelTitle;
        private Label labelAttempts;
        private Label labelAttemptsValue;
        private Label labelGuessedWords;
        private Label labelGuessedWordsValue;
        private Label labelScore;
        private Label labelScoreValue;
        private Label labelHighScore;
        private Label labelHighScoreValue;
        private Label labelTimer;
        private Label labelScrambledWord;
        private Label labelFailedAttempts;
        private TextBox textBoxInput;
        private TextBox textBoxFailedAttempts;
        private Button buttonCheck;
        private Button buttonSkip;
        private Button buttonHint;
        private Button buttonShowAnswer;
        private Button buttonNewGame;
        private Label labelDifficulty;
        private ComboBox comboBoxDifficulty;
        private Label labelTheme;
        private ComboBox comboBoxTheme;
        private Label labelLanguage;
        private ComboBox comboBoxLanguage;
        private Label labelMessage;
        private System.Windows.Forms.Timer gameTimer;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            labelTitle = new Label();
            labelAttempts = new Label();
            labelAttemptsValue = new Label();
            labelGuessedWords = new Label();
            labelGuessedWordsValue = new Label();
            labelScore = new Label();
            labelScoreValue = new Label();
            labelHighScore = new Label();
            labelHighScoreValue = new Label();
            labelTimer = new Label();
            labelScrambledWord = new Label();
            labelFailedAttempts = new Label();
            textBoxInput = new TextBox();
            textBoxFailedAttempts = new TextBox();
            buttonCheck = new Button();
            buttonSkip = new Button();
            buttonHint = new Button();
            buttonShowAnswer = new Button();
            buttonNewGame = new Button();
            labelDifficulty = new Label();
            comboBoxDifficulty = new ComboBox();
            labelTheme = new Label();
            comboBoxTheme = new ComboBox();
            labelLanguage = new Label();
            comboBoxLanguage = new ComboBox();
            labelMessage = new Label();
            gameTimer = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // labelTitle
            // 
            labelTitle.Anchor = AnchorStyles.Top;
            labelTitle.Font = new Font("Georgia", 24F, FontStyle.Bold, GraphicsUnit.Point);
            labelTitle.Location = new Point(110, 25);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(660, 45);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Word Scramble";
            labelTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelAttempts
            // 
            labelAttempts.AutoSize = true;
            labelAttempts.Font = new Font("Georgia", 10F, FontStyle.Bold, GraphicsUnit.Point);
            labelAttempts.Location = new Point(35, 95);
            labelAttempts.Name = "labelAttempts";
            labelAttempts.Size = new Size(74, 17);
            labelAttempts.TabIndex = 1;
            labelAttempts.Text = "Attempts:";
            // 
            // labelAttemptsValue
            // 
            labelAttemptsValue.BackColor = Color.Teal;
            labelAttemptsValue.Font = new Font("Georgia", 10F, FontStyle.Bold, GraphicsUnit.Point);
            labelAttemptsValue.ForeColor = Color.White;
            labelAttemptsValue.Location = new Point(115, 90);
            labelAttemptsValue.Name = "labelAttemptsValue";
            labelAttemptsValue.Size = new Size(35, 27);
            labelAttemptsValue.TabIndex = 2;
            labelAttemptsValue.Text = "0";
            labelAttemptsValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelGuessedWords
            // 
            labelGuessedWords.AutoSize = true;
            labelGuessedWords.Font = new Font("Georgia", 10F, FontStyle.Bold, GraphicsUnit.Point);
            labelGuessedWords.Location = new Point(190, 95);
            labelGuessedWords.Name = "labelGuessedWords";
            labelGuessedWords.Size = new Size(74, 17);
            labelGuessedWords.TabIndex = 3;
            labelGuessedWords.Text = "Guessed:";
            // 
            // labelGuessedWordsValue
            // 
            labelGuessedWordsValue.BackColor = Color.Teal;
            labelGuessedWordsValue.Font = new Font("Georgia", 10F, FontStyle.Bold, GraphicsUnit.Point);
            labelGuessedWordsValue.ForeColor = Color.White;
            labelGuessedWordsValue.Location = new Point(275, 90);
            labelGuessedWordsValue.Name = "labelGuessedWordsValue";
            labelGuessedWordsValue.Size = new Size(35, 27);
            labelGuessedWordsValue.TabIndex = 4;
            labelGuessedWordsValue.Text = "0";
            labelGuessedWordsValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelScore
            // 
            labelScore.AutoSize = true;
            labelScore.Font = new Font("Georgia", 10F, FontStyle.Bold, GraphicsUnit.Point);
            labelScore.Location = new Point(355, 95);
            labelScore.Name = "labelScore";
            labelScore.Size = new Size(53, 17);
            labelScore.TabIndex = 5;
            labelScore.Text = "Score:";
            // 
            // labelScoreValue
            // 
            labelScoreValue.BackColor = Color.Teal;
            labelScoreValue.Font = new Font("Georgia", 10F, FontStyle.Bold, GraphicsUnit.Point);
            labelScoreValue.ForeColor = Color.White;
            labelScoreValue.Location = new Point(420, 90);
            labelScoreValue.Name = "labelScoreValue";
            labelScoreValue.Size = new Size(45, 27);
            labelScoreValue.TabIndex = 6;
            labelScoreValue.Text = "0";
            labelScoreValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelHighScore
            // 
            labelHighScore.AutoSize = true;
            labelHighScore.Font = new Font("Georgia", 10F, FontStyle.Bold, GraphicsUnit.Point);
            labelHighScore.Location = new Point(505, 95);
            labelHighScore.Name = "labelHighScore";
            labelHighScore.Size = new Size(91, 17);
            labelHighScore.TabIndex = 7;
            labelHighScore.Text = "High score:";
            // 
            // labelHighScoreValue
            // 
            labelHighScoreValue.BackColor = Color.Teal;
            labelHighScoreValue.Font = new Font("Georgia", 10F, FontStyle.Bold, GraphicsUnit.Point);
            labelHighScoreValue.ForeColor = Color.White;
            labelHighScoreValue.Location = new Point(610, 90);
            labelHighScoreValue.Name = "labelHighScoreValue";
            labelHighScoreValue.Size = new Size(55, 27);
            labelHighScoreValue.TabIndex = 8;
            labelHighScoreValue.Text = "0";
            labelHighScoreValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelTimer
            // 
            labelTimer.Font = new Font("Georgia", 10F, FontStyle.Bold, GraphicsUnit.Point);
            labelTimer.Location = new Point(690, 93);
            labelTimer.Name = "labelTimer";
            labelTimer.Size = new Size(170, 24);
            labelTimer.TabIndex = 9;
            labelTimer.Text = "Time: none";
            // 
            // labelScrambledWord
            // 
            labelScrambledWord.Anchor = AnchorStyles.Top;
            labelScrambledWord.Font = new Font("Georgia", 20F, FontStyle.Bold, GraphicsUnit.Point);
            labelScrambledWord.Location = new Point(150, 140);
            labelScrambledWord.Name = "labelScrambledWord";
            labelScrambledWord.Size = new Size(580, 45);
            labelScrambledWord.TabIndex = 10;
            labelScrambledWord.Text = "scrambled word";
            labelScrambledWord.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBoxInput
            // 
            textBoxInput.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxInput.Location = new Point(55, 205);
            textBoxInput.Name = "textBoxInput";
            textBoxInput.Size = new Size(190, 29);
            textBoxInput.TabIndex = 1;
            textBoxInput.KeyDown += TextBoxInputKeyDown;
            // 
            // buttonCheck
            // 
            buttonCheck.BackColor = Color.Teal;
            buttonCheck.FlatStyle = FlatStyle.Flat;
            buttonCheck.Font = new Font("Georgia", 10F, FontStyle.Bold, GraphicsUnit.Point);
            buttonCheck.ForeColor = Color.White;
            buttonCheck.Location = new Point(265, 202);
            buttonCheck.Name = "buttonCheck";
            buttonCheck.Size = new Size(105, 34);
            buttonCheck.TabIndex = 2;
            buttonCheck.Text = "Check";
            buttonCheck.UseVisualStyleBackColor = false;
            buttonCheck.Click += ButtonCheckClick;
            // 
            // buttonSkip
            // 
            buttonSkip.BackColor = Color.Teal;
            buttonSkip.FlatStyle = FlatStyle.Flat;
            buttonSkip.Font = new Font("Georgia", 10F, FontStyle.Bold, GraphicsUnit.Point);
            buttonSkip.ForeColor = Color.White;
            buttonSkip.Location = new Point(380, 202);
            buttonSkip.Name = "buttonSkip";
            buttonSkip.Size = new Size(105, 34);
            buttonSkip.TabIndex = 3;
            buttonSkip.Text = "Skip";
            buttonSkip.UseVisualStyleBackColor = false;
            buttonSkip.Click += ButtonSkipClick;
            // 
            // buttonHint
            // 
            buttonHint.BackColor = Color.Teal;
            buttonHint.FlatStyle = FlatStyle.Flat;
            buttonHint.Font = new Font("Georgia", 10F, FontStyle.Bold, GraphicsUnit.Point);
            buttonHint.ForeColor = Color.White;
            buttonHint.Location = new Point(495, 202);
            buttonHint.Name = "buttonHint";
            buttonHint.Size = new Size(105, 34);
            buttonHint.TabIndex = 4;
            buttonHint.Text = "Hint";
            buttonHint.UseVisualStyleBackColor = false;
            buttonHint.Click += ButtonHintClick;
            // 
            // buttonShowAnswer
            // 
            buttonShowAnswer.BackColor = Color.Teal;
            buttonShowAnswer.FlatStyle = FlatStyle.Flat;
            buttonShowAnswer.Font = new Font("Georgia", 10F, FontStyle.Bold, GraphicsUnit.Point);
            buttonShowAnswer.ForeColor = Color.White;
            buttonShowAnswer.Location = new Point(610, 202);
            buttonShowAnswer.Name = "buttonShowAnswer";
            buttonShowAnswer.Size = new Size(105, 34);
            buttonShowAnswer.TabIndex = 5;
            buttonShowAnswer.Text = "Show";
            buttonShowAnswer.UseVisualStyleBackColor = false;
            buttonShowAnswer.Click += ButtonShowAnswerClick;
            // 
            // buttonNewGame
            // 
            buttonNewGame.BackColor = Color.Teal;
            buttonNewGame.FlatStyle = FlatStyle.Flat;
            buttonNewGame.Font = new Font("Georgia", 10F, FontStyle.Bold, GraphicsUnit.Point);
            buttonNewGame.ForeColor = Color.White;
            buttonNewGame.Location = new Point(725, 202);
            buttonNewGame.Name = "buttonNewGame";
            buttonNewGame.Size = new Size(115, 34);
            buttonNewGame.TabIndex = 6;
            buttonNewGame.Text = "New Game";
            buttonNewGame.UseVisualStyleBackColor = false;
            buttonNewGame.Click += ButtonNewGameClick;
            // 
            // labelMessage
            // 
            labelMessage.Font = new Font("Georgia", 10F, FontStyle.Bold, GraphicsUnit.Point);
            labelMessage.ForeColor = Color.Teal;
            labelMessage.Location = new Point(40, 250);
            labelMessage.Name = "labelMessage";
            labelMessage.Size = new Size(800, 30);
            labelMessage.TabIndex = 16;
            labelMessage.Text = "Unscramble the word and press Check.";
            labelMessage.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelFailedAttempts
            // 
            labelFailedAttempts.AutoSize = true;
            labelFailedAttempts.Font = new Font("Georgia", 11F, FontStyle.Bold, GraphicsUnit.Point);
            labelFailedAttempts.Location = new Point(370, 292);
            labelFailedAttempts.Name = "labelFailedAttempts";
            labelFailedAttempts.Size = new Size(135, 18);
            labelFailedAttempts.TabIndex = 17;
            labelFailedAttempts.Text = "Failed attempts:";
            // 
            // textBoxFailedAttempts
            // 
            textBoxFailedAttempts.BackColor = Color.FromArgb(225, 215, 215);
            textBoxFailedAttempts.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxFailedAttempts.Location = new Point(60, 320);
            textBoxFailedAttempts.Multiline = true;
            textBoxFailedAttempts.Name = "textBoxFailedAttempts";
            textBoxFailedAttempts.ReadOnly = true;
            textBoxFailedAttempts.ScrollBars = ScrollBars.Vertical;
            textBoxFailedAttempts.Size = new Size(760, 75);
            textBoxFailedAttempts.TabIndex = 7;
            // 
            // labelDifficulty
            // 
            labelDifficulty.AutoSize = true;
            labelDifficulty.Font = new Font("Georgia", 10F, FontStyle.Bold, GraphicsUnit.Point);
            labelDifficulty.Location = new Point(60, 425);
            labelDifficulty.Name = "labelDifficulty";
            labelDifficulty.Size = new Size(82, 17);
            labelDifficulty.TabIndex = 19;
            labelDifficulty.Text = "Difficulty:";
            // 
            // comboBoxDifficulty
            // 
            comboBoxDifficulty.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxDifficulty.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            comboBoxDifficulty.FormattingEnabled = true;
            comboBoxDifficulty.Location = new Point(155, 421);
            comboBoxDifficulty.Name = "comboBoxDifficulty";
            comboBoxDifficulty.Size = new Size(140, 25);
            comboBoxDifficulty.TabIndex = 8;
            comboBoxDifficulty.SelectedIndexChanged += ComboBoxDifficultySelectedIndexChanged;
            // 
            // labelTheme
            // 
            labelTheme.AutoSize = true;
            labelTheme.Font = new Font("Georgia", 10F, FontStyle.Bold, GraphicsUnit.Point);
            labelTheme.Location = new Point(355, 425);
            labelTheme.Name = "labelTheme";
            labelTheme.Size = new Size(61, 17);
            labelTheme.TabIndex = 21;
            labelTheme.Text = "Theme:";
            // 
            // comboBoxTheme
            // 
            comboBoxTheme.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxTheme.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            comboBoxTheme.FormattingEnabled = true;
            comboBoxTheme.Location = new Point(425, 421);
            comboBoxTheme.Name = "comboBoxTheme";
            comboBoxTheme.Size = new Size(140, 25);
            comboBoxTheme.TabIndex = 9;
            comboBoxTheme.SelectedIndexChanged += ComboBoxThemeSelectedIndexChanged;
            // 
            // labelLanguage
            // 
            labelLanguage.AutoSize = true;
            labelLanguage.Font = new Font("Georgia", 10F, FontStyle.Bold, GraphicsUnit.Point);
            labelLanguage.Location = new Point(625, 425);
            labelLanguage.Name = "labelLanguage";
            labelLanguage.Size = new Size(83, 17);
            labelLanguage.TabIndex = 23;
            labelLanguage.Text = "Language:";
            // 
            // comboBoxLanguage
            // 
            comboBoxLanguage.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxLanguage.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            comboBoxLanguage.FormattingEnabled = true;
            comboBoxLanguage.Items.AddRange(new object[] { "English", "Български" });
            comboBoxLanguage.Location = new Point(715, 421);
            comboBoxLanguage.Name = "comboBoxLanguage";
            comboBoxLanguage.Size = new Size(140, 25);
            comboBoxLanguage.TabIndex = 10;
            comboBoxLanguage.SelectedIndexChanged += ComboBoxLanguageSelectedIndexChanged;
            // 
            // gameTimer
            // 
            gameTimer.Interval = 1000;
            gameTimer.Tick += GameTimerTick;
            // 
            // IndexForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 245, 255);
            ClientSize = new Size(884, 471);
            Controls.Add(comboBoxLanguage);
            Controls.Add(labelLanguage);
            Controls.Add(comboBoxTheme);
            Controls.Add(labelTheme);
            Controls.Add(comboBoxDifficulty);
            Controls.Add(labelDifficulty);
            Controls.Add(textBoxFailedAttempts);
            Controls.Add(labelFailedAttempts);
            Controls.Add(labelMessage);
            Controls.Add(buttonNewGame);
            Controls.Add(buttonShowAnswer);
            Controls.Add(buttonHint);
            Controls.Add(buttonSkip);
            Controls.Add(buttonCheck);
            Controls.Add(textBoxInput);
            Controls.Add(labelScrambledWord);
            Controls.Add(labelTimer);
            Controls.Add(labelHighScoreValue);
            Controls.Add(labelHighScore);
            Controls.Add(labelScoreValue);
            Controls.Add(labelScore);
            Controls.Add(labelGuessedWordsValue);
            Controls.Add(labelGuessedWords);
            Controls.Add(labelAttemptsValue);
            Controls.Add(labelAttempts);
            Controls.Add(labelTitle);
            MaximizeBox = false;
            MaximumSize = new Size(900, 510);
            MinimumSize = new Size(900, 510);
            Name = "IndexForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Word Scramble";
            Load += OnLoad;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
