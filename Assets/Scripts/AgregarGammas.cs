using UnityEngine;
using System.Collections;

public class AgregarGammas : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider other)
	{
		ApplicationModel.gammas += 1;
		ApplicationModel.puntaje += ApplicationModel.constAgregar;
		
		ApplicationModel.ActualizarContadores ();
	}
}
