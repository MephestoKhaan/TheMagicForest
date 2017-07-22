using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectEnabler : Photon.PunBehaviour {


    public bool forcePlayer = true;
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
#if UNITY_STANDALONE_WIN
        if(forcePlayer)
            photonView.TransferOwnership(PhotonNetwork.player);
#elif UNITY_ANDROID
        if(!forcePlayer)
            photonView.TransferOwnership(PhotonNetwork.player);
#endif
    }


}
