using UnityEngine;
using System.Collections;

public class MouseLook : MonoBehaviour {

	public bool lookAxis;
	float minX = -75, minY = -35;
	float maxX = 75, maxY = 75;
	float sensitivity = 1.5f;
	Vector3 mouseLook;
	bool freeLook;
	Animator anim;
	bool isUp = true;

	// Use this for initialization
	void Start () {
		anim = GameObject.Find ("HUD_Cam").GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (!GetComponentInParent<PlayerController> ().IsOnFoot ()) {
			if (Input.GetKeyDown (KeyCode.T))
				isUp = !isUp;
			if (isUp)
				anim.SetBool ("IsUp", true);
			else
				anim.SetBool ("IsUp", false);
			if (Input.GetButtonDown ("FreeLook"))
				freeLook = !freeLook;
			if (freeLook) {
				Cursor.visible = true;
				Cursor.lockState = CursorLockMode.None;
				if (lookAxis) {
					mouseLook.y += Input.GetAxis ("Mouse Y") * sensitivity;
					mouseLook.x = 0;
					mouseLook.y = Mathf.Clamp (mouseLook.y, minY, maxY);
					transform.localEulerAngles = new Vector3 (-mouseLook.y, transform.localEulerAngles.y, 0);
				}
				if (!lookAxis) {
					mouseLook.x += Input.GetAxis ("Mouse X") * sensitivity;
					mouseLook.y = 0;
					mouseLook.x = Mathf.Clamp (mouseLook.x, minX, maxX);
					transform.localEulerAngles = new Vector3 (0, mouseLook.x, 0);
				}
			} else {
				Cursor.visible = false;
				Cursor.lockState = CursorLockMode.Locked;
				mouseLook.x = 0;
				mouseLook.y = 0;
				transform.rotation = GameObject.Find ("Player").transform.rotation;
			}
			if(name == "Main Camera"){
				if(GetComponentInParent<SpaceshipMotor>().GetSpeed() > 0)
					GetComponent<Camera>().fieldOfView = 60 + GetComponentInParent<SpaceshipMotor>().GetSpeed() / 15;
			}
		}
	}
}
