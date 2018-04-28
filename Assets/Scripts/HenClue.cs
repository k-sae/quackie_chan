using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HenClue : MonoBehaviour {

	public Text subtitles;
	public Text subtitles2;
	public static int time;
	void OnTriggerEnter(Collider other) {
		subtitles.text = "hen talk";
		time++;
	}
	void OnTriggerStay(Collider other)
	{
		if (time == 300) {
			subtitles.text = "";
			subtitles2.text = "duck talk";
		} else {
			time++;
		}
	}
	void OnTriggerExit(Collider other)
	{time = 0;
		
		subtitles.text = "";
		subtitles2.text = "";
	}
}
