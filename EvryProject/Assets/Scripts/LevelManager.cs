using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;


// Level verilerini i�eren s�n�f
[Serializable]
public class LevelsData 
{
    public LevelData[] levels;
}

// Tek bir seviyenin verilerini i�eren s�n�f
[Serializable]
public class LevelData
{
    public int level; // Seviye 
    public Vector3[] blockPositions; // Blok pozisyonlar�
}


public class LevelManager : MonoBehaviour
{
    

    [SerializeField] private GameObject[] blocks; // Blok prefablar�
    public GameObject ball; // Top objesi
    public Vector2 ballVelocity; // Topun h�z�
    public GameObject loseMenu; // Kaybetme men�s�
    public GameObject winMenu; // Kazanma men�s�
    public GameObject onCompletedMenu; // Seviye tamamland� men�s�
    public GameObject pauseMenu; // Duraklatma men�s�
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

    // Blok pozisyonlar�n� y�kleyen fonksiyon
    void LoadBlockPositions()
    {
        
        string filePath = Path.Combine( "blocksData.json");
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            levelsData = JsonUtility.FromJson<LevelsData>(json);
            
        }
    }

    // Seviye y�kleme fonksiyonu
    public void LoadLevels(int level)
    {
        
        if ((level >= 0) && (level <= levelsData.levels.Length))
        {

            LevelData levelData = levelsData.levels[level-1];
            int blockCount = blocks.Length;
            int positionCount = levelData.blockPositions.Length;

            // Blok pozisyonlar�n� d�ng� ile ayarla ve bloklar� etkinle�tir
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
    // Oyunu duraklat�ld���nda topun velocity kaydetme
    public void pauseGame()
    {
        ballVelocity = ball.gameObject.GetComponent<Rigidbody2D>().velocity;
       
    }
    // Oyunu devam etti�inde topun velocity'si tekrar topa kazand�rma
    public void continueGame()
    {
        ball.gameObject.GetComponent<Rigidbody2D>().velocity = ballVelocity;
    }

    // Seviye tamamland���nda �a�r�lan fonksiyon
    public void OnLevelComplete()
    {
        // Son seviyeye ula��ld�ysa kazanma men�s�n� g�ster, de�ilse seviye tamamland� men�s�n� g�ster
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

    // Sonraki seviyeye ge�me fonksiyonu
    public void NextLevel()
    {
        currentLevel++;
      
        LoadLevels(currentLevel);
    }

    // Oyun bit�inde �al�sacak fonks�yon
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

    // Oyunu yeniden ba�latan fonksiyon.
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
