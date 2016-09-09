using UnityEngine;
using System.Collections;

public class CameraMoveScript : MonoBehaviour {

	//create a variable to reference the player
	//this is still public, friend. Don't forget this.
	public Transform playerTransform;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//we'll calculate the difference between the player and the camera
		//if they're far away, the camera moves faster
//		float dist = Vector3.Distance(transform, playerTransform);
//		Debug.Log (dist);
//		if (dist > 5) {
//			Vector3 newPosition = 0.75f * (transform.position + playerTransform.position);
//			newPosition.z = -10f;
//			transform.position = newPosition;
//		} else {
			Vector3 newPosition = 0.4f * (transform.position + playerTransform.position);
			newPosition.z = -10f;
			transform.position = newPosition;
//		}
//
	}
}
