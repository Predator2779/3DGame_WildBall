using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayManager : MonoBehaviour
{
    #region Переменные

    //[Header("Score")]
    //[SerializeField] private Text _scoreText;                   /// Поле текст.
    //public int _score = 0;                                      /// Опыт игрока.

    private enum GameModes { Playing, Paused, ToMenu };
    [SerializeField] private GameModes _gameMode;

    [SerializeField] private GameObject _pausePanel;
    //[SerializeField] private GameObject _mainCamera;
    //[SerializeField] private GameObject _menuPanel;
    //[SerializeField] private GameObject _inputPanel;
    //[SerializeField] private GameObject _player;
    //[SerializeField] private Text _name;
    //[SerializeField] private Text _scoreBoardText;

    #endregion

    private void Start()
    {
        
    }

    /// <summary>
    /// Update.
    /// </summary>
    private void Update()
    {
        CheckGameMode();
        EscapeButton();
    }

    /// <summary>
    /// Попасть на доску почета.
    /// </summary>
    public void InputName()
    {
        //_scoreBoardText.text += $"{_name.text}: {_score}\n";
        //_score = 0;

        //_inputPanel.SetActive(false);
        //_menuPanel.SetActive(true);
    }

    /// <summary>
    /// Начало игры.
    /// </summary>
    public void LoadScene(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }

    private void CheckGameMode()
    {
        switch (_gameMode)
        {
            case GameModes.Playing:
                Playing();
                break;
            case GameModes.Paused:
                Paused();
                break;
            case GameModes.ToMenu:
                ToMenu();
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// В меню.
    /// </summary>
    public void ToMenu()
    {
        Time.timeScale = 1;

        LoadScene("[0]_Menu");
    }

    /// <summary>
    /// Продолжить игру.
    /// </summary>
    public void Continue()
    {
        _gameMode = GameModes.Playing;
    }

    /// <summary>
    /// Выход из игры.
    /// </summary>
    public void ExitApp()
    {
        Application.Quit();
    }

    /// <summary>
    /// Процессы во время игры.
    /// </summary>
    private void Playing()
    {
        //MonitorScore();

        //CursorVisible(false);////////////////////////на время

        _pausePanel.SetActive(false);

        Time.timeScale = 1;
    }

    /// <summary>
    /// Пауза.
    /// </summary>
    private void Paused()
    {
        Time.timeScale = 0;
        //CursorVisible(true);/////////////////////////////////на время

        _pausePanel.SetActive(true);
    }

    private void EscapeButton()
    {
        if (Input.GetKeyDown(KeyCode.Escape)/* && _playing*/)
        {
            if (_gameMode != GameModes.Paused)
            {
                _gameMode = GameModes.Paused;
            }
            else
            {
                _gameMode = GameModes.Playing;
            }
        }
    }

    /// <summary>
    /// Вывод очков на экран
    /// </summary>
    private void MonitorScore()
    {
        //_scoreText = GameObject.Find("Score").GetComponent<Text>();
        //_scoreText.text = $"XP: {_score}";
    }

    /// <summary>
    /// Включает/отключает курсор.
    /// </summary>
    /// <param name="visible">Видимость</param>
    private void CursorVisible(bool visible) => Cursor.visible = visible;
}