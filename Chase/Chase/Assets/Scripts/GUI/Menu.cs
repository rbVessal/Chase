using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	void OnGUI () {
		// Make a background box
		Rect menu = new Rect(Screen.width/2 - 50,Screen.height/2 - 45,100,120);
		GUI.Box(menu, "Chase");

		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		if(GUI.Button(new Rect(menu.x + 10,menu.y + 30,80,20), "Play")) {
			Application.LoadLevel("Levels");
		}

		// Make the second button.
		if(GUI.Button(new Rect(menu.x + 10,menu.y + 60,80,20), "Help")) {
			Application.LoadLevel("Help");
		}
		
		// Make the third button.
		if(GUI.Button(new Rect(menu.x + 10,menu.y + 90,80,20), "Quit")) {
			Application.Quit();
		}
	}
}
