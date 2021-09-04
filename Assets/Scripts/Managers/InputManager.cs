using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class InputManager : MonoBehaviour
{
    public float movementX;
    public bool downPressed;
    public bool jumpStart;
    public bool isJumping;
    public bool attackStart;
    public bool isBlocking;
    public bool interactStart;

    public bool controlsEnabled = true;

    public static InputManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        PlayerManager.instance.onPause += DisableControls;
        PlayerManager.instance.onDialogue += DisableControls;
        PlayerManager.instance.onLive += EnableControls;
    }


    void Update()
    {
        if (controlsEnabled)
        {
            movementX = Input.GetAxisRaw("Horizontal");
            isBlocking = Input.GetButton("Block");
            jumpStart = Input.GetButtonDown("Jump");
            isJumping = Input.GetButton("Jump");
            attackStart = Input.GetButtonDown("Attack");
            interactStart = Input.GetButtonDown("Interact");
            if (Input.GetButtonDown("Vertical") && Input.GetAxisRaw("Vertical") < 0)
            {
                downPressed = true;
            }
            else
            {
                downPressed = false;
            }
        }
        else
        {
            movementX = 0;
            jumpStart = false;
        }

    }

    public void DisableControls() => controlsEnabled = false;

    public void EnableControls() => controlsEnabled = true;

    void OnDisable()
    {
        PlayerManager.instance.onDialogue -= DisableControls;
        PlayerManager.instance.onLive -= EnableControls;
        PlayerManager.instance.onPause -= DisableControls;
    }
}
