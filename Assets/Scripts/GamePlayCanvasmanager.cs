using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePlayCanvasManager : MonoBehaviour
{
    public static GamePlayCanvasManager instance;
    
    [Header("Pause Menu Panel......")]
    [SerializeField] private GameObject PauseMenuPanel;
    [SerializeField] public GameObject GameOverPanel;

    [Header("Pause Menu Buttons.......")]
    [SerializeField] private Button NewGameBtn;
    [SerializeField] private Button QuitBtn;
    [SerializeField] private Button ResumeBtn;
    [SerializeField] private Button SettingsBtn;

    [Header("Pause Menu Buttons.......")] [SerializeField]
    private Button NewGameBtn2;
   [SerializeField] private Button exitBtn;
    
    
    
    private bool isPaused = false;

    void Start()
    {

        instance = this;
        
        PauseMenuPanel.SetActive(false);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Locked;
     
        NewGameBtn.onClick.AddListener(RestartGame);
        NewGameBtn2.onClick.AddListener(RestartGame);
        QuitBtn.onClick.AddListener(QuitGame);
        exitBtn.onClick.AddListener(QuitGame);
        ResumeBtn.onClick.AddListener(ResumeGame);
        SettingsBtn.onClick.AddListener(OpenSettings);

       
    }

    void Update()
    {
     
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame(); 
            }
        }
    }

  
    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f;
    
        PauseMenuPanel.SetActive(true); 

     
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None; 
    }


  
    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f; 
        PauseMenuPanel.SetActive(false); 
    }

  
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

      public void QuitGame()
    {
        SceneManager.LoadScene("Main Menu"); 
        Time.timeScale = 1f; 
       
    }

  
    public void OpenSettings()
    {
        Debug.Log("Opening Settings...");
       
    }
}
