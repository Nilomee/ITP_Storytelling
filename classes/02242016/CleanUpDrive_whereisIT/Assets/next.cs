using UnityEngine;
using System.Collections;

public class next : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	void Update() {
		if (Input.GetKeyDown (KeyCode.N)) {
			Application.LoadLevel(1);
		}
}
}