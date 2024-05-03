using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnHome : IMenuItem
{
    private GameObject _closedMenu; // kapanacak men�
    private GameObject _openMenu; // a��lacak men�

    // Contructer method
    public ReturnHome(GameObject closedMenu, GameObject openMenu )
    {
        _closedMenu = closedMenu;
        _openMenu = openMenu;
      
    }

    // Komutun ger�ekle�tirildi�i fonksiyon
    public void Execute()
    {
        _closedMenu.SetActive(false);
        _openMenu.SetActive(true);
     
        GameManager.Instance.EndGame();
    }
}
