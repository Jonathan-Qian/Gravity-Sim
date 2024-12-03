using UnityEngine;

public class MassData : MonoBehaviour {
    public float mass;
    public Vector3 velocity;
    public float radius;

    void Start() {
        SetRadius(radius);
    }

    void FixedUpdate() {
        SetDirection(velocity);
    }

    private void SetRadius(float radius) {
        transform.localScale = new Vector3(radius, radius, radius);
    }

    public void MoveWithForce(Vector3 netForce) {
        Vector3 acceleration = netForce / mass;
        float fixedDeltaTime = Time.fixedDeltaTime;

        velocity += acceleration * fixedDeltaTime;
        transform.position += velocity * fixedDeltaTime;
    }

    private void SetDirection(Vector3 velocity) {
        transform.rotation = Quaternion.LookRotation(velocity.normalized);
    }
}
