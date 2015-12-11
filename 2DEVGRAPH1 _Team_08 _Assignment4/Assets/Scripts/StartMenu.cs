using UnityEngine;
using System.Collections;

public class StartMenu : MonoBehaviour {
	
	public Texture buttonTexture;
	
	public string TutorialLevel;
	public string NormalLevel;
	public string GodlikeLevel;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void OnGUI()
	{

	
		if (GUI.Button (new Rect(Screen.width/2 -150,Screen.height/2 -100,300,80),"PLAY TUTORIAL"))				
		{
			Application.LoadLevel(TutorialLevel);	
		}
			
		if (GUI.Button (new Rect(Screen.width/2 - 150,Screen.height/2,300,80),"SKIP TUTORIAL"))
		{
			Application.LoadLevel(NormalLevel);
		}
		
		if (GUI.Button (new Rect(Screen.width/2 - 150,Screen.height/2 + 100,300,80),"GODLIKE LEVEL"))
		{
			Application.LoadLevel(GodlikeLevel);
		}
			
				
	}
		
	
	
	
}
