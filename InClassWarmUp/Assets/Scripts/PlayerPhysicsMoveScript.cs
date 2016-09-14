using UnityEngine;
using System.Collections;

public class PlayerPhysicsMoveScript : MonoBehaviour {

	//it's been a long time since I've coded, so I'm gonna do this nice and slowly
	//and comment EVERYTHING

	//create a variable for the rigidbody
	Rigidbody playerRigidBody;

	//create a variable for our speed
	//we're initialized at whatever number we want; we should tweak this in the inspector
	//'cause, y'know, IT'S PUBLIC
	public float speed = 1000f;

	//create references to our keys
	public KeyCode moveUp;
	public KeyCode moveDown;
	public KeyCode moveLeft;
	public KeyCode moveRight;
	public KeyCode moveIn;
	public KeyCode moveOut;

	// Use this for initialization
	void Start () {

		//link the variable to this object's actual rigidbody
		playerRigidBody = GetComponent<Rigidbody> ();

	}

	// Update is called once per frame
	void Update () {
		
		//let's adjust for our framerate, so we don't need Time.deltatime everywhere
		float timeAdjustedSpeed = speed * Time.deltaTime;

		//we'll call a function which moves according to which key is pressed
		//Param1 = KeyCode, Param2 = the appropriate Vector3

		MoveByKey (moveUp, new Vector3 (0, timeAdjustedSpeed, 0));
		MoveByKey (moveDown, new Vector3 (0, -timeAdjustedSpeed, 0));
		MoveByKey (moveLeft, new Vector3 (-timeAdjustedSpeed, 0, 0));
		MoveByKey (moveRight, new Vector3 (timeAdjustedSpeed, 0, 0));
//		MoveByKey (moveIn, new Vector3 (0, 0, timeAdjustedSpeed));
//		MoveByKey (moveOut, new Vector3 (0, 0, -timeAdjustedSpeed));

	}

	void MoveByKey (KeyCode key, Vector3 movement){
		if(Input.GetKey(key)){
			playerRigidBody.AddForce (movement);
		}
	}
}
