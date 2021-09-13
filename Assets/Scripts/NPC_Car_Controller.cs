using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Car_Controller : MonoBehaviour
{
    public Transform[] locations;

    Rigidbody rb;
    int index = 0;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        if (transform.position != locations[index].position)
        {
            Vector3 pos = Vector3.MoveTowards(transform.position, locations[index].position, 8 * Time.deltaTime);
            rb.MovePosition(pos);
        } else
            index = (index + 1) % locations.Length;
        Vector3 temp = locations[index].position - transform.position;
        Quaternion newRot = Quaternion.LookRotation(temp);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRot, 5 * Time.deltaTime);
    }
}
