using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEditor;
    public class PhpConnect : MonoBehaviour
{

    public string myUrl = "http://lpaulobos.16mb.com/script.php"; 
    public string nome;


	void Start()
	{
	}
    
    public void ButtonClick()
    {
		int points = 700 - PlayerPrefs.GetInt("globalScore")/2;
        StartCoroutine(SendHighScore(nome, points));
        nome = "Your Name...";
		GameObject.Find("ScoreText").GetComponent<ShowHigh>().GetScore();
    }

    IEnumerator SendHighScore(string _player, int _score)
    {
        WWWForm form = new WWWForm();
        form.AddField("nome", _player);
        form.AddField("score", _score);


        WWW www = new WWW(myUrl,form);
        yield return www;
    
	}
    void Update()
    {
		//EditorUtility.DisplayDialog("PHP Connect", "Sucessful inserted score","Ok");
        nome = GameObject.Find("Text").GetComponent<Text>().text;
    }
}
