using UnityEngine;
using System.Collections;

public class Gamemaster : MonoBehaviour
{
	private static Gamemaster _instance;
	public bool headHit = false;
	public bool bodyHit = false;
	public GameObject embBody;
	public GameObject embHead;
	public bool playerControl = true;
	
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
}