using UnityEngine;
using System.Collections;

public class Needle : MonoBehaviour {
	
	private bool cd;
	public float distance;
	public Collider2D actualCol;
	int layerMask = 1 << 8;

	void Start () {

	}

	void Update () {
		if (Gamemaster.instance.playerControl){
			if (Input.GetKeyDown (KeyCode.Space) && !cd) {
				StartCoroutine(NeedleCD());
				generateAnim();
				animation.Play("test");
			}
		}
	}

	void FixedUpdate(){
		
		RaycastHit2D hit = Physics2D.Raycast (transform.position, -Vector2.up, distance, layerMask);
		
		if (hit.collider != null) {
			actualCol = hit.collider;
			//Debug.DrawLine(transform.position, hit.collider.transform.position, new Color(0, 0, 255), 0.1f);
			Debug.DrawRay(transform.position, hit.collider.transform.position, new Color(0, 0, 255), 0.1f);
			//texto.text = hit.collider.name;
		}
		else {
			actualCol = null;
		}
	}

	void generateAnim(){
		if (actualCol != null){
			AnimationCurve curve = AnimationCurve.Linear(0, -5, 1, -5);
			curve.AddKey(0.5f, actualCol.transform.position.y - 6.0f);
			AnimationClip clip = new AnimationClip();
			clip.SetCurve("", typeof(Transform), "localPosition.y", curve);
			animation.AddClip(clip, "test");
		}
		else {
			AnimationCurve curve = AnimationCurve.Linear(0, -5, 1, -5);
			curve.AddKey(0.5f, -12.0f);
			AnimationClip clip = new AnimationClip();
			clip.SetCurve("", typeof(Transform), "localPosition.y", curve);
			animation.AddClip(clip, "test");
		}
	}
	
	IEnumerator NeedleCD() {
		cd = true;
		Gamemaster.instance.playerControl = false;
		yield return new WaitForSeconds (1);
		cd = false;
		Gamemaster.instance.playerControl = true;
	}
}
