using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart : IMenuItem
{

    // Komutun ger�ekle�tirildi�i fonksiyon
    public void Execute()
    {
       LevelManager.Instance.Restart();
       Time.timeScale = 1;
    }
}
