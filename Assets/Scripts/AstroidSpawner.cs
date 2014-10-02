using UnityEngine;
using System;
using System.Collections;

public class AstroidSpawner : MonoBehaviour
{

    void Start()
    {
        GameObject g = new GameObject("AstroidT");
        SpriteRenderer s = g.AddComponent<SpriteRenderer>();

        Sprite[] ss = UnityEditor.AssetDatabase.LoadAllAssetsAtPath("Assets/Sprites/Planets/Asteroids") as Sprite[];
        s.sprite = ss[0];
    }


    void Update()
    {

    }
}
