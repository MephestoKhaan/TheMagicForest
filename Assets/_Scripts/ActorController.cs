using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorController : Photon.PunBehaviour
{
    public CharacterVoicer[] characters;
    public GameObject[] masks;


    public GameObject playerVoice;

    private void OnEnable()
    {
        ActorSpawner.CharacterInstantiated += CharacterInstantiation_CharacterInstantiated;
    }

    private void OnDisable()
    {
        ActorSpawner.CharacterInstantiated -= CharacterInstantiation_CharacterInstantiated;
    }


    private void CharacterInstantiation_CharacterInstantiated(GameObject character)
    {
        playerVoice = character;
        PhotonVoiceRecorder rec = character.GetComponent<PhotonVoiceRecorder>();
        rec.enabled = true;
    }


    public void PlaceVoiceAtCharacter(int index)
    {
        if (playerVoice != null)
        {
            playerVoice.GetComponent<PhotonVoiceRecorder>().Detect = true;
            characters[index].AttachCharacter(playerVoice);
        }

    }
    
    public void Mute()
    {
        if (playerVoice != null)
        {
            playerVoice.GetComponent<PhotonVoiceRecorder>().Detect = false;
        }
    }
    

    public void GiveItemWithIndex(int index)
    {
        photonView.RPC("ActivateItemWithIndex", PhotonTargets.All, index, true);
    }

    public void RetireAllItems()
    {
        for (int i = 0; i < 3; i++)
        {
            photonView.RPC("ActivateItemWithIndex", PhotonTargets.All, i, false);
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
