using UnityEngine;
using System.Collections;

public class FlaskColor : MonoBehaviour {
	public Color[] castas;
	public Color actualCasta;
	public GameObject liquido;
	public int casta;
	// Use this for initialization
	void Start () {
		casta = Random.Range (0, castas.Length - 1);
		liquido.GetComponent<SpriteRenderer> ().color = castas [casta];
	}

	void Update () {
	
	}
}
