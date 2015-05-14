using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUD_Interface : MonoBehaviour {
	
	GameObject[] locations;
	
	// Update is called once per frame
	void FixedUpdate () {
		switch (name) {
		case "FuelText":
			GetComponent<Text>().text = "Fuel : " + GetComponentInParent<SpaceshipMotor>().fuel.ToString("F1");
			break;
		case "SpeedText":
			GetComponent<Text>().text = "X = " + transform.rotation.eulerAngles.x.ToString("F1") + "\n" + 
				"Y = " + transform.rotation.eulerAngles.y.ToString("F1") + "\n" +
					"Z = " + transform.rotation.eulerAngles.z.ToString("F1");
			break;
		case "MapText":
			locations = GameObject.FindGameObjectsWithTag("Planet");
			GetComponent<Text>().text = locations[0].name + " : " + (locations[0].transform.position - transform.position) + "\n" +
				locations[1].name + " : " + (locations[1].transform.position - transform.position) + "\n" +
				locations[2].name + (locations[2].transform.position - transform.position) + "\n" +
				locations[3].name + " : " + (locations[3].transform.position - transform.position);
			break;
		case "CommText":
			GetComponent<Text>().text = "Fuel : " + GetComponentInParent<SpaceshipMotor>().fuel.ToString("F1") + "\n" + "Shields : " + "1200/1200" + "\n" +
				"Speed : " + GetComponentInParent<SpaceshipMotor>().speed.ToString("F1") + "\n"
					+ "X : " + GetComponentInParent<SpaceshipMotor>().curRot.x.ToString("F1") + "\n"
					+ "Y : " + GetComponentInParent<SpaceshipMotor>().curRot.y.ToString("F1") + "\n"
					+ "Z : " + GetComponentInParent<SpaceshipMotor>().curRot.z.ToString("F1");
			break;
		}
	}
}