using UnityEngine;

public class Hacker : MonoBehaviour
{
    //Game Configuration Data
    const string menuHint = "You may type \"menu\" many times.";
    string[] level1Passwords = { "password", "steal", "game", "steam", "gaben", "master", "sixty", "frames", "seconds", "what" };
    string[] level2Passwords = { "silicon", "information", "technology", "database", "microphone", "speaker", "monitor", "thirteen", "unrealistic", "assembly" };
    string[] level3Passwords = { "scandal", "voice", "dancing", "image", "glamour", "diamond", "shining", "incorrect", "famous", "fortune" };

    //GameState
    int level;
    string password;
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;

    // Start is called before the first frame update
    void Start()
    {
        var greeting = "Hello Kongu";
        ShowMainMenu(greeting);
    }

    public void ShowMainMenu(string greeting)
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine(greeting);
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("Press 1 for the AAA game company");
        Terminal.WriteLine("Press 2 for the big website company");
        Terminal.WriteLine("Press 3 for the big celebrity's account");
        Terminal.WriteLine("Enter your selection: ");
    }

    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            currentScreen = Screen.MainMenu;
            ShowMainMenu("Welcome back");
        }
        else if (input == "quit" || input == "close" || input == "exit")
        {
            Terminal.ClearScreen();
            Terminal.WriteLine("Close the tab to quit the game!");
            Terminal.WriteLine(menuHint);
            Application.Quit();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }

    private void RunMainMenu(string input)
    {
        bool isValidNumber = (input == "1" || input == "2" || input == "3" );

        if (isValidNumber)
        {
            level = int.Parse(input);
            AskPassword();
        }
        else
        {
            Terminal.WriteLine("Choose the valid number");
            Terminal.WriteLine(menuHint);
        }
    }

    private void AskPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine(menuHint);
        Terminal.WriteLine("Hint: " + password.Anagram());      //Password shuffle
        Terminal.WriteLine("Enter your password: ");
    }

    private void SetRandomPassword()
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
                Debug.Log("Invalid level number!");
                break;
        }
    }

    private void CheckPassword(string input)
    {
        if (input == password)
        {
            this.DisplayWinScreen();
            currentScreen = Screen.Win;
        }
        else
        {
            AskPassword();
        }
    }

    private void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        DisplayReward();
        Terminal.WriteLine(menuHint);
    }

    private void DisplayReward()
    {
        Terminal.WriteLine("Correct Password");
        switch (level)
        {
            case 1:
                Terminal.WriteLine("A new game has been leaked...");
                Terminal.WriteLine(@"
       _.-;;-._
'-..-'|   ||   |
'-..-'|_.-;;-._|
'-..-'|   ||   |
'-..-'|_.-''-._|
"
);
                break;
            case 2:
                Terminal.WriteLine("The database has been leaked...");
                Terminal.WriteLine(@"
    .-.
   ( . )
 .-.':'.-. 
(  =,!,=  )
 '-' | '-'
"
);
                break;
            case 3:
                Terminal.WriteLine("The big secret has been exposed...");
                Terminal.WriteLine(@"
 .-.  .-.
|   \/   |
\        /
 `\    /`
   `\/`
"
);
                break;
            default:
                Debug.Log("Invalid level reached!");
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
