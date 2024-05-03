using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Oyun olaylar�n� temsil eden delegeate'ler
    public delegate void GameEvent();
    public static event GameEvent OnGameStart;
    public static event GameEvent OnGameEnd;
    public static event GameEvent OnGamePause;
    public static event GameEvent OnGameContinue;
    public static event GameEvent OnComplatedLevel;
    public static event GameEvent OnNextLevel;
    public static event GameEvent OnFinishLevel;
    
    private static GameManager instance = null;
    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {

        #region Singloton
        // Bu scriptin bulundu�u GameObject'e instance'� ata
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        #endregion
    }
    private void Start()
    {
        // Oyun ba�lang�c�, duraklatma, devam ettirme, seviye tamamlama, sonraki seviye ve oyun sonu olaylar�na abone olma

        OnGameStart += SaveLoadSystem.Instance.Load;
        OnGamePause += LevelManager.Instance.pauseGame;
        OnGameContinue += LevelManager.Instance.continueGame;

        OnComplatedLevel += SaveLoadSystem.Instance.Save;
        OnComplatedLevel += LevelManager.Instance.OnLevelComplete;

        OnNextLevel += LevelManager.Instance.NextLevel;


        OnGameEnd += LevelManager.Instance.EndGame;

        OnFinishLevel += LevelManager.Instance.LoseGaming;




    }

    // // Oyunu ba�latan fonksiyon
    public void StartGame()
    {
        OnGameStart?.Invoke(); // Oyun ba�latma olay�n� tetikle
    }

    // Oyunu sonland�ran fonksiyon
    public void EndGame()
    {
        OnGameEnd?.Invoke(); // Oyun sonland�rma olay�n� tetikle
    }

    // Oyunu duraklatan fonksiyon
    public void PauseGame()
    {
        OnGamePause?.Invoke();  // Oyun duraklatma olay�n� tetikle
    }

    // Oyunu devam ettiren fonksiyon
    public void ContinueGame()
    {
        OnGameContinue?.Invoke(); // Oyun devam ettirme olay�n� tetikle
    }

    // Seviye tamamlama olay�n� tetikleyen fonksiyon
    public void ComplatedLevel()
    {
        OnComplatedLevel?.Invoke(); // Seviye tamamlama olay�n� tetikle
    }

    // Sonraki seviyeye ge�me olay�n� tetikleyen fonksiyon
    public void NextLevel()
    {
        OnNextLevel?.Invoke(); // Sonraki seviye olay�n� tetikle
    }

    // Oyunu kaybetme olay�n� tetikleyen fonksiyon
    public void LoseGame()
    { 
        OnFinishLevel?.Invoke(); // Oyunu kaybetme olay�n� tetikle
    }

}
