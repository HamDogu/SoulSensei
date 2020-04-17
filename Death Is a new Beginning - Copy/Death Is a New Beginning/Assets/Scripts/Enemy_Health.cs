using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health : MonoBehaviour
{
    //public Animator animator;
    public int health = 100;
    public GameObject enemy;
    public GameObject deathEffect;
    public GameObject enemyParticle;
    public GameObject point;

    private Rigidbody2D myrigidbody2d;
    private Vector2 myForce = new Vector2(1f, 1f);
    public float force = 10f;
    public bool isNotGhost = false;

    private void Start()
    {
        myrigidbody2d = GetComponent<Rigidbody2D>();
    }

    public void takeDamage(int damage)
    {
        GameObject playerG = PlayerManager.instance.player;
        if (isNotGhost)
        {
            Enemy_Ninja eh = GetComponent<Enemy_Ninja>();
            Instantiate(enemyParticle, point.transform.position, Quaternion.identity);
            float x, y;

            if (eh.m_FacingRight) x = -1;
            else x = 1;

            if (transform.position.y > playerG.transform.position.y) y = 1;
            else y = -1;

            myForce = new Vector2(x, y);

            myrigidbody2d.AddForce(myForce * force, ForceMode2D.Impulse);
        }
        else
        {
            Enemy_Bat eb = GetComponent<Enemy_Bat>();
            Instantiate(enemyParticle, point.transform.position, Quaternion.identity);
            float x, y;

            if (eb.m_FacingRight) x = -1;
            else x = 1;

            if (transform.position.y > playerG.transform.position.y) y = 1;
            else y = -1;

            myForce = new Vector2(x, y);

            myrigidbody2d.AddForce(myForce * force, ForceMode2D.Impulse);
        }
        

        health -= damage;
        //animator.SetBool("Hit", true);

        if (health <= 0)
        {
            Die();
        }

       
        //animator.SetBool("Hit", false);
    }

    public void Die()
    {
        Instantiate(deathEffect, point.transform.position, Quaternion.identity);
        GameObject playerG = GameObject.FindGameObjectWithTag("Player");
        PlayerScore score = PlayerScore.instance;
        score.enemiesFought++;
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.CompareTag("Player"))
        {
            Debug.Log("Player Shot");
            GameObject playerG = GameObject.FindGameObjectWithTag("Player");
            Health he = playerG.GetComponent<Health>();
            PlayerMovement pm = playerG.GetComponent<PlayerMovement>();
            if (!pm.attacking)
            {
                he.health = he.health - 1;

                //myrigidbody2d.AddForce(myForce * force, ForceMode2D.Impulse);
                // playerG.GetComponent<Rigidbody2D>().AddForce(-1* myForce * force, ForceMode2D.Impulse);

                ///////////////////////
                //float[] newX = { Random.Range(4, 8), Random.Range(-4, -8) };
                ////float[] newY = { Random.Range(4, 8), Random.Range(-4, -8) };
                //float X = newX[(int)Random.Range(0, 1)];
                //float Y = newY[(int)Random.Range(0, 1)];
                if (isNotGhost)
                {
                    Enemy_Ninja eh = GetComponent<Enemy_Ninja>();
                    Instantiate(enemyParticle, point.transform.position, Quaternion.identity);
                    float x, y;

                    if (eh.m_FacingRight) x = -1;
                    else x = 1;

                    if (transform.position.y > playerG.transform.position.y) y = 1;
                    else y = -1;

                    myForce = new Vector2(x, y);

                    myrigidbody2d.AddForce(myForce * force, ForceMode2D.Impulse);
                    AudioManager.instance.Play("Hit");
                    //StartCoroutine(ChangeColor(playerG));
                }
                else
                {
                    //Enemy_Bat eb = GetComponent<Enemy_Bat>();
                    //Instantiate(enemyParticle, point.transform.position, Quaternion.identity);
                    //float x, y;

                    //if (eb.m_FacingRight) x = -1;
                    //else x = 1;

                    //if (transform.position.y > playerG.transform.position.y) y = 1;
                    //else y = -1;

                    //myForce = new Vector2(x, y);

                    //myrigidbody2d.AddForce(myForce * force, ForceMode2D.Impulse);
                }


                if (isNotGhost)
                {
                    return;
                }
                else
                {

                }
                float X = 2.5f;//[(int)Random.Range(8, 10)];
                float Y = 2.5f;//[(int)Random.Range(8, 10)];
                Vector2 newPos;
                newPos.y = Y;
                newPos.x = X;

                //  Debug.Log(newPos);
                Instantiate(deathEffect, transform);
                Instantiate(enemy, transform.position * newPos, Quaternion.identity);
                Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
                rb.MovePosition(newPos + rb.position);

                AudioManager.instance.Play("Hit");
                //StartCoroutine(ChangeColor(playerG));
                Destroy(gameObject);
            }
            
            
            
        }
        //Debug.Log("Trigger Entered Enegy Health Script");
        //Player_Attack enemy = hitInfo.GetComponent<Player_Attack>();
        //Debug.Log(hitInfo.name);
        //if (enemy != null)
        //{
        //    Debug.Log("Enemy Entered");

        //    takeDamage(enemy.damage);
        //    Destroy(gameObject);
        //}

        //else if (hitInfo.tag != "Player")
        //{
        //    Debug.Log(hitInfo.name);
        //    Debug.Log(hitInfo.tag);
        //    Destroy(gameObject);
        //}

    }
}
