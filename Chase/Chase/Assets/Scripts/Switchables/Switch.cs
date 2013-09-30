using UnityEngine;
using System.Collections;

public class Switch : MonoBehaviour {
	
	// this is the max range at which you can activate the switch
    public float RANGE = 5.0f;
	
	// this is the maximum angle at which you are still considered facing the switch
	public float MAX_ANGLE = 30;
	
	// holds all of the things that depend on the switch
	public ArrayList switchables;
	
	public int numberOfSwitchables = 10;
	
	// the amount of rotation to be added to the switch
	public Vector3 addRotation = new Vector3(90, 0, 0);
	
	// the number associated with this switch
	public int switchNo;
   
    // Private
    private GameObject player;
	private bool isRotated = false;
	
	// time remaining before the switch can be used again
	private int lockTime = 0;

    // Use this for initialization
    void Start () {
		
		
		// finds the player
        player = GameObject.Find("Player");
		
		// adds all of the switchables to the list
		// all switchables MUST follow the following naming convention:
		// switchable[switch#]_[index#]
		switchables = new ArrayList(numberOfSwitchables);
		for (int i = 0; i < numberOfSwitchables; i++)
		{
			GameObject component = GameObject.Find("switchable" + switchNo + "_" + i);
			if (! (component == null))
			{
				ISwitchable switchable = component.GetComponent("ISwitchable") as ISwitchable;
				if (! (switchable == null))
				{
					switchables.Add((ISwitchable)switchable);
				}
			}
		}
    }
	
	// Update is called once per frame
	void Update () {
		lockTime--;
		
		// if E is down and you aren't locked out
		if (Input.GetKey(KeyCode.E) && lockTime <= 0)
		{
			// Getting the difference between the positions
			Vector3 direction = this.transform.position - player.transform.position;
			
			// gets the angle between the way the player is looking and the line from the player to the button
			Quaternion playerToSwitch = Quaternion.LookRotation(direction);
			float angle = Quaternion.Angle(player.transform.rotation, playerToSwitch);
			
			//Debug.Log("Angle: " + angle + ", Player Rotation: " + player.transform.rotation.ToString() + ", Player To Switch: " + playerToSwitch.ToString());
			
			if (direction.magnitude < RANGE && angle < MAX_ANGLE)
			{
				// switch ALL THE THINGS
				toggleAll();
				
				// lock the player out for 24 frames (1 second)
				lockTime = 24;
				
			}
		}
	}
	
	protected void toggleGraphics()
	{
		// Debug.Log("rotating");
		if ( isRotated)
		{
			isRotated = false;
			this.transform.Rotate(addRotation);
		}
		else
		{
			isRotated = true;
			this.transform.Rotate(Vector3.zero - addRotation);
		}
	}
	
	protected void toggleAll()
	{
		foreach (ISwitchable switchable in switchables)
		{
			switchable.toggle();
		}
		
		toggleGraphics();
	}
}
