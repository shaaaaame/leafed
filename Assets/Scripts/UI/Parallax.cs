using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Parallax : MonoBehaviour
{
    public GameObject cam;
    float length;
    Vector2 startPos;
    [Range(0, 1)] public float parallaxEffectX;

    void Start()
    {
        startPos = transform.position;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void FixedUpdate()
    {
        HorizontalParallax();
    }

    void HorizontalParallax()
    {
        //distance to be moved from start position
        float distance = cam.transform.position.x * parallaxEffectX;
        transform.position = new Vector2(startPos.x + distance, transform.position.y);

        //if position relative to camera is more than startpos x + length, "reset" startpos
        if (cam.transform.position.x * (1 - parallaxEffectX) > startPos.x + length)
        {
            startPos.x += length;
        }
        else if (cam.transform.position.x * (1 - parallaxEffectX) < startPos.x - length)
        {
            startPos.x -= length;
        }
    }

}