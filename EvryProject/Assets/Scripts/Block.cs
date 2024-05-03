using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Block : MonoBehaviour
{
    
    public BlockData blockData; // Block verileri için scriple obje 
    public static int blockCount; // Oyundaki Blok sayýsý
    private bool breakableBlock; // // Kýrýlabilir blok 
    public int impactCount; // çarpma sayýsý
    

    public Sprite baseSprite; // baþlangýç sprite'ý tutmak için


    

    // Start is called before the first frame update
    void Start()
    {
        baseSprite = GetComponent<SpriteRenderer>().sprite;
       
        impactCount = 0;
    }
    // Blok sayýsýný artýran fonksiyon
    public void BlockCounter()
    {
        breakableBlock = (this.tag == "Block");
        if (breakableBlock)
        {
            blockCount++;
        }

    }
    // Blok sayýsýný azaltan fonksiyon
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

    // Çarpýþma algýlayýcý fonksiyon

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
       // GetComponent<AudioSource>().Play();
        if (breakableBlock)
        {
            
            imppactController();
        }
    }

    // Çarpýþma kontrolcüsü
    public void imppactController()
    {
       
        impactCount++;
        // yeterinde çarpýþma olduysa, bloðu yok et me durumu
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
            blockSpriteChange(); // Blok sprite'ýný deðiþtir
        }
    }

     // Efekt oluþturma fonksiyonu
    void effectSpawn()
    {
        GameObject effect = Instantiate(blockData.effect, gameObject.transform.position, Quaternion.identity) as GameObject; // efect oluþturma 
        effect.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color; // efecte blok rengini verme
        Destroy(effect,2); // oluþturulan efecti yok etme 
    }
    // Bloðun spritýný deðiþtirme
    public void blockSpriteChange()
    {
        this.GetComponent<SpriteRenderer>().sprite = blockData.blockSprites[impactCount - 1];
    }
}
