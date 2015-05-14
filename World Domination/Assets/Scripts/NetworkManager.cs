using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {

	string roomName = "RoomName";
	private RoomInfo[] roomsList;

	// Use this for initialization
	void Start () {
		PhotonNetwork.ConnectUsingSettings ("0.1");
	}

	void OnGUI(){
		if (!PhotonNetwork.connected)
			GUILayout.Label (PhotonNetwork.connectionStateDetailed.ToString ());
		else if (PhotonNetwork.room == null) {
			if(GUI.Button(new Rect(100,100,250,100), "Start Server"))
				PhotonNetwork.CreateRoom(roomName, true, true, 5);
			if(roomsList != null){

			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
