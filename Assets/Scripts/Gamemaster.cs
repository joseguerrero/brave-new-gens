using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Gamemaster : MonoBehaviour
{
	private static Gamemaster _instance;
	public bool playerControl = true;
	public bool headHit = false;
	public bool bodyHit = false;
	public Object prefFlask;
	public Object prefEmbryo;
	public GameObject actualEmbryo;
	public GameObject actualFlask;
	public GameObject correa;
	public float sensorDistance;
	public float score;
	public int kills;
	public Text textScore;
	public Text textKills;
	
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
		//StartCoroutine (SpawnFlask ());
	}

	public void SpawnEmbWrap(){
		//StartCoroutine (SpawnEmbryo ());
	}

	IEnumerator SpawnEmbryo() {
		correa.GetComponent<Correa> ().busy = true;
		yield return new WaitForSeconds (2);
		actualEmbryo = (GameObject) Instantiate(prefEmbryo, new Vector2(0.0f, -5.0f), transform.rotation);
		playerControl = true;
	}

	public void SpawnFlaskWrap(){
		//StartCoroutine (SpawnFlask ());
	}

	IEnumerator SpawnFlask() {
		yield return new WaitForSeconds (2);
		actualFlask = (GameObject) Instantiate(prefFlask, new Vector2(-21.0f, 1.0f), transform.rotation);
	}


	IEnumerator EmbryoKilled(GameObject go) {
		yield return new WaitForSeconds (6);
		correa.GetComponent<Correa> ().Run ();
		yield return new WaitForSeconds (6);
		Destroy (go);
		correa.GetComponent<Correa> ().busy = false;
	}
	
	IEnumerator EmbryoLives() {
		yield return new WaitForSeconds (6);
		correa.GetComponent<Correa> ().Run ();
		yield return new WaitForSeconds (6);
		correa.GetComponent<Correa> ().busy = false;
	}



}