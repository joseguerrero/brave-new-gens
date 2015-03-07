using UnityEngine;
using System.Collections;

//****AUTONOMOUS VEHICLE****//

public class WanderVehicle : MonoBehaviour {

	public Vector3 velocity;
	public float max_force = 3.0f; 
	public float mass = 1.0f;
	public float rotation_speed = 1.0f;
	public float maxspeed = 10.0f;
	Vector3 up;
	Vector3 side;
	Vector3 forward = new Vector3 (0,1,0);
	public Vector3 steering_force;
	Vector3 acceleration;
	public float trueAcceleration = 0;

	
	void Start () {

	}
	
	void FixedUpdate() {
		
	}

	void Update () {
		UpdateVelocity();	
		UpdatePosition();
		UpdateLocalCoords();
		transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(forward,new Vector3(0,0,-1)),Time.deltaTime*rotation_speed);
	}

	public void UpdateVelocity(){	
		steering_force = this.GetComponent<WanderSteering>().Calculate();
		steering_force = truncate(steering_force,max_force);
		acceleration = steering_force/mass;
		velocity = truncate(velocity+acceleration, maxspeed);
		velocity += this.GetComponent<WanderSteering>().CalculateWallCollision();
	}
	
	private void UpdateLocalCoords(){
		if (velocity.magnitude >= 0.05f)
			forward = Vector3.Normalize(velocity);
	}
	
	public void UpdatePosition(){
		transform.position += velocity * Time.deltaTime;
	}
	
	public Vector3 truncate( Vector3 vec, float max){
		if(Vector3.Magnitude(vec) > max)
			vec=Vector3.Normalize(vec) * max;
		return vec;
	}
}
