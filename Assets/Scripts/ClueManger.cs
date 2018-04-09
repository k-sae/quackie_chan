using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClueManger : MonoBehaviour {
	public Text subtitles;
	public static int timeWatch;
	// Use this for initialization
	void Start () {
		timeWatch = 0;
		showText ("");

	}
	
	// Update is called once per frame
	void Update () {
		if (timeWatch < 600) {
			timeWatch++;
		}

		if (timeWatch == 300) {
			showText ("go to duck home to check your children");
		}
		if (timeWatch == 600) {
			showText ("");
		}
		if (timeWatch <  0) {
			
		
			showText( "your children is kidnapped");
		}
	}
	void showText(string text){
		subtitles.text = text;
	}
}
