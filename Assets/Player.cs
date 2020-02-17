using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    int highScore;
    public float JumpForce = 4f;
    public Rigidbody2D rb;
    public string currentColor;
    public SpriteRenderer sr;
    public AudioClip tick;
    public Color colorCyan;
    public Color colorYellow;
    public Color colorMagenta;
    public Color colorPink;
    public GameObject[] circles;
    [HideInInspector]
    public int score;
    float z = 12f;
    public Text score_display;

    void Start()
    {
        SetRandomColor();
    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0) || Input.touchCount == 1)
        {
            rb.velocity = Vector2.up * JumpForce;
            AudioSource.PlayClipAtPoint(tick, transform.position,1f);
        }
        score_display.text = score.ToString();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "ColorChanger")
        {
            SetRandomColor();
            Destroy(collision.gameObject);
            spawn();
            score += 5;
            return;
        }
        if(collision.tag != currentColor)
        {
            PlayerPrefs.SetInt("Score", score);
            if (score > highScore)
            {
                highScore = score;
                PlayerPrefs.SetInt("HighScore", highScore);
            }
            SceneManager.LoadScene(2);
        }
    }

    void spawn()
    {
        Instantiate(circles[Random.Range(0, circles.Length)], new Vector3(0f, z, 0f), Quaternion.identity);
        z += 12;
    }
    void SetRandomColor()
    {
        int index = Random.Range(0, 4);

        switch(index)
        {
            case 0:
                currentColor = "Cyan";
                sr.color = colorCyan;
                break;
            case 1:
                currentColor = "Yellow";
                sr.color = colorYellow;
                break;
            case 2:
                currentColor = "Magenta";
                sr.color = colorMagenta;
                break;
            case 3:
                currentColor = "Pink";
                sr.color = colorPink;
                break;
               
        }
    }
} 
