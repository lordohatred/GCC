using UnityEngine;
using System.Collections;

public class SpaceshipStick : MonoBehaviour {

	public bool lockedX;
	Vector2 stickRot;
	float sensitivity = 1f;
	float minX = -10, minY = -10;
	float maxX = 10, maxY = 10;

	// Update is called once per frame
	void Update () {
		if (lockedX) {
			if(GetComponentInParent<PlayerController> ().desiredRotation.x != 0){
				stickRot.y += GetComponentInParent<PlayerController> ().desiredRotation.x * sensitivity;
				stickRot.x = 0;
				stickRot.y = Mathf.Clamp (stickRot.y, minY, maxY);
				transform.localEulerAngles = new Vector3 (-stickRot.y, transform.localEulerAngles.y, 0);
			}
			else{
				stickRot.y = 0;
				transform.localEulerAngles = new Vector3(0,0,0);
			}
		}
		if (!lockedX) {
			if(GetComponentInParent<PlayerController>().desiredRotation.z != 0){
				stickRot.x += GetComponentInParent<PlayerController> ().desiredRotation.z * sensitivity;
				stickRot.y = 0;
				stickRot.x = Mathf.Clamp (stickRot.x, minX, maxX);
				transform.localEulerAngles = new Vector3 (0, stickRot.x, 0);
			}
			else{
				stickRot.x = 0;
				transform.localEulerAngles = new Vector3(0,0,0);
			}
		}
	}
}
