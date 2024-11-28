using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Launcher : MonoBehaviourPunCallbacks
{
    string gameVersion = "1";
    [SerializeField]
    private byte maxPlayerPerRoom = 4;
    public GameObject prefabPlayer;
    public Vector3 spawn = new Vector3(0, 1, 0);

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.LogWarningFormat("OnDisconnected() was called by PUN with reason {0}", cause);
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = maxPlayerPerRoom});
    }
    
    public override void OnJoinedRoom()
    {
        Debug.Log("Now this client is in room");
        if (PhotonNetwork.InRoom)
        {
            Debug.Log($"Nom de la room : {PhotonNetwork.CurrentRoom.Name}");
            Debug.Log($"Nombre de joueurs dans la room : {PhotonNetwork.CurrentRoom.PlayerCount}");
        }
        PhotonNetwork.Instantiate(prefabPlayer.name, spawn, Quaternion.identity);
    }

    void Awake()
    {
        // Sync the level
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    void Start()
    {
        Connect();
    }

    public void Connect()
    {
        //Check if we are connected if yes join a random room else connect to serv
        if(PhotonNetwork.IsConnected)
        {
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            // Connect to serv
            PhotonNetwork.ConnectUsingSettings();
            PhotonNetwork.GameVersion = gameVersion;
        }
    }
}
