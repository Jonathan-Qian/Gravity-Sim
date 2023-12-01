using UnityEngine;

//This doesn't work properly
public class DrawPath : MonoBehaviour {
    private const int maxPoints = 1000;
    private Color c1;
    private Color c2;
    private LineRenderer lineRenderer;
    private int counter = 0;
    Vector3[] newPositions;

    void Start() {
        c1 = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        c2 = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.widthMultiplier = 100f;
        lineRenderer.positionCount = maxPoints;

        // A simple 2 color gradient with a fixed alpha of 1.0f.
        float alpha = 1.0f;
        Gradient gradient = new Gradient();
        gradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(c1, 0.0f), new GradientColorKey(c2, 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
        );
        lineRenderer.colorGradient = gradient;

        newPositions = new Vector3[lineRenderer.positionCount];
    }
    void FixedUpdate() {
        if (counter < maxPoints) {
            lineRenderer.SetPosition(counter, transform.position);
        }
        else {
            newPositions[0] = transform.position;

            for (int i = 1; i < newPositions.Length; i++) {
                newPositions[i] = lineRenderer.GetPosition(i - 1);
            }

            lineRenderer.SetPositions(newPositions);
        }

        counter++;
    }
}
