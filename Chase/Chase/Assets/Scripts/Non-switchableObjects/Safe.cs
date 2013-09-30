using UnityEngine;
using System.Collections;

public class Safe : MonoBehaviour {
	
	private GameObject force;
	
	// Use this for initialization
	void Start () {
		force = GameObject.Find("Force");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other)
	{
		force.GetComponent<Force>().Range = 0;
	}
	
	void OnTriggerExit(Collider other)
	{
		force.GetComponent<Force>().Range = 99999;
	}
}
