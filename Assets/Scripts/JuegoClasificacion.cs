using UnityEngine;
using System.Collections;

public class JuegoClasificacion : MonoBehaviour {

	//public GameObject embryo;
	public GameObject flask;
	public GameObject mecharm;
	public float distance = 10.0f;
	public Correa correa;

	// Use this for initialization
	void Start () {
		StartCoroutine (SpawnFlask ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){
		RaycastHit2D hit = Physics2D.Raycast (mecharm.transform.position, -Vector2.up, distance);

		if (hit.collider != null &&  hit.collider.name == "Flask(Clone)" && !correa.busy ) {

			if (!correa.stopped){
				correa.Stop();
				//StartCoroutine(SpawnEmbryo());
			}
		}
	}
	
	IEnumerator SpawnFlask() {
		yield return new WaitForSeconds (2);
		Instantiate(flask, new Vector2(-8.0f, 1.0f), transform.rotation);
		//flask.AddComponent ("Drag");
	}


}
