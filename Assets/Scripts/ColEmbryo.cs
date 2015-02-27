using UnityEngine;
using System.Collections;

public class ColEmbryo : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col){
		Gamemaster.instance.embHead.collider2D.enabled = false;
		Gamemaster.instance.embBody.collider2D.enabled = false;
		Gamemaster.instance.embHead.GetComponent<SpriteRenderer>().color = new Color (255, 0, 0, 255);
	}

}
