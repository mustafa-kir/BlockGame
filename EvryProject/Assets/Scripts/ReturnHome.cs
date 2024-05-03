using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnHome : IMenuItem
{
    private GameObject _closedMenu; // kapanacak menü
    private GameObject _openMenu; // açýlacak menü

    // Contructer method
    public ReturnHome(GameObject closedMenu, GameObject openMenu )
    {
        _closedMenu = closedMenu;
        _openMenu = openMenu;
      
    }

    // Komutun gerçekleþtirildiði fonksiyon
    public void Execute()
    {
        _closedMenu.SetActive(false);
        _openMenu.SetActive(true);
     
        GameManager.Instance.EndGame();
    }
}
