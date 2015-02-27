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
		if (col.name == "Aguja" && !Gamemaster.instance.headHit && !Gamemaster.instance.bodyHit) {
			Gamemaster.instance.headHit = true;
			GameObject head = Gamemaster.instance.actualEmbryo.transform.FindChild ("Cabeza").gameObject;
			head.GetComponent<SpriteRenderer>().color = new Color (255, 0, 0, 255);
		}
	}
}
