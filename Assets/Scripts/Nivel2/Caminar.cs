using UnityEngine;
using System.Collections;

public class Caminar : MonoBehaviour {
	public float speedInspector;
	Vector3 direccionInicial;

	// Use this for initialization
	void Start () {
		direccionInicial = new Vector3 (1, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x <= -13) {
			rigidbody.velocity = direccionInicial * speedInspector;
			gameObject.GetComponent<SpriteRenderer>().sprite = JuegoClasificacion.caminandoSprites[0];//.letraSprites[0];
		}

		if (transform.position.x >= 11) {
			rigidbody.velocity = -direccionInicial * speedInspector;
			gameObject.GetComponent<SpriteRenderer>().sprite = JuegoClasificacion.caminandoSprites[1];
		}

	}
}
