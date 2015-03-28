using UnityEngine;
using System.Collections;

public class JuegoClasificacion : MonoBehaviour {
	public float velocidadEmbrion;
	public int nivelDerrota;
	public int nivelAparicionInspector2;
	public int nivelAparicionInspector3;
	public int nivelVictoria;
	public static Sprite[] letraSprites;
	public static Sprite[] caminandoSprites;

	GameObject inspector2, inspector3;
	
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

		EnvaseClass.CreateEnvase ();

		inspector2 = GameObject.Find("inspector2");
		inspector2.SetActive(false);

		inspector3 = GameObject.Find ("inspector3");
		inspector3.SetActive (false);
	}

	void Update() {
		if (ApplicationModel.puntaje < nivelDerrota) {
			Application.LoadLevel("derrota_n1");
		}

		if (!inspector2.activeSelf && (ApplicationModel.puntaje>nivelAparicionInspector2)) {
			inspector2.SetActive(true);
		}

		if (!inspector3.activeSelf && (ApplicationModel.puntaje > nivelAparicionInspector3)) {
			inspector3.SetActive(true);
		}

		if (ApplicationModel.puntaje >= nivelVictoria) {
			Application.LoadLevel("victoria_n1");
		}
	}
}
