using UnityEngine;
using System.Collections;

public class CameraFollowMouse : MonoBehaviour {
	
	float mousePosX;
	
	public int devider = 8;
	
	public int Max = 60;
	public int Min = 32;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//Vector3 thePos = new Vector3( Input.mousePosition.x, transform.position.y, -5); // temporary variable
		
		Vector3 thePos = new Vector3( Mathf.Clamp((Input.mousePosition.x / devider),Min,Max),transform.position.y, -5);
		
		gameObject.transform.position = thePos;
	}
}
