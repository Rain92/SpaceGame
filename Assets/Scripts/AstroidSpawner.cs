using UnityEngine;
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


    public float SelfRotationMin = 0;
    public float SelfRotationMax = 3;

    public float UmrundungsGewschwindigkeit = 0.1f;

    public bool ConstantSpeed = false;


    float umrundung = 0;


    float[] rotations;

    GameObject[] astroids;

    void Start()
    {
        rotations = new float[Layers * Count];
        astroids = new GameObject[Layers * Count];
        Sprite[] ss = UnityEditor.AssetDatabase.LoadAllAssetsAtPath("Assets/Sprites/Planets/Asteroids_vario.png").OfType<Sprite>().ToArray();


        GameObject g = new GameObject("At");
        SpriteRenderer s = g.AddComponent<SpriteRenderer>();

        EdgeCollider2D edge = GetComponent<EdgeCollider2D>();
        Vector2[] points = new Vector2[Count + 1];


        for (int ii = 0; ii < Layers; ii++)
        {
            for (int i = 0; i < Count; i++)
            {
                rotations[ii * Count + i] = UnityEngine.Random.Range(SelfRotationMin, SelfRotationMax);

                float x = Mathf.Sin(2 * Mathf.PI / Count * i) * (RadiusX + ii * RadiusInc) + UnityEngine.Random.Range(-Variance, Variance);
                float y = Mathf.Cos(2 * Mathf.PI / Count * i) * (RadiusY + ii * RadiusInc) + UnityEngine.Random.Range(-Variance, Variance);
                Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, UnityEngine.Random.Range(0, 360)));
                float scale = UnityEngine.Random.Range(ScaleMin, ScaleMax);


                GameObject gg = Instantiate(g, new Vector3(x, y), rotation) as GameObject;
                gg.transform.localScale = new Vector3(scale, scale);
                gg.transform.parent = this.transform;
                astroids[ii * Count + i] = gg;

                s.sprite = ss[UnityEngine.Random.Range(0, 24)];

                if (ii == 0)
                {
                    points[i] = new Vector2(x, y);
                    if (i == 0)
                        points[Count] = new Vector2(x, y);
                }
            }
        }
        edge.points = points;

        GameObject.Destroy(g);
    }

    void Update()
    {

        //EdgeCollider2D edge = GetComponent<EdgeCollider2D>();
        //Vector2[] points = new Vector2[Count + 1];

        for (int ii = 0; ii < Layers; ii++)
        {
            for (int i = 0; i < Count; i++)
            {
                umrundung += UmrundungsGewschwindigkeit;
                astroids[ii * Count + i].transform.Rotate(new Vector3(0, 0, 1), rotations[ii * Count + i]);

                float angle = Mathf.Atan2(astroids[ii * Count + i].transform.position.x / RadiusX, astroids[ii * Count + i].transform.position.y / RadiusY);

                float x = Mathf.Cos(angle) * (RadiusX + ii * RadiusInc);
                float y = -Mathf.Sin(angle) * (RadiusY + ii * RadiusInc);

                if(!ConstantSpeed)
                    astroids[ii * Count + i].transform.position += new Vector3(x, y, 0) / astroids[ii * Count + i].transform.position.magnitude * UmrundungsGewschwindigkeit;
                else
                    astroids[ii * Count + i].transform.position += (new Vector3(x, y, 0) / astroids[ii * Count + i].transform.position.magnitude).normalized * UmrundungsGewschwindigkeit;




                //if (ii == 0)
                //{
                //    points[i] = new Vector2(astroids[ii * Count + i].transform.position.x, astroids[ii * Count + i].transform.position.y);
                //    if (i == 0)
                //        points[Count] = new Vector2(astroids[ii * Count + i].transform.position.x, astroids[ii * Count + i].transform.position.y);
                //}
            }
        }
        //edge.points = points;
    }
}
