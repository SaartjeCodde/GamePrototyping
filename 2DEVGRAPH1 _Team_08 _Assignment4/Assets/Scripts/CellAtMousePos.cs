using UnityEngine;
using System.Collections;

public class CellAtMousePos : MonoBehaviour {

	public float speed = 3.0f;
	
	private Vector3 targetPos;
 	private Vector3 originalPosition;
	
	void Start() 
	{
		
		targetPos = transform.position;
		
	}
 
	void Update() 
	{
	
		targetPos = new Vector3(Input.mousePosition.x,Input.mousePosition.y,5);
		targetPos = Camera.main.ScreenToWorldPoint(targetPos);
		targetPos = new Vector3(targetPos.x,targetPos.y,5);	
	
		transform.position = targetPos;
 
	}
	
}

