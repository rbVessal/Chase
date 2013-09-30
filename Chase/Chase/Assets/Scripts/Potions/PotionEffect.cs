using UnityEngine;
using System.Collections;

/*
 * A general-purpose class for handling potion effects
 */
public class PotionEffect : Object {
	
	protected int durationLeft;
	
	protected string effectType;
	
	protected float magnitude;
	
	public PotionEffect(int duration, string effectType, float magnitude)
	{
		durationLeft = duration;
		this.effectType = effectType;
		this.magnitude = magnitude;
	}
	
	public bool countDown()
	{
		durationLeft--;
		if (durationLeft == 0)
			return true;
		else
			return false;
	}
	
	public void removeSelf(PlayerPotionHandler handler)
	{
		handler.removeEffect(effectType, magnitude);
	}
}
