using UnityEngine;
using System.Collections;

public class RespawnE : MonoBehaviour {

	void RespawnDose() {
		Gamemaster.instance.dose_E += 1;
	}
}
