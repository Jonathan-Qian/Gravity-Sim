using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Label : MonoBehaviour {
    void OnGUI()
    {
        Rect rect = new Rect(0, 0, 300, 100);
        Vector3 offset = new Vector3(0f, 0f, 0.5f); // height above the target position

        Vector3 point = Camera.main.WorldToScreenPoint(gameObject.transform.position + offset);
        rect.x = point.x;
        rect.y = Screen.height - point.y - rect.height; // bottom left corner set to the 3D point
        GUI.Label(rect, gameObject.name); // display its name, or other string
    }
}
