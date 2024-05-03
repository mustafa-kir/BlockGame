using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithMouse : MonoBehaviour, IGameBarMove
{
    // Fare konumuna g�re oyun �ubu�unu hareket ettiren fonksiyon, IGameBarMove iterface'i uygulan�r
    public float Move()
    {

        return Input.mousePosition.x / Screen.width * 16;
    }
}
