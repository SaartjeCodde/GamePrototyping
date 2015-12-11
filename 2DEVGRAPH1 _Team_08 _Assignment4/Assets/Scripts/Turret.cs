using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {

	public GameObject target;
	public GameObject turret;
	
	public float damp = 1.0f;
	
	private bool inRange = false;
	
	private float distance;
	
	public float radius = 10;
	
	public GameObject projectile1;
		public GameObject projectile2;
		public GameObject projectile3;
		public GameObject projectile4;
	
	

	private float tickCounter;
	
	void Start ()
	{
	
	}
	
	void Update () 
	{		
		
		
		
		//var rotate = Quaternion.LookRotation(target.transform.position - turret.transform.position);
		//turret.transform.rotation = Quaternion.Slerp(turret.transform.rotation, rotate, Time.deltaTime * damp);
		
		// turret.transform.LookAt(target.transform.position);	
	/*	if(inRange)
		{
			Debug.Log("I'm in range");
		}
		else
		{
			Debug.Log("Not anymore");
		}
	}	
	/*
	public void OnTriggerStay(Collider other)
	{
		
		if(other.transform.tag == "Target")	
		{
			Debug.Log("test");
		var rotate = Quaternion.LookRotation(target.transform.position - turret.transform.position);
		turret.transform.rotation = Quaternion.Slerp(turret.transform.rotation, rotate, Time.deltaTime * damp);
		}
	}
	*/
		tickCounter += Time.deltaTime;
		distance = (target.transform.position - turret.transform.position).magnitude;
		Debug.Log(distance);
		
		if (distance <= radius)
		{
			Debug.Log("In Range : " + distance);
			inRange = true;
		}
		else {inRange = false;}
		
		if (inRange)
		{
			//var rotate = Quaternion.LookRotation(target.transform.position - turret.transform.position);
			
			//rotate.x = 0;
			//rotate.y = 0;
			
			//turret.transform.rotation = Quaternion.Slerp(turret.transform.rotation, rotate, Time.deltaTime * damp);
			if (tickCounter > 3.0f)
			{
				Instantiate(projectile1, transform.position,Quaternion.identity);
				Instantiate(projectile2, transform.position,Quaternion.identity);
				Instantiate(projectile3, transform.position,Quaternion.identity);
				Instantiate(projectile4, transform.position,Quaternion.identity);
				tickCounter = 0.0f;
			}
		}
		
	}

	
	
}
