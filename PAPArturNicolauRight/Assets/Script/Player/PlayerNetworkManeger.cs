using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerNetworkManeger : NetworkBehaviour
{

    [SerializeField] private GameObject vc;
    [SerializeField] private AudioListener listener;
    [SerializeField] private GameObject model;
    [SerializeField] private GameObject adminInvetory;
    [SerializeField] private GameObject playerInvetory;


    public override void OnNetworkSpawn()
    {
        if (IsOwner)
        {
            vc.SetActive(true);
            listener.enabled = true;
        }
        else
        {
            vc.SetActive(false);

            return;
        }

        if (IsHost)
        {
            var cam = GetComponent<Camera>();
            var script = GetComponent<FreeFlyCamera>();

            cam.enabled = true;
            script.enabled = true;
            adminInvetory.SetActive(true);

        }
        else if(IsClient)
        {
            var thirdPerson = GetComponent<ThirdpersonMovement>();

            thirdPerson.enabled = true;

            gameObject.layer = 3;
            playerInvetory.SetActive(true);
        }
    }
}
