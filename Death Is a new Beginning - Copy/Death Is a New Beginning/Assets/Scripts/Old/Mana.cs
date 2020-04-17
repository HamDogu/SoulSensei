using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mana : MonoBehaviour
{
    public int mana;
    public int numOfMana;

    public Image[] manaImages;
    public Sprite fullMana;
    public Sprite emptyMana;

    public int counter = 0;
    public int counterMax = 60;

    private void Start()
    {
        mana = PlayerPrefs.GetInt("mana", 5);
        numOfMana = PlayerPrefs.GetInt("maxMana", 5);
    }

    // Update is called once per frame
    void Update()
    {
        counter++;
        if (counter > counterMax)
        {
            counter = 0;
            mana++;
        }

        if (mana > numOfMana)
        {
            mana = numOfMana;
        }
        else if (mana < 1)
        {
            mana = 0;
            // OutOfMana();
        }

        for (int i = 0; i < manaImages.Length; i++)
        {
            if (i < mana)
            {
                manaImages[i].sprite = fullMana;
            }
            else
            {
                manaImages[i].sprite = emptyMana;
            }

            if (i < numOfMana)
            {
                manaImages[i].enabled = true;
            }
            else
            {
                manaImages[i].enabled = false;
            }
        }
    }

    public void OutOfMana()
    {
        Debug.Log("No more mana :(");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
