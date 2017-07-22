using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VoicesHolder : MonoBehaviour {

    public static VoicesHolder Instance { get; private set; }

    private void Awake()
    {
        Instance = this; 
    }

    public AudioMixerGroup[] groups;
}
