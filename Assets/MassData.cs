using UnityEngine;

public class MassData : MonoBehaviour {
    public float mass;
    [SerializeField] private Vector3 velocity;
    [SerializeField] private float radius;

    void Start() {
        setRadius(radius);
    }

    public void setRadius(float radius) {
        transform.localScale = new Vector3(radius, radius, radius);
    }

    public void moveWithForce(Vector3 netForce) {
        Vector3 acceleration = netForce / mass;
        float fixedDeltaTime = Time.fixedDeltaTime;

        velocity += acceleration * fixedDeltaTime;
        transform.position += velocity * fixedDeltaTime;
    }
}
