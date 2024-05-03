using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FirstBlock", menuName = "ScriptableObjects/FirstBlock", order = 1)]
public class BlockData : ScriptableObject
{

    public GameObject effect; // efkt objesini tutan de�i�ken
    public int blockHealt;  // blok sa�l���n� tutan de�i�ken
    public Sprite[] blockSprites; // Blok sprite'lar� tutan de�i�ken


}
