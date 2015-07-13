using UnityEngine;
using System.Collections;

public class CameraSwitcher : MonoBehaviour {
	public Camera RearStaticCamera;
	public Camera UpStaticCamera;
	public Camera FirstPersonDynamicCamera;
	public Camera ThirdPersonDynamicCamera;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.F1))
		{
			DisableAllCameras();
			RearStaticCamera.enabled = true;
		}
		else if (Input.GetKeyDown(KeyCode.F2))
		{
			DisableAllCameras();
			UpStaticCamera.enabled = true;
		}
		else if (Input.GetKeyDown(KeyCode.F3))
		{
			DisableAllCameras();
			FirstPersonDynamicCamera.enabled = true;
		}
		else if (Input.GetKeyDown(KeyCode.F4))
		{
			DisableAllCameras();
			ThirdPersonDynamicCamera.enabled = true;
		}
	}
	
	private void DisableAllCameras()
	{
		RearStaticCamera.enabled = false;
		UpStaticCamera.enabled = false;
		FirstPersonDynamicCamera.enabled = false;
		ThirdPersonDynamicCamera.enabled = false;
	}
}
