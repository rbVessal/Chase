using UnityEngine;
using System.Collections;

/**
 * Cannon
 * 
 * A turret/cannon thing, for "Cannon" prefabs.
 * Requires the cannon have Turret GameObject with a Barrel GameObject child.
 * 
 * @author - emr4378: Eduardo Rodrigues
 */
public class Cannon : MonoBehaviour {
	/* Default Values, for use if not set in inspector */
	public const float DF_POWER		= 10.0f;
	public const float DF_ANGLE		= 30.0f;
	public const float DF_MIN_ANGLE = 0.0f;
	public const float DF_MAX_ANGLE	= 60.0f;
	public const float DF_MIN_POWER	= 1.0f;
	public const float DF_MAX_POWER = 50.0f;
	public const float DF_TRIG_RAD	= 2.0f;

	/* Inspector-definable Variables */
	[SerializeField]
	private float _angle = DF_ANGLE;
	[SerializeField]
	private float _power = DF_POWER;
	[SerializeField]
	private float _minAngle = DF_MIN_ANGLE;
	[SerializeField]
	private float _maxAngle = DF_MAX_ANGLE;
	[SerializeField]
	private float _minPower = DF_MIN_POWER;
	[SerializeField]
	private float _maxPower = DF_MAX_POWER;
	[SerializeField]
	private float _triggerRadius = DF_TRIG_RAD;
	
	/* Private Variables */
	private bool _prevFrame;
	private float _barrelSize;
	private GameObject _turret;
	private GameObject _barrel;
	
	/* Properties */
	public float Angle {
		get{ return _angle; }
		set{
			_angle = Mathf.Clamp(value, _minAngle, _maxAngle); 
		}
	}
	public float Power {
		get{ return _power; }
		set{ 
			_power = Mathf.Clamp(value, _minPower, _maxPower);
		}
	}
	
	/* Private Methods*/
	private void Start() {
		Angle = _angle;
		Power = _power;
		
		_turret = this.transform.Find("Cannon_Turret").gameObject;
		_barrel = _turret.transform.Find("Cannon_Barrel").gameObject;
		
		_barrelSize = _barrel.renderer.bounds.size.z + _barrel.transform.position.magnitude;
		_turret.transform.RotateAround(new Vector3(-1, 0, 0), Angle * Mathf.PI / 180);
	}

	private void Update() {
		Vector3 distance = this.transform.position - GameObject.Find("Player").transform.position;
			
		if (distance.magnitude < _triggerRadius) {	
			if (Input.GetKey(KeyCode.E) && !_prevFrame) {
				Fire();
			}
		}
		
		_prevFrame = Input.GetKey(KeyCode.E);
	}
	
	private GameObject CreateCannonBall(Vector3 position, Vector3 velocity, float scale) {
		GameObject ball = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		ball.AddComponent<AutoDestruct>().lifetime = 5.0f;
		
		ball.AddComponent("Rigidbody");
		Rigidbody rigid = ball.GetComponent<Rigidbody>();
	
		ball.transform.localScale *= scale;
		ball.transform.position = position;
		rigid.velocity = velocity;
		
		ball.name = "Cannon_Ball";
		
		return ball;
	}
	
	/*Public Methods */
	public void Fire() {
		Vector3 direction = _turret.transform.forward * _barrelSize + this.transform.forward;
		direction.Normalize();
		Vector3 position = _turret.transform.position + direction;

		GameObject ball = this.CreateCannonBall(position, direction * Power, 0.5f);
		Physics.IgnoreCollision(ball.collider, _barrel.collider);
	}
	
	public void PlayerCollide(GameObject player) {
		if (player.GetComponent<Player>().Velocity.magnitude != 0) {
			Vector3 vectTo = this.transform.position - player.transform.position;
			vectTo.y = 0;
			Vector3 force = player.transform.forward;
			force.y = 0;
			Vector3 up = Vector3.Cross(vectTo, force);
			up.Normalize();
			
			float dot = Vector3.Dot (force, Vector3.Cross (up, vectTo).normalized);
	
			float rot = -dot/vectTo.magnitude;
			rot *= Mathf.PI/180;
			
			this.transform.RotateAround(up, rot);
		}
	}
}