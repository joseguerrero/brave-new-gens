using UnityEngine;
using System.Collections;

public class HeadCol : MonoBehaviour {

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

			GameObject body = Gamemaster.instance.actualEmbryo.transform.FindChild ("Tronco").gameObject;
			body.rigidbody2D.gravityScale = -0.1f;
			body.GetComponent<WanderSteering>().wander = false;

			Gamemaster.instance.correa.GetComponent<Correa>().Run();

			Gamemaster.instance.score -= 50.0f;
			Gamemaster.instance.kills += 1;
			Gamemaster.instance.textScore.text = "Puntuacion: " + Gamemaster.instance.score;
			Gamemaster.instance.textKills.text = "Muertes: " + Gamemaster.instance.kills;

		}
	}
}
