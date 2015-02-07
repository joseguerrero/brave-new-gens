﻿using UnityEngine;
using System.Collections;

public class Embrion : MonoBehaviour {

	// Use this for initialization
	void Start () {
		InvokeRepeating ("SetDir", 1, 1);
	}
	
	// Update is called once per frame
	void Update () {

	}

	void SetDir(){
		rigidbody2D.AddForce(Vector3.up * Random.Range(-1000, 1000));
		rigidbody2D.AddForce(Vector3.right * Random.Range(-1000, 1000));
		transform.Rotate(0, 0, Random.Range(-30, 30));
	}
}
