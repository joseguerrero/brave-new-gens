using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Robot : MonoBehaviour {

	public float movspeed;
	public float edge_left;
	public float edge_right;
	public Color[] dosis;
	public Color actualDose;
	public GameObject marcador;
	public int doseIndex = 2;
	public int maxdoses = 3;
	
	void Start () {
		SetDose ();
	}

	void Update () {
		if (Gamemaster.instance.playerControl){
			if(Input.GetAxis("Horizontal") < 0 ){
				if (transform.position.x > edge_left)
					transform.position = new Vector2(transform.position.x - movspeed, transform.position.y);
			}
			else if (Input.GetAxis("Horizontal") > 0 ) {
				if (transform.position.x < edge_right)
					transform.position = new Vector2(transform.position.x + movspeed, transform.position.y);
			}
		}
	}

	void FixedUpdate(){
		if (Gamemaster.instance.playerControl) {
			if (Input.GetKeyDown(KeyCode.UpArrow)){
				if (doseIndex >= 1){
					doseIndex -= 1;
					SetDose();
				}
			}
			else if (Input.GetKeyDown(KeyCode.DownArrow)){
				if (doseIndex < dosis.Length-1){
					doseIndex += 1;
					SetDose();
				}
			}
		}
	}

	void SetDose(){
		marcador.GetComponent<SpriteRenderer> ().color = dosis [doseIndex];
	}
	
	IEnumerator RespawnDoses() {
		yield return new WaitForSeconds (2);
		//actualFlask = (GameObject) Instantiate(prefFlask, new Vector2(-21.0f, 1.0f), transform.rotation);
	}


}
