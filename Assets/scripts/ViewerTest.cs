using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine;
using Polyworks;

[System.Serializable]
public struct ButtonMap {
	public string key;
	public string name;
}

public class ViewerTest : MonoBehaviour {

	public Book book;

	public ButtonMap[] buttonMaps;

	private BookViewer viewer;

	private InputObject input;

	private Dictionary<string, bool> downButtons;

	void Awake () 
	{
		GameObject viewerObj = GameObject.Find("book-viewer");
		if(viewerObj != null)
		{
			viewer = viewerObj.GetComponent<BookViewer>();
			viewer.Init();

			if(book != null)
			{
				viewer.SetBook(book);
			}
		}
	}
	
	void FixedUpdate () 
	{
		if(viewer.isActivated) 
		{
			input = new InputObject();

			input.horizontal = CrossPlatformInputManager.GetAxis("Horizontal");
			input.vertical = CrossPlatformInputManager.GetAxis("Vertical");

			input.isSubmitDown = CrossPlatformInputManager.GetButtonDown("Submit");
			input.isCancelDown = CrossPlatformInputManager.GetButtonDown("Cancel");
			input.isLeftDown = CrossPlatformInputManager.GetButtonDown("Left");
			input.isRightDown = CrossPlatformInputManager.GetButtonDown("Right");
			input.isZoomInDown = CrossPlatformInputManager.GetButtonDown("ZoomIn");
			input.isZoomOutDown = CrossPlatformInputManager.GetButtonDown("ZoomOut");

			viewer.SetInput(input);
		} 
		else if(CrossPlatformInputManager.GetButtonDown("Submit"))
		{
			viewer.Activate();
		}		
	}
}
