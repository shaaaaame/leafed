using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;
    public List<GameObject> EnemyList;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void RegisterEnemy(GameObject enemyObject)
    {
        EnemyList.Add(enemyObject);
    }

}
