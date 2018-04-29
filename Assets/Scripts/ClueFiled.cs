using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClueFiled : MonoBehaviour {

	public Text subtitles;

	void OnTriggerEnter(Collider other) {
		if (ClueManger.count == 2) {
			ClueManger.count++;
		}
		if (ClueManger.count > 2) {
			
			subtitles.text = "man talk";
		}


	}
	void OnTriggerStay(Collider other)
	{
		
	}
	void OnTriggerExit(Collider other)
	{

		subtitles.text = "";

	}

}
