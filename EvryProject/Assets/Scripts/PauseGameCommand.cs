using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGameCommand : IMenuItem
{
    private GameObject _closedMenu; // kapanacak men�
    private GameObject _openMenu; // a��lacak men�

    // Contructer method
    public PauseGameCommand(GameObject closedMenu, GameObject openMenu)
    {
        _closedMenu = closedMenu;
        _openMenu = openMenu;
    }
    // Komutun ger�ekle�tirildi�i fonksiyon
    public void Execute()
    {
        GameManager.Instance.PauseGame();
        _closedMenu.SetActive(false);
        _openMenu.SetActive(true);
        
        Time.timeScale = 0;

    }
}
