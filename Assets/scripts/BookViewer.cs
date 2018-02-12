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
			Debug.Log("set book");
			_book = book;
		}

		public void Init ()
		{
			Debug.Log("book viewer init");
			_cameraZoom = gameObject.GetComponent<CameraZoom>();
			_translateAgent = gameObject.GetComponent<TranslateAgent>();
			_translateAgent.Init();

			_defaultInput = new InputObject();
			_defaultInput.horizontal = 0;
			_defaultInput.vertical = 0;
			_defaultInput.depth = 0;
			_defaultInput.buttons = new Dictionary<string, bool>();

			_input = _defaultInput;
		}

		public void SetInput(InputObject input)
		{
			_input = input;
		}

		public void Activate()
		{
			Debug.Log("activate");
			isActivated = true;
		}

		public void Deactivate()
		{
			isActivated = false;
		}

		public void Move(float horizontal, float vertical)
		{
			if(horizontal == 0 && vertical == 0)
			{
				return;
			}
			if(_translateAgent != null)
			{
				return;
			}
			_translateAgent.Move(horizontal, vertical);
		}
		
		public void NextPage() 
		{
			Debug.Log("next page");
			if(_book == null)
			{
				return;
			}
			_book.NextPage();
		}

		public void PreviousPage() 
		{
			Debug.Log("prev page");
			if(_book == null)
			{
				return;
			}
			_book.PreviousPage();
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
			if(_input.buttons != null)
			{
				if(_input.buttons.ContainsKey("Cancel"))
				{
					Debug.Log("deactivate");
					_input = _defaultInput;
					Deactivate();
					return;
				}

				if(_input.buttons.ContainsKey("Left"))
				{
					NextPage();
				} 
				else if(_input.buttons.ContainsKey("Right"))
				{
					PreviousPage();
				}

				if(_input.buttons.ContainsKey("ZoomIn"))
				{
					ZoomIn();
				} 
				else if(_input.buttons.ContainsKey("ZoomOut"))
				{
					ZoomOut();
				}
			}

			Move(_input.horizontal, _input.vertical);
			
			_input = _defaultInput;
		}
	}
}