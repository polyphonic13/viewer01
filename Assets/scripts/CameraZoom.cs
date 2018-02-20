namespace Polyworks 
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class CameraZoom : MonoBehaviour {
		public float maxZoom = 20f;
		public float zoomIncrement = 1f;

		private Camera _camera;
		private float _normalFOV;

		public void Init()
		{
			Debug.Log("camera zoom init");
			_camera = gameObject.GetComponent<Camera>();
			_normalFOV = _camera.fieldOfView;
			Debug.Log(" _camera = " + _camera);
		}		

		public void ToggleZoom()
		{
			Debug.Log("toggle zoom, fov = " + _camera.fieldOfView);
			if(_camera == null)
			{
				return;
			}
			_camera.fieldOfView = (_camera.fieldOfView == _normalFOV) ? maxZoom : _normalFOV;
		}

		public void ZoomIn()
		{
			Debug.Log("zoom in");
			if(_camera == null)
			{
				return;
			}
			if(_camera.fieldOfView > maxZoom)
			{
				_camera.fieldOfView -= zoomIncrement;
			}
		}

		public void ZoomOut()
		{
			Debug.Log("zoom out");
			if(_camera == null)
			{
				return;
			}
			if(_camera.fieldOfView < _normalFOV)
			{
				_camera.fieldOfView += zoomIncrement;
			}
		}

		public void Reset()
		{
			_camera.fieldOfView = _normalFOV;
		}
	}
}