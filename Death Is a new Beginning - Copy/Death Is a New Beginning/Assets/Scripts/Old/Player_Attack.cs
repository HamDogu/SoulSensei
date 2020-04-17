using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{
    public int damage = 50;

    private GameObject player;
    private Collider2D colliderPlayer;
    private Collider2D collider;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Attack Script Activated");
        collider = GetComponent<Collider2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        colliderPlayer = player.GetComponent<Collider2D>();
        Physics2D.IgnoreCollision(colliderPlayer, collider);
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        PlayerMovement pm = player.GetComponent<PlayerMovement>();
        Debug.Log("Trigger Entered Attack");
        Enemy_Health enemy = hitInfo.GetComponent<Enemy_Health>();
        Debug.Log(hitInfo.name);
        //pm.ResetPowder();
        if (enemy != null)
        {
            Debug.Log("Enemy Entered + taken damage");

            enemy.takeDamage(damage);
            //pm.ResetPowder();
            // Destroy(gameObject);
            return;
        }
        CampfireLogic campfireLogic = hitInfo.GetComponent<CampfireLogic>();
        if (campfireLogic != null)
        {
            campfireLogic.ActivateCamp();
           // pm.ResetPowder();
            return;
        }
        

        if (hitInfo.tag != "Player")
        {
            Debug.Log(hitInfo.name);
            Debug.Log(hitInfo.tag);
          //  pm.ResetPowder();
            //   Destroy(gameObject);
        }

       // pm.ResetPowder();

    }
}
