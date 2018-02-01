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
			_camera = gameObject.GetComponent<Camera>();
			_normalFOV = _camera.fieldOfView;
		}		

		public void ToggleZoom()
		{
			_camera.fieldOfView = (_camera.fieldOfView == zoomFOV) ? _normalFOV : zoomFOV;
		}

		public void ZoomIn()
		{
			_camera.fieldOfView = zoomFOV;
		}

		public void ZoomOut()
		{
			_camera.fieldOfView = _normalFOV;
		}
	}
}