using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseSide : MonoBehaviour
{
    public GameObject Human;
    private Animator anim;
    public GameObject Button;
    public AudioSource plusPoint;
    public AudioSource minusPoint;
    private SpriteRenderer spriteRenderer;
    public Sprite outline;
    public Sprite angel;
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
            anim.Play("YEETHeaven");
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
        this.GetComponent<Animator>().SetBool("isHovering", true);
    }

    private void OnMouseExit()
    {
        spriteRenderer.sprite = defaultSprite;
        this.GetComponent<Animator>().SetBool("isHovering", false);
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
            
            Human.GetComponent<SpriteRenderer>().sprite = angel;

            if (checkLetter.GoodOrBad >= 0)
            {
                plusPoint.Play();
                checkLetter.GoodOrBad = 0;
                print("Welcome to heaven my child");
                checkLetter.scorePoint = checkLetter.scorePoint + 1;
            }
            else
            {
                minusPoint.Play();
                checkLetter.GoodOrBad = 0;
                print("HE WAS A BAD GUY");
                checkLetter.scorePoint = checkLetter.scorePoint - 1;
            }
        } else
        {
            print("false");
        }
    }
}
