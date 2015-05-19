using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {

    GameObject player;
    private const string VERSION = "V0.0.1";
    public string roomName = "Harrison's Ford";
    Handler handle;

    void Start () {
        PhotonNetwork.ConnectUsingSettings (VERSION);
        handle = GameObject.Find ("Handler").GetComponent<Handler> ();
    }

    void OnJoinedLobby () {
        RoomOptions roomOptions = new RoomOptions () { isVisible = true, maxPlayers = 5 };
        PhotonNetwork.JoinOrCreateRoom (roomName, roomOptions, TypedLobby.Default);
    }

    void OnJoinedRoom () {
        GameObject player;
        player = PhotonNetwork.Instantiate ("Country " + (Random.Range(1, 23)).ToString("F0"), transform.position,
            transform.rotation, 0);
        player.GetComponent<CountryMotor> ().isPlayer = true;
        player.name = GameObject.Find ("Handler").GetComponent<Handler> ().GetPlayerName ();
    }
}
