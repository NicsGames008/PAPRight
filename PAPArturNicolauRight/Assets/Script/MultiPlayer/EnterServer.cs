using TMPro;
using UnityEngine;

public class EnterServer : MonoBehaviour
{
    // Referência ao componente de texto que mostra o personagem selecionado
    [SerializeField]
    TMP_Text charcterSelected;

    // Objeto estático da classe ClassCharacter para armazenar as informações do personagem selecionado
    public static ClassCharacter character = new ClassCharacter();

    // Método chamado ao selecionar um personagem
    public void SelectedCharacter()
    {
        // Percorre a lista de personagens na classe ClassUser
        foreach (ClassCharacter chare in ClassUser.CharactersList)
        {
            // Verifica se o nome do personagem atual é igual ao texto do personagem selecionado
            if (chare.nameCharacter == charcterSelected.text)
            {
                // Armazena as informações do personagem atual no objeto estático "character"
                character = chare;
            }
        }
    }

}
