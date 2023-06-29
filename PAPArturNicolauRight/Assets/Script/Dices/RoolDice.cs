using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RoolDice : MonoBehaviour
{
    [SerializeField]
    private TMP_Text dice;

    private int sides;

    public void OnMouseDown(int numSides)
    {
        sides = numSides;
        StartCoroutine("RollTheDice");
    }

    private IEnumerator RollTheDice()
    {
        int randomDiceSide = 0;

        int finalSide = 0;

        for (int i = 0; i <= 20; i++)
        {
            randomDiceSide = Random.Range(1, sides);

            dice.text = randomDiceSide.ToString();

            // Pause before next itteration
            yield return new WaitForSeconds(0.05f);
        }

        finalSide = randomDiceSide + 1;

        dice.text = finalSide.ToString();
    }
}
