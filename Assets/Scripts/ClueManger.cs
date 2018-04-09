using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClueManger : MonoBehaviour {
	public Text subtitles;
	public static int timeWatch;
	private Vector3 DBPPL;//diffrent Between postion of  player  and  letter  posion
	// Use this for initialization
	void Start () {
		timeWatch = 0;
		showText ("");

	}
	
	// Update is called once per frame
	void Update () {
		if (timeWatch < 500) {
			timeWatch++;
		}

		if (timeWatch == 250) {
			showText ("go to duck home to check your children");
		} else if (timeWatch == 490) {
			showText ("");
		}
		if(timeWatch >490){
			DBPPL = GameObject.FindGameObjectWithTag("Player").transform.position - GameObject.FindGameObjectWithTag("letter").transform.position;
			if (  -1.3 < DBPPL [2] &&  DBPPL [2] < 1.3) {
				showText ("your children is kidnapped , go  to  high place to look  of  them ");
			} else {
				showText ("");
			}
	}
	}
	void showText(string text){
		subtitles.text = text;
	}
}
