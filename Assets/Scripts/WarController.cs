using UnityEngine;
using UnityEngine.UI;

public class WarController : MonoBehaviour
{
    public GameController gameController;
    public float timeToCreateWar = 3.0f;
    public int warRequire = 5;
    
    private bool _isCreatingWar;
    private float _currentTime;
    private Scrollbar _warCreationProgress;

    private void Start()
    {
        InitializeReferences();
        ResetWarCreation();
    }

    private void Update()
    {
        UpdateWarCreationProgress();
    }

    private void InitializeReferences()
    {
        gameController = FindObjectOfType<GameController>();
        _warCreationProgress = GetComponentInChildren<Scrollbar>();
    }

    private void ResetWarCreation()
    {
        _currentTime = timeToCreateWar;
        _warCreationProgress.gameObject.SetActive(false);
        _isCreatingWar = false;
    }
    
    private void UpdateWarCreationProgress()
    {
        if (_isCreatingWar)
        {
            _currentTime -= Time.deltaTime;
            _warCreationProgress.size = _currentTime / timeToCreateWar;

            if (_currentTime <= 0)
            {
                ResetWarCreation();
                gameController.CreateNewWar();
            }
        }
    }
    private void StartWarCreation()
    {
        if (gameController.food >= warRequire && !_isCreatingWar)
        {
            _isCreatingWar = true;
            _warCreationProgress.gameObject.SetActive(true);
            gameController.food -= warRequire;
        }
    }

    private void OnMouseDown()
    {
        StartWarCreation();
    }
}