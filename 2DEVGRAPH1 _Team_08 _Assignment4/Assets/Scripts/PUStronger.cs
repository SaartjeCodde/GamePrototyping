using UnityEngine;
using System.Collections;

public class PUStronger : MonoBehaviour {
	
	public bool IsActive;	

	private Vector3 startPos;
	private Vector3 defPos; //def van "defence"
	
	
	// Use this for initialization
	void Start () {
	startPos = transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
		
		var bigCells = GameObject.FindGameObjectsWithTag("BigCell");
		var numOfBigCells = bigCells.Length;
		int numInfected = 0;
		
			foreach(GameObject target in bigCells)
		{
			var scriptCell = target.GetComponent<TargetableCell>();
			
			if(scriptCell.GetIsVirus() == true)
			{
				++numInfected;
				
			}			
		}
		
		if(numInfected >= (numOfBigCells/3))
		{
			IsActive = true;
			transform.localPosition = defPos;
		}
		renderer.enabled = IsActive;	
	}
	
	void OnTriggerEnter(Collider other) 
	{
		
		if (IsActive == true)
		{
		if(other.tag == "Cell")
		{
			other.gameObject.transform.localScale += new Vector3(1F, 1F, 1F);
			
			var manager = other.GetComponent<Cell>();
			manager.bPUStrongerPickedUp = true;
			Destroy(gameObject);
		}
		}
    }
}



