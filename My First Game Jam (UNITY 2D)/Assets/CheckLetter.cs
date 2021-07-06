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
    public Text[] Sin;
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

        switch (Sin[0].text)
        {
            case "Has been good.":
                GoodOrBad++;
                break;
            case "Has been bad.":
                GoodOrBad--;
                break;
        }

        switch (Sin[1].text)
        {
            case "Has been good.":
                GoodOrBad++;
                break;
            case "Has been bad.":
                GoodOrBad--;
                break;
        }

        switch (Sin[2].text)
        {
            case "Has been good.":
                GoodOrBad++;
                break;
            case "Has been bad.":
                GoodOrBad--;
                break;
        }

        scorePointText.text = scorePoint.ToString();
    }
    public void checkingThoseSins()
    {
        string[] Sins = new string[] { "Has been good.", "Has been bad." };
        string currentText = Sins[Random.Range(0, Sins.Length)];

        string[] Sins1 = new string[] { "Has been good.", "Has been bad." };
        string currentText1 = Sins[Random.Range(0, Sins.Length)];

        string[] Sins2 = new string[] { "Has been good.", "Has been bad." };
        string currentText2 = Sins[Random.Range(0, Sins.Length)];

        Sin[0].text = currentText;
        Sin[1].text = currentText1;
        Sin[2].text = currentText2;

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
