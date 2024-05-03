using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart : IMenuItem
{

    // Komutun gerçekleþtirildiði fonksiyon
    public void Execute()
    {
       LevelManager.Instance.Restart();
       Time.timeScale = 1;
    }
}
