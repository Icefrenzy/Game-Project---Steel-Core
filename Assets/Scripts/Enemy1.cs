using UnityEngine;
using System.Collections;

public class Enemy1 : MonoBehaviour {

	public GameObject player, bullet, shootpoint;

	Transform turret;

	private bool canShoot = false;

	private float lifeTime = 6.0f;
	private float bulletTimer;
	private float bulletLife = 1.0f;

	private int health = 100;

	// Use this for initialization
	void Start () {
		turret = gameObject.transform.FindChild("Turret");
	}
	
	// Update is called once per frame
	void Update () {
		bulletTimer += Time.deltaTime;
		if (health <= 0){
			Destroy(gameObject);
		}
		moveToPoint();
	}

	void FixedUpdate(){
		TurretMove();
		ShootBullet();

	}

	void ShootBullet(){
		if (bulletTimer >= bulletLife && canShoot == true){
			Instantiate(bullet, turret.position, turret.rotation);
			bulletTimer = 0.0f;
		}
	}



	void OnTriggerEnter2D(Collider2D collision){
		if (collision.gameObject.tag == "Bullet"){
			print ("sdfsf");
			health -= 5;
		}

	}

	void TurretMove(){
		Vector3 playerPos = player.transform.position;
		turret.transform.rotation = Quaternion.LookRotation (Vector3.forward, 
			playerPos - turret.transform.position);
	}

	void moveToPoint(){

		if (transform.position.y > 2.5f){
			transform.position -= new Vector3(0.0f, Time.deltaTime * 0.7f, 0.0f);
		}
		else {
			canShoot = true;
		}
	}
}
