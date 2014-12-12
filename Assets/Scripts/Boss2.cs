using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Boss2 : MonoBehaviour {

	public GameObject player, bullet;

	public Text bossText;
	public Slider bossHealth;

	Transform turret1, turret2;
	
	private bool canShoot = false;
	
	//private float lifeTime = 6.0f;
	private float bulletTimer;
	private float bulletLife = 1.0f;
	
	private int health = 800;
	
	// Use this for initialization
	void Start () {
		bossText.enabled = false;
		bossHealth.enabled = false;
		turret1 = gameObject.transform.FindChild("Turret1");
		turret2 = gameObject.transform.FindChild("Turret2");
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
			Instantiate(bullet, turret1.position, turret1.rotation);
			Instantiate(bullet, turret2.position, turret2.rotation);
			bulletTimer = 0.0f;
		}
	}
	
	void OnTriggerEnter2D(Collider2D collision){
		if (collision.gameObject.tag == "Bullet"){
			print ("sdfsf");
			health -= 5;
			bossHealth.value -= 0.00625f;
		}
		
	}
	
	void TurretMove(){
		Vector3 playerPos = player.transform.position;
		turret1.transform.rotation = Quaternion.LookRotation (Vector3.forward, 
		                                                    playerPos - turret1.transform.position);
		turret2.transform.rotation = Quaternion.LookRotation (Vector3.forward, 
		                                                    playerPos - turret2.transform.position);
	}
	
	void moveToPoint(){
		if (transform.position.y > 3.5f){
			transform.position -= new Vector3(0.0f, Time.deltaTime * 0.3f, 0.0f);
		}
		else {
			canShoot = true;
			bossText.enabled = true;
			bossHealth.enabled = true;
		}
	}
}
