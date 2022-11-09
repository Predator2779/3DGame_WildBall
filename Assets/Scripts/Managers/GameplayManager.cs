using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameplayManager : MonoBehaviour
{
    #region ����������

    //[Header("Score")]
    //[SerializeField] private Text _scoreText;                   /// ���� �����.
    //public int _score = 0;                                      /// ���� ������.

    [Header("GameManager")]                                     
    public bool _playing = false;                               /// ������.
    public bool _paused = false;                                /// �����.

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
        //print("Start" + SceneManager.GetActiveScene().name);
    }

    /// <summary>
    /// Update.
    /// </summary>
    private void Update()
    {
        //Playing();
        Pause();
        EscapeButton();
    }

    /// <summary>
    /// ������� �� ����� ������.
    /// </summary>
    public void InputName()
    {
        //_scoreBoardText.text += $"{_name.text}: {_score}\n";
        //_score = 0;

        //_inputPanel.SetActive(false);
        //_menuPanel.SetActive(true);
    }

    /// <summary>
    /// ������ ����.
    /// </summary>
    public void LoadScene(string nameScene)
    {
        //_menuPanel.SetActive(false);
        //_mainCamera.SetActive(false);
        //_playing = true;

        SceneManager.LoadScene(nameScene);
    }

    /// <summary>
    /// � ����.
    /// </summary>
    public void ToMenu()
    {
        _paused = false;

        LoadScene("[0]_Menu");

        //_playing = false;
        //_paused = false;

        //_pausePanel.SetActive(false);
        //_menuPanel.SetActive(true);
        //_mainCamera.SetActive(true);

        //Time.timeScale = 1;
    }

    /// <summary>
    /// ���������� ����.
    /// </summary>
    public void Continue()
    {
        _paused = false;

        //_mainCamera.SetActive(false);
        _pausePanel.SetActive(false);
        CursorVisible(false);

        Time.timeScale = 1;
    }

    /// <summary>
    /// ����� �� ����.
    /// </summary>
    public void ExitApp()
    {
        Application.Quit();
    }

    /// <summary>
    /// �������� �� ����� ����.
    /// </summary>
    private void Playing()
    {
        if (_playing && !_paused)
        {
            //MonitorScore();
        }
    }

    /// <summary>
    /// �����.
    /// </summary>
    private void Pause()
    {
        if (/*_playing && */_paused)
        {
            Time.timeScale = 0;
            CursorVisible(true);
            //_mainCamera.SetActive(true);
            _pausePanel.SetActive(true);
        }
    }

    private void EscapeButton()
    {
        if (Input.GetKey(KeyCode.Escape)/* && _playing*/)
        {
            if (!_paused)
            {
                _paused = true;
            }
            else
            {
                _paused = false;
            }
        }
    }

    /// <summary>
    /// ����� ����� �� �����
    /// </summary>
    private void MonitorScore()
    {
        //_scoreText = GameObject.Find("Score").GetComponent<Text>();
        //_scoreText.text = $"XP: {_score}";
    }

    /// <summary>
    /// ��������/��������� ������.
    /// </summary>
    /// <param name="visible">���������</param>
    private void CursorVisible(bool visible) => Cursor.visible = visible;
}