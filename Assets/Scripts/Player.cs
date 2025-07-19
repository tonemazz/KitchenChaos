using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    // The [SerializeField] tag gives the inspector pane access to the variable
    [FormerlySerializedAs("move_speed")] [SerializeField] float moveSpeed = 5f;
    [SerializeField] private float turnSpeed = 3f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        // Using old input system
        // We define an input vector which maps to our movement keys
        // E.g. pressing W maps to input_vector.y, equivalent to saying "While W is pressed, move along the positive Y axis
        Vector2 inputVector = new Vector2(0, 0);

        if (Input.GetKey(KeyCode.W))
        {
            inputVector.y = +1;
        }

        if (Input.GetKey(KeyCode.S))
        {
            inputVector.y = -1;
        }

        if (Input.GetKey(KeyCode.D))
        {
            inputVector.x = +1;
        }

        if (Input.GetKey(KeyCode.A))
        {
            inputVector.x = -1;
        }

        // Handling both axis inputs at the same time (so diagonal movement isn't faster than single-axis movement)
        inputVector = inputVector.normalized;

        // We construct a 3D vector and use the information from input_vector as base data
        // Then we plug that into the transform.
        Vector3 moveDirection = new Vector3(inputVector.x, 0f, inputVector.y);
        transform.position += moveDirection * Time.deltaTime * moveSpeed;
        transform.forward = Vector3.Slerp(transform.forward, moveDirection, Time.deltaTime * turnSpeed);

        Debug.Log(inputVector);
    }
}