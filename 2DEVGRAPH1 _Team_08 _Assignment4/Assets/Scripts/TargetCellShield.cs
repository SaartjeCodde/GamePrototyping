using UnityEngine;
using System.Collections;

public class TargetCellShield : MonoBehaviour {

	//Geschreven door -A
	
	public bool IsActive = true;
	public bool IsFriendly = false;
	
	public int NumHits;
	public int MaxHits;
	
	public Color ShieldFriendly;
	public Color ShieldEvil;
	
	private Vector3 startPos;
	private Vector3 defPos; //def van "defence"
	
	private Vector3 startScale;
	private Vector3 defScale;
	private Vector3 bigCellScale;
	
	void Start () {
		startPos = transform.localPosition;
		startScale = transform.parent.localScale/2;
		
		defScale.x = startScale.x + (float)(MaxHits)/5;
		defScale.y = 1.0f;
		defScale.z = startScale.z + (float)(MaxHits)/5;
		
		Debug.Log(defScale);
			
		bigCellScale = transform.parent.localScale;
		
	} 
	
	void Update () {
		
		var parentCell = transform.parent.GetComponent<TargetableCell>();
		transform.localScale = defScale;
		
		if(parentCell.GetIsHealthy() == true)
		{
			IsFriendly = true;
			//IsActive = true;
		}
		else if(parentCell.GetIsHealthy() == false)
			{
				IsFriendly = false;
				//IsActive = true;
			}
		
		if(IsFriendly == true)
		{
			renderer.material.color = ShieldFriendly;
		}
		else if(IsFriendly == false)
			{
				renderer.material.color = ShieldEvil;
			}
		
		if(NumHits >= MaxHits)
		{
			IsActive = false;
		}	
		
		if(IsActive == false)
		{
			NumHits = 0;
			
			defScale.x = startScale.x + (float)(MaxHits)/5;
			defScale.y = 1.0f;
			defScale.z = startScale.z + (float)(MaxHits)/5;
			
			transform.localScale = defScale;
		}
		
		renderer.enabled = IsActive;	
		//Debug.Log(defScale);
		//Debug.Log(IsActive);
		
	}
	
	public void OnTriggerEnter(Collider other)
	{
		if(IsFriendly == true)
		{
			if(other.gameObject.tag == "Virus cell")
			{
				if(IsActive == true)
				{
					++NumHits;
					defScale.x = startScale.x + (float)(MaxHits - NumHits)/5;
					defScale.z = startScale.z + (float)(MaxHits - NumHits)/5;
					transform.localScale = defScale;
					
					Destroy(other.gameObject);
					
				}
			}
		}
		
		if(IsFriendly == false)
		{
			if(other.gameObject.tag == "Cell")
			{
				if(IsActive == true)
				{
					++NumHits;
					defScale.x = startScale.x + (float)(MaxHits - NumHits)/5;
					defScale.z = startScale.z + (float)(MaxHits - NumHits)/5;
					transform.localScale = defScale;
					
					Destroy(other.gameObject);
					
				}
			}
		}
		
		/*if(other.gameObject.tag == "BigCell")
		{
			defScale.x = other.transform.localScale.x + (MaxHits);
			defScale.y = 1.0f;
			defScale.z = other.transform.localScale.z + (MaxHits);
			
			transform.localScale = defScale;
			
			bigCellScale = other.transform.localScale;
			
		}*/
	}	
	
	public void SetIsActive(bool tempActive)
	{
		IsActive = tempActive;
	}
}



