using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public int orbs;
    public int maxOrbs = 4;

    public bool updated = true;
    private string[] colours = new string[4];
    public Image[] orbImages;
    public Sprite redOrb;
    public Sprite blueOrb;
    public Sprite greenOrb;
    public Sprite yellowOrb;
    public Sprite emptyMana;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < orbImages.Length; i++)
        {
            orbImages[i].sprite = emptyMana;
        }
        orbs = new int();
        CheckSprites();
        orbs = 0;
        //orbImages[i].color.a.Equals(0);
    }

    private void CheckSprites()
    {
        if (blueOrb == null)
        {
            Debug.Log("Blue = null");

        }
        else
        {
            Debug.Log("Blue = NOT Null");
        }
    }

    // Update is called once per frame
    void Update()
    {
          

        if (orbs > maxOrbs -1)
        {
            orbs = maxOrbs -1;
        }
        else if (orbs < 0)
        {
            orbs = 0;
            // OutOfMana();
        }

        if (!updated)
        {
            if (orbs > 0)
            {
                ChangeOrb(colours[orbs - 1], orbs - 1);
                updated = true;
                // orbImages[orbs].sprite = bl\ueOrb;
            }
        }

        //for (int i = 0; i < orbImages.Length; i++)
        //{
        //    if (i < orbs)
        //    {
        //        //orbImages[i].sprite = fullMana;
        //    }
        //    else
        //    {
        //        orbImages[i].sprite = emptyMana;
        //    }

        //    if (i < maxOrbs)
        //    {
        //        orbImages[i].enabled = true;
        //    }
        //    else
        //    {
        //        orbImages[i].enabled = false;
        //    }
        //}
    }

    private void ChangeOrb(string info, int orbs)
    {
        if (info == "red")
        {
            orbImages[orbs].sprite = redOrb;
        }
        else if (info == "blue")
        {
            if (blueOrb != null) Debug.Log("Blue NOT null");
            orbImages[orbs].sprite = blueOrb;
        }
        else if (info == "green")
        {
            orbImages[orbs].sprite = greenOrb;
        }
        else if (info == "yellow")
        {
            orbImages[orbs].sprite = yellowOrb;
        }
    }

    public void AddOrb(string info)
    {
        orbs++;
        //Debug.Log(orbs);
        //orbs = 0;
        Debug.Log(orbs);
        updated = false;
        colours[orbs-1] = info;
        //if (info == "red")
        //{
        //    orbImages[orbs].sprite = redOrb;
        //}
        //else if (info == "blue")
        //{
        //    if (blueOrb != null) Debug.Log("Blue NOT null");
        //    orbImages[orbs].sprite = blueOrb;
        //}
        //else if (info == "green")
        //{
        //    orbImages[orbs].sprite = greenOrb;
        //}
        //else if (info == "yellow")
        //{
        //    orbImages[orbs].sprite = yellowOrb;
        //}

    }
}
