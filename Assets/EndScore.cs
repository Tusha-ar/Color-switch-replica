using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScore : MonoBehaviour
{
    public Text endScore;
    int score;
    // Start is called before the first frame update
    void Start()
    {
        endScore.text += "Score = ";
        score = PlayerPrefs.GetInt("Score", score);
        endScore.text += score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
