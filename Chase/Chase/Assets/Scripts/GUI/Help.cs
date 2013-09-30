using UnityEngine;
using System.Collections;

public class Help : MonoBehaviour {

	// Use this for initialization
	void OnGUI () {
		int boxWidth = 450;
		int boxHeight = 400;
		Rect box = new Rect(Screen.width/2 - boxWidth / 2, Screen.height/2 - boxHeight/2, boxWidth, boxHeight);
		GUI.Box(box, "Help");
		
		Rect textContainer = new Rect(box.x + 10, box.y + 30, boxWidth - 20, boxHeight - 40);
		string helpMessage = "Avoid being caught by The Force.  The Force cannot move through walls.  Get to the exit door." + "\n\n" + 
			"Controls:" + "\n" + "Use WASD for movement, space to jump, E to interact with objects, and the mouse to look around the level" + "\n\n" + 
			"Interactive Objects:" + 
				"\nBoxes" + 
				"\nSwitches" + 
				"\nCrushers" + 
				"\nPotions" + 
				"\nCannons" + 
				"\nCoins" + 
				"\nPressure Plates" + 
				"\nSpring Tiles";
		GUI.Label(textContainer, helpMessage);
		// Make the back to menu button.
		if(GUI.Button(new Rect(box.x+boxWidth/2 - 40, box.y+boxHeight/2 + 140,80,20), "Main Menu")) {
			Application.LoadLevel("MainMenu");
		}
	}
}
