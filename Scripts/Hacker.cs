using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Hacker : MonoBehaviour
{
    //Game Configs
    [SerializeField] string[] level1Passwords = { "Hard", "Glad","Menu","Real","Work"};
    [SerializeField] string[] level2Passwords = { "Chinese", "English", "Afrikaans", "Japanese", "Italian" };
    [SerializeField] string[] level3Passwords = { "Americans", "Russians", "Europeans", "Africans", "Koreans" };

    //Game States
    private int level;
    enum Screen { MainMenu, Password, Win};
    Screen currentScreen;
    string password;
    int minRandomRange = 0;

    void Start()
    {
        ShowMainMenu();
        currentScreen = Screen.MainMenu;
    }

    private static void ShowMainMenu()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Please choose where you would like to ");
        Terminal.WriteLine("cyberbreak in?");
        Terminal.WriteLine("");
        Terminal.WriteLine("1.) Your Family Computer.");
        Terminal.WriteLine("2.) The Library.");
        Terminal.WriteLine("3.) The Government Mainframe.");
        Terminal.WriteLine("");
        Terminal.WriteLine("");
        Terminal.WriteLine("Please make your selection:");
    }

    void OnUserInput(string input)
    {
        if (input == "Menu")
        {
            ShowMainMenu();
            currentScreen = Screen.MainMenu;
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if(currentScreen == Screen.Password)
        {
            CheckForPassword(input);
        }
    }

    private void RunMainMenu(string input)
    {
        bool isAValidLevelNumber = (input == "1" || input == "2" || input == "3");

        if (input == "007")
        {
            Terminal.WriteLine("Good Day Mr Bond, Make your selection: ");
        }
        else if (isAValidLevelNumber)
        {
            level = int.Parse(input);
            AskLevel();
        }
        else
        {
            Terminal.WriteLine("Please input the correct command:");
        }
    }

    void CheckForPassword(string input)
    {
        if(input == password)
        {
            currentScreen = Screen.Win;
            DisplayWinScreen();
        }
        else
        {
            AskLevel();
        }
    }

    void AskLevel()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        Terminal.WriteLine("Please enter your password: ");
        ChooseLevelAndPassword();
    }

    private void ChooseLevelAndPassword()
    {
        switch (level)
        {
            case 1:
                password = level1Passwords[Random.Range(minRandomRange, level1Passwords.Length)];
                break;
            case 2:
                password = level2Passwords[Random.Range(minRandomRange, level2Passwords.Length)];
                break;
            case 3:
                password = level3Passwords[Random.Range(minRandomRange, level3Passwords.Length)];
                break;
            default:
                Debug.LogError("Password in Startlevel out of bounds");
                break;
        }
        Terminal.WriteLine("Enter the password " + password.Anagram());
    }

    void DisplayWinScreen()
    {
        Terminal.ClearScreen();
        switch (level)
        {
            case 1:
                Terminal.WriteLine(@"
     ____
    /____\
   /______\
  /________\
 /__________\
/____________\
");
                break;
            case 2:Terminal.WriteLine(@"
  \   _   /
   \ ( ) /
    \|-|/
");
                break;

            case 3:
                Terminal.WriteLine(@"
_______________-|
|_____________|||
\_____________\||
 |____________|||
/_____________/||
");
                break;
            default:
                Debug.LogError("No more Pictures");
                break;
        }

        Terminal.WriteLine("Type Menu to return to main menu");
            
    }
}
