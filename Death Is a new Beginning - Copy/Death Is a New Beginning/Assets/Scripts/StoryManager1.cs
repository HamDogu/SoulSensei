using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryManager1 : MonoBehaviour
{

    #region Singleton

    public static StoryManager1 instance;
    private void Awake()
    {
        instance = this;
        //health = player.GetComponent<Health>();
    }

    #endregion

    public Animator grandpaAnim;
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
                grandpaAnim.SetTrigger("Activate");
            }
          
        }
        else
        {
            LevelChanger.instance.ActivateCandles();
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
            GameObject player = PlayerManager.instance.player;
            player.GetComponent<PlayerMovement>().enabled = true;
            Debug.Log("Enabled Player");
        }

      

    }

}
