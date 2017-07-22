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
        photonView.RPC("AssignVoiceToCharacter", PhotonTargets.All, index);
        
    }

    [PunRPC]
    void AssignVoiceToCharacter(int index)
    {
        Debug.Log("PLACING AT " + index);
        characters[index].AttachCharacter(playerVoice);
    }


    public void GiveItemWithIndex(int index)
    {
        photonView.RPC("ActivateItemWithIndex", PhotonTargets.All, index, true);
    }

    public void RetireAllItems()
    {
        photonView.RPC("RetireItems", PhotonTargets.All);
    }

    [PunRPC]
    void RetireItems()
    {
        for(int i = 0; i < masks.Length; i++)
        {
            ActivateItemWithIndex(i, false);
        }
    }


    [PunRPC]
    void ActivateItemWithIndex(int index, bool activate)
    {
        Debug.Log("ACTIVATING ITEM AT " + index);

        if(masks.Length > index)
        {
            masks[index].GetComponent<MeshRenderer>().enabled = !activate;
            masks[index].GetComponent<Collider>().enabled = activate;
        }
    }
    
}
