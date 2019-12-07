using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlManager : MonoBehaviour {

    public GameObject CurrentCheckpoint;
    void Start()
    {

    }

    void Update()
    {

    }
    public void RespawnPlayer()
    {
        FindObjectOfType<PlayerController>().transform.position = CurrentCheckpoint.transform.position;
    }
}
