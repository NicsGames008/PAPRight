using TMPro;
using UnityEngine;

public class EnterServer : MonoBehaviour
{
    // Refer�ncia ao componente de texto que mostra o personagem selecionado
    [SerializeField]
    TMP_Text charcterSelected;

    // Objeto est�tico da classe ClassCharacter para armazenar as informa��es do personagem selecionado
    public static ClassCharacter character = new ClassCharacter();

    // M�todo chamado ao selecionar um personagem
    public void SelectedCharacter()
    {
        // Percorre a lista de personagens na classe ClassUser
        foreach (ClassCharacter chare in ClassUser.CharactersList)
        {
            // Verifica se o nome do personagem atual � igual ao texto do personagem selecionado
            if (chare.nameCharacter == charcterSelected.text)
            {
                // Armazena as informa��es do personagem atual no objeto est�tico "character"
                character = chare;
            }
        }
    }

}
