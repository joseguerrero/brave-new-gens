using UnityEngine;
using System.Collections;

public class JuegoClasificacion : MonoBehaviour {
	public float velocidadEmbrion;
	public static Sprite[] letraSprites;
	
	void Awake()
	{
		// load all frames in letrasSprites array
		letraSprites = Resources.LoadAll<Sprite>("letras");
	}
	// Use this for initialization
	void Start () {
		ApplicationModel.puntaje = 0;
		ApplicationModel.speedFlask = velocidadEmbrion;
		ApplicationModel.alfas = 0;
		ApplicationModel.constAgregar = 10;
		ApplicationModel.constPerdido = 50;
		ApplicationModel.constReciclar = 1;
		EnvaseClass.CreateEnvase ();
	}
}
