using UnityEngine;
using System.Collections;

public class MouseLook : MonoBehaviour {

	public Camera cam;
	private float camY;
	private bool camLook;
	private float camX;

	void Start () {
		camLook = false;
	}

	void Update () {

		if(Input.GetMouseButton(1))
		{
			if(!camLook)
			{
				camLook = true;
				camY =  Input.mousePosition.y;
				camX =  Input.mousePosition.x;
			}
			float camYNew = Input.mousePosition.y;
			if(camYNew != camY)
			{
				cam.transform.RotateAround(transform.position,transform.right,cam.transform.rotation.x + 0.3f*(camY-camYNew));
				camY = camYNew;
			}

			float camXNew = Input.mousePosition.x;
			if(camXNew != camX)
			{
				transform.Rotate(0,-0.3f*(camX-camXNew),0);
				camX = camXNew;
			}
		}else{
			camLook = false;
		}
	}
}
