using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndMenu : MonoBehaviour
{
    // Assign the button through the inspector
    public Button restartButton;

    void Start()
    {
        // Make sure the button is assigned
        if (restartButton != null)
        {
            restartButton.onClick.AddListener(RestartScene);
        }
        else
        {
            Debug.LogError("Restart button not assigned!");
        }
    }

    void RestartScene()
    {
        // Get the active scene and reload it
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
