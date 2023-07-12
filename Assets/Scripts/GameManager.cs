using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; } // Instancia del Game Manager
    public bool IsPlayerAlive { get; set; } // Estado del jugador

    [SerializeField] GameObject gameOverPanel;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        // Al iniciar, establece el estado del jugador como vivo (true)
        IsPlayerAlive = true;
    }

    private void Update()
    {
        if(IsPlayerAlive == false)
        {
            Invoke("GameOverPanel", 0.6f);
        }


        if (Input.GetKeyDown(KeyCode.Joystick1Button6))
        {
            GameManager.Instance.IsPlayerAlive = true;
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.buildIndex, LoadSceneMode.Single);
        }

    }

    void GameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }
}
