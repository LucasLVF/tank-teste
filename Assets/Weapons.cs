using System.Collections;
using Photon.Pun;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    // Start is called before the first frame update
    public PhotonView pview;
    public GameObject pointoffire;
    float cooldown;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(pview.IsMine)
        {
            cooldown -= Time.deltaTime;
            if (Input.GetButtonDown("Jump")&& cooldown<0)
            {
                GameObject ob= (GameObject)
                PhotonNetwork.Instantiate("Bullet", pointoffire.transform.position, pointoffire.transform.rotation, 0);
                cooldown = 3;
            }
        }
    }
}
