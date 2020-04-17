using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingLayer : MonoBehaviour
{
    GameObject player;
    public Collider2D[] colliders;
    public Transform point;
    public bool colliderDetect;
    // Start is called before the first frame update
    void Start()
    {
        player = PlayerManager.instance.point;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y > transform.position.y)
        {
            if (colliderDetect)
            {
                colliders[0].enabled = false;
                colliders[1].enabled = true;
            }
            GetComponent<SpriteRenderer>().sortingLayerName = "Forground";
        }
        else
        {
            if (colliderDetect)
            {
                colliders[0].enabled = true;
                colliders[1].enabled = false;
            }
            GetComponent<SpriteRenderer>().sortingLayerName = "Default";
        }
    }
}

