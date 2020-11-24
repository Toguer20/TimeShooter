using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

//public class FPSCamera : MonoBehaviour
//{
//    public Camera FPS_Camera;
//    public float horizontalSpeed;
//    public float verticalSpeed;

//    private float h;
//    private float v;
//    private Rigidbody _rb;
//    // Start is called before the first frame update
//    void Start()
//    {
//        _rb = GetComponent<Rigidbody>();
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        h = horizontalSpeed * Input.GetAxis("Mouse X");
//        v = verticalSpeed * Input.GetAxis("Mouse Y");

//        transform.Rotate(0, h, 0);
//        FPS_Camera.transform.Rotate(-v, 0, 0);


//        Vector3 moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
//        _rb.MovePosition(GetComponent<Rigidbody>().position + moveDirection * 1 * Time.deltaTime);
//    }
//}

public class FPSCamera : MonoBehaviour
{
    public Camera FPS_Camera;
    public float horizontalSpeed;
    public float verticalSpeed;

    private float h;
    private float v;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        h = horizontalSpeed * Input.GetAxis("Mouse X");
        v = verticalSpeed * Input.GetAxis("Mouse Y");

        transform.Rotate(0, h, 0);
        FPS_Camera.transform.Rotate(-v, 0, 0);

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 0, 0.01f);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, 0, -0.01f);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-0.01f, 0, 0f);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(0.01f, 0, 0);
        }
    }
}
//Make sure you attach a Rigidbody in the Inspector of this GameObject

//public class FPSCamera : MonoBehaviour
//{
//    public Camera FPS_Camera;
//    public float horizontalSpeed;
//    public float verticalSpeed;

//    private float h;
//    private float v;
//    private Rigidbody _rb;
//    // Start is called before the first frame update
//    void Start()
//    {
//        _rb = GetComponent<Rigidbody>();
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        h = horizontalSpeed * Input.GetAxis("Mouse X");
//        v = verticalSpeed * Input.GetAxis("Mouse Y");

//        transform.Rotate(0, h, 0);
//        FPS_Camera.transform.Rotate(-v, 0, 0);


//        Vector3 moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
//        _rb.MovePosition(GetComponent<Rigidbody>().position + moveDirection * 1 * Time.deltaTime);
//    }
//}