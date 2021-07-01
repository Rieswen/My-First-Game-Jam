using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCharacter : MonoBehaviour
{
    public Sprite[] characters;
    public ChooseDevil chooseDevil;
    public ChooseSide chooseSide;

    // Update is called once per frame
    public void changingCharacter()
    {
        {
            int num = UnityEngine.Random.Range(0, characters.Length);
            this.GetComponent<SpriteRenderer>().sprite = characters[num];
        }
    }
}
