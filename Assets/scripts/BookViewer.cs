namespace Polyworks
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class BookViewer : MonoBehaviour
	{
		public bool isActivated = false;
		
		private InputObject _input;
		private InputObject _defaultInput;
		private TranslateAgent _translateAgent;
		private CameraZoom _cameraZoom;
		private Book _book;

		public void SetBook(Book book)
		{
//			Debug.Log("set book");
			_book = book;
		}

		public void Init ()
		{
//			Debug.Log("book viewer init");
			_cameraZoom = gameObject.GetComponent<CameraZoom>();
			_cameraZoom.Init();

			_translateAgent = gameObject.GetComponent<TranslateAgent>();
			_translateAgent.Init();

			_defaultInput = new InputObject();
			_defaultInput.horizontal = 0;
			_defaultInput.vertical = 0;
			_defaultInput.depth = 0;

			_input = _defaultInput;
		}

		public void SetInput(InputObject input)
		{
			_input = input;
		}

		public void Activate()
		{
//			Debug.Log("activate");
			isActivated = true;
		}

		public void Deactivate()
		{
			_cameraZoom.Reset();
			isActivated = false;
		}

		public void Move(float horizontal, float vertical)
		{
			if(horizontal == 0 && vertical == 0)
			{
				return;
			}
			if(_translateAgent == null)
			{
				return;
			}
			_translateAgent.Move(horizontal, vertical);
		}
		
		public void NextPage() 
		{
//			Debug.Log("next page, _book = " + _book);
			if(_book == null)
			{
				return;
			}
			_book.NextPage();
		}

		public void PreviousPage() 
		{
//			Debug.Log("prev page, _book = " + _book);
			if(_book == null)
			{
				return;
			}
			_book.PreviousPage();
		}

		public void Zoom()
		{
//			Debug.Log("zoom");
			_cameraZoom.ToggleZoom();
		}

		public void ZoomIn()
		{
			_cameraZoom.ZoomIn();
		}

		public void ZoomOut()
		{
			_cameraZoom.ZoomOut();
		}

		private void FixedUpdate()
		{
			if(!isActivated)
			{
				return;
			}

				if(_input.isCancelDown)
				{
//					Debug.Log("deactivate");
					_input = _defaultInput;
					Deactivate();
					return;
				}

				if(_input.isRightDown)
				{
					NextPage();
				} 
				else if(_input.isLeftDown)
				{
					PreviousPage();
				}

				if(_input.isZoomInDown)
				{
					ZoomIn();
				}

				if(_input.isZoomOutDown)
				{
					ZoomOut();
				}

			Move(_input.horizontal, _input.vertical);
			
			_input = _defaultInput;
		}
	}
}