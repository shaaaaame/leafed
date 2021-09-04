using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="New Interactable Object", menuName="World/Interactable Object")]
public class InteractableObjectType : ScriptableObject
{
    public Sprite defaultSprite;
    public AnimationClip onInteractAnimation;


}
