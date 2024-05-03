using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithMouse : MonoBehaviour, IGameBarMove
{
    // Fare konumuna göre oyun çubuðunu hareket ettiren fonksiyon, IGameBarMove iterface'i uygulanýr
    public float Move()
    {

        return Input.mousePosition.x / Screen.width * 16;
    }
}
