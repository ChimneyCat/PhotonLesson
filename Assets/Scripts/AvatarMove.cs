using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class AvatarMove : MonoBehaviourPunCallbacks
{
    // Update is called once per frame
    void Update()
    {
        //そのアバターが自分のかどうかを確認して処理を反映させる
        //基本的にPhotonでのアバターはUpdate内にif(photonView.IsMine)が必須
        if (photonView.IsMine)
        {
            //十字キーの操作でtransformを利用して移動する
            Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")) * 0.1f;
            transform.position += input;
        }
    }
}
