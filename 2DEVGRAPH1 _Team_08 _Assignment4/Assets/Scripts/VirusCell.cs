using UnityEngine;
using System.Collections;

public class VirusCell : MonoBehaviour {

	public float virusSpeed = 10f;
	
	void Start() 
	{
				
	}
	
	void Update()
	{
		
		float amountToMove = virusSpeed * Time.deltaTime;
		transform.Translate(Vector3.left * amountToMove);		
		
	}
	
	void SetNewSpeed(int newSpeed)
	{
		virusSpeed = newSpeed;
	}
	
}
