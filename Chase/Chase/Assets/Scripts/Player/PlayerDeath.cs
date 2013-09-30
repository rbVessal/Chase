using UnityEngine;
using System.Collections;

public class PlayerDeath: MonoBehaviour 
{
	//Attributes
	private GameObject force;
	private GameObject crusher;
	private GameObject crusher1;
	private GameObject crusher2;
	private GameObject crusher3;
	private GameObject crusher4;
	private GameObject crusher5;
	private GameObject crusher6;
	private GameObject crusher7;
	private GameObject crusher8;
	private GameObject crusher9;
	// Use this for initialization
	void Start () 
	{
		//Set the collision detection to detect fast moving objects
		//Initialize the force to the sphere on stage
		force = GameObject.Find("Force");
		crusher = GameObject.Find("Crusher");
		crusher1 = GameObject.Find("Crusher1");
		crusher2 = GameObject.Find("Crusher2");
		crusher3 = GameObject.Find("Crusher3");
		crusher4 = GameObject.Find("Crusher4");
		crusher5 = GameObject.Find("Crusher5");
		crusher6 = GameObject.Find("Crusher6");
		crusher7 = GameObject.Find("Crusher7");
		crusher8 = GameObject.Find("Crusher8");
		crusher9 = GameObject.Find("Crusher9");
	}
	
	void Update()
	{
		GameOver();
	}
	
	void GameOver()
	{
		//Grab the distance between the force and the player
		Vector3 difference = force.transform.position - this.transform.position;
		
		//Check to see if their difference is less than the force width
		if (difference.magnitude < .5)
		{
			//Go to the GameOver screen
			Application.LoadLevel("GameOver");
		}
		
		if(crusher!= null)
		{
			//Grab the difference between the crusher and the player
			Vector3 differenceBtwnCrusherAndPlayer = crusher.transform.position - this.transform.position;
			
			//Check to see if their difference is less than half of the crusher's height
			if(differenceBtwnCrusherAndPlayer.magnitude < crusher.renderer.bounds.extents.y+.1)
			{
				Application.LoadLevel("GameOver");
			}
			
		}
		
		if(crusher1!= null)
		{
			//Grab the difference between the crusher and the player
			Vector3 differenceBtwnCrusherAndPlayer = crusher1.transform.position - this.transform.position;
			
			//Check to see if their difference is less than half of the crusher's height
			if(differenceBtwnCrusherAndPlayer.magnitude < crusher1.renderer.bounds.extents.y+.1)
			{
				Application.LoadLevel("GameOver");
			}
			
		}
		if(crusher2!= null)
		{
			//Grab the difference between the crusher and the player
			Vector3 differenceBtwnCrusherAndPlayer = crusher2.transform.position - this.transform.position;
			
			//Check to see if their difference is less than half of the crusher's height
			if(differenceBtwnCrusherAndPlayer.magnitude < crusher2.renderer.bounds.extents.y+.1)
			{
				Application.LoadLevel("GameOver");
			}
			
		}
		if(crusher3!= null)
		{
			//Grab the difference between the crusher and the player
			Vector3 differenceBtwnCrusherAndPlayer = crusher3.transform.position - this.transform.position;
			
			//Check to see if their difference is less than half of the crusher's height
			if(differenceBtwnCrusherAndPlayer.magnitude < crusher3.renderer.bounds.extents.y+.1)
			{
				Application.LoadLevel("GameOver");
			}
			
		}
		if(crusher4!= null)
		{
			//Grab the difference between the crusher and the player
			Vector3 differenceBtwnCrusherAndPlayer = crusher4.transform.position - this.transform.position;
			
			//Check to see if their difference is less than half of the crusher's height
			if(differenceBtwnCrusherAndPlayer.magnitude < crusher4.renderer.bounds.extents.y+.1)
			{
				Application.LoadLevel("GameOver");
			}
			
		}
		if(crusher5!= null)
		{
			//Grab the difference between the crusher and the player
			Vector3 differenceBtwnCrusherAndPlayer = crusher5.transform.position - this.transform.position;
			
			//Check to see if their difference is less than half of the crusher's height
			if(differenceBtwnCrusherAndPlayer.magnitude < crusher5.renderer.bounds.extents.y+.1)
			{
				Application.LoadLevel("GameOver");
			}
			
		}
		if(crusher6!= null)
		{
			//Grab the difference between the crusher and the player
			Vector3 differenceBtwnCrusherAndPlayer = crusher6.transform.position - this.transform.position;
			
			//Check to see if their difference is less than half of the crusher's height
			if(differenceBtwnCrusherAndPlayer.magnitude < crusher6.renderer.bounds.extents.y+.1)
			{
				Application.LoadLevel("GameOver");
			}
			
		}
		if(crusher7!= null)
		{
			//Grab the difference between the crusher and the player
			Vector3 differenceBtwnCrusherAndPlayer = crusher7.transform.position - this.transform.position;
			
			//Check to see if their difference is less than half of the crusher's height
			if(differenceBtwnCrusherAndPlayer.magnitude < crusher7.renderer.bounds.extents.y+.1)
			{
				Application.LoadLevel("GameOver");
			}
			
		}
		if(crusher8!= null)
		{
			//Grab the difference between the crusher and the player
			Vector3 differenceBtwnCrusherAndPlayer = crusher8.transform.position - this.transform.position;
			
			//Check to see if their difference is less than half of the crusher's height
			if(differenceBtwnCrusherAndPlayer.magnitude < crusher8.renderer.bounds.extents.y+.1)
			{
				Application.LoadLevel("GameOver");
			}
			
		}
		if(crusher9!= null)
		{
			//Grab the difference between the crusher and the player
			Vector3 differenceBtwnCrusherAndPlayer = crusher9.transform.position - this.transform.position;
			
			//Check to see if their difference is less than half of the crusher's height
			if(differenceBtwnCrusherAndPlayer.magnitude < crusher9.renderer.bounds.extents.y+.1)
			{
				Application.LoadLevel("GameOver");
			}
			
		}
		
		//Check to see if the player has fallen off a platform
		if (this.transform.position.y < -15)
		{
			//Go to the GameOver screen
			Application.LoadLevel("GameOver");
		}
	}
}
