﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUD_Interface : MonoBehaviour {

	// Update is called once per frame
	void FixedUpdate () {
		switch (name) {
		case "SpeedText":
			GetComponent<Text>().text = "Speed : " + GetComponentInParent<SpaceshipMotor>().speed.ToString("F1") + "   " +
				"Fuel : " + GetComponentInParent<SpaceshipMotor>().fuel.ToString("F1");
			break;
		case "HUD_Speed":
			if(GetComponentInParent<SpaceshipMotor>().speed > 0){
				GetComponent<RectTransform>().localScale = new Vector2(1, 0 + (GetComponentInParent<SpaceshipMotor>().speed / GetComponentInParent<SpaceshipMotor>().GetMaxSpeed()) / 2.5f);
				GetComponent<RectTransform>().localPosition = new Vector2(0.38f,-0.32f + GetComponentInParent<SpaceshipMotor>().speed / 720);
			}else{
				GetComponent<RectTransform>().localScale = new Vector2(1, 0 - (GetComponentInParent<SpaceshipMotor>().speed / GetComponentInParent<SpaceshipMotor>().GetMaxSpeed()) / 2.5f);
				GetComponent<RectTransform>().localPosition = new Vector2(0.38f,-0.32f + GetComponentInParent<SpaceshipMotor>().speed / 680);
			}
			break;
		case "HUD_Fuel":
			GetComponent<RectTransform>().localScale = new Vector2(1, 0 + (GetComponentInParent<SpaceshipMotor>().fuel / GetComponentInParent<SpaceshipMotor>().GetMaxFuel()) / 2.5f);
			GetComponent<RectTransform>().localPosition = new Vector2(0.424f, -0.32f + (GetComponentInParent<SpaceshipMotor>().fuel / 53000) / 2);
			break;
		}
	}
}
