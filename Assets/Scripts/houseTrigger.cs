using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class houseTrigger : MonoBehaviour {

	public Text subtitles;

	void OnTriggerEnter(Collider other) {
		if (ClueManger.count == 1) {
			ClueManger.count++;
		}
		if (ClueManger.count > 1) {

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
