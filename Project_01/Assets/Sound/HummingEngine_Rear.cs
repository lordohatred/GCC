using UnityEngine;
using System.Collections;

public class HummingEngine_Rear : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		if (GetComponentInParent<SpaceshipMotor> ().Speed > 0.5f) {
			GetComponent<AudioSource>().volume = (GetComponentInParent<SpaceshipMotor>().Speed / 25);
		}
		if (GetComponentInParent<SpaceshipMotor> ().Speed < 0.5f && GetComponentInParent<SpaceshipMotor> ().Speed > -0.5f)
			GetComponent<AudioSource> ().volume = 0;
		if (GetComponentInParent<SpaceshipMotor> ().Speed < -0.5f) {
			GetComponent<AudioSource>().volume = (-GetComponentInParent<SpaceshipMotor>().Speed / 25);
		}
	}
}
