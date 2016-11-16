using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuHandling : MonoBehaviour {


	public static bool drank;
	// Use this for initialization
	void Start () {
		if (PlayerPrefs.GetInt ("cans") == 0) {
			PlayerPrefs.SetInt ("cans", 0);
		}

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void yes()
	{
		PlayerPrefs.SetInt ("cans", PlayerPrefs.GetInt ("cans") + 1);
		SceneManager.LoadScene ("Can_Pyramid");
		drank =false;


	}
	public void no()
	{
		SceneManager.LoadScene ("Can_Pyramid");
		drank = true;
	}

}
