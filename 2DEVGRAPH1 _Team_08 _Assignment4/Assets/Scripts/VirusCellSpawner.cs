using UnityEngine;
using System.Collections;

public class VirusCellSpawner : MonoBehaviour {

	public GameObject VirusPrefab;
	
	private float tickCounter = 0;
	
	void Start() 
	{
	
	}	
	
	void Update()
	{
		tickCounter++;
		
		if (tickCounter >= 200)
		{
			tickCounter = 0;
			Instantiate(VirusPrefab, transform.position, Quaternion.identity);					
		}		
		
	}
	
}
