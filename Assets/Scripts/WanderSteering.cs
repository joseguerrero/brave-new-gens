using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WanderSteering : MonoBehaviour {

	public int wander_cycle_skip = 10;
	public float rand_jit = 5;
	public float wanderAmt = 1.0f;
	public float wander_circle_radius = 5;
	public float wander_circle_distance = 5;
	public float avoid_dist_wall_scalar = 0.3f;
	public bool wander = true;
	int wander_timer = 0;

	protected Vector3 wander_target = Vector3.zero;
	WanderVehicle myVehicle;

	public bool getWander()
	{
		return wander;
	}

	void Start () {
	
	}
	
	void LateUpdate(){
		myVehicle = this.GetComponent<WanderVehicle>();
	}
	
	void Update () {	
	
	}
	
	void OnDrawGizmosSelected ()
	{
		if (wander)
		{
			Gizmos.color =new Color(0.5f,0.5f,0,.5f);
			//Gizmos.DrawWireSphere(myVehicle.transform.position+myVehicle.transform.forward*wander_circle_distance,wander_circle_radius);
			Gizmos.color = Color.red;
			Gizmos.DrawWireSphere(this.wander_target,0.2f);
		}
	}

	public void WanderOn()
	{
		wander = true;
		Debug.Log ("wander turned on");
	}
	public void WanderOff()
	{
		wander = false;
		Debug.Log("wander turned off");
	}
	
	public void SetPath(){return;}

	//Calculate() returns all steering forces
	public Vector3 Calculate()
	{
		Vector3 total_steering_force = Vector3.zero;

		if(wander)
			total_steering_force += Wander()*wanderAmt;
		return total_steering_force;
	}	

	Vector3 Wander()
	{
		wander_timer ++;
		if (wander_timer >= wander_cycle_skip)
		{
			wander_target += new Vector3(UnityEngine.Random.Range(-rand_jit,rand_jit),
			                             UnityEngine.Random.Range(-rand_jit,rand_jit),
			                             0.0f);
			//put to circle
			Vector3 to_wander_target = Vector3.Normalize(wander_target - this.transform.position)* wander_circle_radius;
			
			//more forward distance of circle
			to_wander_target += (this.transform.forward * wander_circle_distance);
			wander_target = this.transform.position + to_wander_target;

			Vector3 desired_velocity = Vector3.Normalize(to_wander_target)*myVehicle.maxspeed;
			
			Vector3 steering_force = desired_velocity - myVehicle.velocity;
			
			//zero out z axis for 2d simulation
			steering_force = new Vector3(steering_force.x,steering_force.y,0);
			
			wander_timer = 0;
			return steering_force;
		}
		else
			return Vector3.zero;
	}

	public Vector3 CalculateWallCollision(){
		return Vector3.zero;
	}

	public Vector3 ForwardComponent(){
		return transform.forward;
	}
	
	public Vector3 SideComponent(){
		return transform.right;
	}
}
