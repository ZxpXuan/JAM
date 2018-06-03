﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define {

    public static float selfDamagePerAttack = 3f;//发射时扣的血
    public static float selfDamagePerAttackA1 = 0.5f;//子弹携带的力度a1
    public static float selfDamagePerAttackA2 = 1.5f;//子弹携带的力度a2

    public static float t_max = 3f;
    public static float longPressA1 = 1f;
    public static float longPressA2 = 0.1f;
    public static float longPressA3 = 0.1f;

    public static float longPressA4 = 2f;//长按系数
    public static float knockDownDamage = 30f;//角色被击倒后，固定损失HP：HP_Fall_Cut


    public static float strawMaxAngle = 30f;//吸管最大角度

    public static float shortPressStrength = 9f;//短按固定力

    public static float hpScaleA1 = 1f;//hp->speed

}
