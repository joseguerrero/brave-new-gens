using UnityEngine;
using System.Collections;

public class BodyCol : MonoBehaviour {

	public bool hit = false;
	public HeadCol head;
	public Animator embAnimator;
	
	void Start () {
		head = transform.FindChild ("cabeza").GetComponent<HeadCol> ();
		embAnimator = transform.parent.GetComponent<Animator> ();
	}

	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.name == "inyectadora" && !hit && !head.hit) {
			Debug.Log("Golpeo cuerpo");
			StartCoroutine(BodyHit());
			//Gamemaster.instance.headHit = true;
			//GameObject head = Gamemaster.instance.actualEmbryo.transform.FindChild ("Tronco").gameObject;
			//head.GetComponent<SpriteRenderer>().color = new Color (0, 255, 0, 255);
			//Gamemaster.instance.correa.GetComponent<Correa>().Run();
			//Gamemaster.instance.SpawnFlaskWrap ();
			Gamemaster.instance.score += 50.0f;
			Gamemaster.instance.textScore.text = "Puntuacion: " + Gamemaster.instance.score;
		}
	}

	IEnumerator BodyHit() {
		embAnimator.Play ("embrion2");
		hit = true;
		yield return new WaitForSeconds (1);
		hit = false;
	}
}
