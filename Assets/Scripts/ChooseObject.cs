using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseObject : MonoBehaviour
{
    private ProgrammManeger ProgrammManegerScripts;
    private Button button;
    public GameObject ChoosedObject;
  
    void Start()
    {
        ProgrammManegerScripts = FindObjectOfType<ProgrammManeger>();
        button = GetComponent<Button>();
        button.onClick.AddListener(ChooseObjecFun);
    }

    void ChooseObjecFun()
    {
        ProgrammManegerScripts.ObjectToSpawn = ChoosedObject;
        ProgrammManegerScripts.ChooseObject = true;
        ProgrammManegerScripts.ScrollViev.SetActive(false);
    }
}
