using UnityEngine;
using System.Collections;

public class RespawnA : MonoBehaviour {

	void RespawnDose() {
		Gamemaster.instance.dose_A += 1;
	}
}
