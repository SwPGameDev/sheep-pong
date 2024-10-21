using UnityEngine;
using UnityEngine.InputSystem;

public class PaddleMovement : MonoBehaviour
{
    [SerializeField] InputActionReference movementReference;

    InputAction movement;

    float movementValue;
    float intendedYValue;

    [SerializeField] float movespeed;
    [SerializeField] float upperLimit = 8.5f;
    [SerializeField] float lowerLimit = -8.5f;

    
    void Start()
    {
        movement = movementReference;
    }

    private void Update()
    {
        movementValue = movement.ReadValue<float>();
    }

    void FixedUpdate()
    {
        if (movementValue > 0 && intendedYValue < upperLimit)
        {
            intendedYValue += movespeed * Time.fixedDeltaTime;
            transform.position = new Vector3(transform.position.x, intendedYValue, transform.position.z);
        }
        else if (movementValue < 0 && transform.position.y > lowerLimit)
        {
            intendedYValue -= movespeed * Time.fixedDeltaTime;
            transform.position = new Vector3(transform.position.x, intendedYValue, transform.position.z);
        }
    }

}
