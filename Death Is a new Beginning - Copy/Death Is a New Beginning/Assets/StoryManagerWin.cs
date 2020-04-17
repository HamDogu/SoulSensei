using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryManagerWin : MonoBehaviour
{

    #region Singleton

    public static StoryManagerWin instance;
    private void Awake()
    {
        instance = this;
        //health = player.GetComponent<Health>();
    }

    #endregion

    public GameObject TeleporterEnd;
    public DialogueTrigger[] trigger;
    private int dialogueNum;
    [SerializeField]
    private bool story;
    [SerializeField]
    private bool enablePlayer;

    public void BeginStory()
    {
        if (story)
        {
            Debug.Log(trigger.Length);
            Debug.Log(dialogueNum);
            if (dialogueNum < trigger.Length)
            {
                trigger[dialogueNum].TriggerDialogue();
                dialogueNum++;
            }
            else
            {
                TeleporterEnd.SetActive(true);
            }

        }
        else
        {
            TeleporterEnd.SetActive(true);
        }

        if (enablePlayer)
        {
            GameObject player = PlayerManager.instance.player;
            player.GetComponent<PlayerMovement>().enabled = true;
        }

    }

    public void SpawnPlayer()
    {
        GameObject player = PlayerManager.instance.player;
        player.SetActive(true);
        //player.GetComponent<PlayerMovement>().EnablerRenderer();
    }

    public void BeginSecondLevelDialogue()
    {

        if (dialogueNum < trigger.Length)
        {
            trigger[dialogueNum].TriggerDialogue();
            dialogueNum++;
        }
        else
        {
            TeleporterEnd.SetActive(true);
        }



    }

    public void PlayerWin()
    {
        PlayerManager.instance.health.PlayerWin();
    }

    public void SetTeleporter()
    {
        TeleporterEnd.SetActive(true);
    }

}
