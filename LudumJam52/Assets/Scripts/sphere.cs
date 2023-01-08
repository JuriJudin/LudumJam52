using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sphere : MonoBehaviour
{
    public float speed = 0.4f;
    public float maxSpeed = 1.2f;
    public Transform cameraTransform;
    public Transform plantTransform;
    public float distanceFromCamera = 10;
    private Rigidbody rb;
    private MeshRenderer renderer;
    private float ballheight;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        renderer = GetComponent<MeshRenderer>();
        ballheight = renderer.bounds.size.y;
    }

    // Update is called once per frame
    void Update()
    {
        float movementHorizontal = Input.GetAxis("Horizontal");
        float movementVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(movementHorizontal, 0.0f, movementVertical);

        rb.AddForce(movement * speed);
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);

        Vector3 objectpos = new Vector3(transform.position.x,transform.position.y+5.0f, transform.position.z-5.0f);
        cameraTransform.position = objectpos;

        objectpos = new Vector3(transform.position.x,transform.position.y+ballheight, transform.position.z);
        plantTransform.position = objectpos;
    }
}
