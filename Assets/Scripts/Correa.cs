using UnityEngine;
using System.Collections;

public class Correa : MonoBehaviour {

	public float speed = 100.0f;
	public bool stopped = false;
	private float actualSpeed;
	public bool busy = false;

	void Start(){
		actualSpeed = speed;
	}
	
	void OnCollisionStay2D(Collision2D col) {
		col.rigidbody.AddForce (Vector3.right * actualSpeed);
	}

	public void Stop(){
		Debug.Log ("Deteniendo la correa de transmision");
		stopped = true;
		actualSpeed = 0.0f;
	}

	public void Run(){
		Debug.Log ("Reanudando la correa de transmision");
		stopped = false;
		actualSpeed = speed;
	}
}
