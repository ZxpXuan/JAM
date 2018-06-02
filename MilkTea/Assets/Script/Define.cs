using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define {

    public static float selfDamagePerAttack = 3f;//发射时扣的血
    public static float selfDamagePerAttackA1 = 0.5f;//子弹携带的力度a1
    public static float selfDamagePerAttackA2 = 3f;//子弹携带的力度a2

    public static float t_max = 3f;
    public static float longPressA1 = 1f;
    public static float longPressA2 = 0.1f;
    public static float knockDownDamage = 30f;//角色被击倒后，固定损失HP：HP_Fall_Cut

}
