using UnityEngine;
using System.Collections;

public class FlaskColor : MonoBehaviour {
	public Color[] castas;
	public GameObject liquido;
	public int casta;

	void Start () {
		casta = Random.Range (0, castas.Length);
		liquido.GetComponent<SpriteRenderer> ().color = castas [casta];
	}

	void Update () {
	
	}
}
