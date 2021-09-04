using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy Objects/Enemy")]
public class EnemyType : ScriptableObject
{
    public string enemyName;

    [Header("Assets")]
    public Animation idleAnimation;
    public Animation runAnimation;
    public Animation attackAnimation;
    public Animation damagedAnimation;
    public Animation deathAnimation;

    [Header("Values")]
    public float damage;
    public float health;
    public AttackType attackType;
    public float moveSpeed;

    [Header("Attack Info")]
    public float knockbackForce;
    public float knockbackLength;
}

public enum AttackType
{
    Ranged,
    Melee,
}


