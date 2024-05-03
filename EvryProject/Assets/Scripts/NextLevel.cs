using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : IMenuItem
{
    private GameObject _closedMenu; // kapanacak men�
    private GameObject _openMenu; // a��lacak men�
    private GameObject _game; // oyun nesnleri
   
    // Contructer method
    public NextLevel(GameObject openMenu, GameObject closedMenu, GameObject game)
    {
        _openMenu = openMenu;
        _closedMenu = closedMenu;
        _game = game;
    }
    // Komutun ger�ekle�tirildi�i fonksiyon
    public void Execute()
    {
        _closedMenu.SetActive(false);
        _openMenu.SetActive(true);
        _game.SetActive(true);
        GameManager.Instance.NextLevel();
        Time.timeScale = 1;
        
    }
}
