using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Netcode;
using UnityEngine;

public class OpenPauseMenu : NetworkBehaviour
{

    public GameObject pauseMenu;

    [SerializeField] private CinemachineFreeLook vc;
    [SerializeField] private FreeFlyCamera cam;

    private void FixedUpdate()
    {
        if (!IsOwner) return;

        if (Input.GetKeyDown(KeyCode.Escape))
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
            if (Cursor.visible)
            {
                Cursor.visible = false;
            }
            else
            {
                Cursor.visible = true;
            }

            if (IsClient)
                vc.enabled = !vc.enabled;

            if (IsHost)
                cam.enabled = !cam.enabled;

            vc.m_YAxis.m_InputAxisValue = 0;
            vc.m_XAxis.m_InputAxisValue = 0;

            pauseMenu.SetActive(!pauseMenu.activeSelf);
        }
    }
}
