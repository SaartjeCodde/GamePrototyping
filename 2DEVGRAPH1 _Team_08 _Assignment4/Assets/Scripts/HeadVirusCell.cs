using UnityEngine;
using System.Collections;

public class HeadVirusCell : MonoBehaviour {

	public GameObject VirusPrefab;
	
	private float tickCounter = 0;
	
	public int SpeedToReproduce = 200;
	
	public bool YouWon;
	
	
	void Start()
	{
		//Debug.Log (YouWon);	
	}
	
	void Update()
	{
		
		var bigCells = GameObject.FindGameObjectsWithTag("BigCell");
		var numberOfBigCells = bigCells.Length;
		int numberHealthy = 0;
		
		foreach(GameObject target in bigCells)
		{
			var scriptCell = target.GetComponent<TargetableCell>();
			if (scriptCell.GetIsHealthy() == true)
			{
				++numberHealthy;	
				// Debug.Log(numberInfected);
			}
		}
		
		if (numberHealthy >= numberOfBigCells)
		{
			
			gameObject.tag = "BigCell";
			gameObject.AddComponent<TargetableCell>();
			//int test = gameObject.AddComponent<TargetableCell>().CellCounter;
			//YouLost = true;					
			bigCells = GameObject.FindGameObjectsWithTag("BigCell");
			numberOfBigCells = bigCells.Length;
			
			if (numberHealthy == numberOfBigCells)
			{
				YouWon = true;	
			}
			
			
		}		
		
		tickCounter++;
		
		if (tickCounter >= SpeedToReproduce )
		{
			tickCounter = 0;
			Instantiate(VirusPrefab, transform.position, Quaternion.identity);					
		}		
		
	}
	
}



