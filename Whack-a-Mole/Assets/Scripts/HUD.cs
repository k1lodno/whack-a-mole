using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public RectTransform mPanelGameOver;
    public Text mTextGameOver;
    public int hitCount = 0;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>(); ; 
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + hitCount.ToString();
    }
}
