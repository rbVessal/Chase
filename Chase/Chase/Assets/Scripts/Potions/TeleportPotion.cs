using UnityEngine;
using System.Collections;

public class TeleportPotion : Potion {
	
	
	protected Vector3 fullScale;
	
	
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
			potionHandler.addEffect(0, "teleport", 0.0f);
			this.transform.localScale = new Vector3(0, 0, 0);
		}
	}
}
