using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    // Start is called before the first frame update
    private SoundManager soundManager;

    public Button playButton;
    public Button quitButton;

    private const int firstLevel = 1;

    private void Awake()
        {
            AddListeners();
        soundManager = FindObjectOfType<SoundManager>();
    }

        private void AddListeners()
        {
            playButton.onClick.AddListener(Play);
            quitButton.onClick.AddListener(Quit);
        }


         // Define the first level to load

    public void Play()
    {
        soundManager.PlayButtonClickAudio();
        SceneManager.LoadScene(firstLevel);  // Load the first level
       
    }

    public void Quit()
    {
        soundManager.PlayButtonClickAudio();
        Application.Quit();  // Quit the game
        Debug.Log("Game quit"); // Unity doesn't quit in the editor, so we log it
    }
}
