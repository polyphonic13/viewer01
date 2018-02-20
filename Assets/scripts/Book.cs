namespace Polyworks {

	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class Book : MonoBehaviour {
		public GameObject[] pages;

		public int pageIndex = 0;
		public bool isLoopPages = false;

		public void Init () 
		{
		
		}

		public void NextPage() 
		{
			int offIndex = pageIndex;

			if(pageIndex < pages.Length - 1)
			{
				pageIndex++;
				_updateActivePages(offIndex, pageIndex);
			} 
			else if(isLoopPages)
			{
				pageIndex = 0;
				_updateActivePages(offIndex, pageIndex);
			}
			// Debug.Log("page index now: " + pageIndex);
		}

		public void PreviousPage() 
		{
			int offIndex = pageIndex;

			if(pageIndex > 0)
			{
				pageIndex--;
				_updateActivePages(offIndex, pageIndex);
			}
			else if(isLoopPages)
			{
				pageIndex = pages.Length - 1;
				_updateActivePages(offIndex, pageIndex);
			}
			// Debug.Log("page indez now: " + pageIndex);
		}

		private void _updateActivePages(int offIndex, int onIndex)
		{
			pages[offIndex].SetActive(false);
			pages[onIndex].SetActive(true);
		}
	}
}
