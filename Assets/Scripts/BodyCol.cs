using UnityEngine;
using System.Collections;

public class BodyCol : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.name == "Aguja" && !Gamemaster.instance.headHit && !Gamemaster.instance.bodyHit) {
			Gamemaster.instance.headHit = true;
			GameObject head = Gamemaster.instance.actualEmbryo.transform.FindChild ("Tronco").gameObject;
			head.GetComponent<SpriteRenderer>().color = new Color (0, 255, 0, 255);
			Gamemaster.instance.correa.GetComponent<Correa>().Run();
			Gamemaster.instance.score += 50.0f;
			Gamemaster.instance.textScore.text = "Puntuacion: " + Gamemaster.instance.score;
		}
	}
}
