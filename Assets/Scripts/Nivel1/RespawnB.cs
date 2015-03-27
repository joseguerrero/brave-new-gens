using UnityEngine;
using System.Collections;

public class RespawnB : MonoBehaviour {

	void RespawnDose() {
		Gamemaster.instance.dose_B += 1;
	}
}
