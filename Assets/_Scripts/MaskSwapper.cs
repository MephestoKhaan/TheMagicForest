using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskSwapper : Photon.PunBehaviour
{
    public GameObject[] faces;
    
    public void ChangeFace(int faceIndex)
    {
        photonView.RPC("ChangeFaceNetwork", PhotonTargets.AllBuffered ,faceIndex);
    }

    [PunRPC]
    void ChangeFaceNetwork(int faceIndex)
    {

        if (faces != null)
        {
            for (int i = 0; i < faces.Length; i++)
            {
                faces[i].SetActive(i == faceIndex);
            }
        }
    }
    
}
