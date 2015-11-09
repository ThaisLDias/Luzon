using UnityEngine;
using System.Collections;
using UnityEngine.UI;
    public class PhpConnect : MonoBehaviour
{

    public string myUrl = "http://lpaulobos.16mb.com/script.php"; 
    public string nome;


	void Start()
	{
		StartCoroutine(GuiRect());
	}
    
    public void ButtonClick()
    {
        StartCoroutine(SendHighScore(nome, PlayerPrefs.GetInt("mortes")));
        GameObject.Find("Text4").GetComponent<ShowHigh>().txt = nome + ":  " + PlayerPrefs.GetInt("mortes").ToString();
        PlayerPrefs.SetInt("mortes", 200);
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
        if (www.error != null)
        {
            Debug.Log(www.text);
        }
        else
            Debug.Log(www.text);
    }
    void Update()
    {
        nome = GameObject.Find("Text").GetComponent<Text>().text;
    }
	
	IEnumerator GuiRect()
	{	
		yield return new  WaitForSeconds(0.5f);
		var a = new Rect(0,0,Screen.width/2,Screen.height/2),"Successful inserted score!");
		yield return new  WaitForSeconds(0.5f);
		Destroy(a);
	}
}
