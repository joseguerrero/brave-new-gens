using UnityEngine;
using System.Collections;

public class JuegoClasificacion : MonoBehaviour {

	// Use this for initialization
	void Start () {
		ApplicationModel.puntaje = 0;
		ApplicationModel.speedFlask = 2;
		ApplicationModel.alfas = 0;
		ApplicationModel.constAgregar = 10;
		ApplicationModel.constPerdido = 50;
		EnvaseClass.CreateEnvase ();
	}
}
