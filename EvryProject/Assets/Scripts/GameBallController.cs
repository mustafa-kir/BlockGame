using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBallController : MonoBehaviour
{
    [SerializeField] private GameObject gameBar; // oyun bar objesi
    private Vector3 distanceBallWithBar; // top ile bar aras�ndaki mesafeyi tutan de�i�ken

    public bool isGameStarted; // oyun ba�ay�p ba�lamad���n� kontrol eden de�i�ken

    private static GameBallController instance = null;
    public static GameBallController Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {

        #region Singloton
        if (instance == null)
        {
            instance = this;
          
        }
        
        #endregion
    }

    void Start()
    {
        distanceBallWithBar = this.transform.position - gameBar.transform.position; // top ile �ubuk aras�ndaki mesafeyi tutma i�lemi
    }

    // Update is called once per frame
    void Update()
    {
        StartLocationBallAndBar();
    }


    //E�er oyun ba�lamam�sa Topun bar ile aras�ndaki mesafeyi koruyan fonksiyon
    public void StartLocationBallAndBar()
    {
        if (!isGameStarted)
        {
            this.transform.position = gameBar.transform.position + distanceBallWithBar;
            // sol t�ka t�klad��nda, oyunu ba�latama ve topa h�z verme
            if (Input.GetMouseButtonDown(0))
            {
                GetComponent<AudioSource>().Play();
                isGameStarted = true;
                float mouseXNormalized = Input.mousePosition.x / Screen.width; 
                float horizontalSpeed = 3f; 

                
                if (mouseXNormalized > 0.5f)
                {
                    
                    this.GetComponent<Rigidbody2D>().velocity = new Vector3(horizontalSpeed, 9f, 0f);
                }
                else
                {
                    
                    this.GetComponent<Rigidbody2D>().velocity = new Vector3(-horizontalSpeed, 9f, 0f);
                }
            }
        }
    }

    // topun di�er nesnelerle etkile�imi
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("FinishWall"))
        {
            
            GameManager.Instance.LoseGame();
        }

        Vector2 deviation = new Vector2(Random.Range(0f, 0.3f), Random.Range(0f, 0.3f));
        if (isGameStarted)
        {
            GetComponent<AudioSource>().Play();
            GetComponent<Rigidbody2D>().velocity += deviation;
        }
    }
}
