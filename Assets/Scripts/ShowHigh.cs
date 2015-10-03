using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowHigh : MonoBehaviour {

    public Text text4;
    public string txt;
    void Start()
    {
        text4 = GetComponent<Text>();
        txt = "Without Highscores";
    }
    void Update()
    {
        text4.text = txt;
    }
}
