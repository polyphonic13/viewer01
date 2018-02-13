namespace Polyworks {

	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class Book : MonoBehaviour {

		public int numPages = 0;
		public int pageIndex = 0;
		public bool isLoopPages = false;

		public void Init () 
		{
		
		}
	
		public void NextPage() 
		{
			if(pageIndex < numPages)
			{
				pageIndex++;
			} 
			else if(isLoopPages)
			{
				pageIndex = 0;
			}
			Debug.Log("page index now: " + pageIndex);
		}

		public void PreviousPage() 
		{
			if(pageIndex > 0)
			{
				pageIndex--;
			}
			else if(isLoopPages)
			{
				pageIndex = numPages - 1;
			}
			Debug.Log("page indez now: " + pageIndex);
		}
	}
}
