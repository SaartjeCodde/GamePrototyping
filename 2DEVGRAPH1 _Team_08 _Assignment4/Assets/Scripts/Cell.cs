using UnityEngine;
using System.Collections;

public class Cell : MonoBehaviour {

	
	private GameObject[] cells; 
	private GameObject closestCell;
	
	public int HowManyVirussesLeft = 5;
	public float speed = 10.0f;
	
	private float acceleration;
	private float destinationDistance;
	private float currentSpeed;
	//private float repulseSpeed; // -A
	
	private bool isRepulsed = false; //-A
	
	private Vector3 targetPos;
	private Vector3 movement;
	private Vector3 direction;
	//private Vector3 repulseDir; //-A
	private Vector3 targetVec; //-A
	
	public bool bPUStrongerPickedUp = false;
	
	private Vector3 position;
	float distance;
	
	// Line renderer
	private static Vector3 outOfScreen = new Vector3(-100000,-100000,-100000);
		
	void Start() 
	{
		
		targetPos = transform.position;
		acceleration = 5.0f;
		
		LineRenderer lineRenderer = gameObject.AddComponent("LineRenderer") as LineRenderer;
    	lineRenderer.material = new Material (Shader.Find("Particles/Additive"));
   	 	lineRenderer.SetWidth(0.1f,0.1f);
    	lineRenderer.SetVertexCount(2);		
		
		position = transform.position;
		
		
	}
 
	void Update() 
	{	
	
		LineRenderer lineRenderer = GetComponent<LineRenderer>();
		
		destinationDistance = Vector3.Distance(targetPos, transform.position); 
		// if (Input.GetMouseButton(0)&& GUIUtility.hotControl ==0) 
		// if (Input.GetMouseButtonDown(0)&& GUIUtility.hotControl ==0) 
		targetPos = new Vector3(Input.mousePosition.x,Input.mousePosition.y,0);
		targetPos = Camera.main.ScreenToWorldPoint(targetPos);
		targetPos = new Vector3(targetPos.x,targetPos.y,0);	
		
		//----------------------------------------------
		//Invloed van Repolsor -A		
		if(isRepulsed == true)
		{
			//direction.x = (targetPos.x - (repulseDir.x/1.2f)) - transform.position.x;
			//direction.y = (targetPos.y - (repulseDir.y/1.2f)) - transform.position.y;
			/*direction.x = (targetPos.x - (repulseDir.x/1.2f)) - transform.position.x;
			direction.y = (targetPos.y - (repulseDir.y/1.2f)) - transform.position.y;
			direction.z = 0.0f;*/
			//Debug.Log(repulseDir);
			Vector3 tempVec;
			tempVec.x = (transform.position.x - targetVec.x);
			tempVec.y = (transform.position.y - targetVec.y);
			tempVec.z = 0.0f;
			transform.rigidbody.AddForce(tempVec);
			
		}	
		else
		{
			direction = targetPos - transform.position; //originele lijn code -S
			//Debug.Log(direction);
		}
		//----------------------------------------------
			
		if (destinationDistance < 1)
		{
			movement = direction.normalized * 0.0f * Time.deltaTime;			
		}		
		else if (destinationDistance > 1 && destinationDistance < 7.5)
		{
			currentSpeed = IncrementTowards(currentSpeed,speed,acceleration);			
			movement = direction.normalized * currentSpeed * Time.deltaTime;	
			//Debug.DrawLine(transform.position,targetPos);
			lineRenderer.SetPosition(0, transform.position);
    		lineRenderer.SetPosition(1, targetPos);			
		}
		else
		{
			lineRenderer.SetPosition(0, outOfScreen);
    		lineRenderer.SetPosition(1, outOfScreen);	
		}
		
		
		GetComponent<CharacterController>().Move(movement);
		
		//Debug.Log(bPUStrongerPickedUp); In commentaar gezet -A
	}	
		
	private float IncrementTowards(float currentSpeed, float target, float acceleration) 
	{
		
		
		if (currentSpeed == target)	// If the current speed is already equal to the target,
		{
			return currentSpeed;	// then we can just return the current speed.	
		}
		else 						// Otherwise, 
		{
			float direction = Mathf.Sign(target - currentSpeed);		// we check in which direction the current speed must be incemented to get to the target.
			
			currentSpeed += acceleration * Time.deltaTime * direction; 	// Then we increment the current speed by the acceleration, times by the direction.  
			
			if (direction == Mathf.Sign (target - currentSpeed))	// If the direction is still the same / the currentspeed hasn't passed the target (once incremented),
			{
				return currentSpeed; 			// we return the currentspeed.	
			}
			else                         		// Otherwise, if it has passed the target (incremented to far),
			{
				return target;					// then just return the target.
			}			
		}
		
	}
	
	public void ChangePUStronger()
	{
		bPUStrongerPickedUp = true;
	}
	
	void OnTriggerEnter(Collider other) 
	{
		if(other.tag == "Virus cell")
		{
			if(bPUStrongerPickedUp == true)
			{
				if(HowManyVirussesLeft > 0)
				{
					Destroy(other.gameObject);
					--HowManyVirussesLeft;
				}
			}
			else
			{
				// Voor als er toch iets gebeurt als de cel het virus raakt
			}
		}	
		
		//Onderstaande is de code voor wanneer een cell in contact komt met de trigger van een Repulsorcell -A
		if(other.gameObject.tag == "Repulsor")
		{
			/*transform.rigidbody.velocity = transform.rigidbody.velocity * -1000;*/  //RigidBody's zijn niet compatibel met bestaande Code om muis te volgen -A
			Vector3 distanceVec = other.transform.position - this.transform.position; //Vec voor Vector
			targetVec = other.transform.position;
			
			//Debug.Log(distanceVec);
			
			/*if(distanceVec.x > 0)
			{
				repulseDir.x = 10.0f - distanceVec.x;
			}
			else
			{
				repulseDir.x = 10.0f - (distanceVec.x *-1);
			}
			
			if(distanceVec.y > 0)
			{
				repulseDir.y = 10.0f - distanceVec.y;
			}
			else
			{
				repulseDir.y = 10.0f - (distanceVec.y *-1);
			}
			
			repulseDir.z = 0.0f;*/
			/*float fDistance = Mathf.Sqrt(Mathf.Pow(distanceVec.x, 2.0f) + Mathf.Pow(distanceVec.y, 2.0f) + Mathf.Pow(distanceVec.z, 2.0f));
			repulseSpeed = speed - fDistance;
			
			if(repulseSpeed < 0)
			{
				repulseSpeed = 0;
			}*/
			
			
			isRepulsed = true;
			
			//Debug.Log(repulseDir);
			//Debug.Log("IsRepulsed");
		}
		
		if(other.gameObject.tag == "BigCell")
		{
			float tempDiff = (transform.position - position).sqrMagnitude;
				
			if(tempDiff < distance && tempDiff > 2.5f) 
			{
				Destroy(gameObject);
				
			}
		}
			
	}
	
	public void OnTriggerExit(Collider other) // -A
	{
		if(other.gameObject.tag == "Repulsor")
		{
			isRepulsed = false;
		}
	}
}






