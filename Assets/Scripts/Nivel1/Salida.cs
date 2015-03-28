using UnityEngine;
using System.Collections;

public class Salida : MonoBehaviour {
	
	void Start () {
	
	}

	void Update () {
	
	}
	
	void OnTriggerEnter2D(Collider2D col){
		//Debug.Log ("Muerte, destruccion, cumbia!");
		if (col.name == "Frasco") {
			if (col.transform.parent.FindChild("Emb").transform.FindChild("cuerpo").transform.GetComponent<BodyCol>().n_iny == 1){
				if (Gamemaster.instance.score - 5.0f < 0){
					Gamemaster.instance.score = 0;
				}
				else{
					Gamemaster.instance.score -= 5.0f;
				}
				GameObject s = (GameObject) Instantiate(Gamemaster.instance.skip);
				s.transform.SetParent(Gamemaster.instance.canvas.transform, false);
				Gamemaster.instance.textScore.text = Gamemaster.instance.score.ToString();
			}

			Destroy(col.transform.parent.gameObject);
		}
	}

}
