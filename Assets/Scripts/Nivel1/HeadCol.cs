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
			hit = true;
			wanderpath.wander = false;
			embAnimator.Play ("emb_fail");
			if (Gamemaster.instance.score - 20.0f < 0){
				Gamemaster.instance.score = 0;
			}
			else{
				Gamemaster.instance.score -= 20.0f;
			}
			Gamemaster.instance.kills += 1;
			Gamemaster.instance.textScore.text = "Puntuacion: " + Gamemaster.instance.score;
			Gamemaster.instance.textKills.text = "Muertes: " + Gamemaster.instance.kills;
		}
	}
}
