using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerNetworkManeger : NetworkBehaviour
{

    [SerializeField] private GameObject vc;
    [SerializeField] private AudioListener listener;
    [SerializeField] private GameObject adminInvetory;
    [SerializeField] private GameObject playerInvetory;
    [SerializeField] private GameObject defaultModel, mageModel, goblinModel, humanModel, knightModel;

    [SerializeField] private TMP_Text nameCharacter, raceCharacter, discCharacter, hpCharacter, strCharacter, dexCharacter, constCharacter, intCharacter, manaCharacter;

    private void Start()
    {
        if (!IsOwner)
            return;

        //if (IsClient)
        //    NetworkManager.Singleton.OnClientDisconnectCallback += NetworkManeger_OnClientDisconnectCallback;
    }

    //private void NetworkManeger_OnClientDisconnectCallback(ulong clientID)
    //{
    //    if (!IsOwner)
    //        return;

    //    if (IsClient)
    //    {
    //        SceneManager.LoadScene(0);

    //        Debug.Log("aaaaaaaaaaaaaaaaaa");

    //    }
    //}



    //public void LoadMainPageNonError()
    //{
    //    if (!IsOwner)
    //        return;


    //    NetworkManager.Singleton.Shutdown();
    //    SceneManager.LoadScene(0);


    //}

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
            defaultModel.SetActive(true);

            return;
        }

        if (IsHost)
        {
            var cam = GetComponent<Camera>();
            var script = GetComponent<FreeFlyCamera>();

            cam.enabled = true;
            script.enabled = true;
            adminInvetory.SetActive(true);
            defaultModel.SetActive(true);

        }
        else if (IsClient)
        {
            var thirdPerson = GetComponent<ThirdpersonMovement>();

            thirdPerson.enabled = true;

            gameObject.layer = 3;
            playerInvetory.SetActive(true);

            nameCharacter.text = EnterServer.character.nameCharacter;
            discCharacter.text = EnterServer.character.backgroundCharacter;
            hpCharacter.text = EnterServer.character.healthCharacter.ToString();
            strCharacter.text = EnterServer.character.strCharacter.ToString();
            dexCharacter.text = EnterServer.character.dexCharacter.ToString();
            constCharacter.text = EnterServer.character.constCharacter.ToString(); ;
            intCharacter.text = EnterServer.character.intCharacter.ToString();
            manaCharacter.text = EnterServer.character.manaCharacter.ToString();

            switch (EnterServer.character.raceCharcter)
            {
                case "M":
                    defaultModel.SetActive(false);
                    mageModel.SetActive(true);
                    goblinModel.SetActive(false);
                    humanModel.SetActive(false);
                    knightModel.SetActive(false);
                    raceCharacter.text = "Mago";
                    break;
                case "G":
                    defaultModel.SetActive(false);
                    mageModel.SetActive(false);
                    goblinModel.SetActive(true);
                    humanModel.SetActive(false);
                    knightModel.SetActive(false);
                    raceCharacter.text = "Goblin";
                    break;
                case "H":
                    defaultModel.SetActive(false);
                    mageModel.SetActive(false);
                    goblinModel.SetActive(false);
                    humanModel.SetActive(true);
                    knightModel.SetActive(false);
                    raceCharacter.text = "Humano";
                    break;
                case "k":
                    defaultModel.SetActive(false);
                    mageModel.SetActive(false);
                    goblinModel.SetActive(false);
                    humanModel.SetActive(false);
                    knightModel.SetActive(true);
                    raceCharacter.text = "Cavaleiro";
                    break;

                default:
                    defaultModel.SetActive(true);
                    mageModel.SetActive(false);
                    humanModel.SetActive(false);
                    knightModel.SetActive(false);
                    goblinModel.SetActive(false);
                    break;
            }
        }
    }
}
