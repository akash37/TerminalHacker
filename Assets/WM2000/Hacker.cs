using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Screen
{
	MainMenu,
	Password,
	Win
}

public class Hacker : MonoBehaviour
{
	private const string _menuHint = "You can type MENU ar any time";
	private int _level;
	private Screen _currentScreen;
	private string[] level1Paswwords = {"books", "aisle", "shelf", "font", "borrow"};
	private string[] level2Passwords = {"prisoners", "handcuffs", "uniform", "holster"};
	private string[] level3Passwords = {"starfield", "telescope", "environment","exploration"};
	private string _password;
	
	void Start () {
		ShowMainMenu();
	}

	void ShowMainMenu()
	{
		_currentScreen = Screen.MainMenu;
		Terminal.ClearScreen();
		Terminal.WriteLine("What would you like to hack into ?");
		Terminal.WriteLine("Press 1 For the local library");
		Terminal.WriteLine("Press 2 For the Police Station");
		Terminal.WriteLine("Press 3 For NASA");
		Terminal.WriteLine("Enter Your Selection:");
	}

	void OnUserInput(string input)
	{
		if (input == "menu")
		{
			ShowMainMenu();
		}
		else if (input == "quit" || input == "close" || input == "exit")
		{
			Terminal.WriteLine("If on the web close the tab");
			Application.Quit();
		}
		else if (_currentScreen == Screen.MainMenu)
		{
			RunMainMenu(input);
		}
		else if (_currentScreen == Screen.Password)
		{
			CheckPassword(input);
		}
	}

	void RunMainMenu(string input)
	{
		bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
		if (isValidLevelNumber)
		{
			_level = int.Parse(input);
			AskForPassWord();
		}
		else
		{
			Terminal.WriteLine("Select a valid Option");
			Terminal.WriteLine(_menuHint);
		}
	}

	void CheckPassword(string input)
	{
		if (input == _password)
		{
			DisplayWinScreen();
		}
		else
		{
			AskForPassWord();
		}
		
	}

	void SetRandomPassword()
	{
		switch (_level)
		{
			case 1:
				_password = level1Paswwords[Random.Range(0, level1Paswwords.Length)];
				break;
			case 2:
				_password = level2Passwords[Random.Range(0, level2Passwords.Length)];
				break;
			case 3:
				_password = level3Passwords[Random.Range(0, level3Passwords.Length)];
				break;
			default:
				Debug.LogError("Invalid Level Number");
				break;
					
		}
	}

	void AskForPassWord()
	{
		_currentScreen = Screen.Password;
		SetRandomPassword();
		Terminal.ClearScreen();
		Terminal.WriteLine("Please Enter Your Password hint:" + _password.Anagram());
	}

	void DisplayWinScreen()
	{
		_currentScreen = Screen.Win;
		Terminal.ClearScreen();
		ShowLevelReward();
		Terminal.WriteLine(_menuHint);
	}

	void ShowLevelReward()
	{
		switch (_level)
		{
			case 1:
				Terminal.WriteLine("Have a book !");
				Terminal.WriteLine(@"
	_______
   /      //
  /      //
 /_____ //
(______(/           
"
				);
				break;
			case 2:
				Terminal.WriteLine("You got a prison key !");
				Terminal.WriteLine(@"
 __
/0 \_______
\__/-=' = '         
"
				);
				break;
			case 3:
				Terminal.WriteLine(@"
 _ __   __ _ ___  __ _
| '_ \ / _` / __|/ _` |
| | | | (_| \__ \ (_| |
|_| |_|\__,_|___)\__,_|
"
				);
				Terminal.WriteLine("Welcome to NASA!");
				break;
			default:
				Debug.LogError("Invalid Level");
				break;
		}
	}
	
}
