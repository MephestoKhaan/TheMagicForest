using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CharacterVoicer : MonoBehaviour
{
    public int AudioMixerGroupIndex;

    public void AttachCharacter(GameObject character)
    {
        character.GetComponent<VoiceChanger>().ChangeMixer(AudioMixerGroupIndex);
        character.transform.position = this.transform.position;
    }
}
