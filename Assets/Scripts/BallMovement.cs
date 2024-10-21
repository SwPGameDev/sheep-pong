using UnityEngine;

public class BallMovement : MonoBehaviour
{
    Vector3 ballPos;
    Rigidbody rb;
    Vector3 startVelocity;
    [SerializeField] Vector3 startPos = Vector3.zero;
    [SerializeField] float startLaunchForce = 10;
    [SerializeField] float speedMultiplier = 1.01f;

    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        LaunchBall();
    }

    private void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, rb.linearVelocity.y, 0);
        print("Ball Velocity: " + rb.linearVelocity.magnitude);
    }

    private void OnCollisionEnter(Collision collision)
    {
        rb.linearVelocity *= (1 + speedMultiplier);
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, rb.linearVelocity.y, 0);
    }

    public void LaunchBall()
    {
        rb.linearVelocity = Vector3.zero;
        gameObject.transform.position = startPos;

        startVelocity = Random.onUnitSphere;
        startVelocity = new Vector3(startVelocity.x, startVelocity.y, 0).normalized;

        rb.linearVelocity = startVelocity * startLaunchForce;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(ballPos, startVelocity);

        if (rb != null && rb.linearVelocity != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(transform.position, transform.position + (rb.linearVelocity * Time.fixedDeltaTime));
        }
    }
}
