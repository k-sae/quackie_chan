using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class letterTriger : MonoBehaviour {

	public Text subtitles;

	void OnTriggerEnter(Collider other) {
		if (ClueManger.count == 0) {
			ClueManger.count++;
		}
		subtitles.text = "man talk";
	}
	void OnTriggerStay(Collider other)
	{
		
	}
	void OnTriggerExit(Collider other)
	{

		subtitles.text = "";

	}

}
