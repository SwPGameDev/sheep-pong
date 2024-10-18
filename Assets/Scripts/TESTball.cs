using UnityEngine;
using UnityEngine.InputSystem;

public class TESTball : MonoBehaviour
{
    Vector3 ballPos;
    Rigidbody rb;
    Vector3 startVelocity;
    [SerializeField] Vector3 startPos = Vector3.zero;
    [SerializeField] float startLaunchForce = 10;

    InputAction resetAction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartGame();


        print(startVelocity);

        resetAction = InputSystem.actions.FindAction("Reset");
    }

    // Update is called once per frame
    void Update()
    {
        ballPos.z = 0;

        if (resetAction.WasPressedThisFrame())
        {
            StartGame();
        }
        
    }

    void StartGame()
    {
        gameObject.transform.position = startPos;

        startVelocity = Random.onUnitSphere;
        startVelocity = new Vector3(startVelocity.x, startVelocity.y, 0).normalized;

        rb.linearVelocity = startVelocity * startLaunchForce;
    }



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(ballPos, startVelocity);
    }
}
