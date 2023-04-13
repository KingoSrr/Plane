using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipSpawn : MonoBehaviour
{
    public GameObject greenGO;
    public GameObject blueGO;
    public Transform greenSpawnPoint;
    public Transform blueSpawnPoint;
    void Start()
    {
        GameObject green = Instantiate(greenGO);
        GameObject blue = Instantiate(blueGO);
        green.transform.position = greenSpawnPoint.position;
        blue.transform.position = blueSpawnPoint.position;
    }
}
