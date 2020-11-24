using UnityEngine;
using UnityEngine.UIElements;

public class Hacker : MonoBehaviour
{

    // game configuration data
    string[] level1_passwords = { "books" };
    string[] level2_passwords = { "animation", "alphabets", "encryption", "astrology", "kitchen", "anonymous" };
    string[] level3_passwords = { "ephemeral", "gratuitous", "disinterested", "enormity", "unabashed", "literally" };
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
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
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
        //Terminal.WriteLine("you have choosed level " + level);
        Terminal.ClearScreen();
        switch (level)
        {
            case 1:
                password = level1_passwords[Random.Range(0, level1_passwords.Length)];
                break;
            case 2:
                password = level2_passwords[Random.Range(0, level2_passwords.Length)];
                break;
            case 3:
                password = level3_passwords[Random.Range(0, level3_passwords.Length)];
                break;
            default:
                Terminal.WriteLine("Invalid level number");
                break;
        }
        Terminal.WriteLine("Enter your password:,hint: " + password.Anagram());

    }
    void checkPassword(string input)
    {
        if (input == password)
        {
            DisplayWinScreen();
        }
        else
        {
            Terminal.WriteLine("Sorry, wrong password !");
            StartGame();
        }
    }

    void showLevelRewards()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("have a book...");
                Terminal.WriteLine(
                    @"
    _______
   /      /,
  /      //
 /______//
(______(/
          
");
                break;
            case 2:
                Terminal.WriteLine("have a ghost...");
                Terminal.WriteLine(
                    @"
  .-""""-.
    / -   -  \
   |  .-. .- |
   |  \o| |o (
   \     ^    \
   |'.  )--'  /|
  / / '-. .-'`\ \
 / /'---` `---'\ \
 '.__.       .__.'
     `|     |`
      |     \
      \      '--.
       '.        `\
         `'---.   |
            ,__) /
             `..'

");
                break;




            case 3:
                Terminal.WriteLine("have a house...");
                Terminal.WriteLine(
                    @"
             +
             A
          __/_\__
         /\-'o'-/\
        _||:<_>:||_
       /\_/=====\_/\
      _|:_:_[I]_:_:|_
   _/::::::::::::::::\_
 _/::::::::::::::::::::\_
/::::::::::::::::::::::::\'

");
                break;
        }
    }
    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        showLevelRewards();
    }
}
