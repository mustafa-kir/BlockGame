using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class gameBarController : MonoBehaviour
{
    public bool AI; // Yapay zeka kullanılacak mı durumunu kontrol eden değişken
    private IGameBarMove gameBar; // oyun çubuğunu hareket ettircek nesne
    [SerializeField] private GameObject gameBall; // oyun tpo nesnesi
   
    // Start is called before the first frame update
    void Start()
    {
        updateMove();
       
    }

    // Update is called once per frame
    void Update()
    {
        ;
        if (Input.GetMouseButtonDown(0))
        {
            updateMove();
        }

        // Oyun çubuğunu hareket ettir
        float xPosition = gameBar.Move();
        Vector3 newPositon = new Vector3(math.clamp(xPosition, -7.5f, 7.5f), this.transform.position.y, 0f);
        this.transform.position = newPositon;
    }

    private void updateMove()
    {
        // Yapay zeka kullanılıyorsa MoveWithAI ile, kullanılmıyorsa MoveWithMouse ile
        if (AI)
        {
            gameBar = new MoveWithAI(gameBall);


        }
        else
        {
            gameBar = new MoveWithMouse();
        }
    }
}
