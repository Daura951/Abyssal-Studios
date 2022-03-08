using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fraglog : MonoBehaviour
{
    public static int[] FLog = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    private int checkers;
    
    

    public int CheckFrag( int _frag )
    {
        checkers = FLog[_frag];
        return checkers;
    }

    public void UpdateFrag(int _frick)
    {
        FLog[_frick] = 1;
    }

    //Debug.log()
}
