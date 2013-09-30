using UnityEngine;
using System.Collections;

// drag this onto the player in order to use potions
public class PlayerPotionHandler : MonoBehaviour {
	
	// the distance away that the force teleports to you
	public float teleportDistance = 1.0f;
	
	protected ArrayList potionEffects = new ArrayList();
	
	// the player
    private ThirdPersonController playerController;
	private Force theForce;
	private GameObject forceObj;
	
	// Use this for initialization
	void Start () {
	
		// gets the force
		forceObj = GameObject.Find("Force");
		theForce = forceObj.GetComponent("Force") as Force;
		
		// gets the player controller
		playerController = this.GetComponent("ThirdPersonController") as ThirdPersonController;
	}
	
	public void addEffect(int duration, string effectType, float magnitude = 0)
	{
		if (effectType == "speed")
		{
			magnitude += 1.0f;
			playerController.walkSpeed *= magnitude;
			playerController.runSpeed *= magnitude;
		}
		else if (effectType == "slow")
		{
			magnitude = 1.0f - magnitude;
			playerController.walkSpeed *= magnitude;
			playerController.runSpeed *= magnitude;
		}
		else if (effectType == "invisibility")
		{
			theForce.Range = 0;
		}
		else if (effectType == "teleport")
		{
			Vector3 newPos;
			System.Random rng = new System.Random();
			double angle = rng.NextDouble() * 2 * Mathf.PI;
			float x, z;
			x = Mathf.Cos((float)angle) * teleportDistance;
			z = Mathf.Sin((float)angle) * teleportDistance;
			Vector3 newLoc = new Vector3(x, 0, z);
			newLoc += this.transform.position;
			forceObj.transform.position = newLoc;
			return;
		}
		else
		{
			return;
		}
		
		potionEffects.Add(new PotionEffect((int)(Mathf.Round(duration / Time.deltaTime)), effectType, magnitude));
		//Debug.Log("Effect Added: " + effectType);
	}
	
	public void removeEffect(string effectType, float magnitude)
	{
		if (effectType == "speed" || effectType == "slow")
		{
			playerController.walkSpeed /= magnitude;
			playerController.runSpeed /= magnitude;
		}
		else if (effectType == "invisibility")
		{
			theForce.Range = 99999;
		}
		else
		{
			return;
		}
		
		//Debug.Log("Effect Removed: " + effectType);
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = potionEffects.Count -1; i >= 0; i--)
		{
			PotionEffect effect = potionEffects[i] as PotionEffect;
			if (effect.countDown())
			{
				effect.removeSelf(this);
				potionEffects.RemoveAt(i);
			}
		}
	}
}
