using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    #region Singleton

    public static PlayerManager instance;
    private void Awake()
    {
        instance = this;
    //    health = player.GetComponent<Health>();
    }

    #endregion

    public GameObject player;
    public GameObject point;
    public Health health;
}
