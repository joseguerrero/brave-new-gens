using UnityEngine;
using System.Collections;

public class Needle : MonoBehaviour {
	/*
	public float movspeed = 100;
	public bool reposo = false;
	public Text texto;
	public bool cd = false;
	public Correa correa;
	public GameObject embryo;
	public GameObject flask;
	*/
	
	public float distance;
	public Collider2D actualCol;
	int layerMask = 1 << 8;
	public Color[] dosis;
	public GameObject marcador;
	public int doseIndex = 2;
	public int maxdoses = 1;
	
	void Start () {
		SetDose ();
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.Space) &&  Gamemaster.instance.playerControl){
			switch (doseIndex){
			case 0:
				if (Gamemaster.instance.dose_A >= 1){
					Gamemaster.instance.dA.GetComponent<Animator>().enabled = true;
					Gamemaster.instance.dA.GetComponent<Animator>().Play("dA_Spend");
					Gamemaster.instance.dose_A -= 1;
					Inyectar();
				}
				else {
					Gamemaster.instance.hintColor = "A";
					GameObject h = (GameObject) Instantiate(Gamemaster.instance.hint);
					h.transform.SetParent(Gamemaster.instance.canvas.transform, false);
				}
				break;
			case 1:
				if (Gamemaster.instance.dose_B >= 1){
					Gamemaster.instance.dB.GetComponent<Animator>().enabled = true;
					Gamemaster.instance.dB.GetComponent<Animator>().Play("dB_Spend");
					Gamemaster.instance.dose_B -= 1;
					Inyectar();
				}
				else {
					Gamemaster.instance.hintColor = "B";
					GameObject h = (GameObject) Instantiate(Gamemaster.instance.hint);
					h.transform.SetParent(Gamemaster.instance.canvas.transform, false);
				}
				break;
			case 2:
				if (Gamemaster.instance.dose_G >= 1){
					Gamemaster.instance.dG.GetComponent<Animator>().enabled = true;
					Gamemaster.instance.dG.GetComponent<Animator>().Play("dG_Spend");
					Gamemaster.instance.dose_G -= 1;
					Inyectar();
				}
				else {
					Gamemaster.instance.hintColor = "G";
					GameObject h = (GameObject) Instantiate(Gamemaster.instance.hint);
					h.transform.SetParent(Gamemaster.instance.canvas.transform, false);
				}
				break;
			case 3:
				if (Gamemaster.instance.dose_D >= 1){
					Gamemaster.instance.dD.GetComponent<Animator>().enabled = true;
					Gamemaster.instance.dD.GetComponent<Animator>().Play("dD_Spend");
					Gamemaster.instance.dose_D -= 1;
					Inyectar();
				}
				else {
					Gamemaster.instance.hintColor = "D";
					GameObject h = (GameObject) Instantiate(Gamemaster.instance.hint);
					h.transform.SetParent(Gamemaster.instance.canvas.transform, false);

				}
				break;
			case 4:
				if (Gamemaster.instance.dose_E >= 1){
					Gamemaster.instance.dE.GetComponent<Animator>().enabled = true;
					Gamemaster.instance.dE.GetComponent<Animator>().Play("dE_Spend");
					Gamemaster.instance.dose_E -= 1;
					Inyectar();
				}
				else {
					Gamemaster.instance.hintColor = "E";
					GameObject h = (GameObject) Instantiate(Gamemaster.instance.hint);
					h.transform.SetParent(Gamemaster.instance.canvas.transform, false);
				}
				break;
			}
		}
	}

	void Inyectar(){
		StartCoroutine(NeedleCD());
		generateAnim();
		animation.Play("test");
	}

	void FixedUpdate(){
		if (Gamemaster.instance.playerControl) {
			if (Input.GetKeyDown(KeyCode.UpArrow)){
				if (doseIndex >= 1){
					doseIndex -= 1;
					SetDose();
				}
			}
			else if (Input.GetKeyDown(KeyCode.DownArrow)){
				if (doseIndex < dosis.Length-1){
					doseIndex += 1;
					SetDose();
				}
			}
		}
		
		RaycastHit2D hit = Physics2D.Raycast (transform.position, -Vector2.up, distance, layerMask);
		
		if (hit.collider != null) {
			actualCol = hit.collider;
			Debug.DrawRay(transform.position, hit.collider.transform.position, new Color(0, 0, 255), 0.1f);
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
			curve.AddKey(0.5f, -18.0f);
			AnimationClip clip = new AnimationClip();
			clip.SetCurve("", typeof(Transform), "localPosition.y", curve);
			animation.AddClip(clip, "test");
		}
	}
	
	IEnumerator NeedleCD() {
		Gamemaster.instance.playerControl = false;
		yield return new WaitForSeconds (1);
		Gamemaster.instance.playerControl = true;
	}

	void SetDose(){
		marcador.GetComponent<SpriteRenderer> ().color = dosis [doseIndex];
	}

	/*
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space) && reposo && !cd) {
			StartCoroutine(NeedleCD());
			reposo = false;
			rigidbody2D.AddForce(-Vector3.up * movspeed, ForceMode2D.Impulse);
		}
	}

	void FixedUpdate(){

	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.collider.name == "Base")
		{
			Debug.Log("Esta en la base");
			reposo = true;
		}
		else if (col.collider.name == "Cabeza" && !reposo)
		{
			col.collider.GetComponent<Embrion>().alive = false;
			col.collider.GetComponent<SpriteRenderer>().color = new Color (133, 88, 7, 100);
			col.collider.rigidbody2D.gravityScale = 0.1f;
			texto.text = "Mataste al embrion";
			cd = true;
			StartCoroutine("EmbryoKilled", col.collider.gameObject.transform.parent.gameObject);
		}
		else if (col.collider.name == "Cuerpo" && !reposo)
		{
			col.collider.GetComponent<SpriteRenderer>().color = new Color (0, 255, 0, 100);
			cd = true;
			texto.text = "Aplicaste la dosis";
			StartCoroutine(EmbryoLives());
		}
	}

	IEnumerator NeedleCD() {
		cd = true;
		yield return new WaitForSeconds (2);
		cd = false;
	}

	IEnumerator EmbryoKilled(GameObject go) {
		yield return new WaitForSeconds (6);
		correa.Run ();
		yield return new WaitForSeconds (6);
		Destroy (go);
		correa.busy = false;
		Instantiate(flask, new Vector2(-8.0f, 1.0f), transform.rotation);
	}

	IEnumerator EmbryoLives() {
		yield return new WaitForSeconds (6);
		correa.Run ();
		yield return new WaitForSeconds (6);
		correa.busy = false;
		Instantiate(flask, new Vector2(-8.0f, 1.0f), transform.rotation);
	}

	*/
}