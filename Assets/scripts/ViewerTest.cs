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
	
	private bool GetIsButtonDown(string key)
	{
		return CrossPlatformInputManager.GetButtonDown(key);
	}

	private Dictionary<string, bool> SetButtonsDown() 
	{
		downButtons = new Dictionary<string, bool>();

		foreach(ButtonMap map in buttonMaps)
		{
			downButtons.Add(map.key, GetIsButtonDown(map.name));
		}
		return downButtons;
	}

	void FixedUpdate () 
	{
		if(CrossPlatformInputManager.GetButtonDown("Submit"))
		{
			Debug.Log("submit = " + CrossPlatformInputManager.GetButtonDown("Submit"));
		}
		
		if(viewer.isActivated) 
		{
			input = new InputObject();

			input.horizontal = CrossPlatformInputManager.GetAxis("Horizontal");
			input.vertical = CrossPlatformInputManager.GetAxis("Vertical");
			input.buttons = SetButtonsDown();
			input.isSubmitDown = CrossPlatformInputManager.GetButtonDown("Submit");
//			Debug.Log("input.buttons = " + input.buttons);
			viewer.SetInput(input);
		} 
		else if(CrossPlatformInputManager.GetButtonDown("Submit"))
		{
			viewer.Activate();
		}
		
	}
}
