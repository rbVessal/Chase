using UnityEngine;
using System.Collections;

public class SpeedPotion : Potion {
	
	// the percent change in walk speed under the potion's effects
	public float walkSpeedIncrease = .5f;
	
	protected Vector3 fullScale;
	
	// the duration of the potion's effects in seconds
	public int duration = 3;
	
	private bool pickedUp = false;
	
	// Use this for initialization
	public void Start () {
		base.Start();
		fullScale = this.transform.localScale;
		
	}
	
	// Update is called once per frame
	public void Update () {
		base.Update();
	}
	
	public override void PickUp()
	{
		if (!pickedUp)
		{
			pickedUp = true;
			PlayerPotionHandler potionHandler = thePlayer.GetComponent("PlayerPotionHandler") as PlayerPotionHandler;
			potionHandler.addEffect(duration, "speed", walkSpeedIncrease);
			this.transform.localScale = new Vector3(0, 0, 0);
		}
	}
}
