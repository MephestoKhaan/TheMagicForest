﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : Photon.PunBehaviour
{
    void Update()
    {
        if (photonView.isMine)
        {
            this.transform.position = Camera.main.transform.position;
            this.transform.rotation = Camera.main.transform.rotation;
        }
    }
}
