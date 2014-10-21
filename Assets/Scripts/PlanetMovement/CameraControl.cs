using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour
{
    GameObject earth;

    // Use this for initialization
    void Start()
    {
        earth = GameObject.Find("Rocket");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(earth.transform.position.x, earth.transform.position.y, transform.position.z);
    }
}
