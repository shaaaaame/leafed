using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObjectBehaviour : MonoBehaviour
{
    public InteractableObjectType objectType;
    public SpriteRenderer spriteRenderer;
    public Animator anim;
    private bool isInteractable = false;

    void Update()
    {
        if (isInteractable && InputManager.instance.interactStart)
        {
            Interact();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            isInteractable = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            isInteractable = false;
        }
    }

    void Interact()
    {
        //use in inherited class
        Debug.Log("Interacted with " + gameObject.name);
        anim.SetTrigger("OnInteract");
    }

}
