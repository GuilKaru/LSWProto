using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//GameAssets to have a mini database of all the items
public class GameAssets : MonoBehaviour
{
    private static GameAssets _i;

    public static GameAssets i
    {
        get
        {
            if (_i == null) _i = Instantiate(Resources.Load<GameAssets>("GameAssets"));
            return _i;
        }
    }

    public Sprite s_Outfit1;
    public Sprite s_Outfit2;
    public Sprite s_Outfit3;
    public Sprite s_Outfit4;
    public Sprite s_Outfit5;

}
