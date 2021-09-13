using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowAround : MonoBehaviour
{
    public Transform player;
    public Camera minimap;
    Vector3 offset;
    void Start()
    {
        offset = transform.position - player.position;
    }

    void Update()
    {
        minimap.transform.localEulerAngles = new Vector3(0, 0, 0);
        transform.position = player.position + offset;
    }
}
