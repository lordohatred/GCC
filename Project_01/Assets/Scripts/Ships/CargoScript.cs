using UnityEngine;
using System.Collections;

public class CargoScript : MonoBehaviour {

	int steel = 0;
	int spice = 5;
	int weaponParts = 0;
	int clothes = 0;
	int cargoUsed;
	public int money = 250;

	void Update(){
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
