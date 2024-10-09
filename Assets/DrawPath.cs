using UnityEngine;
using System.Collections.Generic;

//This doesn't work properly
public class DrawPath : MonoBehaviour {
    private const int maxPoints = 1000;
    private Color c1;
    private Color c2;
    private LineRenderer lineRenderer;
    private Stack<Vector3> positions;
    private int counter = 0;

    void Start() {
        c1 = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.widthMultiplier = 100f;

        Gradient gradient = new Gradient();
        gradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(c1, 0.0f), new GradientColorKey(new Color((int) (c1.r + c1.r * 0.1), (int) (c1.g + c1.g * 0.1), (int) (c1.b + c1.b *0.1)), 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(0.5f, 1.0f) }
        );
        lineRenderer.colorGradient = gradient;
        lineRenderer.positionCount = 0;

        positions = new Stack<Vector3>(maxPoints);
    }
    void FixedUpdate() {
        if (counter < maxPoints) {
            counter++;
            lineRenderer.positionCount = counter;
        }

        positions.Push(transform.position);
        lineRenderer.SetPositions(positions.ToArray());
    }
}
