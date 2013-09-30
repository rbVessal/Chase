using UnityEngine;
using System.Collections;

/**
 * AutoDestruct
 * 
 * A small script to be attached to objects that should be destroyed after
 * a certain amount of time.
 * 
 * @author - emr4378: Eduardo Rodrigues
 */
public class AutoDestruct : MonoBehaviour {
	public float lifetime = 10.0f;	//the time to exist, in seconds
	
	void Start () {
		this.StartCoroutine("TimedDestruct");
	}
	
    IEnumerator TimedDestruct() {
        yield return new WaitForSeconds(lifetime);
        Destroy(this.gameObject);
    }
}
