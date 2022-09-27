using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletcon : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D other)
    {
    	ea3con enimy;
    	if(other.gameObject.name=="EA3 1(Clone)")
    	{
    		enimy=other.gameObject.GetComponent<ea3con>();
    		enimy.takebullet(1.5f);
    		Destroy(gameObject);
    	}
    	else if(other.gameObject.name!="Robot_rwg")
    	{
    		Destroy(gameObject);
    	}
    }
}
