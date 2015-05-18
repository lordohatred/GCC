using UnityEngine;
using System.Collections;

public class CargoScript : MonoBehaviour {

	int steel = 0;
	string steelString;
	int spice = 5;
	string spiceString;
	int weaponParts = 0;
	string weaponString;
	int clothes = 0;
	string clothesString;
	string cargo = "Suck on my nads";
	int cargoUsed;
	public int money = 250;

	void Update(){
		if (steel > 0)
			steelString = "Steel : " + steel.ToString ();
		else
			steelString = "Steel : N/A";
		if (spice > 0)
			spiceString = "Spice : " + spice.ToString ();
		else
			spiceString = "Spice : N/A";
		if (weaponParts > 0)
			weaponString = "Weapon Parts : " + weaponParts.ToString ();
		else
			weaponString = "Weapon Parts : N/A";
		if (clothes > 0)
			clothesString = "Clothes : " + clothes.ToString ();
		else
			clothesString = "Clothes : N/A";
		if (steel > 0 || spice > 0 || weaponParts > 0 || clothes > 0)
			cargo = "Money = " + money.ToString() + "\n" + steelString + "\n" + spiceString + "\n" + weaponString + "\n" + clothesString + "\n" + "Current Cargo" + "\n"
				+ cargoUsed + "/" + GetComponentInParent<SpaceshipMotor>().CargoSpace;
		else
			cargo = "Money = " + money.ToString() + "\nCargo hold is empty.";
		cargoUsed = steel + spice + weaponParts + clothes;
	}
	
	public int GetSteel(){
		return steel;
	}
	
	public int GetSpice(){
		return spice;
	}
	
	public int GetWeaponParts(){
		return weaponParts;
	}
	
	public int GetClothes(){
		return clothes;
	}
	
	public string GetCargo(){
		return cargo;
	}
	
	public int GetCargoUsed(){
		return cargoUsed;
	}

	public void AddjustSteel(int value){
		steel += value;
	}

	public void AddjustSpice(int value){
		spice += value;
	}

	public void AddjustWeaponParts(int value){
		weaponParts += value;
	}

	public void AddjustClothes(int value){
		clothes += value;
	}
}
