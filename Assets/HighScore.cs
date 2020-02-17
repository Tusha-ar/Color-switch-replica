using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HighScore : MonoBehaviour
{
    public Text highScore;
    int hs;
    // Start is called before the first frame update
    void Start()
    {
        highScore.text = "High Score is ";
        hs = PlayerPrefs.GetInt("HighScore", hs);
        highScore.text += hs.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
