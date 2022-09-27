using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guncon : MonoBehaviour
{
	Vector2 gpos;
	Vector2 mpos;
	Vector2 dir;
	float gunangle;
	public GameObject holder;
	shootercon shooterscript;
	[SerializeField]
	GameObject bullet;
	[SerializeField]
	int bullet_speed;
	GameObject instance;
	GameObject shootanime;
	Animator shootblast;
	[SerializeField]
	GameObject bulcount;
	[SerializeField]
	int maxbullets;
	int curbullets;
	int mag;
	bool reloading=false;
	float rtime=4f;
	AudioSource shootsound;

	void Start()
	{
		shootsound=GetComponent<AudioSource>();
	}

    void Update()
    {
    	gpos=transform.position;
    	mpos=Camera.main.ScreenToWorldPoint(Input.mousePosition);
    	if(Input.GetMouseButtonDown(0))
    	{
			if(Time.timeScale==1)
			{
	    		fire();
			}
    	}
    	if(Input.GetKey(KeyCode.R)&&mag>0)
		{
			reloading=true;
		}
    }
    
    void FixedUpdate()
    {
    	dir=gpos-mpos;
    	gunangle=Mathf.Atan2(dir.y,dir.x)*Mathf.Rad2Deg-180;
    	transform.rotation=Quaternion.AngleAxis(gunangle,new Vector3(0,0,1));
    	shooterscript=holder.GetComponent<shootercon>();
    	if(gunangle<-90 && gunangle>-260)
    	{
    		shooterscript.face(180);
    	}
    	else
    	{
    		shooterscript.face(0);
    	}
    	shootanime=transform.GetChild(0).gameObject;
    	shootblast=shootanime.GetComponent<Animator>();
    	shootblast.SetBool("shoot",false);
		if(reloading)
		{
			rtime-=Time.deltaTime;
			if(rtime<0)
			{
				rtime=4f;
				reloading=false;
				reload();
			}
			else
			{
				bulcount.GetComponent<TMPro.TextMeshProUGUI>().text="Reloading...";
			}
		}
    }

	public void wavechange()
	{
		maxbullets=80;
		curbullets=40;
		mag=maxbullets-curbullets;
		bulcount.GetComponent<TMPro.TextMeshProUGUI>().text=""+curbullets+"/"+mag;
	}
    
    void fire()
    {
		if(maxbullets>0&&!reloading)
		{
			curbullets-=1;
			maxbullets-=1;
    		Rigidbody2D brb;
    		instance=Instantiate(bullet,transform.position,transform.rotation);
    		brb=instance.GetComponent<Rigidbody2D>();
    		brb.AddForce(-dir.normalized*bullet_speed);
			if(curbullets==0&&mag>0)
			{
				reloading=true;
			}
    		bulcount.GetComponent<TMPro.TextMeshProUGUI>().text=""+curbullets+"/"+mag;
    		shootblast.SetBool("shoot",true);
			shootsound.Play();
		}
    }

	void reload()
	{
		reloadwait();
		if(!reloading)
		{
			if(curbullets>0)
			{
				if(curbullets+mag<=40)
				{
					curbullets+=mag;
					mag=0;
				}
				else
				{
					int n=40-curbullets;
					mag-=n;
					curbullets=40;
				}
			}
			else
			{
				if(mag<40)
				{
					curbullets=mag;
					mag=0;
				}
				else
				{
				mag-=40;
				curbullets=40;
				}
			}
			bulcount.GetComponent<TMPro.TextMeshProUGUI>().text=""+curbullets+"/"+mag;
		}
	}

	void reloadwait()
	{
		
	}
}
