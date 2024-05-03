using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Continue : IMenuItem
{
    private GameObject _closedMenu; // kapancak men�
    private GameObject _openMenu; // a��lacak men�

    // Devre d��� b�rak�lacak men� ve a��lacak men�y� belirleyen Constructor method
    public Continue(GameObject closedMenu, GameObject openMenu)
    {
        _closedMenu = closedMenu;
        _openMenu = openMenu;
    }
   
    // Komutlar� ger�ekle�tiricek fonskiyon
    public void Execute()
    {

        _closedMenu.SetActive(false);
        _openMenu.SetActive(true);
        GameManager.Instance.ContinueGame();
        Time.timeScale = 1;
        ;
    }
}
