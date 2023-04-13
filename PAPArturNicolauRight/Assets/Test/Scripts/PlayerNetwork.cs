using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerNetwork : NetworkBehaviour
{
    private NetworkVariable<int> randomNumber = new NetworkVariable<int>(1, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Owner);


    public override void OnNetworkSpawn()
    {
        randomNumber.OnValueChanged += (int preciousValue, int newvalue) =>
        {
            Debug.Log(OwnerClientId + "; randomnumber: " + randomNumber.Value);

        };
    }

    // Update is called once per frame
    void Update()
    {

        if (!IsOwner) return;

        if (Input.GetKey(KeyCode.T))
        {
            randomNumber.Value = Random.Range(0, 100);
        }

        Vector3 moveDir = new Vector3(0, 0, 0);

        if (Input.GetKey(KeyCode.W)) moveDir.z = +1;
        if (Input.GetKey(KeyCode.S)) moveDir.z = -1;
        if (Input.GetKey(KeyCode.A)) moveDir.x = -1;
        if (Input.GetKey(KeyCode.D)) moveDir.x = +1;

        float moveSpeed = 3f;

        transform.position += moveDir * moveSpeed * Time.deltaTime;
    }      
}
