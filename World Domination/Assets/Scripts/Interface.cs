using UnityEngine;
using System.Collections;

public class Interface : MonoBehaviour {

	string attacker, defender;
	bool showLeaderboards = true;
	GameObject[] countryList;
	int score1, score2, score3, score4, score5;
	string country1, country2, country3, country4, country5;
	public GUIStyle style;

	// Use this for initialization
	void Start () {
		score1 = 10;
		score2 = 10;
		score3 = 10;
		score4 = 10;
		score5 = 10;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Tab))
			showLeaderboards = !showLeaderboards;
		countryList = GameObject.FindGameObjectsWithTag ("Country");
		CalculateLeaderboards ();
	}

	void CalculateLeaderboards(){
		for (int i = 0; i < countryList.Length; i++) {
			if (countryList [i] != null) {
				if (countryList [i].GetComponent<CountryMotor> ().GetPopulation () > score5) {
					if (countryList [i].GetComponent<CountryMotor> ().GetPopulation () > score4) {
						if (countryList [i].GetComponent<CountryMotor> ().GetPopulation () > score3) {
							if (countryList [i].GetComponent<CountryMotor> ().GetPopulation () > score2) {
								if (countryList [i].GetComponent<CountryMotor> ().GetPopulation () > score1) {
									score1 = countryList[i].GetComponent<CountryMotor>().GetPopulation();
									country1 = countryList[i].name;
								} else {
									if(countryList [i].GetComponent<CountryMotor> ().GetPopulation () != score1){
										score2 = countryList[i].GetComponent<CountryMotor>().GetPopulation();
										country2 = countryList[i].name;
									}
								}
							} else {
								if(countryList [i].GetComponent<CountryMotor> ().GetPopulation () != score2){
									score3 = countryList[i].GetComponent<CountryMotor>().GetPopulation();
									country3 = countryList[i].name;
								}
							}
							} else {
								if(countryList [i].GetComponent<CountryMotor> ().GetPopulation () != score3){
									score4 = countryList[i].GetComponent<CountryMotor>().GetPopulation();
									country4 = countryList[i].name;
							}
						}
							} else {
						if(countryList [i].GetComponent<CountryMotor> ().GetPopulation () != score4){
							score5 = countryList[i].GetComponent<CountryMotor>().GetPopulation();
							country5 = countryList[i].name;
						}
					}
				}
			}
		}
	}

	
//	if (countryList [i].GetComponent<CountryMotor> ().GetPopulation () > score1) {
//		score1 = countryList [i].GetComponent<CountryMotor> ().GetPopulation ();
//		country1 = countryList [i].name;
//	}

	public void ShowAnexation(string big, string small){
		attacker = big;
		defender = small;
	}

	void OnGUI(){
		if (attacker != null && defender != null) {
			GUI.Label (new Rect (Screen.width / 2 - 125, Screen.height - 50, 250, 50), attacker + " just annexed " + defender, style);
		}
		if (showLeaderboards) {
			if(country1 != "")
				GUI.Label(new Rect(Screen.width - 250, 30, 250, 25), "#1 " + score1.ToString() + " " + country1, style);
			if(country2 != "")
				GUI.Label(new Rect(Screen.width - 250, 55, 250, 25), "#2 " + score2.ToString() + " " + country2, style);
			if(country3 != "")
				GUI.Label(new Rect(Screen.width - 250, 80, 250, 25), "#3 " + score3.ToString() + " " + country3, style);
			if(country4 != "")
				GUI.Label(new Rect(Screen.width - 250, 105, 250, 25), "#4 " + score4.ToString() + " " + country4, style);
			if(country5 != "")
				GUI.Label(new Rect(Screen.width - 250, 130, 250, 25), "#5 " + score5.ToString() + " " + country5, style);
		}
	}
}
