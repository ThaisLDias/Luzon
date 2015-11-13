using UnityEngine;
using System.Collections;
using UnityEngine.UI;

    public class PhpConnect : MonoBehaviour
{

    public string myUrl = "http://lpaulobos.16mb.com/script.php"; 
    public string nome;

    public void ButtonClick()
    {
		int points = 1000 - PlayerPrefs.GetInt ("globalDeaths") * 2;
		StartCoroutine (SendHighScore (nome, points));
    }

    IEnumerator SendHighScore(string _player, int _score)
    {
        WWWForm form = new WWWForm();
		if (_player == "" || _player == null) {
			_player = "Player";
		}
        form.AddField("nome", _player);
        form.AddField("score", _score);


        WWW www = new WWW(myUrl,form);
        yield return www;
		
		Application.LoadLevel (Application.loadedLevel);
    
	}
    void Update()
    {
        nome = GameObject.Find("Text").GetComponent<Text>().text;
		if (nome == "" || nome == null)
			Debug.Log ("Name:" + nome);
		else 
			Debug.Log ("Nomezin:" + nome);
    }
}
