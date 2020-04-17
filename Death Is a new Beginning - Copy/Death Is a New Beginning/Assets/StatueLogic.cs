using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueLogic : MonoBehaviour
{
    DialogueTrigger trigger;
    bool inspected = false;
    bool triggered = false;

    // Start is called before the first frame update
    void Start()
    {
        trigger = GetComponent<DialogueTrigger>();
    }

    // Update is called once per frame
    void Update()
    {
        if (triggered && !inspected)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                trigger.TriggerDialogue();
                PlayerScore.instance.statuesInspected++;
                AudioManager.instance.Play("Coin");
                PlayerManager.instance.health.health++;
                inspected = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        triggered = true;
        PlayerMovement pm = PlayerManager.instance.player.GetComponent<PlayerMovement>();
        pm.chestNear = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        triggered = false;
        PlayerMovement pm = PlayerManager.instance.player.GetComponent<PlayerMovement>();
        pm.chestNear = false;
    }
}
