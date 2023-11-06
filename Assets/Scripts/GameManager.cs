using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool isPaused;

    public void Pause()
    {
        Time.timeScale = isPaused ? 1 : 0;
        isPaused = !isPaused;
    }
}