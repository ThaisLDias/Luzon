using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowHigh : MonoBehaviour {

    public Text text;
    public string txt;
    public string link;
	
	void Awake()
	{
		Network.proxyIP = "10.10.10.1";
		Network.proxyPort = 3128;
		Network.useProxy = true;
	}
    void Start()
    {
        text = GetComponent<Text>();
        txt = "Without Highscores";
		link = "http://lpaulobos.16mb.com/getHighScore.php";
		StartCoroutine(GetHighScore(link)); 
	}
	public IEnumerator GetHighScore(string url)
    {
		WWW www = new WWW(url);
		yield return www;
		 
		text.text = www.text.Replace("<br>", "                   ");	
		
    }
    public void GetScore()
    {
		StartCoroutine(GetHighScore(link)); 
    }
	
}
