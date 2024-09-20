using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 
public class MainMenuManager : MonoBehaviour
{
    [Header("Panels.....")]
    
    [SerializeField] private GameObject MainMenuPanel;
    [SerializeField] private GameObject SettingsPanel;
    [SerializeField] private GameObject ExitPanel;

    [Header("Buttons.....")]
    
    [SerializeField] private Button StartBtn;
    [SerializeField] private Button SettingsMenu;
    [SerializeField] private Button Back;
    [SerializeField] private Button QuitBtn;
    
    void Start()
    {
      ///  Cursor.visible = true;
       /// Cursor.lockState = CursorLockMode.Locked;
        
        
        StartBtn.onClick.AddListener(OnStartClicked);
        SettingsMenu.onClick.AddListener(OpenSettingsPanel);
        Back.onClick.AddListener(BackToMainMenu);
        
       
        MainMenuPanel.SetActive(true);
        SettingsPanel.SetActive(false);
        ExitPanel.SetActive(false);
    }

   
    void OnStartClicked()
    {
        Debug.Log("Start Game");
        SceneManager.LoadScene("Play"); 
    }


    void OpenSettingsPanel()
    {
        SettingsPanel.SetActive(true);
    }

    void BackToMainMenu()
    {
        ExitPanel.SetActive(true);
       
    }

    void Quit()
    {
        Application.Quit();
    }
}