using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
        public Color[] circleColors;

    void Start()
    {
        int index = UnityEngine.Random.Range(0, 4);
        GetComponent<SpriteRenderer>().color = circleColors[index];
    }
}
