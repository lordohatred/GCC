using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    Vector2 movement;
    float speed = 0.15f;
    bool runToLook = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
    void FixedUpdate () {
        if (Input.GetKeyDown (KeyCode.LeftShift))
            runToLook = true;
        if (Input.GetKeyUp (KeyCode.LeftShift))
            runToLook = false;
        float lerpTime = Time.deltaTime * 3;
        movement.x = Input.GetAxis ("Vertical");
        movement.y = Input.GetAxis ("Horizontal");
        MoveForward (movement.x * speed);
        MoveRight (movement.y * speed);
        if(runToLook)
            transform.rotation = Quaternion.Lerp (transform.rotation, GameObject.Find("CameraHolder").transform.rotation, lerpTime);
	}

    void MoveForward (float value) {
        transform.position += transform.forward * value;
    }

    void MoveRight (float value) {
        transform.position += transform.right * value;
    }
}
