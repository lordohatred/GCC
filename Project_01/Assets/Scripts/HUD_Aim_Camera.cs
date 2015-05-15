using UnityEngine;
using System.Collections;

public class HUD_Aim_Camera : MonoBehaviour {

	public Material[] camMat;
	Camera front;
	Camera rear;
	Camera third;

	void Start(){
		front = GameObject.Find ("HUD_Front_Cam").GetComponent<Camera> ();
		rear = GameObject.Find("HUD_Rear_Cam").GetComponent<Camera>();
		third = GameObject.Find ("HUD_3ps_Cam").GetComponent<Camera> ();
		rear.enabled = false;
		third.enabled = false;
		front.fieldOfView = 60;
		rear.fieldOfView = 60;
		third.fieldOfView = 60;
	}

	public void ChangeCamera(int number){
		switch (number) {
		case 0:
			GetComponent<Renderer>().material = camMat[0];
			rear.enabled = false;
			third.enabled = false;
			front.enabled = true;
			break;
		case 1:
			GetComponent<Renderer>().material = camMat[1];
			front.enabled = false;
			third.enabled = false;
			rear.enabled = true;
			break;
		case 2:
			GetComponent<Renderer>().material = camMat[2];
			front.enabled = false;
			rear.enabled = false;
			third.enabled = true;
			break;
		}
	}

	public void ZoomCamera(int number){
		switch (number) {
		case 0:
			front.fieldOfView = 30;
			rear.fieldOfView = 30;
			third.fieldOfView = 30;
			break;
		case 1:
			front.fieldOfView = 60;
			rear.fieldOfView = 60;
			third.fieldOfView = 60;
			break;
		case 2:
			front.fieldOfView = 90;
			rear.fieldOfView = 90;
			third.fieldOfView = 90;
			break;
		}
	}
}
