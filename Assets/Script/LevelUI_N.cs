using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelUI_N : MonoBehaviour
{
    public TextMeshProUGUI level_Text, gameOver_Text;
    private int level_Number;

    public GameObject gameOverPanel, levelPanel;
    public Button restart_Button, mainMenu_Button;

    public LevelManager levelManager;
    private SoundManager soundManager;


    private void Awake()
    {
        //Rest of the Code
        AddListener(); //imram change
        soundManager = FindObjectOfType<SoundManager>();
    }
    private void Start()
    {
        
        level_Number = SceneManager.GetActiveScene().buildIndex;//imram change
        UpdateLevelText();
    }




    private void UpdateLevelText()
    {
        level_Text.text = "Level: " + level_Number;
    }

    private void HideLevelPanel()
    {
        levelPanel.SetActive(false);
    }

    private void SetGameOverPanel(bool isActive)
    {
        gameOverPanel.SetActive(isActive);
    }
    ///////////////////////////////////////////////////////////////////////////////u
    void AddListener()
    {
        restart_Button.onClick.AddListener(RestartButton);
        mainMenu_Button.onClick.AddListener(MainMenuButton);
    }
   

    private void RestartButton()
    {
        soundManager.PlayButtonClickAudio();
        levelManager.RestartLevel();
    }
    private void MainMenuButton()
    {
        soundManager.PlayButtonClickAudio();
        soundManager.DestroySoundManager();  // Destroy the current SoundManager
        levelManager.LoadMainMenu();
    }

    
    /// /////////////////////////////////////////////////////////////////////////////
    
    public void ShowGameWinUI()
    {
        SetGameOverPanel(true);

        gameOver_Text.text = "Game Completed!!";
        gameOver_Text.color = Color.green;
        //HideLevelPanel();
    }

    public void ShowGameLoseUI()
    {
        SetGameOverPanel(true);

        gameOver_Text.text = "Game Over!!";
        gameOver_Text.color = Color.red;
        //HideLevelPanel();
    }

   
}
