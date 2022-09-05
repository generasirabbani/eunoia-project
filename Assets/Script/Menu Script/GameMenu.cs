using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public GameObject uiInventory;
    public void BackButton()
    {
        SceneManager.LoadScene(0);
    }

    public void InventoryShow()
    {
        uiInventory.SetActive(true);
    }
    public void InventoryHide()
    {
        uiInventory.SetActive(false);
    }
}
