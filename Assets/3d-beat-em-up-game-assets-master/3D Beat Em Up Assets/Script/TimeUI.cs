using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeUI : MonoBehaviour
{
    public float timeRemaining = 120f; 
    public Text timerText; 

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimerDisplay();
        }
        else
        {
            timeRemaining = 0; 
            LoadLossScene();
        }
    }

    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);

        string timerString = string.Format("{0:00}:{1:00}", minutes, seconds);

        timerText.text = timerString;
    }

    void LoadLossScene()
    {
        SceneManager.LoadScene("Loss"); // Load scene Loss
    }
}
