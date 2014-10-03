﻿using UnityEngine;
using System;
using System.Collections;
using System.Linq;

public class AstroidSpawner : MonoBehaviour
{
    public int RadiusX = 250; 
    public int RadiusY = 200;

    public int Count = 100;

    public int Layers = 10;
    public int RadiusInc = 10;

    public float Variance = 5;
    public float ScaleMin = 3;
    public float ScaleMax = 7;



    void Start()
    {
        Sprite[] ss = UnityEditor.AssetDatabase.LoadAllAssetsAtPath("Assets/Sprites/Planets/Asteroids_vario.png").OfType<Sprite>().ToArray();


        GameObject g = new GameObject("At");
        SpriteRenderer s = g.AddComponent<SpriteRenderer>();

        EdgeCollider2D edge = GetComponent<EdgeCollider2D>();
        Vector2[] points = new Vector2[Count + 1];

        
        for (int ii = 0; ii < Layers; ii++)
        {
            for (int i = 0; i < Count; i++)
            {

                float x = Mathf.Sin(2 * Mathf.PI / Count * i) * (RadiusX + ii * RadiusInc) + UnityEngine.Random.Range(-Variance, Variance);
                float y = Mathf.Cos(2 * Mathf.PI / Count * i) * (RadiusY + ii * RadiusInc) + UnityEngine.Random.Range(-Variance, Variance);
                Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, UnityEngine.Random.Range(0, 360)));
                float scale = UnityEngine.Random.Range(ScaleMin, ScaleMax);


                GameObject gg = Instantiate(g, new Vector3(x, y), rotation) as GameObject;
                gg.transform.localScale = new Vector3(scale, scale);
                gg.transform.parent = this.transform;

                s.sprite = ss[UnityEngine.Random.Range(0, 24)];

                if (ii == 0)
                    points[i] = new Vector2(x, y);
                if (ii == 0 && i == 0)
                    points[Count] = new Vector2(x, y);
            }
        }
        edge.points = points;

        GameObject.Destroy(g);
    }


    void Update()
    {

    }
}
