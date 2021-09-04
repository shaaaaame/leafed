using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public List<GameObject> uiItems;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        PlayerManager.instance.onPause += DisableHUD;
        PlayerManager.instance.onDialogue += DisableHUD;
        PlayerManager.instance.onLive += EnableHUD;
    }

    public void DisableHUD()
    {
        foreach (GameObject item in uiItems)
        {
            item.SetActive(false);
        }
    }

    public void EnableHUD()
    {
        foreach (GameObject item in uiItems)
        {
            item.SetActive(true);
        }
    }

    public void RegisterUIItem(GameObject uiItem)
    {
        uiItems.Add(uiItem);
    }

    void OnDisable()
    {
        PlayerManager.instance.onPause -= DisableHUD;
        PlayerManager.instance.onDialogue -= DisableHUD;
        PlayerManager.instance.onLive -= EnableHUD;
    }

}
