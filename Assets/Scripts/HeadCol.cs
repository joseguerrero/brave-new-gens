using UnityEngine;
using System.Collections;

public class HeadCol : MonoBehaviour {

	public bool hit = false;
	public BodyCol body;
	public Animator embAnimator;
	public WanderSteering wanderpath;

	void Start () {
		body = transform.parent.GetComponent<BodyCol> ();
		embAnimator = transform.parent.transform.parent.GetComponent<Animator> ();
		wanderpath = transform.parent.GetComponent<WanderSteering> ();
	}

	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.name == "inyectadora" && !hit && !body.hit) {
			//GameObject head = Gamemaster.instance.actualEmbryo.transform.FindChild ("Cabeza").gameObject;
			//head.GetComponent<SpriteRenderer>().color = new Color (255, 0, 0, 255);
			hit = true;
			wanderpath.wander = false;
			embAnimator.Play ("death");
			//GameObject body = Gamemaster.instance.actualEmbryo.transform.FindChild ("Tronco").gameObject;
			//body.rigidbody2D.gravityScale = -0.1f;
			//body.GetComponent<WanderSteering>().wander = false;
			//Gamemaster.instance.correa.GetComponent<Correa>().Run();
			//Gamemaster.instance.SpawnFlaskWrap ();
			Gamemaster.instance.score -= 50.0f;
			Gamemaster.instance.kills += 1;
			Gamemaster.instance.textScore.text = "Puntuacion: " + Gamemaster.instance.score;
			Gamemaster.instance.textKills.text = "Muertes: " + Gamemaster.instance.kills;

		}
	}
}
