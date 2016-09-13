using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIScript : MonoBehaviour {

	public Text death;
	public Text time;
	int timer;

	// Use this for initialization
	void Start () {
		death = GameObject.Find ("Deaths").GetComponent<Text> ();
		time = GameObject.Find ("Time").GetComponent<Text> ();
		timer = PlayerPrefs.GetInt ("time");
		StartCoroutine (Timer ());
	}
	
	// Update is called once per frame
	void Update () {
		PlayerPrefs.SetInt("time", timer);
		death.text = "Deaths:" + PlayerPrefs.GetInt ("mortes").ToString();
		time.text = "Time:" + PlayerPrefs.GetInt("time").ToString () + " sec";
	}
	IEnumerator Timer()
	{
		yield return new WaitForSeconds (1f);
		timer ++;
		StartCoroutine (Timer ()); 
	}
}