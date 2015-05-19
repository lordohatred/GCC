using UnityEngine;
using System.Collections;

public class MouseLook : MonoBehaviour {

	public bool lookAxis;
	float minX = -75, minY = -35;
	float maxX = 75, maxY = 75;
	float sensitivity = 1;
	Vector3 mouseLook;
	bool freeLook;

    void Start () {
        this.enabled = false;
    }

	// Update is called once per frame
	void FixedUpdate () {
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
			int highFOV = 60;
			int lowFOV = 45;
			if (Input.GetMouseButton (1))
				GetComponent<Camera> ().fieldOfView = lowFOV;
			else
				GetComponent<Camera>().fieldOfView = highFOV;
			if(GetComponentInParent<SpaceshipMotor>().Speed > 0 && GetComponent<Camera>().fieldOfView == highFOV)
				GetComponent<Camera>().fieldOfView = 60 + GetComponentInParent<SpaceshipMotor>().Speed / 15;
			if(GetComponentInParent<SpaceshipMotor>().Speed > 0 && GetComponent<Camera>().fieldOfView == lowFOV)
				GetComponent<Camera>().fieldOfView = 45 + GetComponentInParent<SpaceshipMotor>().Speed / 15;
		}
	}
}
