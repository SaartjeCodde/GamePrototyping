using UnityEngine;
using System.Collections;

public class Projectile3 : MonoBehaviour {

	public float projectileSpeed = 10f;
	
	void Start() 
	{
				
	}
	
	void Update()
	{
		
		float amountToMove = projectileSpeed * Time.deltaTime;
		
		transform.Translate(Vector3.up * amountToMove);		
		
	}
	
	void OnTriggerEnter(Collider other) 
	{
      
		if (other.tag == "Cell")
		{
			Destroy(other.gameObject);		
		
		}
		
		if (other.tag == "Cellbreaker")
		{
			Destroy (gameObject);	
		}
	}
	
}