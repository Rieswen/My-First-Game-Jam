using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckLetter : MonoBehaviour
{
    public GameObject Human;
    public GameObject sinsAndShit;
    private Animator anim;
    public GameObject button;
    private Animator letterAnim;
    public GameObject checkSins;
    public Text Sin;
    public ChooseDevil chooseDevil;
    public ChooseSide chooseSide;
    public bool isClicked = false;
    public int GoodOrBad;
    public bool canGivePoint = false;
    public int scorePoint;
    public Text scorePointText;

    private void Start()
    {
        Human = GameObject.Find("Human");
        sinsAndShit = GameObject.Find("SinsAndShit");
        anim = Human.GetComponent<Animator>();
        letterAnim = sinsAndShit.GetComponent<Animator>();
    }
    public void Update()
    {
        if (isClicked == false)
        {
            GoodOrBad = 0;
            sinsAndShit.GetComponent<Animator>().SetBool("isReading", false);
        }
        else if(isClicked == true)
        {
            canGivePoint = true;
            sinsAndShit.GetComponent<Animator>().SetBool("isReading", true);
        }

        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1) //Animation is done
        {
            checkSins.SetActive(true);
            chooseDevil.enabled = true;
            chooseSide.enabled = true;
        }
        else
        {
            canGivePoint = false;
            checkSins.SetActive(false);
            chooseDevil.enabled = false;
            chooseSide.enabled = false;
            checkingThoseSins();
        }

        switch (Sin.text)
        {
            case "Good":
                GoodOrBad++;
                break;
            case "Mid Good":
                print("no value changed");
                break;
            case "Bad":
                GoodOrBad--;
                break;
        }

        scorePointText.text = scorePoint.ToString();
    }
    public void checkingThoseSins()
    {
        string[] Sins = new string[] { "Good", "Mid Good", "Bad" };
        string currentText = Sins[Random.Range(0, Sins.Length)];
        Sin.text = currentText;
    }

    public void isClickedTrueOrNot()
    {
        if (isClicked == true)
        {
            isClicked = false;
            letterAnim.Play("CheckSinsBack");
        }
        else
        {
            isClicked = true;
            letterAnim.Play("CheckSins");
        }
    }
}
