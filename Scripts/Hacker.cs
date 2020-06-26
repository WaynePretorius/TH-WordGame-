using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{

    private string yourName = "Hello Ben";
    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu(yourName);
    }

    private static void ShowMainMenu(string firstLine)
    {
        Terminal.ClearScreen();
        Terminal.WriteLine(firstLine);
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
        Terminal.ClearScreen();
        Debug.Log("The user pressed: " + input);
    }

}
