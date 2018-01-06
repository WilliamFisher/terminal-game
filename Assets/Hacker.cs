using UnityEngine;

public class Hacker : MonoBehaviour
{
    string[] level1Passwords = { "books", "pencil", "desk", "chair", "sports" };
    string[] level2Passwords = { "prisoner", "handcuffs", "uniform", "arrest" };
    string[] level3Passwords = { "intelligence", "agency", "federal", "government", "investigation" };

    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;
    int level;
    string playerName = "Ashton";
    string password;

    void Start()
    {
        ShowMainMenu(playerName);
    }

    void ShowMainMenu(string n)
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("Welcome, " + n);
        Terminal.WriteLine("Pick a hecking target.");
        Terminal.EmptyLine();
        Terminal.WriteLine("Pick 1 to hack the school.");
        Terminal.WriteLine("Pick 2 to hack the police station.");
        Terminal.WriteLine("Pick 3 to hack the FBI.");
        Terminal.EmptyLine();
        Terminal.WriteLine("Enter a selection: ");
    }

    /// <summary>
    /// Decides what to do with user input.
    /// </summary>
    /// <param name="input">Input.</param>
    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            ShowMainMenu(playerName);
        }
        else if(currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if(currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
        else if(currentScreen == Screen.Win)
        {
            ShowMainMenu(playerName);
        }
    }

    void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
        if(isValidLevelNumber)
        {
            level = int.Parse(input);
            StartGame();
        }
        else if (input == "8828")
        {
            Terminal.WriteLine("Access Granted!");
        }
        else
        {
            Terminal.WriteLine("Please enter a valid input.");
        }
    }

    void StartGame()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        GenerateRandomPassword();
        Terminal.WriteLine("Enter your password: " + password.Anagram());
    }

    void GenerateRandomPassword()
    {
        switch (level)
        {
            case 1:
                password = level1Passwords[Random.Range(0, level1Passwords.Length)];
                break;
            case 2:
                password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                break;
            case 3:
                password = level3Passwords[Random.Range(0, level3Passwords.Length)];
                break;
            default:
                Debug.LogError("Invalid Level Number");
                break;
        }
    }

    void CheckPassword(string input)
    {
        if(input == password)
        {
            DisplayWinScreen();
        }
        else
        {
            StartGame();
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        Terminal.WriteLine("Access Granted!");
    }
}