using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCOntroller : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject car;
    public Camera cam;

    public float TurnSpeed;
    public float speed;

    Vector3 lerpAngles;
    Vector3 Offset;

    float acceleration;

    public bool Reverse = false;
    public bool decission = false;

    void Start() {
        Offset = transform.position - car.transform.position;
        acceleration = 0;
        lerpAngles = car.transform.eulerAngles;
    }

    void Update() {
        transform.position = car.transform.position + Offset;
        if (!Reverse)
            rb.velocity = new Vector3(cam.transform.forward.x, 0, cam.transform.forward.z) * acceleration;
        else
            rb.velocity = new Vector3(cam.transform.forward.x, 0, cam.transform.forward.z) * -acceleration;
        if (acceleration != 0)
        {
            lerpAngles = new Vector3(Mathf.LerpAngle(lerpAngles.x, lerpAngles.x, Time.deltaTime * TurnSpeed), Mathf.LerpAngle(lerpAngles.y, cam.transform.localEulerAngles.y, Time.deltaTime * TurnSpeed), Mathf.LerpAngle(lerpAngles.z, lerpAngles.z, Time.deltaTime * TurnSpeed));
            car.transform.eulerAngles = lerpAngles;
        }
        if (Input.GetButton("Fire1") && !decission)
        {
           acceleration += 0.3f;
            if (acceleration >= speed)
                acceleration = speed;
        }
        else
        {
            acceleration -= 0.8f;
            if (acceleration <= 0)
                acceleration = 0;
        }
    }
}
