using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Bottles : MonoBehaviour {


	public Image pepsi;
	public Image mtndew;
	public Image coke;
	public Image nextCan;
	public GameObject UI;
	public GameObject can;


	public GameObject cokedrop;
	public GameObject cokeexp;
	public GameObject pepsidrop;
	public GameObject pepsiexp;
	public GameObject mtndewdrop;
	public GameObject mtndewexp;

	public Text canCountText;


	float xwidth;
	public int numBottles;
	Vector3 nextBottlepos;

	//STATS TEXT
	public Text height;
	public Text weight;
	public Text sugar;
	public Text cal;
	public Text money;

	// Use this for initialization
	void Start () {
		//PlayerPrefs.DeleteAll ();
		if (MenuHandling.drank) {
			numBottles = PlayerPrefs.GetInt ("cans");
			canCountText.text = (PlayerPrefs.GetInt("cans")).ToString ();
		}
		else{
			numBottles = PlayerPrefs.GetInt ("cans")-1;
			canCountText.text = (PlayerPrefs.GetInt("cans")-1).ToString ();
		}
	
		//setting stats
		height.text = (Mathf.Round((float)numBottles * 0.4025f)).ToString ()+"ft";
		weight.text = (Mathf.Round((float)numBottles * 0.81571f)).ToString ()+"lb";
		sugar.text = (Mathf.Round((float)numBottles * 42.5f)).ToString ()+"g";
		cal.text = (Mathf.Round((float)numBottles * 150f)).ToString ()+"cal";
		money.text = "$"+(Mathf.Round((float)numBottles * 0.50f)).ToString ();

		xwidth = 0.52f;
		//Debug.Log(Screen.width);
		int rows = 0;
		int rowBottles = 1;


		while (numBottles >= rowBottles) {
			numBottles -= rowBottles;
			rowBottles++;
			rows++;
		}
		int extras = numBottles;
		int bonus = 0;
		bool nextBottle = false;
		Camera.main.orthographicSize = xwidth * rows / 0.7f + 1;
	
		float xshift = (xwidth) * rows / 2;
		float yshift = ((Camera.main.orthographicSize -1) * 1.777f) / 2 * 0.80f + 0.15f / rows;
		UI.transform.localScale = new Vector3 (Camera.main.orthographicSize / 5, Camera.main.orthographicSize / 5, 1);


		//Debug.Log (yshift);
		float xoffset = 0f;
	

		if (numBottles == 0) {
			float xpos = -xshift + (xwidth) * (rows);
			float ypos = -yshift;
			nextBottlepos = new Vector3 (xpos, ypos, 0);
		}
		for (int i = rows; i > 0; i--) {
			if (extras > 0) {
				extras--;
				bonus = 1;
				if(!nextBottle && numBottles > 0)
				{
					//Debug.Log (i);
					nextBottle = true;
					float xpos = -xshift + (xwidth) * (i-numBottles) + (rows - i + numBottles) * (xwidth/2);
					float ypos = -yshift +  (rows - i + numBottles);
					nextBottlepos = new Vector3 (xpos, ypos, 0);

				}
			}

			for (int x = 0; x < i + bonus ; x++) {
				float xpos = -xshift + (xwidth) * x + (rows - i) * (xwidth/2);
				float ypos = -yshift +  (rows - i);
				randomize ();
				Image temp = Instantiate (nextCan, new Vector3 (xpos, ypos, 0), Quaternion.identity) as Image;
				temp.transform.SetParent (can.transform);
			}
			bonus = 0;

		}
		GameObject dropcan = null;

		if (MenuHandling.drank) {	
			int i = Random.Range (0, 3);
			switch (i) {
			case 0:
				dropcan = cokeexp;
				break;
			case 1:
				dropcan = pepsiexp;
				break;
			case 2:
				dropcan = mtndewexp;
				break;
			}
			
		} else {
			StartCoroutine (timer ());
			int i = Random.Range (0, 3);
			switch (i) {
			case 0:
				dropcan = cokedrop;
				break;
			case 1:
				dropcan = pepsidrop;
				break;
			case 2:
				dropcan = mtndewdrop;
				break;
			}

		}
		GameObject temp2 = Instantiate (dropcan, new Vector3 (nextBottlepos.x, nextBottlepos.y, 0), Quaternion.identity) as GameObject;
		temp2.transform.SetParent (can.transform);

	
	


	
	}
	public void randomize()
	{
		int i = Random.Range (0, 3);
		switch (i) {
		case 0:
			nextCan = pepsi;
			break;
		case 1:
			nextCan = coke;
			break;
		case 2:
			nextCan = mtndew;
			break;
		}
	}
	public void randomizeFinal()
	{
		
	}
	
	// Update is called once per frame
	void Update () {
		
	
	}

	IEnumerator timer()
	{
		yield return new WaitForSeconds (2.0f);
		//numBottles++;
		canCountText.text = PlayerPrefs.GetInt("cans").ToString();
	}

}
