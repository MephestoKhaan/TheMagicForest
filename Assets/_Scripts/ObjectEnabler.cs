using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectEnabler : Photon.PunBehaviour {
    
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
#if UNITY_STANDALONE
        photonView.TransferOwnership(PhotonNetwork.player);
#endif
    }


}
