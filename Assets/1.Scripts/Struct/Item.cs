




[System.Serializable]
public struct Item {

    //public enum Element
    //{
    //    Fire,
    //    Wind,
    //    Earth,
    //    Water
    //}

    public int Id { set; get; }
    public string Name { set; get; }
    public int Rank { set; get; }
    public float Hp { set; get; }
    public float Damage { set; get; }
    public float Armor { set; get; }
    public float Attackspeed { set; get; }
    public float Movespeed { set; get; }
    public float Cooltime { set; get; }
    public int Atktype { set; get; }
    public string Explain { set; get; }


    public Item(int id, string name, int rank, float hp, float damage, float armor, float attackspeed,
        float movespeed, float cooltime,int atktype, string explain)

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
        Atktype = atktype;
        Explain = explain;



    }



}
