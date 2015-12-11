using UnityEngine;
using System.Collections;

public class MouseTest : MonoBehaviour {
	 
	//Test om te zien of het draggen van cellen niet makkelijker is met rigdbody's en adforce
	/*private bool isHit = false;
	private Vector3 destinationVec;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(isHit == true)
		{
			Vector3 dirVec;
			dirVec.x = (transform.localPosition.x - destinationVec.x);
			dirVec.y = (transform.localPosition.y - destinationVec.y);
			dirVec.z = 0.0f;
			
			transform.rigidbody.AddForce(dirVec);
			
			Debug.Log(dirVec);
		}
	
		//Debug.Log(isHit);
	}
	
	public void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.name == "CellAtMousePos")
		{
			isHit = true;
			destinationVec = other.transform.localPosition;
		}
	}
	
	public void OnTriggerExit(Collider other)
	{
		if(other.gameObject.name == "CellAtMousePos")
		{
			isHit = false;
		}
	}*/
}
