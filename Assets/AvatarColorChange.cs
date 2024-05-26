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
        //�����̃A�o�^�[���m�F
        if (photonView.IsMine)
        {
            //photonView.RPC
            //1.�Ăяo���������\�b�h�𕶎���Ŏw�聦nameof �����g���ƁA�ϐ��A�^�A�܂��̓����o�[�̖��O��������萔�Ƃ��Đ��������̂őł��ԈႢ�����点�܂�
            //2.RPC�𔭉΂���Ώۂ�ݒ� ���S���������ȊO���A�r���Q���҂ɂ����邩�A�@�������g�ɑ΂��Ă��T�[�o�[���o�R���邩�Ȃ�
            //3.���̃��\�b�h�𔭉΂���ۂ̈���
            if (Input.GetKeyDown(KeyCode.Alpha1))   //�L�[�{�[�h��� �u1�v����������c
                photonView.RPC(nameof(ChangeColorRPC), RpcTarget.AllBuffered, 0);
            if (Input.GetKeyDown(KeyCode.Alpha2))
                photonView.RPC(nameof(ChangeColorRPC), RpcTarget.AllBuffered, 1);
            if (Input.GetKeyDown(KeyCode.Alpha3))
                photonView.RPC(nameof(ChangeColorRPC), RpcTarget.AllBuffered, 2);
        }
    }

    //RPC(�����[�g�E�v���V�[�W���E�R�[���j�̐錾�B
    //RPC��Photon�Łu���̊��Ɍ������ă��b�Z�[�W�𑗐M����v��i
    [PunRPC]
    public void ChangeColorRPC(int target)
    {
        GetComponent<Renderer>().material = changeColors[target];
    }
}