using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint_Next : MonoBehaviour
{
    public GameObject[] nextPos;
    public Button btn;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (btn.score >= 6)
                btn.toggleMission(1);
            else
            {
                btn.score++;
                nextPos[Random.Range(0, nextPos.Length)].SetActive(true);
                btn.sec += Random.Range(10, 20);
                if(btn.sec > 60)
                {
                    while(btn.sec > 60)
                    {
                        btn.min++;
                        btn.sec -= 60;
                    }
                }
                gameObject.SetActive(false);
            }
        }
    }
}
