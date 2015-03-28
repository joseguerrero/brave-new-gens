using UnityEngine;
using System.Collections;

public class BodyCol : MonoBehaviour {

	public bool hit = false;
	public HeadCol head;
	public Animator embAnimator;
	public int n_iny = 1;
	public FlaskColor flask;
	
	void Start () {
		head = transform.FindChild ("cabeza").GetComponent<HeadCol> ();
		embAnimator = transform.parent.GetComponent<Animator> ();
		flask = transform.parent.transform.parent.FindChild ("Frasco").GetComponent<FlaskColor> ();
	}

	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.name == "inyectadora" && !hit && !head.hit) {
			StartCoroutine(BodyHit());
			if (flask.casta == col.GetComponent<Needle>().doseIndex){
				Gamemaster.instance.score += (5.0f * n_iny);
				n_iny += 1;
				Gamemaster.instance.textScore.text = Gamemaster.instance.score.ToString();
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
