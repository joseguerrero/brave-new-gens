using UnityEngine;
using System.Collections;

public class OpenScene : MonoBehaviour {
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	public void Open (string SceneName) {
		Application.LoadLevel (SceneName);
	}
}
