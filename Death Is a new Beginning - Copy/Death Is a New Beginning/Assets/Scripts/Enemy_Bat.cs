using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bat : MonoBehaviour
{
    public float speed;
    public float knockedDistance;
    public float startingDistance;
    public float stoppingDistance;
    public float retreatingDistance;

    private float timeBtwShots;
    public float startTimeBtwShots;
    public GameObject projectile;

    private Transform player;
    public bool active = false;
    public bool m_FacingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        player = PlayerManager.instance.player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
        if ((Vector2.Distance(transform.position, player.position) > startingDistance) && active == false)// && active == true)
        {
            //Debug.Log(Vector2.Distance(transform.position, player.position));
            //transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            active = true;
        }
        else if ((Vector2.Distance(transform.position, player.position) > knockedDistance) && active == true)
        {
            //Debug.Log(Vector2.Distance(transform.position, player.position));
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, player.position) > stoppingDistance && Vector2.Distance(transform.position, player.position) < retreatingDistance)
        {
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, player.position) < retreatingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }


        if (timeBtwShots <= 0 && Vector2.Distance(transform.position, player.position) < stoppingDistance)
        {
            timeBtwShots = startTimeBtwShots;
           // Instantiate(projectile, transform.position, Quaternion.identity);

        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }

        if (player.position.x < transform.position.x && m_FacingRight)
        {
            Flip();
        }
        else if (player.position.x > transform.position.x && !m_FacingRight)
        {
            Flip();
        }

    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        transform.Rotate(0f, 180f, 0f);
    }
}