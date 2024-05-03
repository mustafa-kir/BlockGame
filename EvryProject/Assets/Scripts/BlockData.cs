using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FirstBlock", menuName = "ScriptableObjects/FirstBlock", order = 1)]
public class BlockData : ScriptableObject
{

    public GameObject effect; // efkt objesini tutan deðiþken
    public int blockHealt;  // blok saðlýðýný tutan deðiþken
    public Sprite[] blockSprites; // Blok sprite'larý tutan deðiþken


}
