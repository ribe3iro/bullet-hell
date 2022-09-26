using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scroller : MonoBehaviour
{
    [SerializeField] private MeshRenderer _mr;
    [SerializeField] private float _speed;

    // Update is called once per frame
    void Update()
    {   
        _mr.material.mainTextureOffset += new Vector2(0, _speed* Time.deltaTime);
    }
}
