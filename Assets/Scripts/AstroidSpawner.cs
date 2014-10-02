using UnityEngine;
using System;
using System.Collections;
using System.Linq;

public class AstroidSpawner : MonoBehaviour
{
    public int radiusx = 100; 
    public int radiusy = 100;

    public int count = 100;


    void Start()
    {
        Sprite[] ss = UnityEditor.AssetDatabase.LoadAllAssetsAtPath("Assets/Sprites/Planets/Asteroids.png").OfType<Sprite>().ToArray();


        GameObject g = new GameObject("At");
        SpriteRenderer s = g.AddComponent<SpriteRenderer>();

        for (int i = 0; i < count; i++)
        {
            GameObject gg = Instantiate(g, new Vector3(Mathf.Sin(2 * Mathf.PI / count * i) * radiusx, Mathf.Cos(2 * Mathf.PI / count * i) * radiusy), Quaternion.Euler(new Vector3(0, UnityEngine.Random.Range(0, Mathf.PI * 2), 0))) as GameObject;
            s.sprite = ss[UnityEngine.Random.Range(0, 24)];

            gg.transform.localScale = new Vector3(5, 5);

            gg.transform.parent = this.transform;
        }
        GameObject.Destroy(g);
    }


    void Update()
    {

    }
}
