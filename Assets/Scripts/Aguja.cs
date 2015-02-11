using UnityEngine;
using System.Collections;

public class Aguja : MonoBehaviour {

	public float movspeed = 100;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){
		
		if (Input.GetKeyDown (KeyCode.Space)) {

			Debug.Log(-Vector3.up * movspeed);

			rigidbody2D.AddForce(-Vector3.up * movspeed, ForceMode2D.Impulse);
		}
	}
}
