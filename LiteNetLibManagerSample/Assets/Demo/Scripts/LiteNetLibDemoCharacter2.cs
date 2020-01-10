using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiteNetLibDemoCharacter2 : LiteNetLibDemoCharacter
{
    // Testing inherit class
    protected override void Shoot(int bulletType)
    {
        base.Shoot(bulletType);
    }
}
