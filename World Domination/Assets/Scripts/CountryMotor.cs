using UnityEngine;
using System.Collections;

public class CountryMotor : MonoBehaviour {

	public int population;
	public float speed = 1;
	float baseSpeed;
	public bool isPlayer = false;
	float multiplier = 0.005f;
	int enemyHandicap = 3;

	// Use this for initialization
	void Start () {
		SetDifficulty(GameObject.Find ("Handler").GetComponent<Handler> ().GetDifficulty());
		name = GetComponent<SpriteRenderer> ().sprite.texture.name;
		population = 5;
		if (isPlayer)
			GetComponent<AICountry> ().enabled = false;
		else
			GetComponent<PlayerCountry> ().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (isPlayer) {
			baseSpeed = 1.2f;
			if(GameObject.Find("Handler").GetComponent<Handler>().GetPlayerName() != null)
				name = GameObject.Find("Handler").GetComponent<Handler>().GetPlayerName();
		}
		else 
			baseSpeed = 0.8f + (1 / enemyHandicap);
	}

	void Expand(int popGrowth){
		transform.localScale += new Vector3 (multiplier * popGrowth, multiplier * popGrowth, 0);
		if (speed > 0.2f) {
			if (isPlayer)
				speed = baseSpeed + ((-multiplier / 2) * popGrowth) / 5;
			else {
				speed = baseSpeed + (-multiplier * popGrowth) / enemyHandicap;
			}
		} else
			speed = 0.2f;
	}

	public void Movement(Vector2 target){
		if (isPlayer)
			transform.position = Vector2.MoveTowards (transform.position, target, speed);
		else
			transform.position = Vector2.MoveTowards (transform.position, target, (speed * 60) * Time.deltaTime);
	}

	public int GetPopulation(){
		return population;
	}

	public void AddPopulation(int popCount){
		population += popCount;
		Expand (popCount);
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Population") {
			AddPopulation(1);
			Destroy(other.gameObject);
		}
		if (other.gameObject.GetComponent<CountryMotor> () != null) {
			if (other.gameObject.GetComponent<CountryMotor> ().GetPopulation () < population) {
				GameObject.Find("Interface").GetComponent<Interface>().ShowAnexation(this.name, other.name);
				AddPopulation(other.gameObject.GetComponent<CountryMotor> ().GetPopulation ());
				Destroy (other.gameObject);
			}
		}
	}

	public void SetDifficulty(int difficulty){
		switch (difficulty) {
		case 0:
			enemyHandicap = 5;
			break;
		case 1:
			enemyHandicap = 3;
			break;
		case 2:
			enemyHandicap = 2;
			break;
		}
	}
}
