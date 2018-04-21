using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClueManger : MonoBehaviour {
	public Text subtitles;
	public static int timeWatch;
	private Vector3 DBPPL;//diffrent Between postion of  player  and  letter  posion
	private Vector3 player;
	private Vector3 clue_field;
	// Use this for initialization
	void Start () {
		
		showText ("");

	}
	
	// Update is called once per frame
	void Update () {
		player = GameObject.FindGameObjectWithTag ("Player").transform.position;

		clue_field = GameObject.FindGameObjectWithTag ("clue_filed").transform.position ;

		if (Time.time < 11 && Time.time  > 6) {
			showText ("go to duck home to check your children" );
		} else if (Time.time  == 11) {
			showText ("");
		}
		if(Time.time >11){
			DBPPL = player - GameObject.FindGameObjectWithTag("letter").transform.position;
			if (  -1.3 < DBPPL [2] &&  DBPPL [2] < 1.3) {
				showText ("your children is kidnapped , go  to  high place to look  of  them ");
			} if (player [1] > 14) {
				showText (clue_field + "");
			}
			else {
				showText ("");
			}
	}
	}
	void showText(string text){
		subtitles.text = text;
	}
}
