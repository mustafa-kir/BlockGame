using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBallController : MonoBehaviour
{
    [SerializeField] private GameObject gameBar; // oyun bar objesi
    private Vector3 distanceBallWithBar; // top ile bar arasýndaki mesafeyi tutan deðiþken

    public bool isGameStarted; // oyun baþayýp baþlamadýðýný kontrol eden deðiþken

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
        distanceBallWithBar = this.transform.position - gameBar.transform.position; // top ile çubuk arasýndaki mesafeyi tutma iþlemi
    }

    // Update is called once per frame
    void Update()
    {
        StartLocationBallAndBar();
    }


    //Eðer oyun baþlamamýsa Topun bar ile arasýndaki mesafeyi koruyan fonksiyon
    public void StartLocationBallAndBar()
    {
        if (!isGameStarted)
        {
            this.transform.position = gameBar.transform.position + distanceBallWithBar;
            // sol týka týkladðýnda, oyunu baþlatama ve topa hýz verme
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

    // topun diðer nesnelerle etkileþimi
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
