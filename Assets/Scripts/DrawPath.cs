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
    private float colorVariance = 0.8f;

    void Start() {
        c1 = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        c2 = new Color(c1.r + (1 - c1.r) * colorVariance, c1.g + (1 - c1.g) * colorVariance, c1.b + (1 - c1.b) * colorVariance);
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.widthCurve = new AnimationCurve(new Keyframe[] {new Keyframe(0.0f, 1.0f * GetComponent<MassData>().radius), new Keyframe(1.0f, 0.0f)});

        Gradient gradient = new Gradient();
        gradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(c1, 0.0f), new GradientColorKey(c2, 0.8f) },
            new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(0.0f, 0.8f) }
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
