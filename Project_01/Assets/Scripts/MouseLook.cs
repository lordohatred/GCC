using UnityEngine;
using System.Collections;

public class MouseLook : MonoBehaviour {

	public bool lookAxis;
	float minX = -75, minY = -35;
	float maxX = 75, maxY = 75;
	float sensitivity = 1;
	Vector3 mouseLook;
	bool freeLook;
	Animator anim;
	bool isUp = true;

	// Use this for initialization
	void Start () {
		anim = GameObject.Find ("HUD_Cam").GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Ray vray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit = new RaycastHit();
		if (!GetComponentInParent<PlayerController> ().IsOnFoot ()) {
			if (Input.GetKeyDown (KeyCode.T))
				isUp = !isUp;
			if (isUp)
				anim.SetBool ("IsUp", true);
			else
				anim.SetBool ("IsUp", false);
			if (Input.GetButtonDown ("FreeLook"))
				freeLook = !freeLook;
			if (freeLook) {
				Cursor.visible = true;
				Cursor.lockState = CursorLockMode.None;
				if (lookAxis) {
					mouseLook.y += Input.GetAxis ("Mouse Y") * sensitivity;
					mouseLook.x = 0;
					mouseLook.y = Mathf.Clamp (mouseLook.y, minY, maxY);
					transform.localEulerAngles = new Vector3 (-mouseLook.y, transform.localEulerAngles.y, 0);
				}
				if (!lookAxis) {
					mouseLook.x += Input.GetAxis ("Mouse X") * sensitivity;
					mouseLook.y = 0;
					mouseLook.x = Mathf.Clamp (mouseLook.x, minX, maxX);
					transform.localEulerAngles = new Vector3 (0, mouseLook.x, 0);
				}
				if(Physics.Raycast(vray, out hit, 5)){
					if(hit.collider.name != null && Input.GetMouseButtonDown(0)){
						switch(hit.collider.name){
						case "HUD_Cam_Button_06":
							GameObject.Find("HUD_Cam_Renderer").GetComponent<HUD_Aim_Camera>().ChangeCamera(0);
							Debug.Log("First Cam");
							break;
						case "HUD_Cam_Button_05":
							GameObject.Find("HUD_Cam_Renderer").GetComponent<HUD_Aim_Camera>().ChangeCamera(1);
							print("2nd Cam");
							break;
						case "HUD_Cam_Button_04":
							GameObject.Find("HUD_Cam_Renderer").GetComponent<HUD_Aim_Camera>().ChangeCamera(2);
							print("3rd Cam");
							break;
						case "HUD_Cam_Button_01":
							GameObject.Find("HUD_Cam_Renderer").GetComponent<HUD_Aim_Camera>().ZoomCamera(2);
							break;
						case "HUD_Cam_Button_02":
							GameObject.Find("HUD_Cam_Renderer").GetComponent<HUD_Aim_Camera>().ZoomCamera(1);
							break;
						case "HUD_Cam_Button_03":
							GameObject.Find("HUD_Cam_Renderer").GetComponent<HUD_Aim_Camera>().ZoomCamera(0);
							break;
						case "HUD_System_Button_01":
							GameObject.Find("SystemText").GetComponent<HUD_Interface>().systemMenu = 0;
							break;
						case "HUD_System_Button_02":
							GameObject.Find("SystemText").GetComponent<HUD_Interface>().systemMenu = 1;
							break;
						case "HUD_System_Button_03":
							GameObject.Find("SystemText").GetComponent<HUD_Interface>().systemMenu = 2;
							break;
						case "HUD_System_Button_04":
							GameObject.Find("SystemText").GetComponent<HUD_Interface>().systemMenu = 3;
							break;
						case "HUD_Waypoint_Button_01":
							GameObject.Find("WaypointText").GetComponent<HUD_Interface>().waypointMenu = 0;
							break;
						case "HUD_Waypoint_Button_02":
							GameObject.Find("WaypointText").GetComponent<HUD_Interface>().waypointMenu = 1;
							break;
						case "HUD_Waypoint_Button_03":
							GameObject.Find("WaypointText").GetComponent<HUD_Interface>().waypointMenu = 2;
							break;
						}
					}
				}
			} else {
				Cursor.visible = false;
				Cursor.lockState = CursorLockMode.Locked;
				mouseLook.x = 0;
				mouseLook.y = 0;
				transform.rotation = GameObject.Find ("Player").transform.rotation;
			}
			if(name == "Main Camera"){
				int highFOV = 60;
				int lowFOV = 45;
				if (Input.GetMouseButton (1))
					GetComponent<Camera> ().fieldOfView = lowFOV;
				else
					GetComponent<Camera>().fieldOfView = highFOV;
				if(GetComponentInParent<SpaceshipMotor>().GetSpeed() > 0 && GetComponent<Camera>().fieldOfView == highFOV)
					GetComponent<Camera>().fieldOfView = 60 + GetComponentInParent<SpaceshipMotor>().GetSpeed() / 15;
				if(GetComponentInParent<SpaceshipMotor>().GetSpeed() > 0 && GetComponent<Camera>().fieldOfView == lowFOV)
					GetComponent<Camera>().fieldOfView = 45 + GetComponentInParent<SpaceshipMotor>().GetSpeed() / 15;
			}
		}
	}
}
