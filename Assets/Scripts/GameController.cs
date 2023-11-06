using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public SceneMachine SceneMachine;
    public int wars = 1;
    public int food = 5;
    public int peasants = 1;
    public int enemy = 1;

    public TMP_Text warsRender;
    public TMP_Text foodRender;
    public TMP_Text peasantsRender;
    public TMP_Text enemyRender;

    public Image attackTime;
    public Image foodCalculation;

    private float _currentAttackTime;
    private float _currentFoodCalculationTime;

    public float nextAttackTime = 30;
    public float foodCalculationTime = 5;

    private void Start()
    {
        InitializeGame();
    }

    private void Update()
    {
        UpdateTimers();
    }

    private void InitializeGame()
    {
        SceneMachine = FindObjectOfType<SceneMachine>();
        _currentAttackTime = nextAttackTime;
        _currentFoodCalculationTime = foodCalculationTime;
        
        UpdateUI();
    }

    private void UpdateTimers()
    {
        _currentAttackTime -= Time.deltaTime;
        _currentFoodCalculationTime -= Time.deltaTime;

        UpdateTimersUI();
        PerformFoodCalculation();
        PerformEnemyAttack();
    }

    private void PerformFoodCalculation()
    {
        if (!(_currentFoodCalculationTime <= 0)) return;
        _currentFoodCalculationTime = foodCalculationTime;

        food += (peasants - wars);
        if (food < 0)
        {
            wars = 0;
            food = 0;
        }

        UpdateUI();
    }

    private void PerformEnemyAttack()
    {
        if (!(_currentAttackTime <= 0)) return;
        
        _currentAttackTime = nextAttackTime;
        wars -= enemy;
        enemy += peasants / 3 + 1;
        if (wars < 0)
        {
            SceneMachine.Lose();
        }
        UpdateUI();
    }
    public void CreateNewWar()
    {
        wars++;
        UpdateUI();
    }

    public void CreateNewPeasant()
    {
        peasants++;
        UpdateUI();
    }

    private void UpdateUI()
    {
        warsRender.text = wars.ToString();
        peasantsRender.text = peasants.ToString();
        foodRender.text = food.ToString();
        enemyRender.text = enemy.ToString();
    }

    private void UpdateTimersUI()
    {
        attackTime.fillAmount = _currentAttackTime / nextAttackTime;
        foodCalculation.fillAmount = _currentFoodCalculationTime / foodCalculationTime;
    }
}