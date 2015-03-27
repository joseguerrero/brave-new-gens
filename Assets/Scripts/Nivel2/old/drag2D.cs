using UnityEngine;
using System.Collections;

public class drag2D : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDrag()
	{
		Vector3 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		point.x = gameObject.transform.position.x;
		point.y = gameObject.transform.position.y;
		point.z = gameObject.transform.position.z;
		gameObject.transform.position = point;
	}
}
