using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_HP : MonoBehaviour {

    public Image UIobj;
    public bool roop;
    public float countTime = 5.0f;
    public GameObject over;
    public GameObject Player;

    private void Start()
    {
        UIobj.fillAmount -= 1.0f / 360*45;
     
    }
    // Update is called once per frame
    void Update()
    {
        if (roop)
        {
            UIobj.fillAmount -= 1.0f / countTime * Time.deltaTime;
  
            if(UIobj.fillAmount <= 0.1f)
            {
                Destroy(UIobj);
                Player.SetActive(false);
                over.SetActive(true);
                roop = false;
            }
        }
    }
}

