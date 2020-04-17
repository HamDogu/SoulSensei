using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbLogic : MonoBehaviour
{
    public string orb;
    public Inventory inventory;
    public GameObject particle;

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
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player == null) Debug.Log("No player found");
        Inventory inventory = player.GetComponent<Inventory>();
        if (inventory == null) Debug.Log("No invernt found");
        Debug.Log("Enter orb");
        inventory.AddOrb(orb);
        Instantiate(particle, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
