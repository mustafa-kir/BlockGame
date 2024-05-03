using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Block : MonoBehaviour
{
    
    public BlockData blockData; // Block verileri i�in scriple obje 
    public static int blockCount; // Oyundaki Blok say�s�
    private bool breakableBlock; // // K�r�labilir blok 
    public int impactCount; // �arpma say�s�
    

    public Sprite baseSprite; // ba�lang�� sprite'� tutmak i�in


    

    // Start is called before the first frame update
    void Start()
    {
        baseSprite = GetComponent<SpriteRenderer>().sprite;
       
        impactCount = 0;
    }
    // Blok say�s�n� art�ran fonksiyon
    public void BlockCounter()
    {
        breakableBlock = (this.tag == "Block");
        if (breakableBlock)
        {
            blockCount++;
        }

    }
    // Blok say�s�n� azaltan fonksiyon
    public void BlockCounterReset()
    {
        breakableBlock = (this.tag == "Block");
        if (breakableBlock)
        {
            if (blockCount > 0)
            {
                blockCount--;
            }
            
        }

    }

    // �arp��ma alg�lay�c� fonksiyon

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
       // GetComponent<AudioSource>().Play();
        if (breakableBlock)
        {
            
            imppactController();
        }
    }

    // �arp��ma kontrolc�s�
    public void imppactController()
    {
       
        impactCount++;
        // yeterinde �arp��ma olduysa, blo�u yok et me durumu
        if (impactCount >= blockData.blockHealt)
        {
            
            blockCount--;
            effectSpawn();
            gameObject.SetActive(false);
            GetComponent<SpriteRenderer>().sprite = baseSprite;
            impactCount = 0; 
            if (blockCount <= 0)
            {
                
                GameManager.Instance.ComplatedLevel();
            }

        }
        else
        {
            blockSpriteChange(); // Blok sprite'�n� de�i�tir
        }
    }

     // Efekt olu�turma fonksiyonu
    void effectSpawn()
    {
        GameObject effect = Instantiate(blockData.effect, gameObject.transform.position, Quaternion.identity) as GameObject; // efect olu�turma 
        effect.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color; // efecte blok rengini verme
        Destroy(effect,2); // olu�turulan efecti yok etme 
    }
    // Blo�un sprit�n� de�i�tirme
    public void blockSpriteChange()
    {
        this.GetComponent<SpriteRenderer>().sprite = blockData.blockSprites[impactCount - 1];
    }
}
