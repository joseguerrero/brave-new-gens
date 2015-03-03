using UnityEngine;
using System.Collections;

public class EnvaseClass : MonoBehaviour {

	public static void CreateEnvase ()
	{
		Vector3 posicionInicial = new Vector3 (-8.31f, 8.4f, 0);
		Vector3 direccionInicial = new Vector3 (1, 0, 0);
		GameObject ObjEnvase = GameObject.Find("_envase");
		GameObject envaseClone = (GameObject)Object.Instantiate (ObjEnvase, posicionInicial, new Quaternion());
		envaseClone.rigidbody.velocity = direccionInicial * ApplicationModel.speedFlask;
	}
}

