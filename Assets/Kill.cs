﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Kill : MonoBehaviour {
	public float duration  = 1.5f; // time to die
	public float alpha;
	public float r = 255;
	public float g = 0;
	public float b = 0;
	void Start(){
		alpha = 1.0f;
		GetComponent<Text>().text = "¡Cuidado! ¡Has asesinado un embrion!";
	}
	
	void Update(){
		if (alpha>0){
			transform.position = new Vector3(transform.position.x, 
			                                 transform.position.y - 1,
			                                 transform.position.z);
			alpha -= Time.deltaTime/duration; 
			GetComponent<Text>().color = new Color(r, g, b, alpha);
		} else {
			Destroy(gameObject);
		}
	}
}