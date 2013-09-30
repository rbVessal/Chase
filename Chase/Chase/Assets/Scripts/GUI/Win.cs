using UnityEngine;
using System.Collections;

public class Win : MonoBehaviour 
{

	// Use this for initialization
	void OnGUI ()
	{
		
		Rect menu = new Rect(Screen.width/2 - 50, Screen.height/2 - 45,200,70);
		//Create a menu screen with the title Game Over
		GUI.Box(menu, "YOU WON! CONGRATS!");

		// Make the first button. If it is pressed, it will go back to the Main Menu
		if(GUI.Button(new Rect(menu.x + menu.width/3 -10,menu.y + 30,80,20), "Play again?")) 
		{
			Application.LoadLevel("MainMenu");
		}
		/*if(GUI.Button(new Rect(menu.x + menu.width/3 -10,menu.y + 75,80,20), "Next Level")) 
		{
			Application.LoadLevel("level 2");
		}*/
	
	
	}
}
