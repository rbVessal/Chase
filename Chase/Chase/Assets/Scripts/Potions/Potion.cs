using UnityEngine;
using System.Collections;

public abstract class Potion : MonoBehaviour {
	
	public float range = 1.5f;
	
	protected GameObject thePlayer;
	
	// Use this for initialization
	public void Start () {
	
        thePlayer = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	public void Update () {
		
		// Getting the difference between the positions
		Vector3 direction = this.transform.position - thePlayer.transform.position;
		
		if (direction.magnitude < range)
		{
			PickUp();
		}
	}
	
	public abstract void PickUp();
}
