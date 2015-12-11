using UnityEngine;
using System.Collections;

public class HeadHealthyCell : MonoBehaviour {
	
	public GameObject CellPrefab;
	
	private bool clicked = false;
	
	public bool YouLost;
	
	// Use this for initialization
	void Start () {
		// Debug.Log (YouLost);
	}
	
	// Update is called once per frame
	void Update () 
	{
		var bigCells = GameObject.FindGameObjectsWithTag("BigCell");
		var numberOfBigCells = bigCells.Length;
		int numberInfected = 0;
		
		// Debug.Log(numberInfected);
		
		foreach(GameObject target in bigCells)
		{
			var scriptCell = target.GetComponent<TargetableCell>();
			if (scriptCell.GetIsVirus() == true)
			{
				++numberInfected;	
				// Debug.Log(numberInfected);
			}
		}
		
		if (numberInfected >= numberOfBigCells)
		{
			gameObject.tag = "BigCell";
			
			//gameObject.GetComponent<TargetableCell>().enabled = true;
			
			gameObject.AddComponent<TargetableCell>();
			//int test = gameObject.AddComponent<TargetableCell>().VirusCellCounter;
			//YouLost = true;					
			bigCells = GameObject.FindGameObjectsWithTag("BigCell");
			numberOfBigCells = bigCells.Length;
			
			if (numberInfected == numberOfBigCells)
			{
				YouLost = true;	
			}
		}		
		
		
		//if(Input.GetMouseButtonDown(0))
		//{
			// Debug.Log("IsHappening");
			//Instantiate(CellPrefab, transform.position, Quaternion.identity);	
		//}
		
	}	
	
	void OnMouseDown(){
		Debug.Log ("BEEP");
		Vector3 testpos = new Vector3 (transform.position.x,transform.position.y,transform.position.z + 5);
		Instantiate(CellPrefab, testpos, Quaternion.identity);	
	 }   
	
}

		
