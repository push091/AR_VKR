using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddObject : MonoBehaviour
{

    private Button button;
    private ProgrammManeger ProgrammManegerScript;

    // Start is called before the first frame update
    void Start()
    {
        ProgrammManegerScript = FindObjectOfType<ProgrammManeger>();
        button = GetComponent<Button>();
        button.onClick.AddListener(AddObjectfun);
        
    }

    // Update is called once per frame
    void AddObjectfun()
    {
        
        
        
           
        if (ProgrammManegerScript.ScrollViev.activeSelf == false)
        {
            ProgrammManegerScript.ScrollViev.SetActive(true);
        }
        else
        {
            ProgrammManegerScript.ScrollViev.SetActive(false);
        }
    }
}
