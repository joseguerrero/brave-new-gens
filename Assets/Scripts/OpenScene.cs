using UnityEngine;
using System.Collections;

public class OpenScene : MonoBehaviour {
	public string SceneName;

	public void Open_Scene(){
		Application.LoadLevel (SceneName);
	}
}
