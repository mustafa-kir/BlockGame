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
    // Oyun �ubu�unu hareket ettiren fonksiyon, IGameBarMove iterface'i uygulan�r
    public float Move()
    {
        return _gameBall.transform.position.x;
    }
}
