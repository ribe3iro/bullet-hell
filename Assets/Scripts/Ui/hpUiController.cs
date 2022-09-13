using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hpUiController : MonoBehaviour
{
    
    public float hpDistance;
    public GameObject hpPrefab;

    // Start is called before the first frame update
    void Start()
    {
        player playerSc = FindObjectOfType<player>();

        for (int i = 0; i < playerSc.maxHp; i++){
            GameObject hpObj = Instantiate(hpPrefab);
            hpObj.GetComponent<hpUi>().thisHeartNum = i+1;
            hpObj.transform.position = new Vector3(hpDistance * i + transform.position.x, transform.position.y, 0);
            hpObj.transform.parent = this.gameObject.transform;
        }
    }

}
