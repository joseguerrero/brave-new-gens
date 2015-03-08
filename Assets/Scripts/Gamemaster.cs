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
	public Text dA;
	public Text dB;
	public Text dG;
	public Text dD;
	public Text dE;
	
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