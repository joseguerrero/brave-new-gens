using UnityEngine;
using System.Collections;

//****AUTONOMOUS VEHICLE****//

public class Vehicle : MonoBehaviour {
	
	
	public Vector3 velocity;
	public float max_force = 3.0f; 
	public float mass = 1.0f;
	public float rotation_speed = 1.0f;
	
	public float maxspeed = 10.0f;
	//Vector3 position;
	Vector3 up;
	Vector3 side;
	Vector3 forward = new Vector3 (0,1,0);
	public Vector3 steering_force;
	Vector3 acceleration;
	public float trueAcceleration = 0;

	
	void Start () {
	}
	
	void FixedUpdate()
	{
		
	}
	void Update () {
	
		UpdateVelocity();	
		UpdatePosition();
		UpdateLocalCoords();
		
		transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(forward,new Vector3(0,0,-1)),Time.deltaTime*rotation_speed);
		//if (velocity.magnitude!=0)
		//	transform.forward = Vector3.Lerp(transform.forward,velocity.normalized,rotation_speed*Time.deltaTime);
		
		//transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(velocity),Time.deltaTime*rotation_speed);
		
	}
	
	
	public void UpdateVelocity()
	{	
		//use Physics equations  A=F/M , v2=v1+AT
		steering_force = this.GetComponent<SteeringBehavior>().Calculate();
		steering_force = truncate(steering_force,max_force);
		acceleration = steering_force/mass;
		
		velocity = truncate(velocity+acceleration,maxspeed);
		//trueAcceleration = maxspeed - Vector3.Magnitude(velocity);
		velocity += this.GetComponent<SteeringBehavior>().CalculateWallCollision();
		
	}
	
	private void UpdateLocalCoords()
	{
		if (velocity.magnitude >= 0.05f)
			forward = Vector3.Normalize(velocity);
		//Vector3 temp_up = Vector3.Normalize(up);
		//side = Vector3.Cross(forward,temp_up);
		//up = Vector3.Cross(forward,side);
	}
	
	public void UpdatePosition()
	{
		transform.position += velocity * Time.deltaTime;
		
	}
	
	public Vector3 truncate( Vector3 vec, float max)
	{
		if(Vector3.Magnitude(vec) > max)
			vec=Vector3.Normalize(vec) * max;
		return vec;
	}
	

		
/*	
	public Vector3 getCurrentVelocity(){
		return direction * speed;
	}*/
}
