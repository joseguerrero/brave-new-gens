using UnityEngine;
using System.Collections;

public class Robot : MonoBehaviour {

	public float movspeed = 100;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetAxis("Horizontal") < 0 ){
		//if (Input.GetButton ("left")) {
			rigidbody2D.AddForce(-Vector3.right * movspeed);
			//rigidbody2D.MovePosition(-Vector2.right * movspeed);
		}
		else if (Input.GetAxis("Horizontal") > 0 ) {
			rigidbody2D.AddForce(Vector3.right * movspeed);
			//rigidbody2D.MovePosition(Vector2.right * movspeed);
		}
	}

	void FixedUpdate(){

	}

}
