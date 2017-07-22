using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CharacterVoicer : MonoBehaviour
{
    public AudioMixerGroup mixerGroup;

    public void AttachCharacter(GameObject character)
    {
        character.GetComponent<AudioSource>().outputAudioMixerGroup = mixerGroup;
        character.transform.position = this.transform.position;
    }
}
