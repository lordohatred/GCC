using UnityEngine;
using System.Collections;

public class Handler : MonoBehaviour {
	
	public Vector2 size;
	public Vector2 maxPop;
	public GameObject[] Country;
	public GameObject pop;
	public GameObject player;
	public GameObject[] map;
	bool canSpawn = false;
	bool canSpawnMap = true;
	int mapNumber = 0;
	int difficulty = 1;
	string playerName;
	int maxCountries = 0, spawnedCountries = 0;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Country");
		DontDestroyOnLoad (this);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (canSpawn){
			if(Input.GetKeyDown(KeyCode.Escape)){
				CanSpawn(false);
				Application.LoadLevel(0);
			}
			if(canSpawnMap){
				Instantiate (map [mapNumber], new Vector3 (0, 0, 2), Quaternion.Euler(90,180,0));
				canSpawnMap = false;
			}
			if(player == null)
				player = GameObject.FindGameObjectWithTag ("Country");
			if (player != null) {
				player.GetComponent<AICountry> ().enabled = false;
				player.GetComponent<PlayerCountry> ().enabled = true;
				player.GetComponent<CountryMotor>().isPlayer = true;
				GameObject.Find("Main Camera").GetComponent<CameraFollowPlayerScript>().player = player.transform.position;
				GameObject.Find("Main Camera").GetComponent<Camera>().orthographicSize = player.transform.localScale.x * 50;
			}
			if (GameObject.FindGameObjectsWithTag ("Population").Length <= maxPop.x)
				InstantiateCountries();
			if(GameObject.FindGameObjectsWithTag("Country").Length <= maxPop.y)
				InstantiatePopulation();
		}
	}

	void InstantiateCountries(){
		if (maxCountries != 0) {
			if(spawnedCountries < maxCountries){
				Instantiate (pop, new Vector3 (Random.Range (size.x, -size.x), Random.Range (size.y, -size.y), 0), transform.rotation);
				spawnedCountries++;
			}
		}
		else
			Instantiate (pop, new Vector3 (Random.Range (size.x, -size.x), Random.Range (size.y, -size.y), 0), transform.rotation);
	}

	void InstantiatePopulation(){
		Instantiate (Country[Random.Range(0, Country.Length)], new Vector3 (Random.Range (size.x, -size.x), Random.Range (size.y, -size.y), 0), transform.rotation);
	}

	public void SetSpawnRate(int population, int players){
		maxPop.x = population;
		maxPop.y = players;
	}

	public void CanSpawn(bool value){
		canSpawn = value;
		canSpawnMap = value;
	}

	public void whatMapToSpawn(int value){
		mapNumber = value;
	}

	public int GetDifficulty(){
		return difficulty;
	}

	public void SetDifficulty(int value){
		difficulty = value;
	}

	public string GetPlayerName(){
		return playerName;
	}

	public void SetPlayerName(string nickname){
		playerName = nickname;
	}
}
