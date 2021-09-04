using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;


    public void PlayDamagedAnimation()
    {
        animator.SetTrigger("Damaged");
    }
}
