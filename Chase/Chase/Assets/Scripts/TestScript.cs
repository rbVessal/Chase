using UnityEngine;
using System.Collections;

public class TestScript : MonoBehaviour {
	
	private GameObject testObject;
	private bool prevFrame;
	
	// Use this for initialization
	void Start () {
		testObject = GameObject.Find("Moving P");	
	}
	
	// Update is called once per frame
	void Update () {
		prevFrame = Input.GetKey(KeyCode.E);
	}
	
	void OnTriggerEnter(Collider other)
	{
		testObject.GetComponent<MovingPlatform>().isMoving = true;
	}
	
	void OnTriggerExit(Collider other)
	{
		testObject.GetComponent<MovingPlatform>().isMoving = false;
	}
}