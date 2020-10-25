using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonEvent : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private Outline outline;
    private AudioSource audioSource;
    private GameManager gameManager;
    private PauseMenu pauseMenu;

    enum ButtonTypeEnum
    {
        Start, Resume, Restart, Menu, Exit
    }
    
    [SerializeField]
    private AudioClip hoverButton;
    [SerializeField]
    private AudioClip explosion;
    [SerializeField]
    private ButtonTypeEnum buttonType;

    private Scene currentScene;

    void Start()
    {
        outline = transform.GetChild(0).GetComponent<Outline>();
        audioSource = GetComponent<AudioSource>();
        gameManager = GameObject.Find("GameManager")?.GetComponent<GameManager>();
        pauseMenu = GameObject.Find("PauseCanvas")?.GetComponent<PauseMenu>();
        currentScene = SceneManager.GetActiveScene();

         if (pauseMenu == null && currentScene.name != "Menu")
         {
             Debug.LogError("pauseMenu is not defined");
         }

         if (gameManager == null)
         {
             Debug.LogError("gameManager is not defined");
         }

        if (outline == null)
        {
            Debug.LogError("outline is not defined");
        }

        if (audioSource == null)
        {
            Debug.LogError("audioSource is not defined");
        }
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        audioSource.PlayOneShot(hoverButton);
        outline.enabled = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        outline.enabled = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (explosion != null)
        {
            audioSource.PlayOneShot(explosion, 0.1f);
        }
        
        if (buttonType == ButtonTypeEnum.Start)
        {
            gameManager.LoadTutorialLevel();
        }

        if (currentScene.name != "Menu")
        {
            if (buttonType == ButtonTypeEnum.Resume)
            {
                pauseMenu.ResumeGame();
            }
        
            if (buttonType == ButtonTypeEnum.Restart)
            {
                pauseMenu.ResumeGame();
                gameManager.PlayerLoses();
            }
        
            if (buttonType == ButtonTypeEnum.Menu)
            {
                pauseMenu.ResumeGame();
                gameManager.LoadMenu();
            }
        }
        
        
        if (buttonType == ButtonTypeEnum.Exit)
        {
            Application.Quit();
        }
    }
}
