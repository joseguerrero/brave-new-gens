using UnityEngine;
using System.Collections;

public class Needle : MonoBehaviour {
	
	private bool cd;
	public float distance;
	public Collider2D actualCol;
	int layerMask = 1 << 8;
	public Color[] dosis;
	public GameObject marcador;
	public int doseIndex = 2;
	public int maxdoses = 3;
	public int dose_A; // rojo
	public int dose_B; // azul
	public int dose_G; // verde
	public int dose_D; // amarillo
	public int dose_E; // morado

	void Start () {
		SetDose ();
		InvokeRepeating ("RespawnDoses", 1, 30);
	}

	void Update () {
		if (Gamemaster.instance.playerControl){
			if (Input.GetKeyDown (KeyCode.Space) && !cd) {
				switch (doseIndex){
				case 0:
					if (dose_A >= 1){
						dose_A -= 1;
						Inyectar();
					}
					break;
				case 1:
					if (dose_B >= 1){
						dose_B -= 1;
						Inyectar();
					}
					break;
				case 2:
					if (dose_G >= 1){
						dose_G -= 1;
						Inyectar();
					}
					break;
				case 3:
					if (dose_D >= 1){
						dose_D -= 1;
						Inyectar();
					}
					break;
				case 4:
					if (dose_E >= 1){
						dose_E -= 1;
						Inyectar();
					}
					break;
				}
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
			//Debug.DrawLine(transform.position, hit.collider.transform.position, new Color(0, 0, 255), 0.1f);
			Debug.DrawRay(transform.position, hit.collider.transform.position, new Color(0, 0, 255), 0.1f);
			//texto.text = hit.collider.name;
		}
		else {
			actualCol = null;
		}
		Gamemaster.instance.dA.text = "Dosis Alfas: " + dose_A;
		Gamemaster.instance.dB.text = "Dosis Betas: " + dose_B;
		Gamemaster.instance.dG.text = "Dosis Gammas: " + dose_G;
		Gamemaster.instance.dD.text = "Dosis Deltas: " + dose_D;
		Gamemaster.instance.dE.text = "Dosis Epsilons: " + dose_E;
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
		cd = true;
		Gamemaster.instance.playerControl = false;
		yield return new WaitForSeconds (1);
		cd = false;
		Gamemaster.instance.playerControl = true;
	}

	void SetDose(){
		marcador.GetComponent<SpriteRenderer> ().color = dosis [doseIndex];
	}
	
	void RespawnDoses() {
		if (dose_A<maxdoses)
			dose_A += 1;
			
		if (dose_B<maxdoses)
			dose_B += 1;
			
		if (dose_G<maxdoses)
			dose_G += 1;
			
		if (dose_D<maxdoses)
			dose_D += 1;
			
		if (dose_E<maxdoses)
			dose_E += 1;
	}
}
