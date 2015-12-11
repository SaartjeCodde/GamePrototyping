using UnityEngine;
using System.Collections;

public class VirusBehaviour : MonoBehaviour {
	
	private GameObject[] cells; 
	private GameObject closestCell;
	float distance;
	public float virusSpeed = 10.0f;
	private Vector3 position;
	private Vector3 targetPos;
	GameObject target;
	
	//private TargetableCell closestCell;
	//[HideInInspector]
	//public GameObject startCell;
	//public Vector3 startCellPos;
			
	void Start () 
	{
		
		//closestCell = GetComponent<TargetableCell>();
		position = transform.position;
		
		target = FindClosestCell();
			
	}
	
	void Update () 
	{
		
		targetPos = target.transform.position;
		 
		float amountToMove = virusSpeed * Time.deltaTime;
		
		// transform.Translate(targetPos);	
		
		
		
		transform.position = Vector3.MoveTowards(transform.position, targetPos, amountToMove);
		
		//Debug.Log(targetPos.ToString("F2"));
	//	Debug.Log(startCellPos.ToString("F2"));
	}
	
	GameObject FindClosestCell()
	{
		cells = GameObject.FindGameObjectsWithTag("BigCell");
		distance = Mathf.Infinity;
		
		position = transform.position;
		
		float prevDistance = 0.0f;
				
		closestCell = GameObject.FindGameObjectWithTag("Head Virus Cell");
		
		foreach (GameObject cell in cells)
		{
			
			float tempDiff = (cell.transform.position - position).sqrMagnitude;
			
			TargetableCell closestCellController = cell.GetComponent<TargetableCell>();
			
			if(tempDiff > 2.5f && closestCellController.isVirus == false) 
			{
				
				prevDistance = distance;
				distance = (cell.transform.position - position).sqrMagnitude;
				
				if(distance < prevDistance)
				{
					closestCell = cell;
				}
					
			}
						
		}
		return closestCell;
	}
	
	void OnTriggerEnter(Collider other) 
	{
		if(other.gameObject.tag == "BigCell")
		{
			float tempDiff = (transform.position - position).sqrMagnitude;
			
			if(tempDiff < distance && tempDiff > 2.5f) 
			{
				Destroy(gameObject);
				
			}
		}
			
	}
}


    

  