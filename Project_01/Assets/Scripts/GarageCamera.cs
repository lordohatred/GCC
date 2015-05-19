using UnityEngine;
using System.Collections;

public class GarageCamera : MonoBehaviour {

	bool showColors = false;
	bool primColor = false;
	bool secColor = false;
	bool detColor = false;
	bool glassColor = false;
	GameObject[] shipParts;
	public Material[] Primary;
	public Material[] Secondary;
	public Material[] Detail;
	public Material[] Glass;
	Material[] primMats;
	bool canStart = false;
	ShipMaster ship;

	// Use this for initialization
	void Start () {
		GameObject.Find ("Main Camera").GetComponent<MouseLook> ().enabled = false;
		GameObject.Find ("CameraHolder").GetComponent<MouseLook> ().enabled = false;
		GameObject.Find ("Player").GetComponent<PlayerController> ().enabled = false;
		GameObject.Find ("Player").GetComponent<SpaceshipMotor> ().enabled = false;
		shipParts = GameObject.FindGameObjectsWithTag ("ShipParts");
		for (int i = 0; i < shipParts.Length; i++) {
			shipParts[i].GetComponent<Renderer>().materials[0].color = Color.white;
			shipParts[i].GetComponent<Renderer>().materials[1].color = Color.white;
			shipParts[i].GetComponent<Renderer>().materials[2].color = Color.white;
			if(shipParts[i].GetComponent<Renderer>().materials.Length > 3)
				shipParts[i].GetComponent<Renderer>().materials[3].color = Color.white;
		}
		ship = GameObject.Find ("ShipMaster").GetComponent<ShipMaster> ();
	}
	
	// Update is called once per frame
	void Update () {
        if (shipParts == null)
            for (int i = 0; i < shipParts.Length; i++) {
                shipParts[i].GetComponent<Renderer> ().materials[0].color = Color.white;
                shipParts[i].GetComponent<Renderer> ().materials[1].color = Color.white;
                shipParts[i].GetComponent<Renderer> ().materials[2].color = Color.white;
                if (shipParts[i].GetComponent<Renderer> ().materials.Length > 3)
                    shipParts[i].GetComponent<Renderer> ().materials[3].color = Color.white;
            }
		Ray vray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit = new RaycastHit();
		if(Physics.Raycast(vray, out hit)){
			if(hit.collider.name != null && Input.GetMouseButtonDown(0)){
				if(hit.collider.tag == "SelectionCube"){
					hit.collider.GetComponent<ShipSelectionScript>().ToggleSelection();

				}
			}
		}
		if (ship.cockpit != -1 && ship.wings != -1 && ship.engines != -1)
			canStart = true;
	}

	void ShowColorPicker(int windowID){
		if (!primColor && !secColor && !detColor && !glassColor) {
			if (GUI.Button (new Rect (25, 25, 200, 75), "Primary Color")) {
				primColor = true;
			}
//			if (GUI.Button (new Rect (250, 25, 200, 75), "Secondary Color")) {
//				secColor = true;
//			}
//			if (GUI.Button (new Rect (475, 25, 200, 75), "Detail Color")) {
//				detColor = true;
//			}
//			if (GUI.Button (new Rect (700, 25, 200, 75), "Glass Color")) {
//				glassColor = true;
//			}
			if (GUI.Button (new Rect (925, 25, 200, 75), "Close Window")) {
				showColors = false;
			}
		}
		if (primColor) {
			if (GUI.Button (new Rect (25, 25, 200, 75), "White")) {
				ChangePrimColor("White");
			}
			if (GUI.Button (new Rect (250, 25, 200, 75), "Black")) {
				ChangePrimColor("Black");
			}
			if (GUI.Button (new Rect (475, 25, 200, 75), "Red")) {
				ChangePrimColor("Red");
			}
			if (GUI.Button (new Rect (700, 25, 200, 75), "Blue")) {
				ChangePrimColor("Blue");
			}
			if (GUI.Button (new Rect (925, 25, 200, 75), "Close Window")) {
				primColor = false;
			}
		}
		if (secColor) {
			if (GUI.Button (new Rect (25, 25, 200, 75), "Blue")) {
				ChangeSecColor("Blue");
			}
			if (GUI.Button (new Rect (250, 25, 200, 75), "Orange")) {
				ChangeSecColor("Orange");
			}
			if (GUI.Button (new Rect (475, 25, 200, 75), "Green")) {
				ChangeSecColor("Green");
			}
			if (GUI.Button (new Rect (700, 25, 200, 75), "Black")) {
				ChangeSecColor("Black");
			}
			if (GUI.Button (new Rect (925, 25, 200, 75), "Close Window")) {
				secColor = false;
			}
		}
		if (detColor) {
			if (GUI.Button (new Rect (25, 25, 200, 75), "Plastic")) {
				ChangeDetColor("Plastic");
			}
			if (GUI.Button (new Rect (250, 25, 200, 75), "Rubber")) {
				ChangeDetColor("Rubber");
			}
			if (GUI.Button (new Rect (475, 25, 200, 75), "Steel")) {
				ChangeDetColor("Steel");
			}
			if (GUI.Button (new Rect (700, 25, 200, 75), "Gold")) {
				ChangeDetColor("Gold");
			}
			if (GUI.Button (new Rect (925, 25, 200, 75), "Close Window")) {
				detColor = false;
			}
		}
		if (glassColor) {
			if (GUI.Button (new Rect (25, 25, 200, 75), "Black")) {
				ChangeGlassColor("Black");
			}
			if (GUI.Button (new Rect (250, 25, 200, 75), "Mirror")) {
				ChangeGlassColor("Mirror");
			}
			if (GUI.Button (new Rect (475, 25, 200, 75), "Gold")) {
				ChangeGlassColor("Gold");
			}
			if (GUI.Button (new Rect (700, 25, 200, 75), "Blue")) {
				ChangeGlassColor("Blue");
			}
			if (GUI.Button (new Rect (925, 25, 200, 75), "Close Window")) {
				glassColor = false;
			}
		}
	}

#region ColorChangers
	void ChangePrimColor(string color){
		switch (color) {
		case "White":
			for(int i = 0; i < shipParts.Length; i++){
				shipParts[i].GetComponent<Renderer>().materials[0].color = Color.white;
				shipParts[i].GetComponent<Renderer>().materials[1].color = Color.white;
				shipParts[i].GetComponent<Renderer>().materials[2].color = Color.white;
				if(shipParts[i].GetComponent<Renderer>().materials.Length > 3)
					shipParts[i].GetComponent<Renderer>().materials[3].color = Color.white;
			}
			break;
		case "Black":
			for(int i = 0; i < shipParts.Length; i++){
				shipParts[i].GetComponent<Renderer>().materials[0].color = Color.black;
				shipParts[i].GetComponent<Renderer>().materials[1].color = Color.black;
				shipParts[i].GetComponent<Renderer>().materials[2].color = Color.black;
				if(shipParts[i].GetComponent<Renderer>().materials.Length > 3)
					shipParts[i].GetComponent<Renderer>().materials[3].color = Color.black;
			}
			break;
		case "Red":
			for(int i = 0; i < shipParts.Length; i++){
				shipParts[i].GetComponent<Renderer>().materials[0].color = Color.red;
				shipParts[i].GetComponent<Renderer>().materials[1].color = Color.red;
				shipParts[i].GetComponent<Renderer>().materials[2].color = Color.red;
				if(shipParts[i].GetComponent<Renderer>().materials.Length > 3)
					shipParts[i].GetComponent<Renderer>().materials[3].color = Color.red;
			}
			break;
		case "Blue":
			for(int i = 0; i < shipParts.Length; i++){
				shipParts[i].GetComponent<Renderer>().materials[0].color = Color.blue;
				shipParts[i].GetComponent<Renderer>().materials[1].color = Color.blue;
				shipParts[i].GetComponent<Renderer>().materials[2].color = Color.blue;
				if(shipParts[i].GetComponent<Renderer>().materials.Length > 3)
					shipParts[i].GetComponent<Renderer>().materials[3].color = Color.blue;
			}
			break;
		}
	}

	void ChangeSecColor(string color){
		switch (color) {
		case "Blue":
			for(int i = 0; i < shipParts.Length; i++){
				shipParts[i].GetComponent<Renderer>().material = Secondary[0];
			}
			break;
		case "Orange":
			for(int i = 0; i < shipParts.Length; i++){
				shipParts[i].GetComponent<Renderer>().material = Secondary[1];
			}
			break;
		case "Green":
			for(int i = 0; i < shipParts.Length; i++){
				shipParts[i].GetComponent<Renderer>().material = Secondary[2];
			}
			break;
		case "Black":
			for(int i = 0; i < shipParts.Length; i++){
				shipParts[i].GetComponent<Renderer>().material = Secondary[3];
			}
			break;
		}
	}

	void ChangeDetColor(string color){
		switch (color) {
		case "Plastic":
			for(int i = 0; i < shipParts.Length; i++){
				shipParts[i].GetComponent<Renderer>().material = Detail[0];
			}
			break;
		case "Rubber":
			for(int i = 0; i < shipParts.Length; i++){
				shipParts[i].GetComponent<Renderer>().material = Detail[1];
			}
			break;
		case "Steel":
			for(int i = 0; i < shipParts.Length; i++){
				shipParts[i].GetComponent<Renderer>().material = Detail[2];
			}
			break;
		case "Gold":
			for(int i = 0; i < shipParts.Length; i++){
				shipParts[i].GetComponent<Renderer>().material = Detail[3];
			}
			break;
		}
	}

	void ChangeGlassColor(string color){
		switch (color) {
		case "Black":
			for(int i = 0; i < shipParts.Length; i++){
				shipParts[i].GetComponent<Renderer>().material = Glass[0];
			}
			break;
		case "Mirror":
			for(int i = 0; i < shipParts.Length; i++){
				shipParts[i].GetComponent<Renderer>().material = Glass[1];
			}
			break;
		case "Gold":
			for(int i = 0; i < shipParts.Length; i++){
				shipParts[i].GetComponent<Renderer>().material = Glass[2];
			}
			break;
		case "Blue":
			for(int i = 0; i < shipParts.Length; i++){
				shipParts[i].GetComponent<Renderer>().material = Glass[3];
			}
			break;
		}
	}
#endregion

	void OnGUI(){
		if (showColors) {
			GUI.Window(1, new Rect(Screen.width / 6, Screen.height / 1.15f, Screen.width / 1.5f, Screen.height / 8), ShowColorPicker, "Color Scheme");
		}
		if (!showColors) {
			if(GUI.Button(new Rect( Screen.width / 1.2f, Screen.height / 1.15f, Screen.width / 8, Screen.height / 8), "Show Colors")){
				showColors = true;
			}
		}
		if (canStart)
			if (GUI.Button (new Rect (Screen.width / 1.2f, Screen.height / 1.35f, Screen.width / 8, Screen.height / 8), "Head out!")) {
				Application.LoadLevel(Application.loadedLevel + 1);
			}
	}
}
