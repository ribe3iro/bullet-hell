using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hpUi : MonoBehaviour
{
    [HideInInspector] public int thisHeartNum;
    player playerSc;
    private Image im = null;
    void Start()
    {
        im = GetComponent<Image>();
        playerSc = FindObjectOfType<player>();
    }

    void Update()
    {
        if (thisHeartNum > playerSc.heartNum && im.enabled)
        {
            im.enabled = false;
        }
    }
}
