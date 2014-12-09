using UnityEngine;
using System.Collections;

public class EnemyBullet : MonoBehaviour {

	public float speed = 1f;
	public float lifetime = 5.0f;
	public int damage = 10;

	
	private float lifetimer = 0.0f;
	private Vector3 location;
	
	// Use this for initialization
	void Start () {
		rigidbody2D.AddForce (transform.up * speed);
		location = transform.position;
		location.z = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		rigidbody2D.AddForce (transform.up * speed);
		lifetimer += Time.deltaTime;
		
		
		if(lifetimer >= lifetime)
		{
			Destroy (this.gameObject);
		}
	}
	
	void OnTriggerEnter2D(Collider2D collision){
		
		if (collision.gameObject.tag == "Player"){
			Destroy(gameObject);
		}
	}
	
	void OnCollisionEnter2D(Collision2D collision)
	{
		//Destroy(gameObject);
	}
}
