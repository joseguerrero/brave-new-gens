using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Gamemaster : MonoBehaviour
{
	private static Gamemaster _instance;
	public bool playerControl = true;
	public Object subject;
	public GameObject correa;
	public float sensorDistance;
	public float score;
	public int kills;
	public Text textScore;
	public Text textKills;
	public int dose_A = 1; // rojo
	public int dose_B = 1; // naranja
	public int dose_G = 100; // verde
	public int dose_D = 1; // amarillo
	public int dose_E = 1; // morado
	public GameObject dA;
	public GameObject dB;
	public GameObject dG;
	public GameObject dD;
	public GameObject dE;
	public Object hint;
	public string hintColor;
	public Canvas canvas;
	
	public static Gamemaster instance {
		get {
			if (_instance == null) {
				_instance = GameObject.FindObjectOfType<Gamemaster> ();
				DontDestroyOnLoad (_instance.gameObject);
			}
			return _instance;
		}
	}
	
	void Awake ()
	{
		if (_instance == null) {
			_instance = this;
			DontDestroyOnLoad (this);
		} else {
			if (this != _instance)
				Destroy (this.gameObject);
		}
	}

	void Start () {
		Gamemaster.instance.textScore.text = "Puntuacion: 0";
		Gamemaster.instance.textKills.text = "Muertes: 0";
		SpawnSubject ();
	}

	public void SpawnSubject(){
		Instantiate(subject, new Vector2(-25.0f, -8.0f), transform.rotation);
	}
	
	void Update () {
		if (score >= 100) {
			Application.LoadLevel("victoria_n1");
		}
		if (kills >= 3) {
			Application.LoadLevel("derrota_n1");
		}
	}
}