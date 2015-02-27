using UnityEngine;
using System.Collections;

public class Gamemaster : MonoBehaviour
{
	private static Gamemaster _instance;
	public bool playerControl = true;
	public bool headHit = false;
	public bool bodyHit = false;
	public Object prefFlask;
	public Object prefEmbryo;
	public GameObject embBody;
	public GameObject embHead;
	public GameObject actualEmbryo;
	public GameObject actualFlask;
	public GameObject correa;
	
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
		StartCoroutine (SpawnFlask ());
	}

	IEnumerator SpawnFlask() {
		yield return new WaitForSeconds (2);
		//GameObject tmp = (GameObject) Instantiate(player_robot, pos, rot);
		actualEmbryo = (GameObject) Instantiate(prefFlask, new Vector2(-21.0f, 1.0f), transform.rotation);
	}

	public void SpawnEmbWrap(){
		StartCoroutine (SpawnEmbryo ());
	}

	IEnumerator SpawnEmbryo() {
		correa.GetComponent<Correa> ().busy = true;
		yield return new WaitForSeconds (2);
		actualEmbryo = (GameObject) Instantiate(prefEmbryo, new Vector2(0.0f, -5.0f), transform.rotation);
		playerControl = true;
	}


}