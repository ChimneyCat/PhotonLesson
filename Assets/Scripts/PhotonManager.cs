using Photon.Pun;           //PhotonのUnity関連機能
using Photon.Realtime;      //Photonのネットワーク接続用
using UnityEngine;


public class PhotonManager : MonoBehaviourPunCallbacks     //[MonoBehaviourPunCallbacks クラスの継承]このクラスは、.photonViewと、PUNが呼び出すことができるすべてのコールバック/イベントを提供します。
{
    [SerializeField] private GameObject avatarSelectUI;
    [SerializeField] private GameObject[] avatarList = new GameObject[3];
    // Start is called before the first frame update
    void Start()
    {
        //UnityエディタのPhotonServerSettingsで設定したAppIDを使用してネットワークに接続する
        PhotonNetwork.ConnectUsingSettings();
        
        avatarSelectUI.SetActive(false);
    }

    // OnConnectedToMasterはクライアントがMaster Serverに接続されていて、マッチメイキングやその他のタスクを行う準備が整ったときに呼び出されます。
    public override void OnConnectedToMaster()
    {
        //JoinOrCreateRoomメソッドでは第一引数で指定した名前のルームが存在すればその部屋に入室し、無ければそのルームを作成します。
        PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions(), TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        //Vector3 pos = new Vector3(Random.Range(-3, 3), 0, Random.Range(-3, 3));
        //PhotonNetwork.Instantiateメソッドを用いることでPhoton経由でGameObjectを生成する。
        //第一引数には"オブジェクトの名前（string）"を指定し、Resourcesフォルダ内にある名前が一致するオブジェクトを生成する。
        //PhotonNetwork.Instantiate(avatar.name, pos, Quaternion.identity);

        avatarSelectUI.SetActive(true);
    }

    public void AvatarSelect(int num)
    {
        Vector3 pos = new Vector3(Random.Range(-3, 3), 0, Random.Range(-3, 3));
        //PhotonNetwork.Instantiateメソッドを用いることでPhoton経由でGameObjectを生成する。
        //第一引数には"オブジェクトの名前（string）"を指定し、Resourcesフォルダ内にある名前が一致するオブジェクトを生成する。
        PhotonNetwork.Instantiate(avatarList[num].name, pos, Quaternion.identity);

        avatarSelectUI.SetActive(false);
    }
}
