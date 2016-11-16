using UnityEngine;
using System.Collections;

public class StatsButton : MonoBehaviour {

	public GameObject statsMenu;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void openStats()
	{
		statsMenu.SetActive (true);
	}
	public void closeStats()
	{
		statsMenu.SetActive (false);
	}
}
