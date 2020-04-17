using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    
    public int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public GameObject deathScreen;

    private void Start()
    {
        health =  PlayerPrefs.GetInt("health", 5);
        numOfHearts = PlayerPrefs.GetInt("maxHealth", 5);
        deathScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (health > numOfHearts)
        {
            health = numOfHearts;
        }
        else if (health < 1)
        {
            PlayerDie();
        }

        for (int i = 0; i < hearts.Length; i++)
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

    public void PlayerDie()
    {
        Debug.Log("You died :(");
      
        GameObject player = PlayerManager.instance.player;
        PlayerScore score = PlayerScore.instance;
        player.SetActive(false);
        score.CountScore(true);

        deathScreen.SetActive(true);

        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PlayerWin()
    {
        Debug.Log("Teleporter Reached");
  
        GameObject player = PlayerManager.instance.player;
        PlayerScore score = PlayerScore.instance;
        player.SetActive(false);
        score.CountScore(false);

        deathScreen.SetActive(true);

    }

    public void Resetter()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
