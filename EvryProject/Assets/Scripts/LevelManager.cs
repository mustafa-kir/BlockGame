using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;


// Level verilerini içeren sýnýf
[Serializable]
public class LevelsData 
{
    public LevelData[] levels;
}

// Tek bir seviyenin verilerini içeren sýnýf
[Serializable]
public class LevelData
{
    public int level; // Seviye 
    public Vector3[] blockPositions; // Blok pozisyonlarý
}


public class LevelManager : MonoBehaviour
{
    

    [SerializeField] private GameObject[] blocks; // Blok prefablarý
    public GameObject ball; // Top objesi
    public Vector2 ballVelocity; // Topun hýzý
    public GameObject loseMenu; // Kaybetme menüsü
    public GameObject winMenu; // Kazanma menüsü
    public GameObject onCompletedMenu; // Seviye tamamlandý menüsü
    public GameObject pauseMenu; // Duraklatma menüsü
    public GameObject game; // Oyun objesi.


    [NonSerialized] public int currentLevel = 1; // Mevcut level


    public static LevelManager Instance { get; set; }
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
            Destroy(this.gameObject);
            return;
        }
        #endregion
    }


    public LevelsData levelsData; // Seviye verileri

    void Start()
    {
        
        LoadBlockPositions(); 

    }

    // Blok pozisyonlarýný yükleyen fonksiyon
    void LoadBlockPositions()
    {
        
        string filePath = Path.Combine( "blocksData.json");
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            levelsData = JsonUtility.FromJson<LevelsData>(json);
            
        }
    }

    // Seviye yükleme fonksiyonu
    public void LoadLevels(int level)
    {
        
        if ((level >= 0) && (level <= levelsData.levels.Length))
        {

            LevelData levelData = levelsData.levels[level-1];
            int blockCount = blocks.Length;
            int positionCount = levelData.blockPositions.Length;

            // Blok pozisyonlarýný döngü ile ayarla ve bloklarý etkinleþtir
            for (int i = 0; i < positionCount; i++)
            {
                if (i < blockCount)
                {
                    blocks[i].transform.position = levelData.blockPositions[i];
                    blocks[i].gameObject.SetActive(true);
                    blocks[i].gameObject.GetComponent<Block>().BlockCounter();
                }
            }

            
        }
    }
    // Oyunu duraklatýldýðýnda topun velocity kaydetme
    public void pauseGame()
    {
        ballVelocity = ball.gameObject.GetComponent<Rigidbody2D>().velocity;
       
    }
    // Oyunu devam ettiðinde topun velocity'si tekrar topa kazandýrma
    public void continueGame()
    {
        ball.gameObject.GetComponent<Rigidbody2D>().velocity = ballVelocity;
    }

    // Seviye tamamlandýðýnda çaðrýlan fonksiyon
    public void OnLevelComplete()
    {
        // Son seviyeye ulaþýldýysa kazanma menüsünü göster, deðilse seviye tamamlandý menüsünü göster
        if (levelsData.levels.Length == currentLevel)
        {
            GameBallController.Instance.isGameStarted = false;
            winMenu.SetActive(true);
            game.SetActive(false);

            Time.timeScale = 0;
        }
        else
        {
            GameBallController.Instance.isGameStarted = false;
            
            onCompletedMenu.SetActive(true);
            game.SetActive(false);

            Time.timeScale = 0;
        }
       

       
    }

    // Sonraki seviyeye geçme fonksiyonu
    public void NextLevel()
    {
        currentLevel++;
      
        LoadLevels(currentLevel);
    }

    // Oyun bitðinde çalýsacak fonksþyon
    public void EndGame()
    {
        List<GameObject> menus = new List<GameObject> { pauseMenu, loseMenu, winMenu, onCompletedMenu };

        foreach (GameObject menu in menus)
        {
            if (menu.activeSelf)
            {
                menu.SetActive(false);
            }
        }
        foreach (GameObject block in blocks)
        {
            block.SetActive(false);
            block.gameObject.GetComponent<SpriteRenderer>().sprite = block.GetComponent<Block>().baseSprite;
            block.gameObject.GetComponent<Block>().impactCount = 0;
            block.gameObject.GetComponent<Block>().BlockCounterReset();
        }
        GameBallController.Instance.isGameStarted = false;
        
    }

    // Oyunu yeniden baþlatan fonksiyon.
    public void Restart()
    {
        game.SetActive(true);
        GameManager.Instance.EndGame();

        
        GameManager.Instance.StartGame();
     ;

    }
    // Oyun kebetme durum fonksiyonu
    public void LoseGaming()
    {
        GameBallController.Instance.isGameStarted = false;
        loseMenu.SetActive(true);
        game.SetActive(false);
    }

}
