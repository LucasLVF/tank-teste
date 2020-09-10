using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public PhotonView pview;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IrProMenu ()
    {
        if (pview.IsMine)
        PhotonNetwork.LoadLevel("Menu");
    }
}
