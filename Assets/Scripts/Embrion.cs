using UnityEngine;
using System.Collections;

public class Embrion : MonoBehaviour {

	public bool alive = true;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("SetDir", 1, 1);
	}
	
	// Update is called once per frame
	void Update () {

	}

	void SetDir(){
		if (alive) {
			rigidbody2D.AddForce(Vector3.up * Random.Range(-200, 200));
			rigidbody2D.AddForce(Vector3.right * Random.Range(-200, 200));
			//transform.Rotate(0, 0, Random.Range(-45, 45));
		}
	}
}
