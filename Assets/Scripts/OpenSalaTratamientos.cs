using UnityEngine;
using System.Collections;

public class OpenSalaTratamientos : MonoBehaviour {
	private bool loadLock;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0) && !loadLock) {
				Application.LoadLevel ("mov-aguja");
				loadLock=false;
				}

	}
}
