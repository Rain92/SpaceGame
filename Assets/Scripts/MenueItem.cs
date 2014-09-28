using UnityEngine;
using System.Collections;

public class MenueItem : MonoBehaviour
{

    void OnMouseOver()
    {
        Component.FindObjectOfType<TextMesh>().color = new Color(255, 0, 0);
    }
}