using System.Collections;
using Photon.Pun;
using System.Collections.Generic;
using UnityEngine;

public class tankId : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMesh name;
    public PhotonView pview;
    public int lives = 100;
    void Start()
    {
        name.text = pview.Owner.NickName;
    }

    // Update is called once per frame
    void Update()
    {
        //name.transform.LookAt(Camera.main.transform);
        name.transform.forward = transform.position - Camera.main.transform.position;
        if (pview.IsMine)
        { 
            if (lives < 0)
            {
                PhotonNetwork.Destroy(gameObject); // comentario
            
            }
        }
    }

    public void DamageTaken(Vector3 pos)
    {
        if (pview.IsMine)
        {
            float distance = Vector3.Distance(pos, transform.position);

            lives-=(int) (50/(distance+1));

            pview.RPC("DamageCall", RpcTarget.All, pos, lives);

            GetComponent<Rigidbody>().AddExplosionForce(1000, pos, 20);
        }

    }

    [PunRPC]
    void DamageCall(Vector3 pos, int livesRemain)
    {
        lives = livesRemain;        
        name.text = pview.Owner.NickName + "" + lives.ToString();
    }
}
