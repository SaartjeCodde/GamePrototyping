using UnityEngine;
using System.Collections;

public class TargetableCell : MonoBehaviour {

	public int CellCounter = 0;
	public int VirusCellCounter = 0;
	
	public Color healthyColor;
	public Color virusColor;
	
	private int tickCounterCells;
	private int tickCounter;
	
	public GameObject VirusPrefab;
	public GameObject CellPrefab;
	
	public bool isVirus = false;
	public bool isHealthy = false;
	
	public int SpeedToReproduce = 280;
	
	
		
	void Start()
	{
		
	}
	
	void Update()
	{
		//---------------- A
		var child = transform.GetComponentInChildren<TargetCellShield>();
		
		//-----------------
		
		
		// Healthy cells
		if (CellCounter > 0)
		{
			isHealthy = true;	
			isVirus = false;
			tickCounterCells++;
			
			//-------------- A
			if(child != null)
			{
				child.SetIsActive(true);
			}
			//---------------
		
			if (tickCounterCells >= 300)
			{
				tickCounterCells = 0;
				CellCounter++;					
			}		
			
			if(Input.GetMouseButtonDown(0))
			{
				// Debug.Log("IsHappening");
				// Physics.IgnoreCollision(collider, transform.gameObject.collider);
				/*
				Vector3 testpos = new Vector3 (transform.position.x,transform.position.y,transform.position.z +5);
				Instantiate(CellPrefab, testpos, Quaternion.identity);	
				CellCounter--;
				*/
			}
			
		}
		// else isHealthy = false;
		
		// Virus cells
		if (VirusCellCounter > 0)
		{
			isVirus = true;	
			isHealthy = false;
			tickCounterCells++;
			
			//-------------- A
			if(child != null)
			{
				child.SetIsActive(true);
			}
			//---------------
			
			tickCounter++;
			if (tickCounter >= SpeedToReproduce)
			{
				tickCounter = 0;
			
				VirusCellCounter--;
				Instantiate(VirusPrefab, transform.position, Quaternion.identity);		
			}
		}
		//else isVirus = false;
		
		//if (isHealthy = true)
		//{
		// 	CellCounter = 5;	
		//}
		//if (isVirus = true)
		//{
		//	VirusCellCounter = 5;	
		//}
		
		string temp = VirusCellCounter + " .... " + CellCounter;
		//Debug.Log(temp);
		//Debug.Log(isVirus);
		
		if(isHealthy)
		renderer.material.color = healthyColor;
		if(isVirus)
		renderer.material.color = virusColor;			
		
	}
	
	// -A --------
	public bool GetIsVirus()
	{
		return isVirus;
	}
	//-----------
		
	public bool GetIsHealthy()
	{
		return isHealthy;	
	}
	
	void OnTriggerEnter(Collider other) 
	{
      
		if (other.tag == "Cell")
		{
			Destroy(other.gameObject);
			
			if (VirusCellCounter > 0) VirusCellCounter--;
			else ++CellCounter;
					
		}
		
		if(other.tag == "Virus cell")
		{
			//Destroy(other.gameObject);
			
			if (CellCounter > 0) CellCounter--;
			
			else
			{					
				++VirusCellCounter;					
			}
		}		
		
    }	
	
	void OnMouseDown(){
		if (CellCounter > 0)
		{
		Vector3 testpos = new Vector3 (transform.position.x,transform.position.y,transform.position.z + 7);
		
		Instantiate(CellPrefab, testpos, Quaternion.identity);	
		CellCounter--;
			
		}
	 }   
	
}
