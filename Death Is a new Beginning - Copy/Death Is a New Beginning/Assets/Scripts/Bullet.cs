using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 40f;
    public int damage = 40;
    public float destroyDistance;
    public string direction;

    private GameObject playerG;
    private Transform player;
    public Rigidbody2D rb;
    public GameObject boomEffect;
    // Start is called before the first frame update
    void Start()
    {
        playerG = PlayerManager.instance.player;
        player = playerG.transform;
        PlayerMovement pm = playerG.GetComponent<PlayerMovement>();
        if (direction == "up")
        {
            rb.velocity = transform.up * bulletSpeed;
        }
        else if (direction == "side")
        {
            rb.velocity = transform.right * bulletSpeed;
        }
        else
        {
            rb.velocity = transform.up * -1 * bulletSpeed;
        }
        
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, player.position) > destroyDistance)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy_Health enemy = hitInfo.GetComponent<Enemy_Health>();
        if (enemy != null)
        {
            enemy.takeDamage(damage);
            //    Instantiate(boomEffect, transform.position, Quaternion.identity);
            //Debug.Log("Enemy Hit");
            AudioManager.instance.Play("Enemy");

            Destroy(gameObject);
        }

        else if (hitInfo.tag != "Player")
        {
            Debug.Log(hitInfo.name);
            Debug.Log(hitInfo.tag);
            Destroy(gameObject);

        }
        else if (hitInfo.CompareTag("Player"))
        {
            //Debug.Log("Enemy not hit");
        }
        else
        {
            Debug.Log("Enemy not hit");
            Destroy(gameObject);
        }
       

    }
}
