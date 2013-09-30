using UnityEngine;
using System.Collections;

public class PlayerWin : MonoBehaviour 
{
	//Attributes
	private GameObject door;
	void Start()
	{
		door = GameObject.Find("Door");
		
	}
	
	void OnTriggerEnter(Collider collider)
	{
		Debug.Log (collider.gameObject);
		if(collider.gameObject == door)
		{
			Application.LoadLevel ("Win");
		}
	}
	
	
}
