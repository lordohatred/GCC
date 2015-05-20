using UnityEngine;
using System.Collections;

public class NetworkPlayer : Photon.MonoBehaviour {

    private Camera cam;
    private bool isAlive = true;
    private Vector3 pos;
    private Quaternion rot;
    private float networkSmoothing = 10.0f;

	// Use this for initialization
	void Start () {
        cam = GetComponentInChildren<Camera> ();
        if (photonView.isMine) {
            if (!cam.enabled)
                cam.enabled = true;
            GetComponent<CountryMotor> ().isPlayer = true;
        } else {

        }
	}

    void OnPhotonSerializeView (PhotonStream stream, PhotonMessageInfo info) {
        if (stream.isWriting) {
            stream.SendNext (transform.position);
        }
        if (stream.isReading) {
            pos = (Vector3)stream.ReceiveNext ();
            StartCoroutine ("Alive");
        }
    }

    IEnumerator Alive () {
        while (isAlive) {
            transform.position = Vector3.Lerp (transform.position, pos, Time.deltaTime * networkSmoothing);
            yield return null;
        }
    }
}
