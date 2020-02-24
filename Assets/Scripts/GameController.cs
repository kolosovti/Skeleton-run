using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    WallSpawner wallSpawner;
    void Start()
    {
        wallSpawner = WallSpawner.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > 1)
            wallSpawner.SetActive(true);
        Debug.Log(Time.time);
    }
}
