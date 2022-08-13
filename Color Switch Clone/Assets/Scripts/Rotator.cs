using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Rotator : MonoBehaviour
{
    float rotationSpeed = 50f;

    private void Update()
    {
        transform.Rotate(0f, 0f, rotationSpeed * Time.fixedDeltaTime);
    }
}
