//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

public enum Element
{
    Fire,
    Wind,
    Earth,
    Water
}

[System.Serializable]
public struct Ability
{

    //id	name	rank	hp	damage	armor	attackspeed	movespeed	cooltime	deftype	atktype	damagedtype	atktypelv	
    //level	exp	explain


    public int Id { set; get; }
    public string Name { set; get; }
    public int Rank { set; get; }
    public float Hp { set; get; }
    public float Damage { set; get; }
    public float Armor { set; get; }
    public float Attackspeed { set; get; }
    public float Movespeed { set; get; }
    public float Cooltime { set; get; }
    public int Deftype { set; get; }
    public int Atktype { set; get; }
    public int Damagedtype { set; get; }
    public int Atktypelv { set; get; }
    public int Level { set; get; }
    public int Exp { set; get; }
    public string Explain { set; get; }


     public Ability(int id, string name, int rank, float hp, float damage, float armor, float attackspeed,
         float movespeed, float cooltime, int deftype, int atktype, int damagedtype, int atktypelv, int level,
         int exp, string explain)
     
     {
        Id = id;
        Name = name;
        Rank = rank;
        Hp = hp;
        Damage = damage;
        Armor = armor;
        Attackspeed = attackspeed;
        Movespeed = movespeed;
        Cooltime = cooltime;
        Deftype = deftype;
        Atktype = atktype;
        Damagedtype = damagedtype;
        Atktypelv = atktypelv;
        Level = level;
        Exp = exp;
        Explain = explain;



     }





}



