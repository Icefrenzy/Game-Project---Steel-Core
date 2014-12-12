using UnityEngine;
using System.Collections;

public class Boss1 : MonoBehaviour {
	public GameObject player, bullet;
	
	Transform turret, aperture;
	
	private bool canShoot = false;
	
	//private float lifeTime = 6.0f;
	private float bulletTimer;
	private float bulletLife = 1.0f;
	
	private int health = 800;
	
	// Use this for initialization
	void Start () {
		turret = gameObject.transform.FindChild("Boss Turret");
		aperture = turret.gameObject.transform.FindChild("Aperture");
	}
	
	// Update is called once per frame
	void Update () {
		bulletTimer += Time.deltaTime;
		if (health <= 0){
			Destroy(gameObject);
		}
		//moveToPoint();
	}
	
	void FixedUpdate(){
		TurretMove();
		ShootBullet();
		
	}
	
	void ShootBullet(){
		if (bulletTimer >= bulletLife && canShoot == true){
			Instantiate(bullet, aperture.position, turret.rotation);
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
		
		/*if (Vector2.Distance(transform.position, shootpoint.transform.position) > 0.1f){
			Vector3 distance = transform.position - shootpoint.transform.position;
			distance.Normalize();
			
			transform.Translate(
				(distance.x * 1.0f * Time.deltaTime),
				(distance.y * 1.0f * Time.deltaTime),
				0, Space.World);
		}*/
		//transform.position = Vector3.Lerp(transform.position, shootpoint.transform.position, 2.0f);
		//gameObject.transform.rotation = Quaternion.LookRotation (shootpoint.transform.position);
		//gameObject.transform.Translate(Vector3.forward* 1.0f * Time.deltaTime);
	}
}
