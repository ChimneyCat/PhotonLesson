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
        //���̃A�o�^�[�������̂��ǂ������m�F���ď����𔽉f������
        //��{�I��Photon�ł̃A�o�^�[��Update����if(photonView.IsMine)���K�{
        if (photonView.IsMine)
        {
            //�\���L�[�̑����transform�𗘗p���Ĉړ�����
            Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")) * 0.1f;
            transform.position += input;
        }
    }
}
