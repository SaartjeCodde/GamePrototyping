using UnityEngine;
using System.Collections;

public class StatsManager : MonoBehaviour {
	
	private bool VirusTakenOver = false;
	private bool HealthyTakenOver = false;
	
	private HeadVirusCell virus;
	private HeadHealthyCell healthy;
	
	public GameObject cell;
	
	public int test = 0;
	public int testVirus = 0;
	
	public string WhichLevel;
	public string RestartLevel;
	
	//public GUIText CellText;
	public TextMesh CellText;
	public TextMesh VirusText;
	
		
	void Start()
	{
		//virus = gameObject.GetComponent<HeadVirusCell>();
		//healthy = gameObject.GetComponent<HeadHealthyCell>();	
		
		virus = GameObject.Find("Head virus cell").GetComponent<HeadVirusCell>();
		healthy = GameObject.Find("Head healthy cell").GetComponent<HeadHealthyCell>();
		
	// 	test = cell.GetComponent<TargetableCell>().CellCounter;		
		
//		test = cell.CellCounter;
		
		var test2 = cell.GetComponent<TargetableCell>();
		
		if (CellText != null)
		{
			CellText.text = "" + test;	
		}	
		
		if (VirusText != null)
		{
			VirusText.text = "" + test;	
		}
		
	}
	
	void Update()
	{
		
		var test2 = cell.GetComponent<TargetableCell>();
		test = test2.CellCounter;
		
		if (CellText != null)
		{
			CellText.text = "" + test;	
		}	
		
		test = test2.VirusCellCounter;
		if (VirusText != null)
		{
			VirusText.text = "" + test;	
		}
		
	}
	
	public void OnGUI()
	{
		VirusTakenOver = healthy.YouLost;
		HealthyTakenOver = virus.YouWon;
				
		if (GUI.Button (new Rect(10,10,160,50),"Skip this level"))	
		{
			Application.LoadLevel(WhichLevel);	
		}
	
		
		if (VirusTakenOver == true)
		{
			if (GUI.Button (new Rect(Screen.width/2 - 80,Screen.height/2,160,50),"You lost! Restart?"))				
			{
				Application.LoadLevel(RestartLevel);
			}
			
			//virus.enabled =false;
			//healthy.enabled =false;
		}
		
		if (HealthyTakenOver == true)
		{
			if (GUI.Button (new Rect(Screen.width/2 - 100,Screen.height/2,200,50),"You won! Proceed to next level?"))
			{
					Application.LoadLevel(WhichLevel);
			}
			
			//virus.enabled =false;
			//s healthy.enabled =false;
			
		}
		
	}
	
}


