﻿using UnityEngine;
using System.Collections;

public class MerchantScript : MonoBehaviour {

	public bool inRange = false;
	int steel = 0;
	int spice = 0;
	int weaponParts = 0;
	int clothes = 0;
	int money = 0;
	int steelPrice = 0;
	int spicePrice = 0;
	int weaponPrice = 0;
	int clothesPrice = 0;
	public Material[] mat;
	Renderer[] rend;

	// Use this for initialization
	void Start () {
		rend = GetComponentsInChildren<Renderer> ();
		for (int i = 0; i < rend.Length; i++) {
			rend[i].material = mat [Random.Range (0, 3)];
		}
		steel = Random.Range (0, 50);
		spice = Random.Range (0, 15);
		weaponParts = Random.Range (0, 80);
		clothes = Random.Range (0, 150);
		steelPrice = Random.Range (15, 45);
		spicePrice = Random.Range (80, 122);
		weaponPrice = Random.Range (30, 80);
		clothesPrice = Random.Range (5, 50);
		money = Random.Range (250, 1000);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		if (other.name == "Player")
			inRange = true;
		GameObject.Find ("Player").GetComponent<SpaceshipMotor> ().MaxSpeed = (5);
		GameObject.Find ("Player").GetComponent<SpaceshipMotor> ().Gravity = (0);
	}
	
	void OnTriggerExit(Collider other){
		if (other.name == "Player")
			inRange = false;
		GameObject.Find ("Player").GetComponent<SpaceshipMotor> ().MaxSpeed = (50);
		GameObject.Find ("Player").GetComponent<SpaceshipMotor> ().Gravity = (0.1f);
	}

	void ShowShop(int windowID){
		GUI.Label (new Rect (30, 20, 125, 25), money.ToString() + "  Money  " + GameObject.Find("Cargo").GetComponent<CargoScript>().money.ToString());
		GUI.Label (new Rect (30, 50, 140, 25), steel.ToString() + "  Steel  " + GameObject.Find("Cargo").GetComponent<CargoScript>().GetSteel().ToString());
		GUI.Label (new Rect (30, 80, 140, 25), spice.ToString() + "  Spice  " + GameObject.Find("Cargo").GetComponent<CargoScript>().GetSpice().ToString());
		GUI.Label (new Rect (30, 110, 140, 25), weaponParts.ToString() + "  Weapon Parts  " + GameObject.Find("Cargo").GetComponent<CargoScript>().GetWeaponParts().ToString());
		GUI.Label (new Rect (30, 140, 140, 25), clothes.ToString() + "  Clothes  " + GameObject.Find("Cargo").GetComponent<CargoScript>().GetClothes().ToString());
		if(GUI.Button(new Rect(160, 50, 100, 25), "Buy")){
			if(steel > 0 && GameObject.Find("Cargo").GetComponent<CargoScript>().money > 0 &&
					GameObject.Find("Cargo").GetComponent<CargoScript>().GetCargoUsed() < GameObject.Find("Player").GetComponent<SpaceshipMotor>().CargoSpace){
				GameObject.Find("Cargo").GetComponent<CargoScript>().AddjustSteel(1);
				GameObject.Find("Cargo").GetComponent<CargoScript>().money -= steelPrice + 1;
				steel--;
				money += steelPrice +1;
			}
		}
		if(GUI.Button(new Rect(260, 50, 100, 25), "Sell")){
			if(GameObject.Find("Cargo").GetComponent<CargoScript>().GetSteel() > 0 && money > 0){
				GameObject.Find("Cargo").GetComponent<CargoScript>().AddjustSteel(-1);
				GameObject.Find("Cargo").GetComponent<CargoScript>().money += steelPrice - 1;
				money -= steelPrice -1;
				steel++;
			}
		}
		if(GUI.Button(new Rect(160, 80, 100, 25), "Buy")){
			if(spice > 0 && GameObject.Find("Cargo").GetComponent<CargoScript>().money > 0 &&
					GameObject.Find("Cargo").GetComponent<CargoScript>().GetCargoUsed() < GameObject.Find("Player").GetComponent<SpaceshipMotor>().CargoSpace){
				GameObject.Find("Cargo").GetComponent<CargoScript>().AddjustSpice(1);
				GameObject.Find("Cargo").GetComponent<CargoScript>().money -= spicePrice + 1;
				spice--;
				money += spicePrice +1;
			}
		}
		if(GUI.Button(new Rect(260, 80, 100, 25), "Sell")){
			if(GameObject.Find("Cargo").GetComponent<CargoScript>().GetSpice() > 0 && money > 0){
				GameObject.Find("Cargo").GetComponent<CargoScript>().AddjustSpice(-1);
				GameObject.Find("Cargo").GetComponent<CargoScript>().money += spicePrice - 1;
				money -= spicePrice -1;
				spice++;
			}
		}
		if(GUI.Button(new Rect(160, 110, 100, 25), "Buy")){
			if(weaponParts > 0 && GameObject.Find("Cargo").GetComponent<CargoScript>().money > 0 &&
				   GameObject.Find("Cargo").GetComponent<CargoScript>().GetCargoUsed() < GameObject.Find("Player").GetComponent<SpaceshipMotor>().CargoSpace){
				GameObject.Find("Cargo").GetComponent<CargoScript>().AddjustWeaponParts(1);
				GameObject.Find("Cargo").GetComponent<CargoScript>().money -= weaponPrice + 1;
				weaponParts--;
				money += weaponPrice +1;
			}
		}
		if(GUI.Button(new Rect(260, 110, 100, 25), "Sell")){
			if(GameObject.Find("Cargo").GetComponent<CargoScript>().GetWeaponParts() > 0 && money > 0){
				GameObject.Find("Cargo").GetComponent<CargoScript>().AddjustWeaponParts(-1);
				GameObject.Find("Cargo").GetComponent<CargoScript>().money += weaponPrice - 1;
				money -= weaponPrice -1;
				weaponParts++;
			}
		}
		if(GUI.Button(new Rect(160, 140, 100, 25), "Buy")){
			if(clothes > 0 && GameObject.Find("Cargo").GetComponent<CargoScript>().money > 0 &&
					GameObject.Find("Cargo").GetComponent<CargoScript>().GetCargoUsed() < GameObject.Find("Player").GetComponent<SpaceshipMotor>().CargoSpace){
				GameObject.Find("Cargo").GetComponent<CargoScript>().AddjustClothes(1);
				GameObject.Find("Cargo").GetComponent<CargoScript>().money -= clothesPrice + 1;
				clothes--;
				money += clothesPrice +1;
			}
		}
		if(GUI.Button(new Rect(260, 140, 100, 25), "Sell")){
			if(GameObject.Find("Cargo").GetComponent<CargoScript>().GetClothes() > 0 && money > 0){
				GameObject.Find("Cargo").GetComponent<CargoScript>().AddjustClothes(-1);
				GameObject.Find("Cargo").GetComponent<CargoScript>().money += clothesPrice - 1;
				money -= clothesPrice -1;
				clothes++;
			}
		}
		GUI.Label (new Rect (30, 160, 200, 25), "Steel is worth : " + steelPrice.ToString ());
		GUI.Label (new Rect (30, 190, 200, 25), "Spice is worth : " + spicePrice.ToString ());
		GUI.Label (new Rect (30, 220, 250, 25), "Weapon Parts are worth : " + weaponPrice.ToString ());
		GUI.Label (new Rect (30, 250, 200, 25), "Clothes are worth : " + clothesPrice.ToString ());
		if(GUI.Button(new Rect (30, 280, 250, 50), "Refuel for " + 
		              ((GameObject.Find("Player").GetComponent<SpaceshipMotor>().MaxFuel - GameObject.Find("Player").GetComponent<SpaceshipMotor>().Fuel) / 8).ToString("F0"))){
			if(GameObject.Find("Cargo").GetComponent<CargoScript>().money >
			   (GameObject.Find("Player").GetComponent<SpaceshipMotor>().MaxFuel - GameObject.Find("Player").GetComponent<SpaceshipMotor>().Fuel) / 8){

				GameObject.Find("Player").GetComponent<SpaceshipMotor>().Fuel = GameObject.Find("Player").GetComponent<SpaceshipMotor>().MaxFuel;
				GameObject.Find("Cargo").GetComponent<CargoScript>().money -= 
					(int)(GameObject.Find("Player").GetComponent<SpaceshipMotor>().MaxFuel - GameObject.Find("Player").GetComponent<SpaceshipMotor>().Fuel) / 8;
				money += (int)(GameObject.Find("Player").GetComponent<SpaceshipMotor>().MaxFuel - GameObject.Find("Player").GetComponent<SpaceshipMotor>().Fuel) / 8;
			}
		}
		if (GUI.Button (new Rect (30, 340, 250, 50), "Upgrade Acceleration for 1500")) {
			if(GameObject.Find("Cargo").GetComponent<CargoScript>().money > 1500){
				GameObject.Find("Cargo").GetComponent<CargoScript>().money -= 1500;
				GameObject.Find("Player").GetComponent<SpaceshipMotor>().Acceleration = (2.5f + GameObject.Find("Player").GetComponent<SpaceshipMotor>().Acceleration);
			}
		}
		if (GUI.Button (new Rect (30, 400, 250, 50), "Upgrade Max Speed for 1500")) {
			if(GameObject.Find("Cargo").GetComponent<CargoScript>().money > 1500){
				GameObject.Find("Cargo").GetComponent<CargoScript>().money -= 1500;
				GameObject.Find("Player").GetComponent<SpaceshipMotor>().Speed = (25 + GameObject.Find("Player").GetComponent<SpaceshipMotor>().Acceleration);
			}
		}
		if (GUI.Button (new Rect (30, 460, 250, 50), "Upgrade Max Fuel for 1500")) {
			if(GameObject.Find("Cargo").GetComponent<CargoScript>().money > 1500){
				GameObject.Find("Cargo").GetComponent<CargoScript>().money -= 1500;
				GameObject.Find("Player").GetComponent<SpaceshipMotor>().MaxFuel = (7500 + GameObject.Find("Player").GetComponent<SpaceshipMotor>().MaxFuel);
			}
		}
		if (GUI.Button (new Rect (30, 520, 250, 50), "Upgrade Turn Speed for 1500")) {
			if(GameObject.Find("Cargo").GetComponent<CargoScript>().money > 1500){
				GameObject.Find("Cargo").GetComponent<CargoScript>().money -= 1500;
				GameObject.Find("Player").GetComponent<SpaceshipMotor>().TurnSpeed = (10 + GameObject.Find("Player").GetComponent<SpaceshipMotor>().TurnSpeed);
			}
		}
		if (GUI.Button (new Rect (30, 580, 250, 50), "Upgrade Cargohold for 1500")) {
			if(GameObject.Find("Cargo").GetComponent<CargoScript>().money > 1500){
				GameObject.Find("Cargo").GetComponent<CargoScript>().money -= 1500;
				GameObject.Find("Player").GetComponent<SpaceshipMotor>().CargoSpace = (25 +GameObject.Find("Player").GetComponent<SpaceshipMotor>().CargoSpace);
			}
		}
	}

	void OnGUI(){
		if (inRange) {
			GUI.Window(1, new Rect(Screen.width / 12, Screen.height / 12, Screen.width / 5, Screen.height / 1.3f), ShowShop, "Merchant");
		}
	}
}
