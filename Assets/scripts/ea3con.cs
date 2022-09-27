using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ea3con : MonoBehaviour
{
	[SerializeField]
	Transform robot;
	shootercon shooter;
	[SerializeField]
	float health=5f;
	Vector2 shooterdir;
	[SerializeField]
	float ea3speed;
	Vector3 pos;
	GameObject shooterguy;
	shootercon shooterscript;
	Rigidbody2D rbea;
	Animator destani;
	
	void Start()
	{
		robot=GameObject.Find("Robot_rwg").transform;
		rbea=GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate()
	{
		shooterdir=-(transform.position-robot.position).normalized;
		rbea.MovePosition(Vector2.MoveTowards(transform.position,robot.position,ea3speed*Time.deltaTime));
		transform.right=transform.position-robot.position;
	}
	
	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.name=="Robot_rwg")
		{
			shooter=other.gameObject.GetComponent<shootercon>();
			shooter.takeDamage(2.5f);
			shooterguy=GameObject.Find("Robot_rwg");
    		shooterscript=shooterguy.GetComponent<shootercon>();
    		shooterscript.nowenimy-=1;
			Destroy(gameObject);
		}
	}
	public void takebullet(float bullet)
	{
		health-=bullet;
		if(health<=0)
		{
			shooterguy=GameObject.Find("Robot_rwg");
    		shooterscript=shooterguy.GetComponent<shootercon>();
			shooterscript.kills+=1;
			destani=GetComponent<Animator>();
			destani.SetBool("destroy",true);
			Destroy(gameObject);
			shooterscript.nowenimy-=1;
		}
	}
}
