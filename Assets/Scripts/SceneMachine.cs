using UnityEngine;

public class SceneMachine : MonoBehaviour
{
    public GameObject GameScreen;
    public GameObject LoseScreen;
    private GameObject currentScreen;

    private void Start()
    {
        currentScreen = GameScreen;
        currentScreen.SetActive(true);
    }

    public void Lose()
    {
        currentScreen.SetActive(false);
        LoseScreen.SetActive(true);
    }
}
