using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AICountry : MonoBehaviour {

	GameObject[] possibleTargets;
	GameObject[] enemies;
	public Vector2 target;
	float speed;
	int whatTarget;
	int difficulty = 1;
	bool canTravel;
	int furtherDistance;

	// Use this for initialization
	void Start () {
		SetDifficulty (GameObject.Find ("Handler").GetComponent<Handler> ().GetDifficulty ());
		possibleTargets = GameObject.FindGameObjectsWithTag ("Population");
		enemies = GameObject.FindGameObjectsWithTag ("Country");
	}
	
	// Update is called once per frame
	void Update () {
		furtherDistance = GetComponent<CountryMotor> ().GetPopulation () / 4;
		if (target == null || target == new Vector2 (0, 0) || possibleTargets [whatTarget] == null)
			FindNewTarget ();
		if (Vector3.Distance (transform.position, target) > 200 + furtherDistance) {
			canTravel = false;
			FindNewTarget ();
		} else
			canTravel = true;
		if (target != null && target != new Vector2(0,0) && canTravel) {
			GetComponent<CountryMotor>().Movement(target);
		}
		if (enemies == null)
			enemies = GameObject.FindGameObjectsWithTag ("Country");
		else
			CalculateEnemy ();
		if (target == new Vector2(transform.position.x, transform.position.y))
			FindNewTarget ();
	}

	void CalculateEnemy(){
		for (int i = 0; i < enemies.Length; i++) {
			if(enemies[i] != null){
				if(Vector3.Distance(enemies[i].transform.position, transform.position) <= 200 + furtherDistance && Vector3.Distance(enemies[i].transform.position, transform.position) > 1) {
					if(enemies[i].GetComponent<CountryMotor>().GetPopulation() < this.GetComponent<CountryMotor>().GetPopulation())
						target = enemies[i].transform.position;
				}
			}
		}
	}

	void FindNewTarget(){
		possibleTargets = GameObject.FindGameObjectsWithTag ("Population");
		whatTarget = Random.Range (0, possibleTargets.Length);
		target = possibleTargets[whatTarget].transform.position;
	}

	public void SetDifficulty(int value){
		difficulty = value;
	}
}
