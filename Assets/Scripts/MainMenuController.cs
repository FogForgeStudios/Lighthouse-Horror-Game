using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public AudioSource clickSound;  // Assign this in the Unity Editor

    void Start()
    {
        // Optionally, you can configure the click sound in the Unity Editor
        // clickSound.volume = 0.5f;
    }

    public void StartNewGame()
    {
        // Play the clicking sound
        PlayClickSound();
        // Load the game scene
        SceneManager.LoadScene("GameScene");
    }

    public void ResumeGame()
    {
        // Play the clicking sound
        PlayClickSound();
        // Implement resume game logic
    }

    public void OpenSettings()
    {
        // Play the clicking sound
        PlayClickSound();
        // Load the settings scene
        SceneManager.LoadScene("SettingsScene");
    }

    public void LoadGame()
    {
        // Play the clicking sound
        PlayClickSound();
        // Implement load game logic
    }

    public void ExitGame()
    {
        // Play the clicking sound
        PlayClickSound();

        // Quit the application
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }

    // Additional clickable items can be added with their respective methods
    public void OtherItemClick()
    {
        // Example method for handling clicking sound for another clickable item
        PlayClickSound();
        // Implement logic for the clickable item
    }

    private void PlayClickSound()
    {
        if (clickSound != null)
        {
            clickSound.Play();
        }
    }
}
