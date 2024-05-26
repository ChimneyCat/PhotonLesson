using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class AvatarColorChange : MonoBehaviourPunCallbacks
{
    [SerializeField] private Material[] changeColors = new Material[3];

    // Update is called once per frame
    void Update()
    {
        //自分のアバターか確認
        if (photonView.IsMine)
        {
            //photonView.RPC
            //1.呼び出したいメソッドを文字列で指定※nameof 式を使うと、変数、型、またはメンバーの名前が文字列定数として生成されるので打ち間違いを減らせます
            //2.RPCを発火する対象を設定 →全員か自分以外か、途中参加者にも送るか、　自分自身に対してもサーバーを経由するかなど
            //3.そのメソッドを発火する際の引数
            if (Input.GetKeyDown(KeyCode.Alpha1))   //キーボード上の 「1」を押したら…
                photonView.RPC(nameof(ChangeColorRPC), RpcTarget.AllBuffered, 0);
            if (Input.GetKeyDown(KeyCode.Alpha2))
                photonView.RPC(nameof(ChangeColorRPC), RpcTarget.AllBuffered, 1);
            if (Input.GetKeyDown(KeyCode.Alpha3))
                photonView.RPC(nameof(ChangeColorRPC), RpcTarget.AllBuffered, 2);
        }
    }

    //RPC(リモート・プロシージャ・コール）の宣言。
    //RPCはPhotonで「他の環境に向かってメッセージを送信する」手段
    [PunRPC]
    public void ChangeColorRPC(int target)
    {
        GetComponent<Renderer>().material = changeColors[target];
    }
}