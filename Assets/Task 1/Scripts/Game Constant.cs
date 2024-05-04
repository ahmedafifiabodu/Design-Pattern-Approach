using UnityEngine;

public static class GameConstant
{
    public const string PlayerTag = "Player";
    public const string EnemyTag = "Enemy";

    public static int Walk = Animator.StringToHash("Walk");
    public static int Attack = Animator.StringToHash("Attack");
    public static int Shoot = Animator.StringToHash("Shoot");

    public const string AnimationSpellCastName = "SpellCast";
}