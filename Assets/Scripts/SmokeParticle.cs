using UnityEngine;
using System.Collections;

public class SmokeParticle : MonoBehaviour {

	private float lifetimer = 0.0f;

	void Start(){
		particleSystem.renderer.sortingLayerName = "Player";
		particleSystem.renderer.sortingOrder = 2;
	}
	// Update is called once per frame
	void Update () {
		lifetimer += Time.deltaTime;
		if(lifetimer >= 0.5f)
		{
			Destroy(this.gameObject);
		}
	}
}
