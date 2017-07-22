using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VoiceChanger : Photon.PunBehaviour
{
    
    public void ChangeMixer(int index)
    {
        photonView.RPC("ChangeMixerNetwork", PhotonTargets.AllBuffered, index);
    }

    [PunRPC]
    void ChangeMixerNetwork(int index)
    {
        this.GetComponent<AudioSource>().outputAudioMixerGroup = VoicesHolder.Instance.groups[index];
    }
}
