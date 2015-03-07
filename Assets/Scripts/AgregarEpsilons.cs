using UnityEngine;
using System.Collections;

public class AgregarEpsilons : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider other)
	{
		ApplicationModel.epsilons += 1;
		ApplicationModel.puntaje += ApplicationModel.constAgregar;
		
		ApplicationModel.ActualizarContadores ();
	}
}
