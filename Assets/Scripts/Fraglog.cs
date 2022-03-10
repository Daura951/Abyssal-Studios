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
