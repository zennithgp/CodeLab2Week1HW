using UnityEngine;
using System.Collections;

public class TargetCollisionScript : MonoBehaviour {

//	BoxCollider2D boxCol;

	//create a reference to the player and sfx
	public GameObject player;
	public AudioSource collidingMusic;
	public AudioSource successMusic;
	SpriteRenderer sprite;
	Color originalColor;

	//create a timer to check how long this is colliding with the player
	float collisionTimer = 0f;
	//and a float so we can change the desired collision time in the inspector
	public float collisionTimeLimit = 3f;
	//we'll use this numbers to track how far along you are to succeeding
	float successPercentage;
	bool overlappingWithPlayer = false;

	// Use this for initialization
	void Start () {
	
		player = GameObject.Find ("Player");
		collidingMusic = GetComponent<AudioSource> ();
		successMusic = player.GetComponent<AudioSource> ();
		sprite = GetComponent<SpriteRenderer> ();
		originalColor = sprite.color;


	}
	
	// Update is called once per frame
	void Update () {

		successPercentage = (collisionTimer / collisionTimeLimit);
		Color newColor = sprite.color;
		newColor.r = successPercentage;
		sprite.color = newColor;

		//if you're not colliding with the player, decrease thge collision timer
		if (overlappingWithPlayer == false) {
			if (collisionTimer > 0) {
				collisionTimer -= Time.deltaTime;
			} else {
				collisionTimer = 0;
			}
		}

	}

	void OnTriggerStay(Collider collider){
		//if you're colliding, but not yet at the desired time limit...
		if (collider.gameObject.name == "Player" && (collisionTimer < collisionTimeLimit)) {
			overlappingWithPlayer = true;
			collisionTimer += Time.deltaTime;
			//play and loop the colliding sfx
			if (collidingMusic.isPlaying == false) {
				collidingMusic.Play ();
				collidingMusic.loop = true;
			}
			Debug.Log ("Colliding with the target!" + successPercentage);
		}
		if (collider.gameObject.name == "Player" && (collisionTimer >= collisionTimeLimit)) {
			collidingMusic.Stop ();
			successMusic.Play ();
			MoveThisTarget ();
			Debug.Log ("Timer met!");
			overlappingWithPlayer = false;
		}
	}

	void OnTriggerExit(Collider collider){
		collidingMusic.loop = false;
		overlappingWithPlayer = false;

	}

	void MoveThisTarget(){
		float tempX = Random.Range (-14f, 14f);
		float tempy = Random.Range (-14f, 14f);
		new Vector3 tempPos = (tempX, tempy, 0f);
		transform.position = tempPos;
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
