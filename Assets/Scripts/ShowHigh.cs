using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowHigh : MonoBehaviour {

    public Text text;
    public string txt;
    public string link;
	public string[] scores = new string[5];
	
	void Awake()
	{
		PlayerPrefs.DeleteAll ();
		/*Network.proxyIP = "10.10.10.1";
		Network.proxyPort = 3128;
		Network.useProxy = true;*/
	}
    void Start()
    {
        text = GetComponent<Text>();
        txt = "Without Highscores";
		link = "http://lpaulobos.16mb.com/getHighScore.php";
		GetScore(); 
	}
	public IEnumerator GetHighScore(string url)
    {
		string[] scores = new string[5];
		WWW www = new WWW(url);
		yield return www;
		scores = www.text.Split('/');	

		if (!www.isDone) 
		{
			GameObject.Find ("ScoreText3").GetComponent<Text> ().text = "Connection problem";
		} 
		else 
		{
			for(int i = 0; i < scores.Length;i++)
			{
				GameObject.Find("ScoreText" + (i+1).ToString()).GetComponent<Text>().text = scores[i];
			}
		}
    }
    public void GetScore()
    {
		StartCoroutine(GetHighScore(link));
    }

	
}
