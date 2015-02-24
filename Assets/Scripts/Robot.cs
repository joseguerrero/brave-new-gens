using UnityEngine;
using System.Collections;

public class Robot : MonoBehaviour {

	public float movspeed;
	public float edge_left;
	public float edge_right;
	public float distance;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetAxis("Horizontal") < 0 ){

			if (transform.position.x > edge_left)
				transform.position = new Vector2(transform.position.x - movspeed, transform.position.y);
		}
		else if (Input.GetAxis("Horizontal") > 0 ) {
			if (transform.position.x < edge_right)
				transform.position = new Vector2(transform.position.x + movspeed, transform.position.y);
		}
	}

	void FixedUpdate(){

		RaycastHit2D hit = Physics2D.Raycast (transform.position, -Vector2.up, distance);

		if (hit.collider != null) {
			//Debug.DrawLine(transform.position, hit.collider.transform.position, new Color(0, 0, 255), 0.1f);
			//Debug.DrawRay(transform.position, hit.collider.transform.position, new Color(0, 0, 255), 0.1f);
			//Debug.Log (hit.collider);
		}





		//Debug.DrawLine (transform.position, hit);

	}

}
