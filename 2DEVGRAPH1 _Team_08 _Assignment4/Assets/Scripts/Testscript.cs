using UnityEngine;
using System.Collections;

public class Testscript : MonoBehaviour {
	
	private Vector3 screenPoint;
	private Vector3 offset;
	
	//Geschreven door -A
	
	public bool IsActive;	
	private bool IsStationary = false;
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
			//defPos = new Vector3(-19.4f, 12.4f, 1.2f); //placeholder voor MouseInput
			
			//transform.localPosition = defPos;
		}
		
		if(NumHits >= MaxHits)
		{
			Destroy(gameObject);
		}
		
		/*
		if(IsActive == false)
		{
			transform.localPosition = startPos;
			transform.localScale = startScale;
			NumHits = 0;
		}
		*/
	
		
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
			
			transform.position = new Vector3(other.transform.position.x, other.transform.position.y, 2.5f);
			
			IsStationary = true;
		}
	}
	
	
	
	void OnMouseDown()
	{
		Debug.Log ("Click happens");
		screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
		
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
 
	}
 
	void OnMouseDrag()
	{
		Debug.Log ("Drag happens");
		
		Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		
		
 
		Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
		
		if(!IsStationary)
		transform.position = curPosition;
 
	}
	
}
