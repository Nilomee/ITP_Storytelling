﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class menuScript : MonoBehaviour {
	
	public Canvas QuitMenu;
	public Button startText; //for Play button Component
	public Button exitText;
	
	// Use this for initialization
	void Start () {
		
		QuitMenu = QuitMenu.GetComponent<Canvas> ();
		startText = startText.GetComponent<Button> ();
		exitText = exitText.GetComponent<Button> ();
		QuitMenu.enabled = false;
		
	}
	
	public void ExitPress()
		
	{
		QuitMenu.enabled = true;
		startText.enabled = false;
		exitText.enabled = false;
	}
	
	public void NoPress() 
	{
		QuitMenu.enabled = false;
		startText.enabled = true;
		exitText.enabled = true;
		
		
	}
	
	public void StartLevel()
	{
		Application.LoadLevel (3); 
		
	}
	
	public void ExitGame() {
		Application.Quit ();
		
	}



}
