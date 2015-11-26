#pragma strict

	var Camera_FPS : Camera;
	var Camera_3rd : Camera;
	var CameraTest : Camera;

	// Use this for initialization
	function Start () {
			
		Camera_FPS.enabled = true;
		Camera_3rd.enabled = false;
		CameraTest.enabled = false;

	}
	
	// Update is called once per frame
	function Update () {
	
		 if (Input.GetKeyDown(KeyCode.V) && (Camera_FPS.enabled == true || CameraTest.enabled == true)) {
     Camera_FPS.enabled = false;
     Camera_3rd.enabled = true;
     CameraTest.enabled = false;
     }
     else if (Input.GetKeyDown(KeyCode.B) && (Camera_3rd.enabled == true || Camera_FPS.enabled == true)) {
     Camera_FPS.enabled = false;
     Camera_3rd.enabled = false;
     CameraTest.enabled = true;
     }
     else if (Input.GetKeyDown(KeyCode.C) && (Camera_3rd.enabled == true || CameraTest.enabled == true)) {
     Camera_FPS.enabled = true;
     Camera_3rd.enabled = false;
     CameraTest.enabled = false;
     }

	}