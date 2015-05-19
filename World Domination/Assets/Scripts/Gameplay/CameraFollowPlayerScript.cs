using UnityEngine;
using System.Collections;

public class CameraFollowPlayerScript : MonoBehaviour {

	public Vector3 player;
	
	// Update is called once per frame
	void FixedUpdate () {
		if(player != null)
			transform.position = new Vector3 (player.x, player.y, -5);
	}
}
