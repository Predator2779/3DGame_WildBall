using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameplayManager _gameplayManager;
    [SerializeField] private GameObject _playerPrefab;
    [SerializeField] private string _loadScene;

    private void Start()
    {
        var playerPos = new Vector3(Random.Range(-35, 35), 6, Random.Range(-35, 35));

        PhotonNetwork.Instantiate(_playerPrefab.name, playerPos, Quaternion.identity);
    }

    public override void OnLeftRoom()
    {
        ///  огда текущий игрок (мы) покидает комнату.

        SceneManager.LoadScene(_loadScene);
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.Disconnect();

        _gameplayManager.ToMenu();
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.LogFormat("Player {0} entered the room", newPlayer.NickName);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        Debug.LogFormat("Player {0} left the room", otherPlayer.NickName);
    }
}
