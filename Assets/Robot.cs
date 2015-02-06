using UnityEngine;
using System.Collections;

public class Robot : MonoBehaviour {

	public float movspeed = 100;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){

		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			rigidbody2D.AddForce(-Vector3.right * movspeed);
		}
		else if (Input.GetKeyDown (KeyCode.RightArrow)) {
			rigidbody2D.AddForce(Vector3.right * movspeed);
		}

	}

}
