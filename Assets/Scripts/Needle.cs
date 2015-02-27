using UnityEngine;
using System.Collections;

public class Needle : MonoBehaviour {
	
	private bool cd;
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space) && !cd) {
			StartCoroutine(NeedleCD());
			generateAnim();
			animation.Play("test");
		}
	}

	void generateAnim(){
		if (transform.parent.GetComponent<Robot>().actualCol != null){
			AnimationCurve curve = AnimationCurve.Linear(0, 0, 1, 0);
			curve.AddKey(0.5f, transform.parent.GetComponent<Robot>().actualCol.transform.position.y);
			AnimationClip clip = new AnimationClip();
			clip.SetCurve("", typeof(Transform), "localPosition.y", curve);
			animation.AddClip(clip, "test");
		}
		else {
			AnimationCurve curve = AnimationCurve.Linear(0, 0, 1, 0);
			curve.AddKey(0.5f, -3.0f);
			AnimationClip clip = new AnimationClip();
			clip.SetCurve("", typeof(Transform), "localPosition.y", curve);
			animation.AddClip(clip, "test");
		}
	}
	
	IEnumerator NeedleCD() {
		cd = true;
		Gamemaster.instance.playerControl = false;
		yield return new WaitForSeconds (2);
		cd = false;
		Gamemaster.instance.playerControl = true;
	}
}
