using UnityEngine;
using System.Collections;

public class BodyCol : MonoBehaviour {

	public bool hit = false;
	public HeadCol head;
	public Animator embAnimator;
	public int n_iny = 1;
	public FlaskColor flask;
	public WanderSteering wanderpath;
	public bool dead = false;
	
	void Start () {
		head = transform.FindChild ("cabeza").GetComponent<HeadCol> ();
		embAnimator = transform.parent.GetComponent<Animator> ();
		flask = transform.parent.transform.parent.FindChild ("Frasco").GetComponent<FlaskColor> ();
		wanderpath = GetComponent<WanderSteering> ();
	}

	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.name == "inyectadora" && !hit && !head.hit) {
			StartCoroutine(BodyHit());
			if (flask.casta == col.GetComponent<Needle>().doseIndex){
				Gamemaster.instance.score += (10.0f * n_iny);
				n_iny += 1;
				Gamemaster.instance.textScore.text = Gamemaster.instance.score.ToString();
			}
			else{
				hit = true;
				wanderpath.wander = false;
				embAnimator.Play ("emb_fail");
				if (Gamemaster.instance.score - 20.0f < 0){
					Gamemaster.instance.score = 0;
				}
				else{
					Gamemaster.instance.score -= 20.0f;
				}
				dead = true;
				GameObject k = (GameObject) Instantiate(Gamemaster.instance.kill);
				k.transform.SetParent(Gamemaster.instance.canvas.transform, false);
				Gamemaster.instance.kills += 1;
				Gamemaster.instance.textScore.text = Gamemaster.instance.score.ToString();
				Gamemaster.instance.textKills.text = "x " + Gamemaster.instance.kills;
			}
		}
	}

	IEnumerator BodyHit() {
		embAnimator.Play ("emb_dosed");
		hit = true;
		yield return new WaitForSeconds (1);
		hit = false;
	}
}
