using UnityEngine;
using System.Collections;

public class Force : MonoBehaviour {

	public float ChaseSpeed = 0.05f;
	public float WanderSpeed = 0.00005f;
    public float Range = 10.0f;
    public bool NormalizeSpeed = true;
	
	private Vector3 randDir;
	
	public float totalTime;
	private float changeTime;
	private float timeRange = 5.0f;
	private float timeOffset = .20f;
	
   
    // Private
    private GameObject player;
   public float RotationSpeed = 200.0f;

    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player");
		totalTime = 0.0f;
		randDir = new Vector3(Random.Range (-1.0f, 1.0f), 0, Random.Range (-1.0f, 1.0f));
		randDir.Normalize();
    }
   
    // Update is called once per frame
    void Update () {
      
        // Getting the difference between the positions
        Vector3 direction = player.transform.position - this.transform.position;
       
        // Check the range
        if(direction.magnitude < Range)
        {
            // Normalize
            if (NormalizeSpeed)
            {
                direction.Normalize();
            }

            // Add to this position
            this.transform.position += direction * ChaseSpeed;
        }
		else
		{
			direction = randDir;
	    	this.transform.position += direction * WanderSpeed;
		}
		
		totalTime += Time.deltaTime;
		
		if (totalTime > changeTime)
		{
			randDir = new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(-1.0f, 1.0f));
			randDir.Normalize();
			totalTime = 0;
			changeTime = Random.Range(timeRange - timeOffset, timeRange + timeOffset);
		}
		
    }
}
