using Cinemachine;
using Unity.Netcode;
using UnityEngine;

public class InventoryUI : NetworkBehaviour
{
    public Transform itemsParent;

    //Associa ao Inventario
    Inventory inventory;

    public GameObject inventoryUI;
    [SerializeField] private CinemachineFreeLook vc;
    private CinemachineFreeLook vcTemp;


    [SerializeField] private GameObject player;

    //Guarda todos os slots no Vertice
    InventorySlot[] slots;

    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;

        //Quando o iventario muda muda o ui junto
        inventory.onItemChangecallback += UpdateUI;

        vcTemp = vc;

        //Pega em todos os slots do iventario e guarda no array
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsOwner) return;

        //Quando o utilizador carregar na tecla responsavel por abrir o iventario...
        if (Input.GetButtonDown("Inventory"))
        {
            //Ve se o rato esta preso no meu do ecra
            if (Cursor.lockState == CursorLockMode.None)
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
            else if (Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;
            }

            //Torna o rato invisivel ou visivel, depende de como estava antes
            Cursor.visible = !Cursor.visible;

            if (vc == null)
            {
                vc = vcTemp;
            }
            else
            {
                vc = null;
            }
                //vc.enabled = !vc.enabled;

            //Mostra o canvas do msm
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
    }

    void UpdateUI()
    {
        //passa por todos os slots
        for (int i = 0; i < slots.Length; i++)
        {
            //Se tiver algo adiciona o item ao slot
            if (i < inventory.items.Count)
            {
                //Adiciona o item ao slot
                slots[i].AddItem(inventory.items[i]);
            }
            //Ses�o apaga o item do slot
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
