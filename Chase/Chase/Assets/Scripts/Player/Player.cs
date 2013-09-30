using UnityEngine;
using System.Collections;

/**
 * Player
 * 
 * Basic Player script; keeps track of velocity and checks for collisions
 * against Cannon GameObjects.
 * 
 * To use, add new script Component to Player GameObject:
 * Component > Scripts > Player
 * 
 * Probably could have a better name, but w/e
 * 
 * @author - emr4378: Eduardo Rodrigues
 */
public class Player : MonoBehaviour {
	/* Private Variables */
	private Vector3 _prevPosition;
	private Vector3 _velocity;
	
	/* Properties */
	public Vector3 Velocity {
		get { return _velocity; }
	}
	
	/* Private Methods */
	private void Start() {}
	
	private void Update() {
		_velocity = (this.transform.position - _prevPosition) / Time.deltaTime;
		_prevPosition = this.transform.position;
	}
	
	private void OnControllerColliderHit(ControllerColliderHit hit) {
		if (hit.moveDirection.y < -0.3F) {
			return;
		}
		
		//recursively find Cannon; Cannon doesn't have hitbox, its children do
		GameObject gObj = RecursivelyCheckTag(hit.gameObject, "Cannon");
		if (gObj != null) {
			Cannon cannon = gObj.GetComponent<Cannon>();
			cannon.PlayerCollide(this.gameObject);
		}
	}
	
	/*Public Methods*/
	public static GameObject RecursivelyCheckTag(GameObject gObj, string tag) {
		if (gObj.tag == tag) {
			return gObj;
		} else if (gObj.transform.parent == null) {
			return null;
		} else {
			return RecursivelyCheckTag(gObj.transform.parent.gameObject, tag);
		}
	}
}
