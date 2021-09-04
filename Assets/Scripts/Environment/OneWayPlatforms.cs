using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayPlatforms : MonoBehaviour
{
    PlatformEffector2D effector;
    public float waitTime = 1;

    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
    }

    void Update()
    {
        if(InputManager.instance.downPressed)
        {
            StartCoroutine(FlipEffector(waitTime));
        }
    }

    IEnumerator FlipEffector(float seconds)
    {
        effector.rotationalOffset = 180;
        yield return new WaitForSeconds(seconds);
        effector.rotationalOffset = 0;
    }

}
