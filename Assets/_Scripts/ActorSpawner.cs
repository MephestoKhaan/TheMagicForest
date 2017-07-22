using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorSpawner : OnJoinedInstantiate
{
    public delegate void OnCharacterInstantiated(GameObject character);

    public static event OnCharacterInstantiated CharacterInstantiated;

    public new void OnJoinedRoom()
    {
        if(PhotonNetwork.isMasterClient)
        {
            return;
        }

        if (this.PrefabsToInstantiate != null)
        {
            GameObject o = PrefabsToInstantiate[0];
            
            o = PhotonNetwork.Instantiate(o.name, Vector3.zero, Quaternion.identity, 0);
            if (CharacterInstantiated != null)
            {
                CharacterInstantiated(o);
            }
        }
    }
}
    