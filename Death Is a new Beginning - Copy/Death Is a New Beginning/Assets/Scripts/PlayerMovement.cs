using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;
    public GameObject shuriken;
    public GameObject shurikenUp;
    public GameObject shurikenDown;
    public Transform attackPoint;
    public Transform attackPointUp;
    public Transform attackPointDown;

    public float moveSpeed = 5f;

    private bool m_FacingRight = true;
    public float radiusScan;

    public bool movementEnabled = true;
    public bool chestNear = false;

    public bool attacking = false;
    private float initialLight;
   // private Mana mana;

    Vector2 movement;
    [HideInInspector] public Vector2 move;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (movementEnabled)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
        }
        else
        {
            movement.x = 0;
            movement.y = 0;
        }
       

        if (movement != Vector2.zero)
        {
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            move.x = movement.x;
            move.y = movement.y;
        }
        animator.SetFloat("Speed", movement.sqrMagnitude);

        // If the input is moving the player right and the player is facing left...
        if (movement.x > 0 && !m_FacingRight)
        {
            Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (movement.x < 0 && m_FacingRight)
        {
            Flip();
        }

        //Attack
        if (Input.GetButtonDown("Fire1") && !attacking && movementEnabled && chestNear == false) // && mana.mana > 0)
        {
            movementEnabled = false;
            attacking = true;
            animator.SetTrigger("Attacking");
           // movementEnabled = false;

        }
        else if (Input.GetButtonDown("Fire1") && chestNear == true)
        {
            //Debug.Log("Open Chest button down");
            GameObject chest = ReturnChestObj();
            //Debug.Log("Chest Data: " + chest.name + "  " + chest.tag);
            chestLogic logic = chest.GetComponent<chestLogic>();
            //Debug.Log("logic function done?");
            if (logic == null) Debug.Log("No logic found");
           // Debug.Log("Logic Data: " + logic.name + "  " + logic.tag);
            //Debug.Log("Opening Chest");
            else logic.OpenChest();
            chestNear = false;
            //movementEnabled = true;
        }
    }

    private GameObject ReturnChestObj()
    {
        GameObject chest;

        Collider2D[] hitColliders = Physics2D.OverlapCircleAll (new Vector2(transform.position.x, transform.position.y), radiusScan);

        /*   //DEBUG INFO
        Debug.Log("Length of hit objects: " + hitColliders.Length);
        for (int i = 0; i < hitColliders.Length; i++)
        {
            Debug.Log(hitColliders[i].name);
            Debug.Log(hitColliders[i].gameObject.name);
            Debug.Log(hitColliders[i].gameObject.tag);
            Debug.Log(" ");

        }
        */

        for (int i = 0; i < hitColliders.Length; i++)
        {
            if (hitColliders[i].gameObject.tag == "Chest")
            {
                chest = hitColliders[i].gameObject;
                Debug.Log("Chest Found");
                return chest;
            }
        }
        chestNear = false;
        animator.SetTrigger("ThrowPowder");
        Debug.Log("Chest NOT found");
        return new GameObject();

    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        transform.Rotate(0f, 180f, 0f);
    }

    private void ThrowPowder()
    {
     //   mana.mana--;
        Instantiate(shuriken, attackPoint.position, attackPoint.rotation);
        AudioManager.instance.Play("Throw");
        animator.ResetTrigger("Attacking");
        ResetPowder();
    }

    private void ThrowPowderUp()
    {
        //   mana.manaattackPoint
        Instantiate(shurikenUp, attackPointUp.position, attackPointUp.rotation);
        AudioManager.instance.Play("Throw");
        animator.ResetTrigger("Attacking");
        ResetPowder();
    }

    private void ThrowPowderDown()
    {
        //   mana.mana--;
        Instantiate(shurikenDown, attackPointDown.position, attackPointDown.rotation);
        AudioManager.instance.Play("Throw");
        animator.ResetTrigger("Attacking");
        ResetPowder();
    }

    public void DeactivatePowder()
    {
        movementEnabled = false;
        Debug.Log("Movement Deactivated");
    }

    public void ResetPowder()
    {
        movementEnabled = true;
        attacking = false;
        //Debug.Log("Movement Reset");
    }
    
    public void EnablerRenderer()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.enabled = true;
    }


}
