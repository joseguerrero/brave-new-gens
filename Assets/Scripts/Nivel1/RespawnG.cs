using UnityEngine;
using System.Collections;

public class RespawnG : MonoBehaviour {

	void RespawnDose() {
		Gamemaster.instance.dose_G += 1;
	}
}
