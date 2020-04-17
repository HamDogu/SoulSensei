using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chestLogic : MonoBehaviour
{

    private GameObject player;
    public GameObject[] item;
    public GameObject openChest;
    private PlayerMovement pm;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pm = player.GetComponent<PlayerMovement>();
        pm.chestNear = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Left Chest");
        pm.chestNear = false;
    }


    
    public void OpenChest()
    {
        Debug.Log(transform.position);
        //Debug.Log("Open Chest Function reached... Instatiating Chest");
        Instantiate(openChest, gameObject.transform.position, gameObject.transform.rotation);
        //Debug.Log("Instantiating Item");
        int rand = Random.Range(0, item.Length);

        GameObject Item = Instantiate(item[rand], transform.position, gameObject.transform.rotation);
        Debug.Log(Item.transform.position);
        //Debug.Log("Deactivating chest near flag");
        pm.chestNear = false;

        PlayerScore score = player.GetComponent<PlayerScore>();
        score.chestsOpened++;
        //Debug.Log("Destroying gameobject");
        Destroy(gameObject);
        
    }
}
