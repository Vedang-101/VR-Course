using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    public MovementCOntroller mc;

    public Vector3 Original;
    public Vector3 Pushed;

    public int score = 0;
    public bool mision = false;
    public GameObject[] particles;
    public Text timer;
    public Text message;

    public int min = 0;
    public int sec = 0;

    public AudioClip Horn;
    public AudioSource AS;
    public AudioClip[] bg;
    int index = 1;

    public void playHorn()
    {
        AS.clip = Horn;
        AS.Play();
    }

    public void PlaySound()
    {
        AS.clip = bg[index];
        AS.Play();
        index = (index + 1) % bg.Length;
    }

    public void toggleMission(int state)
    {
        if(mision)
        {
            StopAllCoroutines();
            foreach (GameObject c in particles)
                c.SetActive(false);
            mision = false;
            timer.text = "--:--";
            if (state == 0)
                message.text = "Better luck next time!";
            else if (state == 1)
                message.text = "You won!";
            else if (state == 2)
                message.text = "Press 'M' to start mission";
            score = 0;
            min = 0;
            sec = 0;
            transform.localPosition = Original;
        } else
        {
            transform.localPosition = Pushed;
            mision = true;
            message.text = "";
            GameObject final = particles[0];
            float distance = (particles[0].transform.position - transform.position).magnitude;
            foreach(GameObject c in particles)
            {
                if(distance > (c.transform.position - transform.position).magnitude)
                {
                    distance = (c.transform.position - transform.position).magnitude;
                    final = c;
                }
            }
            final.SetActive(true);
            min = 0;
            sec = Random.Range(10, 20);
            StartCoroutine(Timer());
        }
    }

    IEnumerator Timer()
    {
        while(min != 0 || sec != 0)
        {
            yield return new WaitForSeconds(1.0f);
            sec--;
            if(sec == 0)
            {
                min--;
                sec = 60;
            }
            if (min < 0)
            {
                toggleMission(0);
                break;
            }
            timer.text = min.ToString() + ":" + sec.ToString();
        }
    }

    public void toggleReverse()
    {
        if(mc.Reverse)
        {
            mc.Reverse = !mc.Reverse;
            transform.localPosition = Original;
        }
        else
        {
            mc.Reverse = !mc.Reverse;
            transform.localPosition = Pushed;
        }
    }

    public void setDecission()
    {
        mc.decission = true;
    }

    public void resetDecission()
    {
        mc.decission = false;
    }
}
