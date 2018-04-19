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
		
		showText ("");

	}
	
	// Update is called once per frame
	void Update () {
		


		if (Time.time < 11 && Time.time  > 6) {
			showText ("go to duck home to check your children" );
		} else if (Time.time  == 11) {
			showText ("");
		}
		if(Time.time >11){
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
