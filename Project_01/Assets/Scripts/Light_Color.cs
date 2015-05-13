using UnityEngine;
using System.Collections;

public class Light_Color : MonoBehaviour {

	GameObject[] cockpitLights;

	void Start(){
		cockpitLights = GameObject.FindGameObjectsWithTag ("CockpitLight");
		SetColor (Color.blue);
	}

	public void SetColorRed(){
		SetColor (Color.red);
	}
	
	public void SetColorBlue(){
		SetColor (Color.blue);
	}
	
	public void SetColorGreen(){
		SetColor (Color.green);
	}

	void SetColor(Color color){
		for (int i = 0; i < cockpitLights.Length; i++) {
			cockpitLights[i].GetComponent<Light>().color = color;
		}
	}
}
