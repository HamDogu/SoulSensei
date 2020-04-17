using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] spawnpoints;
    public GameObject teleporter;
    // Start is called before the first frame update
    void Start()
    {
        int rnd = Random.Range(0, spawnpoints.Length);
        Debug.Log("Spwan point " + rnd);
        GameObject spawnPoint = Instantiate(spawnpoints[rnd]);
        teleporter.transform.position = spawnPoint.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
