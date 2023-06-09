using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour
{
	public RenderTexture rendtex;
	public Transform playerCamera;
	public Transform portal;
	public Transform otherPortal;
	private Camera cam;
	public Material portalMaterial;
	private void Start()
	{
		cam = GetComponent<Camera>();
		if(cam.targetTexture != null)
        {
			cam.targetTexture.Release();
        }
		cam.targetTexture = new RenderTexture(960, Screen.height-200, 24);
		portalMaterial.mainTexture = cam.targetTexture;
		rendtex.width = Screen.width;
		rendtex.height = Screen.height;
	}
	// Update is called once per frame
	void Update()
	{
		Vector3 playerOffsetFromPortal = playerCamera.position - otherPortal.position;
		transform.position = portal.position + playerOffsetFromPortal - new Vector3(0,0,1.7f);

		float angularDifferenceBetweenPortalRotations = Quaternion.Angle(portal.rotation, otherPortal.rotation);

		Quaternion portalRotationalDifference = Quaternion.AngleAxis(angularDifferenceBetweenPortalRotations, Vector3.up);
		Vector3 newCameraDirection = portalRotationalDifference * playerCamera.forward;
		transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
	}
}