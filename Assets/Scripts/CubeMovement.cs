using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    Rigidbody rb;
    Vector3 moveInput;
    public float walkVelocity = 2.5f;
    public float mouseSensitivity = 4f;
    private const float ROTATIONLIMITUP = -70;
    private const float ROTAIONLIMITDOWN = 70;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Velocidades de los cubos
        float vel = walkVelocity;
        rb.velocity = transform.forward * vel * moveInput.y +
                      transform.right * vel * moveInput.x +
                      new Vector3(0, rb.velocity.y, 0);
    }
}
