﻿using UnityEngine;
using System.Collections;

public class TargetCollisionScript : MonoBehaviour {

//	BoxCollider2D boxCol;

	//create a reference to the player and sfx
	public GameObject player;
	public AudioSource collidingMusic;
	public AudioSource successMusic;

	//create a timer to check how long this is colliding with the player
	float collisionTimer = 0f;
	//and a float so we can change the desired collision time in the inspector
	public float collisionTimeLimit = 3f;
	//we'll use this numbers to track how far along you are to succeeding
	float successPercentage;

	// Use this for initialization
	void Start () {
	
		player = GameObject.Find ("Player");
		collidingMusic = GetComponent<AudioSource> ();
		successMusic = player.GetComponent<AudioSource> ();

	}
	
	// Update is called once per frame
	void Update () {

		successPercentage = (collisionTimer / collisionTimeLimit);

	}

	void OnCollisionEnter(Collision collider){
		//if you're colliding, but not yet at the desired time limit...
		if (collider.gameObject.name == "Player" && (collisionTimer < collisionTimeLimit)) {
			collisionTimer += Time.deltaTime;
			//play and loop the colliding sfx
			if (collidingMusic.isPlaying == false) {
				collidingMusic.Play ();
				collidingMusic.loop = true;
			}
		}
		if (collider.gameObject.name == "Player" && (collisionTimer >= collisionTimeLimit)) {
			collidingMusic.Stop ();
			successMusic.Play ();
			MoveThisTarget ();
		}
	}

	void MoveThisTarget(){

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
