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

			if (transform.position.x > 0.35f)
				transform.position = new Vector2(transform.position.x - movspeed, transform.position.y);
		}
		else if (Input.GetAxis("Horizontal") > 0 ) {
			if (transform.position.x < 0.85f)
				transform.position = new Vector2(transform.position.x + movspeed, transform.position.y);
		}
	}

	void FixedUpdate(){

	}

}
