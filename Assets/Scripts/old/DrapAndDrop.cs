using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]

public class DrapAndDrop : MonoBehaviour
{
	//public Flask correa;
	private Vector2 screenPoint;
	private Vector2 offset;
	
	void OnMouseDown()
	{
		//screenPoint.x = Camera.main.transform.position.x; //WorldToScreenPoint(gameObject.transform.position);
		//screenPoint.z = Camera.main.transform.position.z;
		
		//offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
		//correa = GetComponent<Flask>();

		offset.x = gameObject.transform.position.x - Input.mousePosition.x;
		offset.y = gameObject.transform.position.y - Input.mousePosition.y;
		
	}
	
	void OnMouseDrag()
	{
		Vector2 curScreenPoint = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
		
		//Vector2 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
		Vector2 curPosition = curScreenPoint + offset;
		transform.position = curPosition;
		
	}
	
}
