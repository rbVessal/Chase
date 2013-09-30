using UnityEngine;
using System.Collections;

public class Spring : MonoBehaviour {
	
	private GameObject spring;
	private GameObject player;
	

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
		spring = GameObject.Find("Spring");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other)
	{
		player.GetComponent<ThirdPersonController>().jumpHeight = 10;
	}
	
	void OnTriggerExit(Collider other)
	{
		player.GetComponent<ThirdPersonController>().jumpHeight = 4;
	}
}
