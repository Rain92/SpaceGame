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
        Sprite[] ss = UnityEditor.AssetDatabase.LoadAllAssetsAtPath("Assets/Sprites/Planets/Asteroids_vario.png").OfType<Sprite>().ToArray();


        GameObject g = new GameObject("At");
        SpriteRenderer s = g.AddComponent<SpriteRenderer>();

        int radinc = 10;
        
        for (int ii = 0; ii < 10; ii++)
        {
            for (int i = 0; i < count; i++)
            {
                float variance = 5;
                GameObject gg = Instantiate(g,
                    new Vector3(
                        Mathf.Sin(2 * Mathf.PI / count * i) * (radiusx + ii * radinc) + UnityEngine.Random.Range(-variance, variance),
                        Mathf.Cos(2 * Mathf.PI / count * i) * (radiusy + ii * radinc) + UnityEngine.Random.Range(-variance, variance)),
                    Quaternion.Euler(new Vector3(0, 0, UnityEngine.Random.Range(0, 360)))) as GameObject;

                s.sprite = ss[UnityEngine.Random.Range(0, 24)];

                float f = UnityEngine.Random.Range(3, 7);
                gg.transform.localScale = new Vector3(f, f);

                gg.transform.parent = this.transform;
            }
        }
        GameObject.Destroy(g);
    }


    void Update()
    {

    }
}
