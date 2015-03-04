using UnityEngine;
using System.Collections;

public class AgregarDeltas : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider other)
	{
		ApplicationModel.deltas += 1;
		ApplicationModel.puntaje += ApplicationModel.constAgregar;
		
		ApplicationModel.ActualizarContadores ();
	}
}
