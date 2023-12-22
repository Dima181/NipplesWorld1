using UnityEngine;

public class CharacterInputController
{
    public int InputButtonCheckGun()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            return 1;
        if (Input.GetKeyDown(KeyCode.Alpha2))
            return 2;
        else return 0;
    }

    public int InputButtonCheckMelee()
    {
        if(Input.GetMouseButtonDown(0))
            return 1;
        if (Input.GetMouseButtonDown(1))
            return 2; 
        else return 0;
    }
}
