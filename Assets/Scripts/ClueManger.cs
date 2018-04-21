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
	private Vector3 new_postion;
	// Use this for initialization
	void Start () {
		
		showText ("");

	}
	
	// Update is called once per frame
	void Update () {
		player = GameObject.FindGameObjectWithTag ("Player").transform.position;

		clue_field = GameObject.FindGameObjectWithTag ("clue_filed").transform.position ;
		//new_postion = clue_field + [0,1.0];
		//GameObject.FindGameObjectWithTag ("clue_filed").transform.SetPositionAndRotation ();
		if (Time.time < 11 && Time.time  > 6) {
			showText ("go to duck home to check your children" );
		} else if (Time.time  == 11) {
			showText ("");
		}
		if (Time.time > 11) {
			DBPPL = player - GameObject.FindGameObjectWithTag ("letter").transform.position;
			if (-1.3 < DBPPL [2] && DBPPL [2] < 1.3) {
				showText ("your children is kidnapped , go  to  high place to look  of  them ");
			} else {
				if (player [1] > 13) {
					showText ("go to filed   to  see you chiledren");
				} else {
					if (player [2] > -29 && player [2] < -25) {
						showText ("go to car to check  childern");
					} else {
						if (player [2] < 70 && player [2] > 66 && player [1] > .8 && player [1] < 3&& player [0] < -12 && player [0] > -16) {
							showText ("press f to go to the next ");
						} else {
							showText ( "");
						}
					}
				}
			}
		}
	}
	void showText(string text){
		subtitles.text = text;
	}
}
