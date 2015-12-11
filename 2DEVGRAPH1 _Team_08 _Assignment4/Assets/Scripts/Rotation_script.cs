using UnityEngine;
using System.Collections;

public class Rotation_script : MonoBehaviour {
	
	public float RotSpeed = 4.0f;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 tempVec;
		tempVec.x = 0.0f;
		tempVec.y = 0.0f;
		tempVec.z = RotSpeed;
		
		transform.rigidbody.AddTorque(tempVec);
		//transform.Rotate(tempVec);
	
	}
}
