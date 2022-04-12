using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fraglog : MonoBehaviour
{
    public static int[] FLog = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    private int checkers;
    public GameObject FragUI;
    public GameObject Alpha;
    public GameObject Bravo;
    public GameObject Charlie;
    public GameObject Delta;
    public GameObject Echo;
    public GameObject Foxtrot;
    public GameObject Gamma;
    public GameObject Hotel;
    public GameObject India;
    public GameObject Juliet;
    public GameObject Kilo;
    public GameObject Lima;
    static private bool check1 = false;
    static private bool check2 = false;
    static private bool check3 = false;
    static private bool check4 = false;
    static private bool check5 = false;
    static private bool check6 = false;
    static private bool check7 = false;
    static private bool check8 = false;
    static private bool check9  = false;
    static private bool check10 = false;
    static private bool check11 = false;
    static private bool check12 = false;


    void Start()
    {

    }

    void Update()
    {
        
        Alpha.SetActive(check1);
        Bravo.SetActive(check2);
        Charlie.SetActive(check3);
        Delta.SetActive(check4);
        Echo.SetActive(check5);
        Foxtrot.SetActive(check6);
        Gamma.SetActive(check7);
        Hotel.SetActive(check8);
        India.SetActive(check9);
        Juliet.SetActive(check10);
        Kilo.SetActive(check11);
        Lima.SetActive(check12);
    }

    public int CheckFrag( int _frag )
    {
        checkers = FLog[_frag];
        return checkers;
    }

    public void setCheck(int checkIndex, bool newVal)
    {

        if (checkIndex == 0)
        {
            check1 = newVal;
        }
        else if (checkIndex == 1)
        {
             check2 = newVal; 
        }
        else if (checkIndex == 2)
        {
             check3 = newVal; 
        }
        else if (checkIndex == 3)
        {
             check4 = newVal; 
        }
        else if (checkIndex == 4)
        {
             check5 = newVal; 
        }
        else if (checkIndex == 5)
        {
             check6 = newVal; 
        }
        else if (checkIndex == 6)
        {
             check7 = newVal; 
        }
        else if (checkIndex == 7)
        {
             check8 = newVal; 
        }
        else if (checkIndex == 8)
        {
             check9 = newVal; 
        }
        else if (checkIndex == 9)
        {
             check10 = newVal; 
        }
        else if (checkIndex == 10)
        {
             check11 = newVal; 
        }
        else
        {
             check12 = newVal; 
        }
    }

    public bool getCheck(int checkIndex)
    {
       
        if (checkIndex == 0)
        {
            return check1;
        }
        else if (checkIndex == 1)
        {
            return check2;
        }
        else if (checkIndex == 2)
        {
            return check3;
        }
        else if (checkIndex == 3)
        {
            return check4;
        }
        else if (checkIndex == 4)
        {
            return check5;
        }
        else if (checkIndex == 5)
        {
            return check6;
        }
        else if (checkIndex == 6)
        {
            return check7;
        }
        else if (checkIndex == 7)
        {
            return check8;
        }
        else if (checkIndex == 8)
        {
            return check9;
        }
        else if (checkIndex == 9)
        {
            return check10;
        }
        else if(checkIndex == 10)
        {
            return check11;
        }
        else
        {
            return check12;
        }
    }

    public void UpdateFrag(int _frick)
    {
        FLog[_frick] = 1;
        if(_frick == 0)
        {
            check1 = true;
        }
        else if(_frick == 1)
        {
            check2 = true;
        }
        else if (_frick == 2)
        {
            check3 = true;
        }
        else if (_frick == 3)
        {
            check4 = true;
        }
        else if (_frick == 4)
        {
            check5 = true;
        }
        else if (_frick == 5)
        {
            check6 = true;
        }
        else if (_frick == 6)
        {
            check7 = true;
        }
        else if (_frick == 7)
        {
            check8 = true;
        }
        else if (_frick == 8)
        {
            check9 = true;
        }
        else if (_frick == 9)
        {
            check10 = true;
        }
        else if (_frick == 10)
        {
            check11 = true;
        }
        else
        {
            check12 = true;
        }

    }

    //Debug.log()
}
