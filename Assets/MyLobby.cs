using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using System.Linq;

public class MyLobby : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    public string PlayerName;
    public GameObject roomPanel;
    public InputField ifName;
    public GameObject required;
    public PlayerName[] playersNames;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
        if (ifName.text.Length > 0)
        {
            PlayerName = ifName.text;
            PhotonNetwork.LocalPlayer.NickName = PlayerName;
            PhotonNetwork.ConnectUsingSettings();
        }
        else
        {
            required.SetActive(true);
        }
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnConnectedToMaster()
    {
        roomPanel.SetActive(true);
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Não encontrou sala, Criando uma...");
        string roomName = "Sala00";
        RoomOptions rOp = new RoomOptions();
        rOp.MaxPlayers = 32;
        PhotonNetwork.CreateRoom(roomName, rOp);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.Instantiate("PlayerName", Vector3.zero, Quaternion.identity);
        InvokeRepeating("CheckAllReady", 1, 1);
    
        //PhotonNetwork.LoadLevel("Level1");
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log("O jogador" + newPlayer.NickName + "entrou na sala");
        
        
    }

    void CheckAllReady()
    {
        playersNames = FindObjectsOfType<PlayerName>();
        bool allready = false;
        if (playersNames.Length > 1)
        {
            allready = playersNames.All(x => x.ready);
              if (allready)
              {
                PhotonNetwork.CurrentRoom.IsOpen = false; // fecha a sala
                PhotonNetwork.LoadLevel("Level1");
              }
        }

    }
}
