using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawner : MonoBehaviour
{
    private static WallSpawner instance = null;

    [SerializeField] private GameObject wall;
    [SerializeField] private float spawnTime;
    [SerializeField] private float maxHeight;
    [SerializeField] private Vector3 spawnPosition;
    private float timer;
    private bool isActive;

    public static WallSpawner Instance
    {
        get
        {
            if (instance == null) instance = new GameObject("GameManager").AddComponent<WallSpawner>(); //create game manager object if required
            return instance;
        }
    }

    void Awake()
    {
        if (instance)
            DestroyImmediate(gameObject); //Delete duplicate
        else
        {
            instance = this; //Make this object the only instance
            DontDestroyOnLoad(gameObject); //Set as do not destroy
        }
        SetActive(false);
    }

    void Start()
    {
        
    }

    private void Update()
    {
        if (isActive)
        {
            if (timer > spawnTime)
            {
                SpawnWall();
                timer = 0;
            }
            timer += Time.deltaTime;
        }
    }

    private void SpawnWall()
    {
        GameObject newWall = Instantiate(wall);
        SpriteRenderer wallRender = newWall.GetComponent<SpriteRenderer>();
        Transform wallTransform = newWall.GetComponent<Transform>();
        wallRender.size = new Vector2(1, Random.Range(1f, maxHeight));
        wallTransform.position = spawnPosition;
    }

    public void SetActive(bool switcher) => isActive = switcher;
}