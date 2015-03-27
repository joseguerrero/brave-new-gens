using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Robot : MonoBehaviour {

	public float movspeed;
	public float edge_left;
	public float edge_right;
	
	void Start () {

	}

	void Update () {
		if (Gamemaster.instance.playerControl){
			if(Input.GetAxis("Horizontal") < 0 ){
				if (transform.position.x > edge_left)
					transform.position = new Vector2(transform.position.x - movspeed, transform.position.y);
			}
			else if (Input.GetAxis("Horizontal") > 0 ) {
				if (transform.position.x < edge_right)
					transform.position = new Vector2(transform.position.x + movspeed, transform.position.y);
			}
		}
	}
}
