using Photon.Pun;           //Photon��Unity�֘A�@�\
using Photon.Realtime;      //Photon�̃l�b�g���[�N�ڑ��p
using UnityEngine;


public class PhotonManager : MonoBehaviourPunCallbacks     //[MonoBehaviourPunCallbacks �N���X�̌p��]���̃N���X�́A.photonView�ƁAPUN���Ăяo�����Ƃ��ł��邷�ׂẴR�[���o�b�N/�C�x���g��񋟂��܂��B
{
    [SerializeField] private GameObject avatarSelectUI;
    [SerializeField] private GameObject[] avatarList = new GameObject[3];
    // Start is called before the first frame update
    void Start()
    {
        //Unity�G�f�B�^��PhotonServerSettings�Őݒ肵��AppID���g�p���ăl�b�g���[�N�ɐڑ�����
        PhotonNetwork.ConnectUsingSettings();
        
        avatarSelectUI.SetActive(false);
    }

    // OnConnectedToMaster�̓N���C�A���g��Master Server�ɐڑ�����Ă��āA�}�b�`���C�L���O�₻�̑��̃^�X�N���s���������������Ƃ��ɌĂяo����܂��B
    public override void OnConnectedToMaster()
    {
        //JoinOrCreateRoom���\�b�h�ł͑������Ŏw�肵�����O�̃��[�������݂���΂��̕����ɓ������A������΂��̃��[�����쐬���܂��B
        PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions(), TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        //Vector3 pos = new Vector3(Random.Range(-3, 3), 0, Random.Range(-3, 3));
        //PhotonNetwork.Instantiate���\�b�h��p���邱�Ƃ�Photon�o�R��GameObject�𐶐�����B
        //�������ɂ�"�I�u�W�F�N�g�̖��O�istring�j"���w�肵�AResources�t�H���_���ɂ��閼�O����v����I�u�W�F�N�g�𐶐�����B
        //PhotonNetwork.Instantiate(avatar.name, pos, Quaternion.identity);

        avatarSelectUI.SetActive(true);
    }

    public void AvatarSelect(int num)
    {
        Vector3 pos = new Vector3(Random.Range(-3, 3), 0, Random.Range(-3, 3));
        //PhotonNetwork.Instantiate���\�b�h��p���邱�Ƃ�Photon�o�R��GameObject�𐶐�����B
        //�������ɂ�"�I�u�W�F�N�g�̖��O�istring�j"���w�肵�AResources�t�H���_���ɂ��閼�O����v����I�u�W�F�N�g�𐶐�����B
        PhotonNetwork.Instantiate(avatarList[num].name, pos, Quaternion.identity);

        avatarSelectUI.SetActive(false);
    }
}
