namespace Polyworks
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class ViewerCamera : MonoBehaviour
	{
		public bool isEnabled = false;
		public float horizontalSpeed = 2f;
		public float verticalSpeed = 2f;
		public float maxX;
		public float minX;
		public float maxY;
		public float minY;
		
		private CameraZoom _cameraZoom;
		private Book _book;

		private InputObject _inputObj;

		public void SetInput (InputObject data)
		{
			_inputObj = data;
		}

		public void SetBook(Book book)
		{
			_book = book;
		}

		public void Init ()
		{
			_inputObj = new InputObject();
			_cameraZoom = gameObject.GetComponent<CameraZoom>();
		}

		private void FixedUpdate ()
		{
			if (isEnabled) {
				if(_inputObj.isEscapeDown)
				{
					_cleanup();
				}
				if(_inputObj.isRightDown)
				{
					_nextPage();
				}
				if(_inputObj.isLeftDown)
				{
					_previousPage();
				}
				if(_inputObj.isZoomInDown)
				{
					_zoomIn();
				}
				if(_inputObj.isZoomOutDown)
				{
					_zoomOut();
				}
			}
		}

		private void _cleanup() 
		{
			_inputObj.isEscapeDown = false;
			isEnabled = false;
		}

		private void _nextPage() 
		{
			_inputObj.isRightDown = false;

			if(_book ==  null)
			{
				return;
			}
			_book.NextPage();
		}

		private void _previousPage() 
		{
			_inputObj.isLeftDown = false;

			if(_book == null)
			{
				return;
			}
			_book.PreviousPage();
		}

		private void _zoomIn()
		{
			_inputObj.isZoomInDown = false;
			_cameraZoom.ZoomIn();
		}

		private void _zoomOut()
		{
			_inputObj.isZoomOutDown = false;
			_cameraZoom.ZoomOut();
		}
	}
}