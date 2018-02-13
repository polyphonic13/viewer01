namespace Polyworks 
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class CameraZoom : MonoBehaviour {
		public float zoomFOV = 10;

		private Camera _camera;
		private float _normalFOV;

		public void Init()
		{
			Debug.Log("camera zoom init");
			_camera = gameObject.GetComponent<Camera>();
			_normalFOV = _camera.fieldOfView;
		}		

		public void ToggleZoom()
		{
			Debug.Log("toggle zoom, fov = " + _camera.fieldOfView);
			if(_camera == null)
			{
				return;
			}
			_camera.fieldOfView = (_camera.fieldOfView == zoomFOV) ? _normalFOV : zoomFOV;
		}

		public void ZoomIn()
		{
			Debug.Log("zoom in");
			if(_camera == null)
			{
				return;
			}
			_camera.fieldOfView = zoomFOV;
		}

		public void ZoomOut()
		{
			Debug.Log("zoom out");
			if(_camera == null)
			{
				return;
			}
			_camera.fieldOfView = _normalFOV;
		}
	}
}