using UnityEngine;
using System.Collections;

public class SceneScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StartGame(){
		Application.LoadLevel("Stage1");
	}

	public void MainMenu(){
		Application.LoadLevel("MainMenu");
	}
}
