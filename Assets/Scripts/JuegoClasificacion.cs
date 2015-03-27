using UnityEngine;
using System.Collections;

public class JuegoClasificacion : MonoBehaviour {
	public float velocidadEmbrion;
	public static Sprite[] letraSprites;
	public static Sprite[] caminandoSprites;
	
	void Awake()
	{
		// load all frames in letrasSprites array
		letraSprites = Resources.LoadAll<Sprite>("letras");
		caminandoSprites = Resources.LoadAll<Sprite> ("caminando2");
	}
	// Use this for initialization
	void Start () {
		ApplicationModel.puntaje = 0;
		ApplicationModel.speedFlask = velocidadEmbrion;
		ApplicationModel.alfas = 0;
		ApplicationModel.constAgregar = 10;
		ApplicationModel.constPerdido = 50;
		ApplicationModel.constReciclar = 1;
		ApplicationModel.constDetenido = 5;

		//ApplicationModel.speedInspector1 = 7;
		//ApplicationModel.speedInspector1 = 5;
		EnvaseClass.CreateEnvase ();
	}
}
