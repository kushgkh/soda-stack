using UnityEngine;
using System.Collections;

public class SettingButton : MonoBehaviour {
	public GameObject setting;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void open(){
		setting.SetActive (true);
	}
	public void close(){
		setting.SetActive (false);
	}
}
