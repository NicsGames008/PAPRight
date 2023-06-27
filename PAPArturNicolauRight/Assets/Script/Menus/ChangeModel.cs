using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChangeModel : MonoBehaviour
{
    [SerializeField]
    private TMP_Dropdown dropdown;

    public GameObject Default;
    public GameObject Mage;
    public GameObject Goblin;
    public GameObject Human;
    public GameObject Knight;

    // Update is called once per frame
    void Update()
    {
        switch (dropdown.value)
        {
            case 0:
                if (!Default.active)
                {
                    Default.SetActive(true);
                    Mage.SetActive(false);
                    Goblin.SetActive(false);
                    Human.SetActive(false);
                    Knight.SetActive(false);
                }
                break;
            case 1:
                if (!Mage.active)
                {
                    Default.SetActive(false);
                    Mage.SetActive(true);
                    Goblin.SetActive(false);
                    Human.SetActive(false);
                    Knight.SetActive(false);
                }
                break;
            case 2:
                if (!Goblin.active)
                {
                    Default.SetActive(false);
                    Mage.SetActive(false);
                    Goblin.SetActive(true);
                    Human.SetActive(false);
                    Knight.SetActive(false);
                }
                break;
            case 3:
                if (!Human.active)
                {
                    Default.SetActive(false);
                    Mage.SetActive(false);
                    Goblin.SetActive(false);
                    Human.SetActive(true);
                    Knight.SetActive(false);
                }
                break;
            case 4:
                if (!Knight.active)
                {
                    Default.SetActive(false);
                    Mage.SetActive(false);
                    Goblin.SetActive(false);
                    Human.SetActive(false);
                    Knight.SetActive(true);
                }
                break;
        }
    }
}
