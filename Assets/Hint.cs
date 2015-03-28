using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Hint : MonoBehaviour {
	public float duration  = 1.5f; // time to die
	public float alpha;
	public float r;
	public float g;
	public float b;
	void Start(){
		alpha = 1.0f;

		switch (Gamemaster.instance.hintColor) {
		
		case "A":
			GetComponent<Text>().text = "No tienes suficientes dosis Alpha";
			r = 255;
			g = 0;
			b = 0;
			break;
		case "B":
			GetComponent<Text>().text = "No tienes suficientes dosis Beta";
			r = 255;
			g = 185;
			b = 0;
			break;
		case "G":
			GetComponent<Text>().text = "No tienes suficientes dosis Gamma";
			r = 0;
			g = 255;
			b = 0;
			break;
		case "D":
			GetComponent<Text>().text = "No tienes suficientes dosis Delta";
			r = 239;
			g = 253;
			b = 0;
			break;
		case "E":
			GetComponent<Text>().text = "No tienes suficientes dosis Epsilon";
			r = 188;
			g = 0;
			b = 255;
			break;
		}
	}
	
	void Update(){
		if (alpha>0){
			transform.position = new Vector3(transform.position.x, 
			                                 transform.position.y - 1,
			                                 transform.position.z);
			alpha -= Time.deltaTime/duration; 
			//GetComponent<Text>().color = new Color(1.0f, 1.0f, 1.0f, alpha);
			GetComponent<Text>().color = new Color(r, g, b, alpha);
		} else {
			Destroy(gameObject);
		}
	}
}
