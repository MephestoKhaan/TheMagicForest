using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorController : Photon.PunBehaviour
{
    public CharacterVoicer[] characters;
    public GameObject[] masks;

    public GameObject playerVoice;

    public void PlaceVoiceAtCharacter(int index)
    {
        if(!PhotonNetwork.isMasterClient)
        {
            return;
        }
        photonView.RPC("AssignVoiceToCharacter", PhotonTargets.All, index);
        
    }

    [PunRPC]
    void AssignVoiceToCharacter(int index)
    {
        characters[index].AttachCharacter(playerVoice);
    }


    public void GiveItemWithIndex(int index)
    {

    }
}
