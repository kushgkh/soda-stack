using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeHandler : MonoBehaviour {

	int hours;
	int minutes;
	int seconds;


	// Use this for initialization
	void Start () {
		hours = 0;
		minutes = 0;
		seconds = 20;
		InvokeRepeating("decr", 0.0f, 1.0f);
	
	}
	public void decr(){
		seconds--;
	}
	
	// Update is called once per frame
	void Update () {
		
		
		if (seconds < 0) {
			minutes--;
			if (minutes < 0) {
				hours--;
				if (hours < 0) {
					SceneManager.LoadScene ("Question");
				}
				minutes = 59;
			}
			seconds = 59;
		}

		string hr= hours.ToString();
		string min = minutes.ToString ();
		string sec = seconds.ToString ();

		if (seconds.ToString ().Length < 2) { 
			sec = "0" + seconds.ToString ();
		}
		if (minutes.ToString ().Length < 2) { 
			min = "0" + minutes.ToString ();
		}
		if (hours.ToString ().Length < 2) { 
			hr = "0" + hours.ToString ();
		}
		if (hours>= 0) {
			GetComponent<Text> ().text = hr + ":" + min + ":" + sec;
		}
		else {
			GetComponent<Text> ().text = "00:00:00";
		}

	
	}
}
