using UnityEngine;
using System.Collections;
using System.Collections.Generic;


//****AUTONOMOUS STEERING BEHAVIORS****//


public class SteeringBehavior : MonoBehaviour {
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
	Vehicle myVehicle;
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
		
	public bool getSeek()
	{
		return seek;
	}
	public bool getArrive()
	{
		return arrive;
	}
	public bool getFlee()
	{
		return flee;
	}
	public bool getPursuit()
	{
		return pursuit;
	}
	public bool getEvade()
	{
		return evade;
	}
	public bool getWander()
	{
		return wander;
	}
	public bool getAvoid()
	{
		return avoid;
	}
	public bool getAlignment()
	{
		return alignment;
	}
	public bool getCohesion()
	{
		return cohesion;
	}
	public bool getSeparation()
	{
		return separation;
	}
	public bool getWallAvoidance()
	{
		return wallAvoidance;
	}
	public bool getHide()
	{
		return hide;
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
		myVehicle = this.GetComponent<Vehicle>();
		
	}
	
	void Update () {	
		//Debug.Log ("Your Velocity: " + target_vel + "  Pursuer Velocity: " +myVehicle.velocity );

	}
	
	void OnDrawGizmosSelected ()
	{
		if (cohesion || separation || alignment)
		{
			Gizmos.color = new Color(0.3f,0.5f,0.5f,.5f);
			Gizmos.DrawWireSphere(transform.position,BoundingRadius);
		}
		if (wander)
		{
			
			Gizmos.color =new Color(0.5f,0.5f,0,.5f);
			
			//Gizmos.DrawWireSphere(myVehicle.transform.position+myVehicle.transform.forward*wander_circle_distance,wander_circle_radius);
			Gizmos.color = Color.red;
			Gizmos.DrawWireSphere(this.wander_target,0.2f);
		}
		if (avoid)
		{
			Gizmos.color = new Color(0,0,0.5f,.5f);
			Gizmos.DrawWireSphere(p1+transform.forward*1.2f,avoid_rad);
			Gizmos.DrawLine(p1,p2);
			p2 = p1+ transform.forward*avoid_dist;
			Gizmos.DrawWireSphere(p2,avoid_rad);
			
		}
		if (wallAvoidance)
		{
			Gizmos.color = Color.green;
			
			foreach(Vector3 feeler in feelers)
				Gizmos.DrawLine(transform.position,transform.position+feeler);
			
		}
	}
	
	public void SeekOn()
	{
		seek = true;
		Debug.Log("seek turned on");
	}
	
	public void SeekOff()
	{
		seek = false;
		Debug.Log("seek turned off");
	}
	
	public void ArriveOn()
	{
		arrive = true;
		Debug.Log("arrive turned on");
	}

	public void ArriveOff()
	{
		arrive = false;
		Debug.Log("arrive turned off");
	}
		public void FleeOn()
	{
		flee = true;
		Debug.Log("flee turned on");
	}
	public void FleeOff()
	{
		flee = false;
		Debug.Log("flee turned off");
	}
	public void PursuitOn()
	{
		pursuit = true;
		Debug.Log("pursuit turned on");
	}
	public void PursuitOff()
	{
		pursuit = false;
		Debug.Log("pursuit turned off");
	}
	public void EvadeOn()
	{
		evade = true;
		Debug.Log ("evade turned on");
	}
	public void EvadeOff()
	{
		evade = false;
		Debug.Log("evade turned off");
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
	public void AvoidOn()
	{
		avoid = true;
		Debug.Log("avoid turned on");
	}
	public void AvoidOff()
	{
		avoid = false;
		Debug.Log("avoid turned off");
	}
	public void AlignmentOn()
	{
		alignment = true;
		Debug.Log("align turned on");
	}
	public void AlignmentOff()
	{
		alignment = false;
		Debug.Log("align turned off");
	}
	public void SeparationOn()
	{
		separation = true;
		Debug.Log("separation turned on");
	}
	public void SeparationOff()
	{
		separation = false;
		Debug.Log("separation turned off");
	}
	public void CohesionOn()
	{
		cohesion = true;
		Debug.Log("cohesion turned on");
	}
	public void CohesionOff()
	{
		cohesion = false;
		Debug.Log("cohesion turned off");
	}
	public void HideOn()
	{
		hide = true;
		Debug.Log("hide turned on");
	}
	public void HideOff()
	{
		hide = false;
		Debug.Log("hide turned off");
	}
	
	
	public void SetTarget(GameObject t)
	{
		target = t;
	}
	public void wallAvoidanceOn()
	{
		wallAvoidance = true;
		Debug.Log("wall avoidance turned on");
	}
	public void wallAvoidanceOff()
	{
		wallAvoidance = false;
		Debug.Log("wall avoidance turned off");
	}
	
	public void SetPath(){return;}
	
	public Vector3 CalculateWallCollision()
	{
		if(wallAvoidance)
			return WallAvoidance()*wallAvoidanceAmt;
		else return Vector3.zero;
	}
	
	//Calculate() returns all steering forces
	public Vector3 Calculate()
	{
		Vector3 total_steering_force = Vector3.zero;
		
		if (seek)
			total_steering_force += Seek (target.transform.position)*seekAmt;
		if(arrive)
			total_steering_force += Arrive(target.transform.position)*arriveAmt;
		if(flee)
			total_steering_force += Flee(target.transform.position)*fleeAmt;
		if(pursuit)
			total_steering_force += Pursuit()*pursuitAmt;
		if(evade)
			total_steering_force += Evade()*evadeAmt;
		if(wander)
			total_steering_force += Wander()*wanderAmt;
		if(avoid)
			total_steering_force += Avoid()*avoidAmt;

		if(hide)
			total_steering_force += Hide(HideObject,target.transform.position);
		if (alignment || cohesion || separation)
		{
			enemy_list = GameObject.FindGameObjectsWithTag("enemy");
			TagNeighbors();
		
		if(alignment)
			total_steering_force += Alignment()*alignmentAmt;
		if(cohesion)
			total_steering_force += Cohesion()*cohesionAmt;
		if(separation)
			total_steering_force += Separation()*separationAmt;
		}
	
		
		return total_steering_force;
	}	
	
	void TagNeighbors(){
		foreach (GameObject enemy in enemy_list)
		{
			//untag enemies
			enemy.GetComponent<SteeringBehavior>().tagged = false;
			
			//calc sq distance
			float distance = Vector3.SqrMagnitude(enemy.transform.position - transform.position);
			
			//add both radius
			float range = BoundingRadius + enemy.GetComponent<SteeringBehavior>().BoundingRadius;
			
			if (enemy != this.gameObject && distance< range*range)
				enemy.GetComponent<SteeringBehavior>().tagged = true;
		}
	}
	
	void UpdateFeelers()
	{
		
		feelers[0] = transform.forward * forwardFeelerLength;
		feelers[1] = (Quaternion.AngleAxis(feeler_angle, Vector3.forward) * transform.forward) * sideFeelerLength;
		feelers[2] = (Quaternion.AngleAxis(-feeler_angle, Vector3.forward) * transform.forward) * sideFeelerLength;
		
	}
	
	Vector3 WallAvoidance()
	{
		UpdateFeelers();
		Vector3 steeringForce= Vector3.zero;
		float DistToClosestHit = 99999f;
		RaycastHit closestHit = new RaycastHit();
		RaycastHit hit;
		
		int i = 0;
		int index = -1;
		float length = forwardFeelerLength;
		foreach (Vector3 feeler in feelers)
		{

			if (i>0)length=sideFeelerLength;
			if(Physics.Raycast(this.transform.position,feeler,out hit,length, wallLayerMask))
			{
				Debug.Log("Logro hacer el raycast");
				if (hit.distance < DistToClosestHit)
				{
					Debug.Log("Golpeo algo");
					DistToClosestHit = hit.distance;
					closestHit = hit;
					index = i;
				}
				
			}
			
			if (index >= 0)
			{
				//Debug.Log("hit wall with feeler: " + index);
				Vector3 overShoot = feelers[index]-(closestHit.point - transform.position);
				steeringForce=closestHit.normal*overShoot.magnitude;
			}
			
			i++;
			
		}

		return new Vector3(steeringForce.x,steeringForce.y,0);
		
	}
	
	Vector3 Alignment(){
		
		int e_cnt=0;
		Vector3 AvgHeading = Vector3.zero;
		foreach(GameObject enemy in enemy_list)
		{
			if(enemy != this.gameObject && enemy.GetComponent<SteeringBehavior>().tagged)
			{
				AvgHeading += enemy.GetComponent<Vehicle>().velocity.normalized;
				e_cnt++;
			}
		}
		if(e_cnt > 0) //if more than one enemy (including self)
		{
			AvgHeading /= (float)e_cnt;
			AvgHeading -= myVehicle.velocity.normalized;
		}
		return AvgHeading - new Vector3(0,0,AvgHeading.z);
	}
	
	Vector3 Cohesion(){
		
		Vector3 centerOfMass = Vector3.zero;
		int enmyCnt = 0;
		
		foreach(GameObject enemy in enemy_list)
		{
			if(enemy != this.gameObject && enemy.GetComponent<SteeringBehavior>().tagged)
			{
				centerOfMass += enemy.transform.position;
				enmyCnt++;
			}
		}
		
		if (enmyCnt > 0)
		{
			//center of mass is the average of the sum of possitions
			centerOfMass /= (float)enmyCnt;
			float strength = Vector3.Magnitude(transform.position-centerOfMass)/BoundingRadius*BoundingRadius;
			if (strength > myVehicle.maxspeed) strength = myVehicle.maxspeed;
			//Debug.Log(strength);
			return Seek(centerOfMass)*strength;
		}
		
		
		return Vector3.zero;
	}
	
	Vector3 Separation(){
		
		Vector3 steeringforce = Vector3.zero;
		foreach(GameObject enemy in enemy_list)
		{
			if(enemy != this.gameObject && enemy.GetComponent<SteeringBehavior>().tagged)
			{
				Vector3 to_agent = transform.position - enemy.transform.position;
				
				if (to_agent == Vector3.zero) to_agent += new Vector3 (Random.Range(.001f,.1f),Random.Range(.001f,.1f),0);
				
				steeringforce += to_agent/to_agent.magnitude;
				
			}
			
		}
		
		return new Vector3(steeringforce.x,steeringforce.y,0);
	}
	
	
	//Seek()
	//returns force towards target scaled by max force
	Vector3 Seek(Vector3 target){
		Vector3 steeringForce = (Vector3.Normalize(target - transform.position)* myVehicle.maxspeed)
				- myVehicle.velocity; 
		return new Vector3(steeringForce.x, steeringForce.y, 0);
	}
	
	//Flee()
	//returns a force away from the target scaled by max force
	Vector3 Flee(Vector3 target){
		Vector3 pos = transform.position;
		float maxspd = myVehicle.maxspeed;
		Vector3 from_target = pos - target;
		Vector3 direction_from_target = Vector3.Normalize(from_target);
		Vector3 desired_velocity = direction_from_target * maxspd;
		Vector3 steering = desired_velocity - myVehicle.velocity;
		return new Vector3(steering.x,steering.y,0);//negate z for 2d
	}
	
	//Pursuit()
	//returns a force  towards targets predicted position
	Vector3 Pursuit(){
		Vector3 to_target = target.transform.position - transform.position;
		Vector3 vel_towards_target= Vector3.Dot(Vector3.Normalize(to_target),Vector3.Normalize(myVehicle.velocity)) * myVehicle.velocity;
		float spd1 = Vector3.Magnitude(vel_towards_target);
		Vector3 vel_towards_pursuer= Vector3.Dot(Vector3.Normalize(to_target),Vector3.Normalize(target_vel)) * target_vel;
		float spd2 = Vector3.Magnitude(vel_towards_pursuer);
		float denom = spd1+spd2;
		if (denom==0)
			return Seek (target.transform.position);
		float projected_time = Vector3.Magnitude(to_target)/(spd1+spd2);
		Vector3 projected_target = target_vel * projected_time + target.transform.position;
		return Seek(projected_target);
		
	}
	
	//Evade()
	//returns a force  away from targets predicted position
	Vector3 Evade(){
		Vector3 to_target = target.transform.position - transform.position;
		Vector3 vel_towards_target= Vector3.Dot(Vector3.Normalize(to_target),Vector3.Normalize(myVehicle.velocity)) * myVehicle.velocity;
		float spd1 = Vector3.Magnitude(vel_towards_target);
		Vector3 vel_towards_pursuer= Vector3.Dot(Vector3.Normalize(to_target),Vector3.Normalize(target_vel)) * target_vel;
		float spd2 = Vector3.Magnitude(vel_towards_pursuer);
		float denom = spd1+spd2;
		if (denom==0)
			return Flee (target.transform.position);
		float projected_time = Vector3.Magnitude(to_target)/(spd1+spd2);
		Vector3 projected_target = target_vel * projected_time + target.transform.position;
		return Flee(projected_target);
	}
	
	//Arrive() returns a slower force towards target
	Vector3 Arrive(Vector3 target)
	{
		
		Vector3 to_target = (target-this.transform.position);
		float distance = Vector3.Magnitude(to_target);
		
		if (distance > arrive_stop_distance )
		{
			float speed = distance/(arrive_speed_tweaker);
			speed = Mathf.Min(speed,myVehicle.maxspeed);
			Vector3 desired_velocity = to_target*(speed/distance);
			
			return (desired_velocity - myVehicle.velocity);
		}
		else
			return Vector3.zero;	
			
		
		
	}
	
	Vector3 Wander()
	{
		wander_timer ++;
		if (wander_timer >= wander_cycle_skip)
		{
				
			//Vector3 old_target = wander_target;
			
			wander_target += (wander_circle_distance*-transform.forward)+(transform.position-last_wander_pos);
			wander_target += new Vector3(UnityEngine.Random.Range(-rand_jit,rand_jit),
										UnityEngine.Random.Range(-rand_jit,rand_jit),
										UnityEngine.Random.Range(-rand_jit,rand_jit));
		
			last_wander_pos = transform.position;
			
			//put to circle
			Vector3 to_wander_target = Vector3.Normalize(wander_target-this.transform.position)
															* wander_circle_radius;
			
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
	
	Vector3 Avoid()
	{
		Vector3 steering_force = Vector3.zero;
		RaycastHit hit;
		 p1 = transform.position;
		
		
		if(Physics.SphereCast(p1,avoid_rad,transform.forward*avoid_dist,out hit,avoid_dist,layerMask))
		{
			//if(hit.distance < avoid_dist * avoid_dist_wall_scalar)// <++makeshift wall avoidance
			//	return Flee(hit.point);
				//return Vector3.Normalize( Flee(hit.point))*Vector3.Magnitude( myVehicle.velocity)
			
		
			
			Vector3 to_target = hit.point - transform.position; // to target
			Vector3 collision_line = transform.TransformDirection(Vector3.forward*avoid_dist); // line infront of ship
			float distance_on_line = Vector3.Dot(collision_line.normalized,to_target.normalized); //where on line target was hit
			if (distance_on_line == 0) distance_on_line = avoid_dist;//if orthognal
			Vector3 point_on_line = (transform.position+transform.forward*distance_on_line);
			steering_force = ((point_on_line-hit.point)*avoid_y_scalar);
			
			steering_force += (transform.position-point_on_line)*AvoidBrakeWeight;
			
			
			//Debug.Log("hitpoint: "+ hit.point + "point on line: " + point_on_line + "distance on line: " + distance_on_line);
			//Debug.Log("steering force: " + steering_force);
			
		}
		steering_force = new Vector3(steering_force.x,steering_force.y,0); //negate z for 2d
		//if(hit.distance < avoid_dist * avoid_dist_wall_scalar)
			//return steering_force.normalized*myVehicle.maxspeed;
		return Vector3.Normalize(steering_force)*myVehicle.max_force;
	}
	
	Vector3 GetHidingPosition(GameObject obj,Vector3 pursuer_loc)
	{
	 
		Vector3 awayFromPursuer = Vector3.Normalize(obj.transform.position - pursuer_loc);
		return ((hide_obj_width + hide_from_obj) *obj.transform.localScale.x/2)* awayFromPursuer + obj.transform.position;	
		
	}
	
	Vector3 Hide(GameObject hide_obj, Vector3 target)
	{
		Vector3 hidePos = GetHidingPosition(hide_obj,target);
		return Arrive(hidePos);
	}
	
	
	public Vector3 ForwardComponent(){return transform.forward;}
	
	public Vector3 SideComponent(){return transform.right;}

	
}
