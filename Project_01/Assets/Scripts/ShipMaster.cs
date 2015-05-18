using UnityEngine;
using System.Collections;

public class ShipMaster : MonoBehaviour {

	public int cockpit = -1;
	public int wings = -1;
	public int engines = -1;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (this);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
