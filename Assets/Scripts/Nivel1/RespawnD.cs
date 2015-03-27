using UnityEngine;
using System.Collections;

public class RespawnD : MonoBehaviour {

	void RespawnDose() {
		Gamemaster.instance.dose_D += 1;
	}
}
