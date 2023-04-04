using System.Linq;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RadionButtonSystem : MonoBehaviour
{
    //Recebe o valor do radiobutton
    ToggleGroup toggleGroup;
    public GameObject magic;

    [HideInInspector]
    public int isMagic = 0;

    // Start is called before the first frame update
    void Start()
    {
        //busca o grupo
        toggleGroup = GetComponent<ToggleGroup>();
    }

    //Sabe se o radiobutton foi selecionado e informa de tal
    void LateUpdate()
    {
        Toggle toggle = toggleGroup.ActiveToggles().FirstOrDefault();

        if (toggle.name == "isNotMagic")
        {
            isMagic = 0;
            magic.SetActive(false);
        }
        else if (toggle.name == "isMagic")
        {
            isMagic = 1;
            magic.SetActive(true);
        }
    }
}
