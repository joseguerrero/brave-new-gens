using UnityEngine;
using System.Collections;
using System.Collections.Generic;


//****AUTONOMOUS STEERING BEHAVIORS****//


public class WanderSteering : MonoBehaviour {
	public GameObject HideObject;
// ===================================
// member variables 
// ===================================
	public float seekAmt = 1.0f;
	public float arriveAmt = 1.0f;
	public float fleeAmt = 1.0f;
	public float pursuitAmt = 1.0f;
	public float evadeAmt = 1.0f;
	public float wanderAmt = 1.0f;
	public float avoidAmt = 1.0f;
	public float alignmentAmt = 1.0f;
	public float cohesionAmt = 1.0f;
	public float separationAmt = 1.0f;
	public float wallAvoidanceAmt = 1.0f;
	
	public GameObject target;
	
	//flock behaviours
	public float BoundingRadius = 2.0f;
	public bool tagged;//true if within BoundingRadius for flocking behaviors
	
	//pursue
	//public float pursue_fudgefactor = 1.0f;
	
	//wander
	public float wander_circle_radius = 5;
	public float wander_circle_distance = 5;
	public float rand_jit = 5;
	public int wander_cycle_skip = 10;
	public float avoid_dist_wall_scalar = 0.3f;
	
	//arrive
	public float arrive_speed_tweaker = 3;
	public float arrive_stop_distance = 0.1f;

	//obstacale avoidance
	public float avoid_dist = 5.0f;
	public float avoid_rad = 1.0f;
	public float avoid_y_scalar = 1.5f;
	public float AvoidBrakeWeight = 0.2f;
	
	public float hide_obj_width = 2.0f;
	public float hide_from_obj = 3.0f;
	
	bool seek;
	bool arrive;
	bool flee;
	bool pursuit;
	bool evade;
	bool wander = true;
	bool alignment;
	bool cohesion;
	bool separation;
	bool avoid;
	bool hide;
	bool wallAvoidance;
	int wander_timer = 0;
	
	Vector3 target_last_pos;
	Vector3 target_vel;
	protected Vector3 wander_target = Vector3.zero;
	Vector3 p1;
	Vector3 p2;
	WanderVehicle myVehicle;
	Vector3 last_wander_pos;
	public float feeler_angle = 45.0f;
	Vector3 f_wall_feeler;
	Vector3 s1_wall_feeler;
	Vector3 s2_wall_feeler;
	public float sideFeelerLength = 1.0f;
	public float forwardFeelerLength = 1.5f;
	
	GameObject[] enemy_list;

// ===================================
// accessors
// ===================================
		
	public bool getWander()
	{
		return wander;
	}

	
	List<Vector3> feelers;

	int layerMask = 1 << 8; //to prevent enemies from colliding w/ each other
	int wallLayerMask = 1 << 9;
	
// ===================================
// methods
// ===================================
	void Start () {
		feelers = new List<Vector3>{ f_wall_feeler,s1_wall_feeler,s2_wall_feeler};
		layerMask = ~layerMask;
		wallLayerMask = ~wallLayerMask;
	}
	
	void LateUpdate(){
		target_vel = (target.transform.position - target_last_pos)/Time.deltaTime;
		target_last_pos = target.transform.position;
		myVehicle = this.GetComponent<WanderVehicle>();
		
	}
	
	void Update () {	
		//Debug.Log ("Your Velocity: " + target_vel + "  Pursuer Velocity: " +myVehicle.velocity );
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
			//wander_target += (wander_circle_distance*transform.right)+(transform.position-last_wander_pos);

			wander_target += new Vector3(UnityEngine.Random.Range(-rand_jit,rand_jit),
			                             UnityEngine.Random.Range(-rand_jit,rand_jit),
			                             0.0f);
		
			last_wander_pos = transform.position;
			
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

	public Vector3 CalculateWallCollision()
	{
		return Vector3.zero;
	}

	public Vector3 ForwardComponent(){return transform.forward;}
	
	public Vector3 SideComponent(){return transform.right;}

	
}
