using UnityEngine;
using System.Collections;

public class Aguja : MonoBehaviour {

	public float movspeed = 100;
	public bool reposo = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
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
			Debug.Log("Mataste al embrion");
		}
		else if (col.collider.name == "Cuerpo" && !reposo)
		{
			Debug.Log("Aplicaste la dosis");
		}
	}
}
