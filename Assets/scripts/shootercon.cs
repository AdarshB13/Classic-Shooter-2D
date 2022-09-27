using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine.UI;
using UnityEngine;

public class shootercon : MonoBehaviour
{
	[SerializeField]
	float health=20f;
    Rigidbody2D robotrigid;
	Vector2 nint,rmp,dir;
	float gunangle;
	[SerializeField]
	Image healthrect;
    [SerializeField]
	int enimyno;
	public int nowenimy;
    int requirkills;
    public int kills;
	[SerializeField]
	GameObject ea3;
    Vector2[] enimyspawn=new Vector2[]{new Vector2(13,3),new Vector2(-6,3)};
    [SerializeField]
    GameObject wavetext;
    public int n;
    [SerializeField]
    GameObject Gun;
    guncon gunconscript;
    [SerializeField]
    GameObject pausecanvas;
    pausecon pauseconscript;
    AudioSource bgmusic;

    void Start()
    {
        Time.timeScale=1;
    	robotrigid=GetComponent<Rigidbody2D>();
    	transform.position=new Vector3(-3,2,0);
        n=1;
        wave();
        bgmusic=GetComponent<AudioSource>();
        bgmusic.PlayDelayed(3);
    }

    public void wave()
    {
        if(n==1)
        {
            enimyno=2;
            requirkills=10;
        }
        if(n==2)
        {
            enimyno=3;
            requirkills=15;
        }
        if(n==3)
        {
            enimyno=5;
            requirkills=18;
        }
        gunconscript=Gun.GetComponent<guncon>();
        gunconscript.wavechange();
        kills=0;
        wavetext.GetComponent<TMPro.TextMeshProUGUI>().text="wave"+n+"\n"+kills+"/"+requirkills;
    }

    void Update()
    {
    	nint=robotrigid.position;
        if(Input.GetKey(KeyCode.W))
        {
        	nint.y=nint.y+0.04f;
        }
        if(Input.GetKey(KeyCode.S))
        {
        	nint.y=nint.y-0.04f;
        }
        if(Input.GetKey(KeyCode.A))
        {
        	nint.x=nint.x-0.04f;
        }
        if(Input.GetKey(KeyCode.D))
        {
        	nint.x=nint.x+0.04f;
        }
        if(Input.GetKey(KeyCode.Escape))
        {
            Time.timeScale=0;
            pausecanvas.SetActive(true);
        }
        if(kills>=requirkills)
        {
            n+=1;
            if(n>3)
            {
                n=3;
                pauseconscript=pausecanvas.GetComponent<pausecon>();
                pausecanvas.SetActive(true);
                pauseconscript.Result();
            }
            else   
            {
                wave();
            }
        }
        wavetext.GetComponent<TMPro.TextMeshProUGUI>().text="wave "+n+"\n"+kills+"/"+requirkills;
    }
    
    void FixedUpdate()
    {
        robotrigid.MovePosition(nint);
        if(nowenimy<enimyno)
        {
        	callenimies();
        	nowenimy+=1;
        }
        
    }
    
    public void face(int look)
    {
    	transform.rotation=Quaternion.AngleAxis(look,new Vector3(0,1,0));
    }
    
    public void takeDamage(float damage)
    {
    	health-=damage;
    	healthrect.rectTransform.sizeDelta=new Vector2(308f*health/20,280f);
    	if(health<=0f)
    	{
            pausecanvas.SetActive(true);
            pauseconscript=pausecanvas.GetComponent<pausecon>();
            pauseconscript.Result();
    		Destroy(gameObject);
    	}
    }
    
    void callenimies()
    {
        int i=Random.Range(0,2);
        Instantiate(ea3,enimyspawn[i],Quaternion.identity);
    }
}
