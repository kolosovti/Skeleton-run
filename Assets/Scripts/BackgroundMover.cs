using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMover : MonoBehaviour
{
    [SerializeField] private float speed;
    private Renderer renderer;

    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    void Update()
    {
        float offset = Time.time * speed;
        renderer.material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }
}