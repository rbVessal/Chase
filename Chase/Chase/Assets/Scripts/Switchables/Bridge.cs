using UnityEngine;
using System.Collections;

public class Bridge : MonoBehaviour, ISwitchable {
	
	// the dimensions of the bridge when it is fully scaled up
	public Vector3 fullScale;
	
	// determines whether the bridge starts off active
	public bool extended = false;
	
	// Use this for initialization
	void Start () {
		fullScale = this.transform.localScale;
		if (!extended)
		{
			this.transform.localScale = new Vector3(0, 0, 0);
		}
		else
		{
			this.transform.localScale = fullScale;
		}
	}
	
	public void toggle()
	{
		Debug.Log("Toggle");
		if (extended)
		{
			this.transform.localScale = new Vector3(0, 0, 0);
			extended = false;
		}
		else
		{
			this.transform.localScale = fullScale;
			extended = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
