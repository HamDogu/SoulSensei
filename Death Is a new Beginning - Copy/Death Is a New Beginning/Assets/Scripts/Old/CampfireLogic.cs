using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampfireLogic : MonoBehaviour
{
    public GameObject campfireLit;

    private void Start()
    {
       // Debug.Log("Start Camp");
    }

    public void ActivateCamp()
    {
        Debug.Log("Activeated Camp");
        Instantiate(campfireLit, transform.position, transform.rotation);
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        PlayerScore score = player.GetComponent<PlayerScore>();
        score.statuesInspected++;
        //PlayerMovement pm = player.GetComponent<PlayerMovement>();
        Destroy(gameObject);
    }

    /*   
    private void OnCollisionEnter2D(Collision2D hitInfo)
    {
        Debug.Log("Campfire Lit");

        if (hitInfo.collider.tag == "Magic")
        {
            ActivateCamp();
        }
    }
    */
}
