﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AgregarDeltas : MonoBehaviour {
	//Text txtFortaleza;
	//Text txtResiliencia;
	
	// Use this for initialization
	void Start () {
		//txtFortaleza = GameObject.Find ("txtFortaleza").GetComponent<UnityEngine.UI.Text>();
		//txtResiliencia = GameObject.Find ("txtResiliencia").GetComponent<UnityEngine.UI.Text>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter (Collider other)
	{
		if (other.GetComponent<Atributos>().casta == (int)ApplicationModel.Casta.delta) {
			ApplicationModel.deltas += 1;
			ApplicationModel.puntaje += ApplicationModel.constAgregar;
		
			ApplicationModel.ActualizarContadores ();
		}
	}
}