using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class StartGameCommand : IMenuItem
{
    private GameObject _closedMenu; // kapanacak men�
    private GameObject _openMenu; // a��lacak men�
    private GameObject _game; // oyun nesneleri
    // Contructer method
    public StartGameCommand(GameObject closedMenu, GameObject openMenu, GameObject game)
    {
        this._closedMenu = closedMenu;
        this._openMenu = openMenu;
        _game = game;
    }
    // Komutun ger�ekle�tirildi�i fonksiyon
    public void Execute()
    {
        _closedMenu.SetActive(false);
        _openMenu.SetActive(true);
        _game.SetActive(true);
        GameManager.Instance.StartGame();
        Time.timeScale = 1;


    }
}