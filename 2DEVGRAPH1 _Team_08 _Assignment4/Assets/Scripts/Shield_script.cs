using UnityEngine;
using System.Collections;

public class Shield_script : MonoBehaviour {

	
	//Geschreven door -A
	
	public bool IsActive;	
	public int NumHits;
	public int MaxHits;
	
	private Vector3 startPos;
	private Vector3 defPos; //def van "defence"
	
	private Vector3 startScale;
	private Vector3 defScale;
	private Vector3 bigCellScale;
	
	void Start () {
		startPos = transform.localPosition;
		startScale = transform.localScale;
		
	}
	
	void Update () {
		//GameObject bigCell = GameObject.Find("Big Cell");
		//var scriptCell = bigCell.gameObject.GetComponent<TargetableCell>();
		
		var bigCells = GameObject.FindGameObjectsWithTag("BigCell");
		var numOfBigCells = bigCells.Length;
		int numInfected = 0;
		
		//Debug.Log(numOfBigCells);
		
		foreach(GameObject target in bigCells)
		{
			var scriptCell = target.GetComponent<TargetableCell>();
			
			if(scriptCell.GetIsVirus() == true)
			{
				++numInfected;
				//Debug.Log(numInfected);
			}			
		}
		
		//if(scriptCell.GetIsVirus() == true)
		if(numInfected >= (numOfBigCells/2))
		{
			IsActive = true;
			defPos = new Vector3(-19.4f, 12.4f, 1.2f); //placeholder voor MouseInput
			transform.localPosition = defPos;
		}
		else
		{
			IsActive = false;
		}
		
		if(NumHits >= MaxHits)
		{
			IsActive = false;
		}
		
		if(IsActive == false)
		{
			transform.localPosition = startPos;
			transform.localScale = startScale;
			NumHits = 0;
		}
		
		renderer.enabled = IsActive;	
		//Debug.Log(defScale);
	}
	
	public void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Virus cell")
		{
			if(IsActive == true)
			{
				++NumHits;
				defScale.x = bigCellScale.x + (MaxHits - NumHits);
				defScale.z = bigCellScale.z + (MaxHits - NumHits);
				transform.localScale = defScale;
				
				Destroy(other.gameObject);
				
			}
		}
		
		if(other.gameObject.tag == "BigCell")
		{
			defScale.x = other.transform.localScale.x + (MaxHits);
			defScale.y = 1.0f;
			defScale.z = other.transform.localScale.z + (MaxHits);
			
			transform.localScale = defScale;
			
			bigCellScale = other.transform.localScale;
			
		}
	}
	
	

	
}
