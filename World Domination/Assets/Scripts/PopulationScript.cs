using UnityEngine;
using System.Collections;

public class PopulationScript : MonoBehaviour {

	int colorRange;
	Renderer rend;

	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer> ();
		colorRange = Random.Range (0, 5);
		switch (colorRange) {
		case 1:
			rend.material.color = Color.red;
			break;
		case 2:
			rend.material.color = Color.green;
			break;
		case 3:
			rend.material.color = Color.blue;
			break;
		case 4:
			rend.material.color = Color.yellow;
			break;
		case 5:
			rend.material.color = Color.cyan;
			break;
		default:
			rend.material.color = Color.magenta;
			break;
		}
	}
}
