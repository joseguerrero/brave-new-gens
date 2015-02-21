using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Aguja : MonoBehaviour {

	public float movspeed = 100;
	public bool reposo = false;
	public Text texto;
	public bool cd = false;
	public Correa correa;
	public GameObject embryo;
	public GameObject flask;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space) && reposo && !cd) {
			StartCoroutine(NeedleCD());
			reposo = false;
			rigidbody2D.AddForce(-Vector3.up * movspeed, ForceMode2D.Impulse);
		}
	}

	void FixedUpdate(){

	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.collider.name == "Base")
		{
			Debug.Log("Esta en la base");
			reposo = true;
		}
		else if (col.collider.name == "Cabeza" && !reposo)
		{
			col.collider.GetComponent<Embrion>().alive = false;
			col.collider.GetComponent<SpriteRenderer>().color = new Color (133, 88, 7, 100);
			col.collider.rigidbody2D.gravityScale = 0.1f;
			texto.text = "Mataste al embrion";
			cd = true;
			StartCoroutine("EmbryoKilled", col.collider.gameObject.transform.parent.gameObject);
		}
		else if (col.collider.name == "Cuerpo" && !reposo)
		{
			col.collider.GetComponent<SpriteRenderer>().color = new Color (0, 255, 0, 100);
			cd = true;
			texto.text = "Aplicaste la dosis";
			StartCoroutine(EmbryoLives());
		}
	}

	IEnumerator NeedleCD() {
		cd = true;
		yield return new WaitForSeconds (2);
		cd = false;
	}

	IEnumerator EmbryoKilled(GameObject go) {
		yield return new WaitForSeconds (6);
		correa.Run ();
		yield return new WaitForSeconds (6);
		Destroy (go);
		correa.busy = false;
		Instantiate(flask, new Vector2(-8.0f, 1.0f), transform.rotation);
	}

	IEnumerator EmbryoLives() {
		yield return new WaitForSeconds (6);
		correa.Run ();
		yield return new WaitForSeconds (6);
		correa.busy = false;
		Instantiate(flask, new Vector2(-8.0f, 1.0f), transform.rotation);
	}

}
