using UnityEngine;
using System.Collections;

public class Boss1 : MonoBehaviour {
	public GameObject player, bullet;
	
	Transform joint, turret, aperture;
	
	private bool canShoot = false;
	
	//private float lifeTime = 6.0f;
	private float bulletTimer;
	private float bulletLife = 1.0f;
	
	private int health = 500;
	
	// Use this for initialization
	void Start () {
		joint = gameObject.transform.FindChild("Turret Joint");
		turret = joint.FindChild("Boss Turret");
		aperture = turret.FindChild("Aperture");
	}
	
	// Update is called once per frame
	void Update () {
		bulletTimer += Time.deltaTime;
		if (health <= 0){
			Destroy(gameObject);
			Application.LoadLevel("Stage2");
		}
		moveToPoint();
	}
	
	void FixedUpdate(){
		TurretMove();
		ShootBullet();
		
	}
	
	void ShootBullet(){
		if (bulletTimer >= bulletLife){
			Instantiate(bullet, aperture.position, joint.rotation);
			bulletTimer = 0.0f;
		}
	}
	
	void OnTriggerEnter2D(Collider2D collision){
		if (collision.gameObject.tag == "Bullet"){
			print ("sdfsf");
			health -= 10;
		}
		
	}
	
	void TurretMove(){
		Vector3 playerPos = player.transform.position;
		joint.transform.rotation = Quaternion.LookRotation (Vector3.forward, 
		                                                     playerPos - joint.transform.position);
	}
	
	void moveToPoint(){
		if (transform.position.x < 0.0f){
			transform.position += new Vector3(Time.deltaTime * 0.7f,  0.0f, 0.0f);
		}
		else {
			canShoot = true;
		}

	}
}
