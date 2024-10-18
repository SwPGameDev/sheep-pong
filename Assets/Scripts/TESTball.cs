using UnityEngine;
using UnityEngine.InputSystem;

public class TESTball : MonoBehaviour
{
    Vector3 ballPos;
    Rigidbody rb;
    Vector3 startVector;

    InputAction resetAction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startVector = Random.onUnitSphere;
        startVector = new Vector3(startVector.x, startVector.y, 0).normalized;


        print(startVector);

        resetAction = InputSystem.actions.FindAction("Reset");
    }

    // Update is called once per frame
    void Update()
    {
        ballPos.z = 0;

        if (resetAction.WasPressedThisFrame())
        {
            Restart();
        }
        
    }


    void Restart()
    {
        startVector = Random.onUnitSphere;
        startVector = new Vector3(startVector.x, startVector.y, 0).normalized;
    }



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(ballPos, startVector);
    }
}
