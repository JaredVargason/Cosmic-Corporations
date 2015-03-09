using UnityEngine;
using System.Collections;

//Sets camera sizes and positions on screen depending on how many people are playing.

public class CameraSize : MonoBehaviour {
	
	public Camera _camera1, _camera2, _camera3, _camera4;

	void Awake() 
	{

		switch (PlayMenu._numberOfPlayers) {
		case 1:
			_camera1.enabled = true;
			_camera2.enabled = false;
			_camera3.enabled = false;
			_camera4.enabled = false;
			
			_camera1.rect = new Rect(0.0f, 0.0f, 1.0f, 1.0f);
			break;
			
		case 2:
			_camera1.enabled = true;
			_camera2.enabled = true;
			_camera3.enabled = false;
			_camera4.enabled = false;
			
			_camera1.rect = new Rect(0.0f, 0.501f, 1.0f, 0.499f);
			_camera2.rect = new Rect(0.0f, 0.0f, 1.0f, 0.499f);
			break;
			
		case 3:
			_camera1.enabled = true;
			_camera2.enabled = true;
			_camera3.enabled = true;
			_camera4.enabled = true;
			
			_camera1.rect = new Rect(0.0f, 0.501f, 0.4995f, 0.499f);
			_camera2.rect = new Rect(0.5005f, 0.5f, 0.499f, 0.499f);
			_camera3.rect = new Rect(0.0f, 0.0f, 0.4995f, 0.499f);
			_camera4.rect = new Rect(0.5005f, 0.0f, 0.499f, 0.499f);
			break;
			
		case 4:
			_camera1.enabled = true;
			_camera2.enabled = true;
			_camera3.enabled = true;
			_camera4.enabled = true;
			
			_camera1.rect = new Rect(0.0f, 0.501f, 0.4995f, 0.499f);
			_camera2.rect = new Rect(0.5005f, 0.501f, 0.499f, 0.499f);
			_camera3.rect = new Rect(0.0f, 0.0f, 0.4995f, 0.499f);
			_camera4.rect = new Rect(0.5005f, 0.0f, 0.499f, 0.499f);
			break;
		}
	}

	void Update () 
	{
		
	}
}
