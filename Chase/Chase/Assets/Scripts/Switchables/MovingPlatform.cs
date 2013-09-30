using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour, ISwitchable {
	
	// this is the velocity along the line from the start position to the end position
    public float velocity = 0.01f;
	public bool isMoving = true;
	public Vector3 startPosition;
	public Vector3 endPosition;
	
	// this initial value measures the displacement between start and end
	// in Start, this changes to a direction unit vector.
	public Vector3 direction = new Vector3(0, 0, 20);
   
    // Private

    // Use this for initialization
    void Start () {
		startPosition = this.transform.position;
		
		// this tells how far your platform will be moving
		endPosition = startPosition + direction;
		
		// this converts direction into a unit vector so that the speed is determined by
		// the magnitude of the velocity variable
		direction /= direction.magnitude;
    }
	
	public void toggle()
	{
		if (isMoving)
		{
			StopMoving();
		}
		else
		{
			ResumeMoving();
		}
	}
	
	void ResumeMoving ()
	{
		isMoving = true;
	}
	
	void StopMoving ()
	{
		isMoving = false;
	}
   
    // Update is called once per frame
    void Update () {
		if (!isMoving)
			return;
		
		// this moves the platform velocity units along the line
        this.transform.position += direction * velocity;
		
		// the vector from the start to the end
		Vector3 difference1 = endPosition - startPosition;
		// the vector from here to the end
		Vector3 difference2 = endPosition - this.transform.position;
		// if these two vectors are in the opposite direction and you are moving forward
		// then you have moved past the end
		if (Vector3.Dot(difference1, difference2) < 0 && velocity > 0)
		{
			velocity *= -1;
		}
		// the vector from here to start
		difference2 = startPosition - this.transform.position;
		// reverse the first vector
		difference1 *= -1;
		// if these two vectors are in the opposite direction and you are moving backward
		// then you have moved past the start
		if (Vector3.Dot(difference1, difference2) < 0 && velocity < 0)
		{
			velocity *= -1;
		}
    }
}
