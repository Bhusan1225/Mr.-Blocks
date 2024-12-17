using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{

    
    private int currentSceneIndex;
    public LevelUI_N levelUI_N;
    private const int mainMenuIndex = 0;

    private void Awake()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void OnLevelComplete() 
    {
        Debug.Log("Level Complete");
        LoadNextLevel(); 
    }

 

    private void LoadNextLevel()
    {
        
        int nextSceneIndex = currentSceneIndex + 1;
        int totalNumberOfScenes = SceneManager.sceneCountInBuildSettings;

        if (currentSceneIndex + 1 < totalNumberOfScenes)
            SceneManager.LoadScene(nextSceneIndex);
        else
            levelUI_N.ShowGameWinUI();    
    }

    public void LoadMainMenu() => SceneManager.LoadScene(mainMenuIndex);

    public void OnPlayerDeath() => levelUI_N.ShowGameLoseUI();
    
    public void RestartLevel()
    {
        SceneManager.LoadScene(currentSceneIndex);
    }

    



}

