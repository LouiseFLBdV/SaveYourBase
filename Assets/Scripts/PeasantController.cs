using UnityEngine;
using UnityEngine.UI;

public class PeasantController : MonoBehaviour
{
    public GameController gameController;
    public float timeToCreatePeasant = 10.0f;
    public int peasantRequire = 3;
    
    private bool _isCreatingPeasant;
    private float _currentTime;
    private Scrollbar _peasantCreationProgress;

    private void Start()
    {
        InitializeReferences();
        ResetPeasantCreation();
    }

    private void Update()
    {
        UpdatePeasantCreationProgress();
    }

    private void InitializeReferences()
    {
        gameController = FindObjectOfType<GameController>();
        _peasantCreationProgress = GetComponentInChildren<Scrollbar>();
    }

    private void ResetPeasantCreation()
    {
        _currentTime = timeToCreatePeasant;
        _peasantCreationProgress.gameObject.SetActive(false);
        _isCreatingPeasant = false;
    }
    
    private void UpdatePeasantCreationProgress()
    {
        if (_isCreatingPeasant)
        {
            _currentTime -= Time.deltaTime;
            _peasantCreationProgress.size = _currentTime / timeToCreatePeasant;

            if (_currentTime <= 0)
            {
                ResetPeasantCreation();
                gameController.CreateNewPeasant();
            }
        }
    }
    private void StartPeasantCreation()
    {
        if (gameController.food >= peasantRequire && !_isCreatingPeasant)
        {
            _isCreatingPeasant = true;
            _peasantCreationProgress.gameObject.SetActive(true);
            gameController.food -= peasantRequire;
        }
    }

    private void OnMouseDown()
    {
        StartPeasantCreation();
    }
}