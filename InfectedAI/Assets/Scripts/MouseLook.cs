using UnityEngine;
using System.Collections;

public class MouseLook : MonoBehaviour {

    Vector2 mouseLook;
    float sensitivity = 3.0f;
    float minY = -65, maxY = 65;
    public bool lookAxis;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
    void Update () {
        if (lookAxis) {
            mouseLook.y += Input.GetAxis ("Mouse Y") * sensitivity;
            mouseLook.x = 0;
            mouseLook.y = Mathf.Clamp (mouseLook.y, minY, maxY);
            transform.localEulerAngles = new Vector3 (-mouseLook.y, transform.localEulerAngles.y, 0);
        }
        if (!lookAxis) {
            mouseLook.x += Input.GetAxis ("Mouse X") * sensitivity;
            mouseLook.y = 0;
            transform.localEulerAngles = new Vector3 (0, mouseLook.x, 0);
        }
	}
}
