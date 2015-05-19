using UnityEngine;
using System.Collections;

public class ShipMaster : MonoBehaviour {

    public GameObject player;
	public int cockpit = -1;
	public int wings = -1;
	public int engines = -1;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (this);
	}
	
	// Update is called once per frame
	void Update () {
        if (GameObject.Find ("Player") == null) {
            GameObject newPlayer;
            newPlayer = Instantiate (player, new Vector3 (-14.98f, 6.22f, -4.08f), transform.rotation) as GameObject;
            newPlayer.name = player.name;
//            Rigidbody newPlayer = Instantiate (player, new Vector3 (-14.98f, 6.22f, -4.08f), transform.rotation) as Rigidbody;
        }
	}
}
