using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerCollider : MonoBehaviour {
	public Text countText;
	public Text winText;
	private int count;
	private bool won = false;
	public Object survivor;


	void Start() {
		Time.timeScale = 1;
		count = 0;
		SetCountText ();
		winText.text = "" ;

	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Pick Up")) 
		{
			other.gameObject.SetActive (false);
			count = count + 1;
			SetCountText ();
		
		}
	
	}

	void SetCountText () 
	{ 
		countText.text = "Ozone Holes Sealed: " + count.ToString ()+"/8";
		if (count >= 8) 
		{
			winText.text = "AMAZING!! You just saved our planet!" ;
			Time.timeScale = 0;
			won = true;
	    }
		if (count < 8 && Time.timeScale == 0)
		{
			winText.text = "You couldn't save the planet";
			won = true;
		}
    }

	void Update() {
		if (won && Input.GetKeyDown (KeyCode.R)) {
			Application.LoadLevel(0);
		}

	

		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.LoadLevel (2);

		}
		 


	}
}