using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    public float timeInSeconds;

    void Start()
    {
        StartCoroutine(WaitForDeath(timeInSeconds));
    }

    IEnumerator WaitForDeath(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(this.gameObject);
    }
}
