using UnityEngine;
using System.Collections;

/**
 * GlowHUD - public class
 * 
 * The glowing "danger" indicator for how close the "Force" is to the player.
 * To use, add new GlowHUD Component to Player (Component > Scripts > GlowHUD)
 * 
 * Currently just an early attempt; more work will be done here.
 * 
 * @author - emr4378: Eduardo Rodrigues
 */
public class GlowHUD : MonoBehaviour {
	public const float 	RADIUS 		= 1.5f;
	public const int 	NUM_POINTS 	= 60;
	public const float	LINE_WIDTH 	= 0.05f;
	public const float 	DANGER_RAD	= 15.0f;
	public const bool	USE_MAX_RAD	= true;
	
	private LineRenderer line;
	private GameObject parent;
	private GameObject force;
	
    void Start () {
        parent = GameObject.Find("Player");
		force = GameObject.Find ("Force");
		
		parent.AddComponent("LineRenderer");
		
		line = (LineRenderer)parent.GetComponent("LineRenderer");
		line.material = new Material(Shader.Find("Particles/Additive"));
		line.SetColors(Color.blue, Color.blue);
		line.useWorldSpace = true;
		line.SetVertexCount(NUM_POINTS+1);
		line.SetWidth(LINE_WIDTH, LINE_WIDTH);
    }
   
    void Update () {
		Vector3 vectTo = force.transform.position - parent.transform.position;
		
		for (int i = 0; i <= NUM_POINTS; i++) {
			float rad = i * (360/NUM_POINTS) * Mathf.PI / 180;
			Vector3 pos = parent.transform.position;
			pos.x += Mathf.Cos (rad) * RADIUS;
			pos.z += Mathf.Sin (rad) * RADIUS;
			
			
			Vector3 tempVectTo = force.transform.position - pos;
			float F = DANGER_RAD * DANGER_RAD / Mathf.Pow(tempVectTo.magnitude, 2);
			pos += tempVectTo.normalized * F;
		
			Vector3 bleh = pos - parent.transform.position;
			if (USE_MAX_RAD && bleh.magnitude > RADIUS) {
				bleh.Normalize();
				bleh *= RADIUS;
			
				pos = parent.transform.position + bleh;
			}

			line.SetPosition(i, pos);
		}
    }
}
