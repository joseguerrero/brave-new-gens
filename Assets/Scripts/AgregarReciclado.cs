using UnityEngine;
using System.Collections;

public class AgregarReciclado : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnTriggerEnter (Collider other)
	{
		ApplicationModel.reciclados += 1;
		ApplicationModel.puntaje += ApplicationModel.constReciclar;	
		ApplicationModel.ActualizarContadores ();
	}
}

