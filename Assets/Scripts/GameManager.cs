using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private const int MENU_SCENE = 0;
    private const int TUTORIAL_LEVEL = 1;
    private const int CREDITS = 6;
    private int currentLevel;
    private int totalScenes;
    private Text levelNumberText;
    
    [SerializeField] private Animator transition;
    [SerializeField] private float transitionTime = 2f;

    void Start()
    {
        currentLevel = SceneManager.GetActiveScene().buildIndex;
        totalScenes = SceneManager.sceneCountInBuildSettings;
        levelNumberText = GameObject.Find("LevelNumberText").GetComponent<Text>();

        if(levelNumberText == null)
        {
            Debug.LogError("levelNumberText not defined");
        }
    }

    public void LoadMenu()
    {
        currentLevel = MENU_SCENE;
        SceneManager.LoadScene(currentLevel);
    }

    public void LoadTutorialLevel()
    {
        currentLevel = TUTORIAL_LEVEL;
        levelNumberText.text = $"Level {currentLevel}";
        StartCoroutine(LoadScene(currentLevel));
    }

    public void PlayerWins()
    {
        if (currentLevel < (totalScenes-2))
        {
            currentLevel++;
            levelNumberText.text = $"Level {currentLevel}";
            StartCoroutine(LoadScene(currentLevel));
        }
        else
        {
            currentLevel = CREDITS;
            StartCoroutine(LoadScene(currentLevel));
        }
    }
    
    public void PlayerLoses()
    {
        StartCoroutine(LoadScene(currentLevel));
    }

    private IEnumerator LoadScene(int sceneNumber)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(sceneNumber);
    }
}
