using UnityEngine;
using System.Collections;

public class TargetCollisionScript : MonoBehaviour {

//	BoxCollider2D boxCol;

	//create a reference to the player and sfx
	public GameObject player;
	public AudioSource collidingMusic;
	public AudioSource successMusic;

	//create a timer to check how long this is colliding with the player
	float collisionTimer;
	//and a float so we can change the desired collision time in the inspector
	public float collisionTimeLimit;

	// Use this for initialization
	void Start () {
	
		player = GameObject.Find ("Player");
		collidingMusic = GetComponent<AudioSource> ();
		successMusic = player.GetComponent<Audiosource> ();

	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter(Collision collider){
		//if you're colliding, but not for the desired time limit...
		if (collider.gameObject.name == "Player" && (collisionTimer < collisionTimeLimit)) {
			//play and loop the colliding sfx
			collidingMusic.Play ();
			collidingMusic.loop (true);
		}
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




void OnCollisionEnter(Collision collider){
	if (collider.gameObject.name == "Player" && touchedTheEnd == false) {
		levelMusic.Stop ();
		winMusic.Play();
		touchedTheEnd = true;
		Debug.Log ("You touched the end?");
		gameManagerScript.CheckHighScore ();
		Invoke ("Restart", 4f);
	}