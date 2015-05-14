using UnityEngine;
using System.Collections;

public class HUD_Interface : MonoBehaviour {
	
	GameObject[] locations;
	
	// Update is called once per frame
	void FixedUpdate () {
		switch (name) {
		case "SpeedText":
			GetComponent<TextMesh>().text = "X = " + transform.rotation.eulerAngles.x.ToString("F1") + "\n" + 
				"Y = " + transform.rotation.eulerAngles.y.ToString("F1") + "\n" +
					"Z = " + transform.rotation.eulerAngles.z.ToString("F1");
			break;
		case "WaypointText":
			locations = GameObject.FindGameObjectsWithTag("Planet");
			GetComponent<TextMesh>().text = locations[0].name + "\n" + (locations[0].transform.position - transform.position) + "\n" +
				locations[1].name + "\n" + (locations[1].transform.position - transform.position) + "\n" +
				locations[2].name + "\n" + (locations[2].transform.position - transform.position) + "\n" +
				locations[3].name + "\n" + (locations[3].transform.position - transform.position);
			break;
		case "SystemText":
			GetComponent<TextMesh>().text = "Fuel : " + GetComponentInParent<SpaceshipMotor>().fuel.ToString("F1") + "\n" + "Shields : " + "1200/1200" + "\n" +
				"Speed : " + GetComponentInParent<SpaceshipMotor>().speed.ToString("F1") + "\n"
					+ "X : " + GetComponentInParent<SpaceshipMotor>().curRot.x.ToString("F1") + "\n"
					+ "Y : " + GetComponentInParent<SpaceshipMotor>().curRot.y.ToString("F1") + "\n"
					+ "Z : " + GetComponentInParent<SpaceshipMotor>().curRot.z.ToString("F1");
			break;
		}
	}
}