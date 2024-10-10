using UnityEngine;

public class Label : MonoBehaviour {
    private MassData massData;
    private Rect rect;
    private Vector3 offset, point;

    void Start() {
        massData = GetComponent<MassData>();
        rect = new Rect(0, 0, 300, 20);
        offset = new Vector3(0f, 0.6f * massData.radius, 0.0f); // height above the target position
    }

    void OnGUI() {
        point = Camera.main.WorldToScreenPoint(gameObject.transform.position + offset);
        rect.x = point.x;
        rect.y = Screen.height - point.y - rect.height; // bottom left corner set to the 3D point
        GUI.Label(rect, gameObject.name + "(" + massData.mass + "kg): " + Mathf.Round(massData.velocity.magnitude) + " m/s");
    }
}
