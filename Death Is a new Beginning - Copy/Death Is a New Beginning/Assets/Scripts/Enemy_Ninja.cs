using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Ninja : MonoBehaviour
{
    public float speed;
    public float knockedDistance;
    public float startingDistance;
    public float stoppingDistance;
    public float retreatingDistance;

    private float timeBtwShots;
    public float startTimeBtwShots;
    public GameObject projectile;

    private Animator animator;
    private Transform player;
    public bool active = false;
    public bool m_FacingRight = true;
    private bool attacking = false;

    // Start is called before the first frame update
    void Start()
    {
        player = PlayerManager.instance.player.transform;
        animator = gameObject.GetComponent<Animator>();
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
            animator.SetFloat("Speed", 1);
        }
        else if ((Vector2.Distance(transform.position, player.position) > knockedDistance) && active == true)
        {
            //Debug.Log(Vector2.Distance(transform.position, player.position));
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, player.position) > stoppingDistance && Vector2.Distance(transform.position, player.position) < retreatingDistance)
        {
            transform.position = this.transform.position;
            //if (!attacking)
            //{
            //    attacking = true;
            //    animator.SetTrigger("Attack");
            //}
        }
        else if (Vector2.Distance(transform.position, player.position) < retreatingDistance)
        {
            //if (!attacking)
            //{
            //    attacking = true;
            //    animator.SetTrigger("Attack");
            //}
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
 
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("TriggerEntered");
        if (!attacking)
        {
            attacking = true;
            animator.SetTrigger("Attack");
        }
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        transform.Rotate(0f, 180f, 0f);
    }

    private void ResetAttack()
    {
        animator.ResetTrigger("Attack");
        attacking = false;
    }
}