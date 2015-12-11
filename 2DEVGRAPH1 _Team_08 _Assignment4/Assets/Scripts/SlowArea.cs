using UnityEngine;
using System.Collections;

public class SlowArea : MonoBehaviour {
	
	public int Counter = 500;
	public GameObject[] Objects;
	
	private bool IsArrayFilled = false;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		--Counter;
		
		// Debug.Log(Counter);
		
		if(Counter <= 0)
		{
			if(IsArrayFilled == false)
			{
           		Objects = GameObject.FindGameObjectsWithTag("Virus cell");
				
				IsArrayFilled = true;
			}
			
			foreach (GameObject gameOb in Objects)
			{
            	var manager = gameOb.GetComponent<VirusBehaviour>();
				manager.virusSpeed = 10f;
			}
			
			Destroy(gameObject);
		}
	}
	
	void OnTriggerEnter(Collider other) 
	{
		if(other.tag == "Virus cell")
		{
			var manager = other.gameObject.GetComponent<VirusBehaviour>();
			
			manager.virusSpeed = 0f;
		}		
    }
}
