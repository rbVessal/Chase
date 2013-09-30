using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour
{

	// Use this for initialization
	void OnGUI ()
	{
		
		Rect menu = new Rect(Screen.width/2 - 50,Screen.height/2 - 45,100,120);
		//Create a menu screen with the title Game Over
		GUI.Box(menu, "GAME OVER!");

		// Make the first button. If it is pressed, it will go back to the Main Menu
		if(GUI.Button(new Rect(menu.x + 10,menu.y + 50,80,20), "Play again?")) 
		{
			Application.LoadLevel("MainMenu");
		}
	
	
	}
	
	
}
