using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upgradeSelection : MonoBehaviour
{
    public Animator oneAnim;
    public Animator twoAnim;
    public Animator threeAnim;


    public bool[] isActives = { true, false, false };
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && !isActives[0])
        {
            for (int i = 0; i < isActives.Length; i++)
            {
                switch (i)
                {
                    case 0:
                        isActives[i] = true;
                        break;

                    default:
                        isActives[i] = false;
                        break;
                }
            }

        }

        else if (Input.GetKeyDown(KeyCode.Alpha2) && !isActives[1])
        {
            for (int i = 0; i < isActives.Length; i++)
            {
                switch (i)
                {
                    case 1:
                        isActives[i] = true;
                        break;

                    default:
                        isActives[i] = false;
                        break;
                }
            }

        }

        else if (Input.GetKeyDown(KeyCode.Alpha3) && !isActives[2])
        {
            for (int i = 0; i < isActives.Length; i++)
            {
                switch (i)
                {
                    case 2:
                        isActives[i] = true;
                        break;

                    default:
                        isActives[i] = false;
                        break;
                }
            }

        }

        oneAnim.SetBool("isActive", isActives[0]);
        twoAnim.SetBool("isActive", isActives[1]);
        threeAnim.SetBool("isActive", isActives[2]);
   
    }

}