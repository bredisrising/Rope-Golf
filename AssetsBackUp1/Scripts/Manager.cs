using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Manager : MonoBehaviour
{
    
    [SerializeField] AudioClip select;
    [SerializeField] AudioSource audioSource;
    [SerializeField] GameObject camHolder;
    [SerializeField] Camera cam;
    [SerializeField] GameObject player;
    private GameObject[] playerPositions;
    private GameObject[] camPositions;
    public GameObject[] stars;
    
  
    private GameObject[] portals; 
    public int numOflvls;
    [SerializeField] GameObject ropeLine;
    [SerializeField] GameObject pointer;
    [SerializeField] TextMeshProUGUI scoreTxt;
    [SerializeField] TextMeshProUGUI starTxt;
    [SerializeField] int maxDeaths;
    [SerializeField] Sprite[] playerSprites;
    
    

    int deaths = 0;

    [SerializeField] AdManager adManager;
 
    public bool gameOver = false;
    bool hasRestarted = false;
    bool nextLvl = false;
    public int hasTeleported = 0;

    Color playerColor;

    public int currentLvlIndex;

    GameObject musicStart;

    PlayerCon playerCon;

    public int numStars = 0;

    private void Awake()
    {
        stars = GameObject.FindGameObjectsWithTag("Star");
        Debug.Log("Stars  " + stars.Length.ToString());
        camPositions = GameObject.FindGameObjectsWithTag("camPos");
        playerPositions = GameObject.FindGameObjectsWithTag("playerPos");
        if (PlayerPrefs.HasKey("lvl"))
        {
            currentLvlIndex = PlayerPrefs.GetInt("lvl");
        }
        else
        {
            currentLvlIndex = 0;
        }

        
        if (PlayerPrefs.HasKey("stars"))
        {
            numStars = PlayerPrefs.GetInt("stars");
        }




        for (int i = 0; i < stars.Length; i++)
        {
            if (PlayerPrefs.HasKey("star" + i))
            {
                if (PlayerPrefs.GetInt("star" + i) == 1)
                {
                    stars[i].SetActive(true);
                }
                else
                {
                    stars[i].SetActive(false);
                    Debug.Log("WTH!");
                }

            }
            else
            {
                stars[i].SetActive(true);
            }

        }

        Debug.Log(currentLvlIndex);




        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Game"))
        {
            player.transform.position = playerPositions[currentLvlIndex].transform.position;
            camHolder.transform.position = camPositions[currentLvlIndex].transform.position;
            SelectCharacter();
        }

    }

    private void OnEnable()
    {
        stars = GameObject.FindGameObjectsWithTag("Star");
        Debug.Log("Stars  " + stars.Length.ToString());
        camPositions = GameObject.FindGameObjectsWithTag("camPos");
        playerPositions = GameObject.FindGameObjectsWithTag("playerPos");
        if (PlayerPrefs.HasKey("lvl"))
        {
            currentLvlIndex = PlayerPrefs.GetInt("lvl");
        }
        else
        {
            currentLvlIndex = 0;
        }


        if (PlayerPrefs.HasKey("stars"))
        {
            numStars = PlayerPrefs.GetInt("stars");
        }




        for (int i = 0; i < stars.Length; i++)
        {
            if (PlayerPrefs.HasKey("star" + i))
            {
                if (PlayerPrefs.GetInt("star" + i) == 1)
                {
                    stars[i].SetActive(true);
                }
                else
                {
                    stars[i].SetActive(false);
                    Debug.Log("WTH!");
                }

            }
            else
            {
                stars[i].SetActive(true);
            }

        }

        Debug.Log(currentLvlIndex);




        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Game"))
        {
            player.transform.position = playerPositions[currentLvlIndex].transform.position;
            camHolder.transform.position = camPositions[currentLvlIndex].transform.position;
            SelectCharacter();
        }
    }

    void Start()
    {
        

        















        Debug.Log("STARTED");
        //adManager = GameObject.FindObjectOfType<AdManager>();

        playerColor = player.GetComponent<SpriteRenderer>().color;
        playerCon = player.GetComponent<PlayerCon>();

        musicStart = GameObject.FindGameObjectWithTag("Music");
        musicStart.transform.SetParent(cam.transform);
        musicStart.transform.localPosition = new Vector3(0, 0, 0);

        Debug.Log("HHUUUU");

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Game"))
        {
            portals = GameObject.FindGameObjectsWithTag("Portal");
            portals[currentLvlIndex].SetActive(true);

            for (int i = 0; i < portals.Length - 1; i++)
            {
                if (i != currentLvlIndex)
                {
                    portals[i].SetActive(false);
                }
            }
        }
        
        
       

       

        

        

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Game"))
        {
            scoreTxt.SetText((currentLvlIndex + 1).ToString());
            
        }

        
        starTxt.text = numStars.ToString();

        Debug.Log(adManager.tag);
    }

    
    void Update()
    {
        if (SceneManager.GetActiveScene()==SceneManager.GetSceneByName("Game")) {
            if (gameOver && Input.GetMouseButtonDown(0))
            {

                Restart();
                hasRestarted = true;
            }

            if (hasRestarted)
            {
                if (gameOver && Input.GetMouseButtonUp(0))
                {
                    player.GetComponent<Rigidbody2D>().isKinematic = false;
                    player.GetComponent<TrailRenderer>().Clear();
                    gameOver = false;
                    hasRestarted = false;
                }
            }
        }

        if (hasTeleported==1)
        {
            if (currentLvlIndex != 0)
            {
                portals[currentLvlIndex - 1].SetActive(false);
            }
            portals[currentLvlIndex].SetActive(true);
            camHolder.transform.position = camPositions[currentLvlIndex].transform.position;
            if (nextLvl == true)
            {
                if (Input.GetMouseButtonUp(0))
                {
                    player.GetComponent<Rigidbody2D>().isKinematic = false;
                    playerCon.line.enabled = false;
                    gameOver = false;
                    nextLvl = false;
                    hasTeleported = 0;
                }
            }
        }

        if (hasTeleported == 2)
        {
            StartCoroutine(WaitTeleport(.6f));
        }


        if (deaths >= maxDeaths)
        {
            StartCoroutine(adManager.ShowAdWhenReady());

            deaths = 0;
        }
       

        
    }

    public void TeleportNextLevel()
    {
        
        nextLvl = true;
        gameOver = true;
        
        currentLvlIndex++;
       
        player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        player.GetComponent<TrailRenderer>().Clear();

        
        
        //camHolder.transform.position = camPositions[currentLvlIndex].transform.position;
        player.transform.position = playerPositions[currentLvlIndex].transform.position;
        pointer.transform.position = new Vector2(player.transform.position.x,player.transform.position.y+.7f);

        

        player.GetComponent<Rigidbody2D>().isKinematic = true;
        playerCon.line.enabled = false;
        player.GetComponent<DistanceJoint2D>().enabled = false;
        player.GetComponent<TrailRenderer>().Clear();

        hasTeleported = 2;

        scoreTxt.SetText((currentLvlIndex + 1).ToString());


    }

    void Restart()
    {

        
        
        player.transform.position = playerPositions[currentLvlIndex].transform.position;
        player.GetComponent<SpriteRenderer>().color = playerColor;
        player.GetComponent<CircleCollider2D>().enabled = true;
        player.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
        player.GetComponent<TrailRenderer>().enabled = true;

        deaths++;
        Debug.Log("if ad is shown?"+ (deaths >= maxDeaths).ToString());
        
    }

    public IEnumerator WaitTeleport(float duration)
    {
        yield return new WaitForSeconds(duration);
        hasTeleported = 1;
    }

    public void GameScene()
    {

      




        audioSource.PlayOneShot(select);
        SceneManager.LoadScene("Game");
        Time.timeScale = 1f;
    }

   
    public void SaveStars()
    {
        for (int i=0;i<stars.Length;i++)
        {
            if (stars[i].activeSelf)
            {
                PlayerPrefs.SetInt("star" + i, 1);
            }else if (!stars[i].activeSelf)
            {
                PlayerPrefs.SetInt("star" + i, 0);
            }
        }
    }
  

    public void EndScene()
    {
        
        SceneManager.LoadScene("End");
    }

    public void ShopScene()
    {
        SceneManager.LoadScene("Shop");
    }

    public void Quit()
    {
        SaveStars();
        PlayerPrefs.SetInt("stars", numStars);
        Application.Quit();
    }

    public void StartScene()
    {
        SceneManager.LoadScene("Start");
    }

    public void TutorialScene()
    {
        SceneManager.LoadScene("Tutorial");
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("lvl", currentLvlIndex);
        PlayerPrefs.SetInt("stars", numStars);
    }

    private void Pause()
    {
        Time.timeScale = 0f;
    }
    private void Resume()
    {
        Time.timeScale = 1f;
    }

    public void ResetGame()
    {

        PlayerPrefs.SetInt("stars", numStars);
        PlayerPrefs.SetInt("lvl", 0);
        SceneManager.LoadScene("Start");
    }

    public void AddStars(int amount)
    {
        numStars += amount;
        starTxt.text = numStars.ToString();
        PlayerPrefs.SetInt("stars", numStars);
    }

    public void LoseStars(int amount)
    {
        numStars -= amount;
        starTxt.text = numStars.ToString();
        PlayerPrefs.SetInt("stars", numStars);
    }

    private void SelectCharacter()
    {
        if (PlayerPrefs.HasKey("equip"))
        {
            if ((PlayerPrefs.GetInt("equip")+1) != 0)
            {
                player.GetComponent<SpriteRenderer>().sprite = playerSprites[PlayerPrefs.GetInt("equip")+1];
            }
            else
            {
                player.GetComponent<SpriteRenderer>().sprite = playerSprites[0];
            }
        }
        else
        {
            player.GetComponent<SpriteRenderer>().sprite = playerSprites[0];
        }



    }

    public void ResetWholeGame()
    {

        PlayerPrefs.DeleteAll();
           







        PlayerPrefs.SetInt("stars", 0);
        

        Debug.Log("Yeet");
        Debug.Log("Yeet");

        for (int i = 0; i < 4; i++)
        {
            if (PlayerPrefs.HasKey("star" + i))
            {
                PlayerPrefs.SetInt("star" + i, 1);
                

            }
            

        }

        Debug.Log(PlayerPrefs.GetInt("star" + 1));
        PlayerPrefs.SetInt("bought" + 1, 0);
        PlayerPrefs.SetInt("bought" + 2, 0);
        PlayerPrefs.SetInt("bought" + 3, 0);
        PlayerPrefs.SetInt("lvl", 0);
        PlayerPrefs.SetInt("equip", 0);

        Debug.Log("Reseted");

    }
}
