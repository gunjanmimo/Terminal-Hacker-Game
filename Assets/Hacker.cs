using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    // game state
    int level;

    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;
    string password;
    // Start is called before the first frame update
    void Start()
    {
        showMainMenu();
    }

    // main menu function
    void showMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("Press 1 for the local libraries");
        Terminal.WriteLine("Press 2 for the police station");
        Terminal.WriteLine("Press 3 for NASA");
        Terminal.WriteLine("\nEnter your selection:");
    }
    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            showMainMenu();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            checkPassword(input);
        }
    }



    void RunMainMenu(string input)
    {
        if (input == "1")
        {
            level = 1;
            password = "donkey";
            StartGame();
        }
        else if (input == "2")
        {
            level = 2;
            password = "animation";
            StartGame();
        }
        else if (input == "3")
        {
            level = 3;
            password = "ultrasonography";
            StartGame();
        }
        else if (input == "clear")
        {
            Terminal.ClearScreen();
        }

        else
        {
            Terminal.WriteLine("Invalid command");
        }
    }

    void StartGame()
    {
        currentScreen = Screen.Password;
        Terminal.WriteLine("you have choosed level " + level);
        Terminal.WriteLine("Enter your password: ");

    }
    void checkPassword(string input)
    {
        if (input == password)
        {
            Terminal.WriteLine("well done!");
        }
        else
        {
            Terminal.WriteLine("Sorry, wrong password !");
        }
    }
}
