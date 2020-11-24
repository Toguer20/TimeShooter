using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Rigidbody rb;
    Vector3 moveInput;
    Vector3 rotInput;
    public float walkVelocity = 0.1f;
    public float mouseSensitivity = 1f;
    private const float ROTATIONLIMITUP = -70;
    private const float ROTAIONLIMITDOWN = 70;
    Transform cam;
    float camRotX;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = transform.GetChild(0);
        camRotX = cam.eulerAngles.x;
    }

    // Update is called once per frame
    void Update()
    {
        //Movimiento de la cápsula
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
        //Rotación de la cámara
        rotInput.x = Input.GetAxis("Mouse X") * mouseSensitivity;
        rotInput.y = Input.GetAxis("Mouse Y") * mouseSensitivity;
        //Velocidades del jugador
        float vel = walkVelocity;
        rb.velocity = transform.forward * vel * moveInput.y +
                      transform.right * vel * moveInput.x +
                      new Vector3(0, rb.velocity.y, 0);
        //Rotación de la cámara
        transform.rotation *= Quaternion.Euler(0, rotInput.x, 0);
        cam.rotation *= Quaternion.Euler(-rotInput.y, 0, 0);
        camRotX -= rotInput.y;
        camRotX = Mathf.Clamp(camRotX, ROTATIONLIMITUP, ROTAIONLIMITDOWN);
        cam.localRotation = Quaternion.Euler(camRotX, 0, 0);
    }


}
