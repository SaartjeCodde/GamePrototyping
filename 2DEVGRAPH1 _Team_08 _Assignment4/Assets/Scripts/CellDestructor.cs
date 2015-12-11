using UnityEngine;
using System.Collections;

public class CellDestructor : MonoBehaviour {
	
	
	public Color myColor;
	
	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "Cell")
		{
		other.renderer.material.color = myColor;
		other.gameObject.tag = "Virus cell";
		Destroy(other.gameObject.GetComponent<Cell>());
		other.gameObject.AddComponent<VirusBehaviour>();
			
		}		
	}	
	
}
