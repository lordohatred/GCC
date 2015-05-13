using UnityEngine;
using System.Collections;

public class OnFootMotor : MonoBehaviour {

	float speed = 0.05f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Movement(Vector3 desiredMovement){
		transform.Translate (desiredMovement * speed);
	}
}
