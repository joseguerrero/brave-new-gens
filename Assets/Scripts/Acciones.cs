using UnityEngine;
using System.Collections;

public class Acciones : MonoBehaviour {

	Vector3 dist;
	float posX;
	float posY;

	void OnMouseDown(){
		dist = Camera.main.WorldToScreenPoint(transform.position);
		posX = Input.mousePosition.x - dist.x;
		posY = Input.mousePosition.y - dist.y;
		
	}
	
	void OnMouseDrag(){
		Vector3 curPos = 
			new Vector3(Input.mousePosition.x - posX, 
			            Input.mousePosition.y - posY, dist.z);  
		
		Vector3 worldPos = Camera.main.ScreenToWorldPoint(curPos);
		transform.position = worldPos;
	}

	void OnTriggerEnter (Collider other)
	{
		switch (other.gameObject.tag) {
			case "casta":
				Destroy(gameObject);
				EnvaseClass.CreateEnvase ();
				break;

			case "limbo":
				DescontarPuntaje(1);
				break;

			default:
				break;
		}
	}

	void DescontarPuntaje (int puntos)
	{
		ApplicationModel.puntaje -= ApplicationModel.constPerdido;
		Destroy(gameObject);
		ApplicationModel.ActualizarContadores ();
		EnvaseClass.CreateEnvase ();
	}
	
}
