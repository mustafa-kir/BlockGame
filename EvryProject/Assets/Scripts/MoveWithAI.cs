using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithAI : MonoBehaviour, IGameBarMove
{
    private GameObject _gameBall; // Top nesnesi
    // Contructer method
    public MoveWithAI(GameObject gameBall)
    {
        _gameBall = gameBall;
    }
    // Oyun çubuðunu hareket ettiren fonksiyon, IGameBarMove iterface'i uygulanýr
    public float Move()
    {
        return _gameBall.transform.position.x;
    }
}
