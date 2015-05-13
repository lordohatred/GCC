using UnityEngine;
using System.Collections;

public class MainMenuScript : MonoBehaviour {

	bool showStart;
	bool showMap;
	bool showDiff;
	int mapNumber = 0;
	string mapName;
	string playerName = "";

	// Use this for initialization
	void Start () {
		showStart = true;
		ChangeMap (mapNumber);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Start(int windowID){
		if (GUI.Button (new Rect (25, 25, Screen.width / 4.45f, 50), "Start Game"))
			StartGame ();
		if (GUI.Button (new Rect (25, 85, Screen.width / 4.45f, 50), "Change Map")) {
			showStart = false;
			showMap = true;
		}
		if (GUI.Button (new Rect (25, 145, Screen.width / 4.45f, 50), "Game Options")) {
			showStart = false;
			showDiff = true;
		}
		if (GUI.Button (new Rect (25, 530, Screen.width / 4.45f, 50), "Exit"))
			Application.Quit ();
	}

	void MapOptions(int windowID){
		GUI.Label (new Rect (Screen.width / 9.5f, 25, 100, 50), "Current map:");
		GUI.Label (new Rect (Screen.width / 9.5f, 75, 100, 50), mapName);
		if (GUI.Button (new Rect (25, 460, Screen.width / 8.9f, 50), "-")) {
			mapNumber--;
			if(mapNumber == -1)
				mapNumber = 1;
			ChangeMap(mapNumber);
		}
		if (GUI.Button (new Rect (25 + Screen.width / 8.9f, 460, Screen.width / 8.9f, 50), "+")) {
			mapNumber++;
			if(mapNumber == 2)
				mapNumber = 0;
				ChangeMap(mapNumber);
		}
		if (GUI.Button (new Rect (25, 530, Screen.width / 4.45f, 50), "Back")) {
			GameObject.Find("Handler").GetComponent<Handler>().whatMapToSpawn(mapNumber);
			showMap = false;
			showStart = true;
		}
	}

	void GameSettings(int windowID){
		GUI.Label (new Rect (Screen.width / 8.9f, 25, 100, 100), "Difficulty:");
		if (GUI.Button (new Rect (25, 50, Screen.width / 4.45f, 50), "Easy")) {
			GameObject.Find("Handler").GetComponent<Handler>().SetSpawnRate(2500, 10);
			GameObject.Find("Handler").GetComponent<Handler>().SetDifficulty(0);
		}
		if (GUI.Button (new Rect (25, 110, Screen.width / 4.45f, 50), "Medium")) {
			GameObject.Find("Handler").GetComponent<Handler>().SetSpawnRate(2000, 25);
			GameObject.Find("Handler").GetComponent<Handler>().SetDifficulty(1);
		}
		if (GUI.Button (new Rect (25, 170, Screen.width / 4.45f, 50), "Hard")) {
			GameObject.Find("Handler").GetComponent<Handler>().SetSpawnRate(1000, 50);
			GameObject.Find("Handler").GetComponent<Handler>().SetDifficulty(2);
		}
		GUI.Label (new Rect (Screen.width / 8.9f, 220, 100, 100), "Please enter your name");
		playerName = GUI.TextArea (new Rect (25, 255, Screen.width / 4.45f, 50), playerName, 25);
		if (GUI.Button (new Rect (25, 315, Screen.width / 4.45f, 50), "Save name")) {
				GameObject.Find ("Handler").GetComponent<Handler> ().SetPlayerName (playerName);
		}
		if (GUI.Button (new Rect (25, 530, Screen.width / 4.45f, 50), "Back")) {
			showDiff = false;
			showStart = true;
		}
	}

	void StartGame(){
		Application.LoadLevel (1);
		GameObject.Find ("Handler").GetComponent<Handler> ().CanSpawn (true);
	}

	void ChangeMap(int value){
		switch(mapNumber){
		case 0:
			mapName = "Neon Earth";
			break;
		case 1:
			mapName = "Old Map";
			break;
		}
	}

	void OnGUI(){
		if(showStart)
			GUI.Window (1, new Rect (Screen.width / 2 - Screen.width / 8, Screen.height / 10, Screen.width / 4, Screen.height / 1.5f), Start, "Main Menu");
		if(showMap)
			GUI.Window (1, new Rect (Screen.width / 2 - Screen.width / 8, Screen.height / 10, Screen.width / 4, Screen.height / 1.5f), MapOptions, "Map Options");
		if(showDiff)
			GUI.Window (1, new Rect (Screen.width / 2 - Screen.width / 8, Screen.height / 10, Screen.width / 4, Screen.height / 1.5f), GameSettings, "Gameplay Settings");
	}
}
