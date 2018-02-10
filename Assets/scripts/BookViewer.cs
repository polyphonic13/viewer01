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
			_book = book;
		}

		public void Init ()
		{
			_cameraZoom = gameObject.GetComponent<CameraZoom>();
			_translateAgent = gameObject.GetComponent<TranslateAgent>();
			_translateAgent.Init();

			_defaultInput = new InputObject();
			_defaultInput.horizontal = 0;
			_defaultInput.vertical = 0;
			_defaultInput.depth = 0;
			_defaultInput.buttons = new Dictionary<string, bool>();
		}

		public void SetInput(InputObject input)
		{
			_input = input;
		}

		public void Activate()
		{
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
			if(_book == null)
			{
				return;
			}
			_book.NextPage();
		}

		public void PreviousPage() 
		{
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
			if(_input.buttons.ContainsKey("Cancel"))
			{
				_input = _defaultInput;
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

			Move(_input.horizontal, _input.vertical);
			
			_input = _defaultInput;
		}
	}
}