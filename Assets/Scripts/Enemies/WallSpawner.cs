using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class WallSpawner : MonoBehaviour, IEnemySpawner
{
    [SerializeField] private GameObject wall;
    [SerializeField] private float spawnTime = 1f;
    [SerializeField] private float minHeight = 1f;
    [SerializeField] private float maxHeight = 2f;
    [SerializeField] private Vector3 spawnPosition;
    private float timer;
    private bool isActive;

    void Awake()
    {
        SetActive(false);
        spawnPosition = new Vector3(2.8f, -1.2f, 0.01f);
        wall = Resources.Load<GameObject>("Prefabs/Wall");
    }

    void Update()
    {
        if (isActive)
        {
            if (timer > spawnTime)
            {
                GameObject _ = Spawn();
                timer = 0;
            }
            timer += Time.deltaTime;
        }
    }

    private GameObject Spawn()
    {
        GameObject newWall = Instantiate(wall);

        SpriteRenderer wallRender = newWall.GetComponent<SpriteRenderer>();
        Transform wallTransform = newWall.GetComponent<Transform>();
        BoxCollider2D wallCollider = newWall.GetComponent<BoxCollider2D>();

        wallRender.size = new Vector2(1, Random.Range(minHeight, maxHeight)); //Генерируем высоту стены
        wallTransform.position = spawnPosition; //Перемещаем стену на позицию спавна за пределами кадра

        //Подгоняем размеры и смещение коллайдера под растянутый спрайт
        wallCollider.size = wallRender.size; 
        wallCollider.offset *= wallRender.size.y;

        return newWall;
    }

    public void SetActive(bool switcher) => isActive = switcher;
}