using UnityEngine;
using System.Collections;
using Uniduino;

public class Ground : MonoBehaviour {

	Vector3 north;
	Vector3 south;
	Vector3 northEast;
	Vector3 northWest;
	Vector3 southEast;
	Vector3 southWest;

	public Arduino arduino;
	public int up = 5;
	public int down = 6;
	public int left = 7;
	public int right = 8;
	public int upleft = 9;
	public int upright = 10;
	public int downleft =11;
	public int downright = 12;

	private int upValue = 0;
	private int downValue = 0;
	private int rightValue = 0;
	private int leftValue = 0;
	private int upleftValue = 0;
	private int downrightValue = 0;
	private int uprightValue = 0;
	private int downleftValue = 0;



	void Start() {

		arduino = Arduino.global;
		arduino.Log = (s) => Debug.Log("Arduino: " +s);
		arduino.Setup (ConfigurePins);

		south = new Vector3 (0,0,1);
		north = new Vector3 (0,0,-1);
		northEast = new Vector3 (1, 0, 1);
		northWest = new Vector3 (-1, 0, 1);
		southEast = new Vector3 (1, 0, -1);
		southWest = new Vector3 (-1, 0, -1);

	}

	void ConfigurePins() {
		//arduino.pinMode (pin, pinMode.INPUT);
		arduino.pinMode (up , PinMode.INPUT);
		arduino.pinMode (down, PinMode.INPUT);
		arduino.pinMode (right, PinMode.INPUT);
		arduino.pinMode ( left, PinMode.INPUT);
		arduino.pinMode ( upleft, PinMode.INPUT);
		arduino.pinMode ( downleft, PinMode.INPUT);
		arduino.pinMode ( upright, PinMode.INPUT);
		arduino.pinMode ( downright, PinMode.INPUT);


		arduino.reportDigital((byte)(up/8), 1);
		arduino.reportDigital((byte)(right/8), 1);
		arduino.reportDigital((byte)(left/8), 1);
		arduino.reportDigital((byte)(down/8), 1);
		arduino.reportDigital((byte)(downright/8), 1);
		arduino.reportDigital((byte)(downleft/8), 1);
		arduino.reportDigital((byte)(upleft/8), 1);
		arduino.reportDigital((byte)(upright/8), 1);

	
	}

	void FixedUpdate () 

	{
	
		//USEFUL for keyboard control//
		//if(Input.GetKey (KeyCode.RightArrow)) transform.Rotate(1,0,0);
		//if(Input.GetKey (KeyCode.LeftArrow))transform.Rotate(-1,0,0); 
		//if(Input.GetKey (KeyCode.UpArrow)) transform.Rotate(0,0,1);
		//if(Input.GetKey (KeyCode.DownArrow)) transform.Rotate(0,0,-1);


		upValue = arduino.digitalRead(up);
		downValue = arduino.digitalRead(down);
		leftValue = arduino.digitalRead(left);
		rightValue  = arduino.digitalRead(right);
		upleftValue = arduino.digitalRead (upleft);
		uprightValue = arduino.digitalRead (upright);
		downleftValue = arduino.digitalRead (downleft);
		downrightValue = arduino.digitalRead (downright);


		Debug.Log (upValue);
		Debug.Log (downValue);
		Debug.Log (leftValue);
		Debug.Log (rightValue);
		Debug.Log (uprightValue);
		Debug.Log (upleftValue);
		Debug.Log (downrightValue);
		Debug.Log (downleftValue);


		//if (uprightValue ==1 ) transform.Rotate (1, 0, 1, Space.World);
		//if (upleftValue == 1) transform.Rotate (-1, 0, 1, Space.World);
        //if (downleftValue ==1 ) transform.Rotate (-1, 0, -1, Space.World);
		//if (downrightValue ==1 ) transform.Rotate (1, 0, -1, Space.World);
		//if(downValue ==1 ) transform.Rotate (0,0,-1);		//down
		//if (leftValue ==1) transform.Rotate (-1, 0, 0);	//left
		//if (downValue == 1) transform.Rotate (0, 0, -1);	//up
		//if (rightValue ==1 ) transform.Rotate (1, 0,0);	//right

		if (upValue == 1) transform.Rotate (north, Space.World);		     //down
		if (leftValue ==1) transform.Rotate (Vector3.right, Space.World);	     //left
		if (downValue == 1) transform.Rotate (south, Space.World);	         //up
		if (rightValue == 1) transform.Rotate (Vector3.left, Space.World);	//right
		if (uprightValue == 1) transform.Rotate (northWest,Space.World);  // actually south west .....north and south are flipped
		if (downrightValue == 1) transform.Rotate (southWest,Space.World); //actually north west
		if (upleftValue == 1) transform.Rotate (northEast, Space.World);  // actually south east
		if (downleftValue == 1) transform.Rotate (southEast, Space.World); //actually north east

	}


}
