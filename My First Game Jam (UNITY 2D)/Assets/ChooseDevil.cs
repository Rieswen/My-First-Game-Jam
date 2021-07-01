using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseDevil : MonoBehaviour
{
    public GameObject Human;
    private Animator anim;
    public GameObject Button;
    private SpriteRenderer spriteRenderer;
    public Sprite outline;
    public Sprite defaultSprite;
    public bool isClicked = false;
    public bool isYeeted = false;
    public CheckLetter checkLetter;
    public ChangeCharacter changeCharacter;

    private void Start()
    {
        anim = Human.GetComponent<Animator>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();
    }
    public void Update()
    {
        Human = GameObject.FindGameObjectWithTag("Human");
        anim = Human.GetComponent<Animator>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();

        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
        {
            print("finished");
            Button.SetActive(true);
        }
        else
        {
            Button.SetActive(false);
        }

        if (isClicked == true)
        {
            if (checkLetter.canGivePoint == true)
            {
                StartCoroutine(gotClicked());
            }
        }

        if (isYeeted == true)
        {
            Human.transform.position = new Vector3(-0.13f, 0.9524008f, 0);
            anim.Play("Walk");
        }
    }

    public IEnumerator gotClicked()
    {
        if (checkLetter.canGivePoint == true)
        {
            print("bruh");
            anim.Play("YEETHell");
            yield return new WaitForSeconds(1);
            changeCharacter.changingCharacter();
            isYeeted = true;
            isClicked = false;
            yield return new WaitForSeconds(0.1f);
            isYeeted = false;
        }

    }

    private void OnMouseEnter()
    {
        spriteRenderer.sprite = outline;
    }

    private void OnMouseExit()
    {
        spriteRenderer.sprite = defaultSprite;
    }

    public void OnMouseUp()
    {
        isClicked = false;
    }
    void OnMouseDown()
    {
        isClicked = true;
        if (checkLetter.canGivePoint == true)
        {
            if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
            {
                if (checkLetter.GoodOrBad >= 0)
                {
                    checkLetter.GoodOrBad = 0;
                    print("wtf he was good guy you can't send him here");
                    checkLetter.scorePoint = checkLetter.scorePoint - 1;
                }
                else
                {
                    checkLetter.GoodOrBad = 0;
                    print("good choice");
                    checkLetter.scorePoint = checkLetter.scorePoint + 1;
                }
            }
        }
    }
}
