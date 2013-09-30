using UnityEngine;
using System.Collections;

public class Box : MonoBehaviour {
	
	private bool isCarried;
	private GameObject player;
	private bool buttonPressed;
	private bool prevButton;
	private Rigidbody rb;
	private BoxCollider bc;
	public float Range = 2.0f;
	public float CarryRadius = 1.5f;
	
	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
		isCarried = false;
		bc = this.gameObject.AddComponent("BoxCollider") as BoxCollider;
	}
	
	// Update is called once per frame
	void Update () {
		buttonPressed = Input.GetButton("Fire1");
		if(buttonPressed && !prevButton && !isCarried)
		{
			Vector3 distance = this.transform.position - player.transform.position;
			
			if (distance.magnitude < Range)
			{
				isCarried = true;
				Destroy(rb);
				Destroy(bc);
			}
		}
		else if (buttonPressed && !prevButton && isCarried)
		{
			isCarried = false;
			bc = this.gameObject.AddComponent("BoxCollider") as BoxCollider;
		}
		
		if (isCarried)
		{
			float zLoc = player.transform.position.z + CarryRadius * Mathf.Cos(player.transform.eulerAngles.y * Mathf.PI / 180);
			float xLoc = player.transform.position.x + CarryRadius * Mathf.Sin(player.transform.eulerAngles.y * Mathf.PI / 180);
			float yLoc = player.transform.position.y + .05f;
			this.transform.position = new Vector3(xLoc, yLoc, zLoc);
			this.transform.rotation = player.transform.rotation;
		}
		
		prevButton = buttonPressed;
	}
}
