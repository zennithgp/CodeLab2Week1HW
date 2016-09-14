using UnityEngine;
using System.Collections;

public class TargetCollisionScript : MonoBehaviour {

	BoxCollider2D boxCol;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void CheckIfCollidingWithPlayer(){
		//TODO: Make this check if it's colliding with the player
		//If you are colliding with the player, start a timer
		//As you collide, change the alpha to red
		//If you stop colliding with the player, reset and stop the timer
		//If you collide for three seconds, play a sound, reset the timer and alpha, and reposition this
	}

	void RepositionMe(){
		//TODO: Move this to a random spot in the box that's not colliding with the player
	}
}
