# Word Scramble

## Project idea

Word Scramble is a C# Windows Forms game where the player sees a scrambled 5-letter word and has to guess the original word. The project is made for a 9th grade Programming Fundamentals GUI project.

## Technologies used

- C#
- Windows Forms
- .NET 6
- Text files for storing words and high score

## Main features

- The game reads words from `words.txt`.
- Only valid 5-letter words are used.
- A random word is selected and scrambled.
- The player writes an answer and presses **Check**.
- Wrong answers are saved in the **Failed attempts** box.
- After more than 9 wrong attempts, the game automatically gives a new word.
- **Skip** gives a new word.
- **Hint** shows the first and last letter.
- **Show Answer** shows the correct word and moves to the next word.
- **New Game** restarts the current score and the current progress.
- **High Score** saves the best score between program starts.
- The interface supports English and Bulgarian.
- The player can switch between Light and Dark theme.
- Easy mode has no timer.
- Hard mode has a 30-second timer for each word.
- After 10 guessed words, the game shows a win message.

## Scoring system

- Correct word without Hint: **+10 points**
- Correct word after Hint: **+5 points**
- Show Answer: **0 points**
- Current Score starts from 0 when the app starts and when New Game is clicked.
- High Score keeps the best result and is saved in `highscore.txt`.

## Main files

- `Program.cs` - starts the application.
- `IndexForm.cs` - contains the main game logic.
- `IndexForm.Designer.cs` - contains the form controls and layout.
- `words.txt` - contains the words used in the game.
- `README.md` - explains the project.
- `FEATURES.txt` - short list of the added features.

## How to run

1. Open the `.sln` file in Visual Studio.
2. Make sure **Desktop development with .NET** is installed.
3. Press the green **Start** button or press `F5`.
4. Choose Easy or Hard mode and start playing.

## What I added to make the project original

I added language switching, theme switching, scoring, high score, hint, show answer, new game, difficulty modes and a timer in Hard mode. These features make the game more interactive and easier to present.
