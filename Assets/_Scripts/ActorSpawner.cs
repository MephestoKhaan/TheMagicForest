using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorSpawner : OnJoinedInstantiate
{
    public delegate void ActorSpawnerInstantiated(GameObject character);

    public static event ActorSpawnerInstantiated CharacterInstantiated;

    public new void OnJoinedRoom()
    {
            GameObject o = PrefabsToInstantiate[0];
            
            o = PhotonNetwork.Instantiate(o.name, Vector3.zero, Quaternion.identity, 0);
            if (CharacterInstantiated != null)
            {
                CharacterInstantiated(o);
            }
    }
}
    