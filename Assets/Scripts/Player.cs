using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float verticalspeed = 0.0f;
	public float horizontalspeed = 0.0f;

	public bool ismovingvertical = false;
	public bool ismovinghorizontal = false;

	public float health = 100.0f;
	public float speed = 0.01f;
	public float rotationspeed = 1.0f;

	public float maxverticalspeed = 5.0f;
	public float maxhorizontalspeed = 4.0f;
	public float maxshottimer = 5.0f;
	
	public GameObject bullet;

	private Transform turret1;
	private Transform turret2;

	private float shottimer = 0.0f;

	// Use this for initialization
	void Start () {
		turret1 = gameObject.transform.Find ("Turret1");
		turret2 = gameObject.transform.Find ("Turret2");
	}
	
	// Update is called once per frame
	void Update () {
		shottimer += Time.deltaTime;
		if(Input.GetMouseButton(0))
		{
			shootBullet();
		}

		if (health <= 0){
			Destroy(gameObject);
			Application.LoadLevel("GameOver");
		}
	}

	void FixedUpdate()
	{
		Movement ();
		Turret ();
	}

	void shootBullet()
	{
		if(shottimer >= maxshottimer)
		{
			Instantiate(bullet, new Vector3(turret1.position.x,turret1.position.y,turret1.position.z),turret1.rotation);
			Instantiate(bullet, new Vector3(turret2.position.x,turret2.position.y,turret2.position.z),turret2.rotation);
			shottimer = 0.0f;
		}
	}

	void OnTriggerEnter2D(Collider2D collision){

		print (collision.gameObject.tag);
		if (collision.gameObject.tag == "Enemybullet"){
			print ("U WOT?");
			health -= 10;
		}
	}

	void Movement()
	{
		if(Input.GetKey(KeyCode.W))
		{
			ismovingvertical = true;
			if(verticalspeed <= maxverticalspeed)
			{
				verticalspeed += speed;
			}else 
			{
				verticalspeed = maxverticalspeed;
			}
		}else if(Input.GetKey(KeyCode.S))
		{
			ismovingvertical = true;
			if(verticalspeed >= maxverticalspeed * -1)
			{
				verticalspeed -= speed;
			}else 
			{
				verticalspeed = maxverticalspeed*-1;
			}
		}else
		{
			ismovingvertical = false;
			if(verticalspeed > 0.0f)
			{
				verticalspeed -= speed / 2;
			}else if (verticalspeed < 0.0f)
			{
				verticalspeed += speed / 2;
			}
		}
		
		if(Input.GetKey(KeyCode.D))
		{
			ismovinghorizontal = true;
			if(horizontalspeed <= maxhorizontalspeed)
			{
				horizontalspeed += speed;
			}else 
			{
				horizontalspeed = maxhorizontalspeed;
			}
		}else if(Input.GetKey(KeyCode.A))
		{
			ismovinghorizontal = true;
			if(horizontalspeed >= maxhorizontalspeed*-1)
			{
				horizontalspeed -= speed;
			}else 
			{
				horizontalspeed = maxhorizontalspeed*-1;
			}
		}else
		{
			ismovinghorizontal = false;
			if(horizontalspeed > 0.0f)
			{
				horizontalspeed -= speed / 2;
			}else if (horizontalspeed < 0.0f)
			{
				horizontalspeed += speed / 2;
			}
		}
		transform.position += new Vector3 (horizontalspeed * Time.deltaTime, verticalspeed * Time.deltaTime, 0.0f);
	}

	void Turret()
	{
		Vector3 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		turret1.transform.rotation = Quaternion.LookRotation (Vector3.forward, mousePos - turret1.transform.position);
		turret2.transform.rotation = Quaternion.LookRotation (Vector3.forward, mousePos - turret2.transform.position);

	}
}
