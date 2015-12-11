using UnityEngine;
using System.Collections;


public class CellCounters : MonoBehaviour {

	public TargetableCell cell;
	
	public int test = 0;
	
	public GUIText CellText;
	
	
	// Use this for initialization
	void Start () 
	{
	
		cell = GetComponent<TargetableCell>();		
		
		test = cell.CellCounter;
		
		if (CellText != null)
		{
			CellText.text = "Cells: " + test;	
		}		
		
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
