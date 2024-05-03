using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Continue : IMenuItem
{
    private GameObject _closedMenu; // kapancak menü
    private GameObject _openMenu; // açýlacak menü

    // Devre dýþý býrakýlacak menü ve açýlacak menüyü belirleyen Constructor method
    public Continue(GameObject closedMenu, GameObject openMenu)
    {
        _closedMenu = closedMenu;
        _openMenu = openMenu;
    }
   
    // Komutlarý gerçekleþtiricek fonskiyon
    public void Execute()
    {

        _closedMenu.SetActive(false);
        _openMenu.SetActive(true);
        GameManager.Instance.ContinueGame();
        Time.timeScale = 1;
        ;
    }
}
