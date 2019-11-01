using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField]
    private HUD gameOver;

    public int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    Highscores highscores = new Highscores();

     // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        string json;

        if (!PlayerPrefs.HasKey("highscoreTable"))
        {
            json = JsonUtility.ToJson(0);
            PlayerPrefs.SetString("highscoreTable", json);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(health > numOfHearts)
        {
            health = numOfHearts;
        }

        for(int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    public void Damage()
    {
        health--;

        if(health <= 0)
        {
            gameOver.mPanelGameOver.gameObject.SetActive(true);
            gameOver.mTextGameOver.gameObject.SetActive(true);

            Time.timeScale = 0;
            AddHighscoreEntry(gameOver.hitCount);
        }
    }

    public void AddHighscoreEntry(int score)
    {
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        highscores = JsonUtility.FromJson<Highscores>(jsonString);

        highscores.highscoreEntryList.Add(score);

        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
    }

}
