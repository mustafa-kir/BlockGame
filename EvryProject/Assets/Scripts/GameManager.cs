using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Oyun olaylarýný temsil eden delegeate'ler
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
        // Bu scriptin bulunduðu GameObject'e instance'ý ata
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
        // Oyun baþlangýcý, duraklatma, devam ettirme, seviye tamamlama, sonraki seviye ve oyun sonu olaylarýna abone olma

        OnGameStart += SaveLoadSystem.Instance.Load;
        OnGamePause += LevelManager.Instance.pauseGame;
        OnGameContinue += LevelManager.Instance.continueGame;

        OnComplatedLevel += SaveLoadSystem.Instance.Save;
        OnComplatedLevel += LevelManager.Instance.OnLevelComplete;

        OnNextLevel += LevelManager.Instance.NextLevel;


        OnGameEnd += LevelManager.Instance.EndGame;

        OnFinishLevel += LevelManager.Instance.LoseGaming;




    }

    // // Oyunu baþlatan fonksiyon
    public void StartGame()
    {
        OnGameStart?.Invoke(); // Oyun baþlatma olayýný tetikle
    }

    // Oyunu sonlandýran fonksiyon
    public void EndGame()
    {
        OnGameEnd?.Invoke(); // Oyun sonlandýrma olayýný tetikle
    }

    // Oyunu duraklatan fonksiyon
    public void PauseGame()
    {
        OnGamePause?.Invoke();  // Oyun duraklatma olayýný tetikle
    }

    // Oyunu devam ettiren fonksiyon
    public void ContinueGame()
    {
        OnGameContinue?.Invoke(); // Oyun devam ettirme olayýný tetikle
    }

    // Seviye tamamlama olayýný tetikleyen fonksiyon
    public void ComplatedLevel()
    {
        OnComplatedLevel?.Invoke(); // Seviye tamamlama olayýný tetikle
    }

    // Sonraki seviyeye geçme olayýný tetikleyen fonksiyon
    public void NextLevel()
    {
        OnNextLevel?.Invoke(); // Sonraki seviye olayýný tetikle
    }

    // Oyunu kaybetme olayýný tetikleyen fonksiyon
    public void LoseGame()
    { 
        OnFinishLevel?.Invoke(); // Oyunu kaybetme olayýný tetikle
    }

}
