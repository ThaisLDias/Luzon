using UnityEngine;
using System.Collections;
using UnityEngine.UI;
    public class PhpConnect : MonoBehaviour
{

    public string myUrl = "http://lpaulobos.16mb.com/script.php"; 
    public string textinho;

    public void ButtonClick()
    {
        StartCoroutine(SendHighScore(textinho, PlayerPrefs.GetInt("mortes")));
        GameObject.Find("Text4").GetComponent<ShowHigh>().txt = textinho + ":  " +PlayerPrefs.GetInt("mortes").ToString();
        PlayerPrefs.SetInt("mortes", 200);
        textinho = "Your Name...";
    }

    IEnumerator SendHighScore(string _player, int _score)
    {
        WWWForm form = new WWWForm();
        form.AddField("nome", _player);
        form.AddField("score", _score);


        WWW www = new WWW(myUrl,form);
        yield return www;
        if (www.error != null)
        {
            Debug.Log(www.text);
            GameObject.Find("Text4").GetComponent<ShowHigh>().txt = _player + ": " + _score;
        }
        else
            Debug.Log(www.text);
    }
    void Update()
    {
        textinho = GameObject.Find("Text").GetComponent<Text>().text;
    }
}
