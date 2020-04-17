using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class teleporterLogic : MonoBehaviour
{
    public StoryManager1 story;
    public GameObject teleporterField;
    public GameObject teleportingBeam;
    public bool tutorial = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (tutorial)
        {
            if (collision.CompareTag("Player"))
            {
                ActivateTeleport();
            }
        }
        else
        {
            if (collision.CompareTag("Player"))
            {
                ActivateTeleport();
            }
        }
       
 

        #region Previous
        //GetComponent<StoryManager1>().BeginStory();

        //if (tutorial)
        //{
        //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //}
        //else
        //{
        //    GameObject player = GameObject.FindGameObjectWithTag("Player");
        //    Health health = player.GetComponent<Health>();
        //    health.PlayerWin();
        //}
        //
        #endregion
    }

    public void HidePlayer()
    {
        PlayerManager.instance.player.SetActive(false);
        teleporterField.SetActive(false);
    }

    public void ActivateTeleport()
    {
        teleportingBeam.SetActive(true);
        AudioManager.instance.Play("Teleport");
    }



}
