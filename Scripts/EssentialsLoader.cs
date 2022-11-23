using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EssentialsLoader : MonoBehaviour
{

    public GameObject UIScreen;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        if(UIScript.instance ==null)
        {
            Instantiate(UIScreen);
        }
         if(PlayerController.instance ==null)
        {
            PlayerController clone = Instantiate(Player).GetComponent<PlayerController>();
            PlayerController.instance = clone;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
