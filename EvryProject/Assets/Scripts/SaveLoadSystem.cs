using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;


[Serializable]
public class Level
{
    public int level; // Seviye bilgisini tutan de�i�ken
}



public class SaveLoadSystem : MonoBehaviour
{
    public static SaveLoadSystem Instance { get; set; }
    // Start is called before the first frame update
    private void Awake()
    {
        #region Singloton
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        #endregion
    }
   
    // Level verisini y�kleyen fonksiyon
    public void Load()
    {
        // JSON dosyas�ndan leveli okuyoruz ve current leveli setliyoruz. 
        string json = File.ReadAllText("levelData.json");

        Level loadLevel = JsonUtility.FromJson<Level>(json);
        LevelManager.Instance.currentLevel = loadLevel.level;
        LevelManager.Instance.LoadLevels(loadLevel.level);

    }

    // Level verisini kaydetme fonksiyonu
    public void Save()
    {
        Level currentLevel = new Level();
        currentLevel.level = LevelManager.Instance.currentLevel;
        if (currentLevel.level < 2)
        {
            currentLevel.level++;
        }
        
        // Seviyeyi JSON format�na d�n��t�r
        string json = JsonUtility.ToJson(currentLevel);

        // JSON verisini dosyaya yaz
        File.WriteAllText("levelData.json", json);
    }

   
}
