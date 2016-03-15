using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class GameTimer : MonoBehaviour {

	public float totalTime = 120f;
	public bool countingDown = true;
	public bool gameLost = false;
	private float timeLeft;
	public Text loseText;

	public Text guitext;

	// Use this for initialization
	void Start () {
		timeLeft = totalTime;
		loseText.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		if (countingDown) {
			timeLeft -= Time.deltaTime;
		}

		if (timeLeft <= 0) {
			timeLeft = 0;
			gameLost = true;
		}

		if (guitext) {
			guitext.text = "Time left: "+((int)timeLeft+1).ToString();

		}

		if (gameLost) {
			//Activate gameover UI
			Debug.Log ("Game Over!");
			guitext.text = "Time Left: "+"0";
			loseText.text = "Oh no! You couldn't save our planet";


		}
	}
}
