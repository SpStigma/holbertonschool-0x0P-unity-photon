using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Launcher : MonoBehaviourPunCallbacks
{
    string gameVersion = "1";

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        base.OnDisconnected(cause);
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        PhotonNetwork.CreateRoom(null, new RoomOptions());
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
