using System;

public enum GameTags
{
    // Font Types
    StandardFont = 0,
    LongTextFont = 1,
    TitleTextFont = 2,
    DefaultData = 3,
    AssetsKeeper = 4,
    AbilitySlot = 5,
    LinksPanel = 6
}

/// <summary>Game Dungeon Names</summary>
public enum DungeonName
{
    None = -1,
    SpidersCave = 0,
    GoblinsPlain = 1,
    DruidsForest = 2,
    SoulsSea = 3,
    SecretDungeon = 4
}

///<summary> Card Type Names </summary>
public enum CardType
{
    Monster = 0,
    Equipment = 1,
    PlayerAbility = 2,
    EnemyAbility = 3,
    Trap = 4
}

/// <summary>Equipment Card Buff Names</summary>
public enum BuffEquipmentCard
{
    None = -1,
    Defense = 0,
    DefenseFromPoison = 1,
    DefenseFromFire = 2,
    DefenseFromIce = 3,
    Health = 4,
    Energy = 5,
    Mana = 6,
    Physic = 7,
    Magic = 8,
    Poison = 9,
    Fire = 10,
    Ice = 11
}

/// <summary>Damage Type Names</summary>
public enum DamageTypePlayerAbility
{
    Physic = 0,
    PhysicAOE = 1,
    Magic = 2,
    MagicAOE = 3,
    Poison = 4,
    PoisonAOE = 5,
    Fire = 6,
    FireAOE = 7,
    Ice = 8,
    IceAOE = 9,
    Invulnerability = 10,
    InvulnerabilityAOE = 11,
    Defense = 12,
    DefenseAOE = 13,
    Immediate = 14,
    ImmediateBuffable = 15,
    NoInvulnerability = 16,
    NoPoison = 17,
    NoIce = 18,
    NoFire = 19
}

public enum StatsRequestedPlayerAbility
{
    Defense = 0,
    Health = 1,
    Energy = 2,
    Mana = 3,
    Gold = 4,
    Physic = 5,
    Magic = 6,
    Poison = 7,
    Fire = 8,
    Ice = 9,
    Invulnerability = 10,
    Immediate = 11,
    NoInvulnerability = 12,
    NoPoison = 13,
    NoIce = 14,
    NoFire = 15
}

/// <summary> Damage Type Enemy Ability Names </summary>
public enum DamageTypeEnemyAbility
{
    Defense = 0,
    HiveDefense = 1,
    HiveDefenseAOE = 2,
    Health = 3,
    HiveHealth = 4,
    HiveHealthAOE = 5,
    Physic = 6,
    PhysicAOE = 7,
    HivePhysic = 8,
    Magic = 9,
    MagicAOE = 10,
    HiveMagic = 11,
    Poison = 12,
    PoisonAOE = 13,
    HivePoison = 14,
    Fire = 15,
    FireAOE = 16,
    HiveFire = 17,
    Ice = 18,
    IceAOE = 19,
    HiveIce = 20,
    Invulnerability = 21,
    InvulnerabilityAOE = 22,
    Immediate = 23, 
    DefenseAOE = 24,
    HealthAOE = 25,
    NoInvulnerability = 26,
    NoPoison = 27,
    NoIce = 28,
    NoFire = 29
}

public enum StatsAffectingOnPlayer_EnemyAbility
{
    Defense = 0,
    HiveDefense = 1,
    Health = 3,
    HiveHealth = 4,
    Energy = 6,
    HiveEnergy = 7,
    Mana = 8,
    HiveMana = 9,
    Gold = 10,
    Physic = 11,
    HivePhysic = 12,
    Magic = 13,
    HiveMagic = 14,
    Poison = 15,
    HivePoison = 16,
    Fire = 17,
    HiveFire = 18,
    Ice = 19,
    HiveIce = 20,
    Immediate = 21,
    NoInvulnerability = 22,
    NoPoison = 23,
    NoIce = 24,
    NoFire = 25
}

public enum DamageValueType
{
    Single = 0,
    Range = 1
}

public enum RarityCard
{
    None = 0,
    Common = 1,
    Rare = 2,
    Epic = 3,
    Legendary = 4
}

[Serializable]
public enum Effects
{
    Defense,
    Energy,
    Fire,
    Gold,
    Health,
    Immediate,
    Ice,
    ImmediateBuffable,
    Invulnerability,
    Magic,
    Mana,
    Physic,
    Poison,
    HiveDefenseAOE,
    HiveHealthAOE,
    HiveDefense,
    HiveEnergy,
    HiveFire,
    HiveHealth,
    HiveIce,
    HiveInvulnerability,
    HiveMagic,
    HiveMana,
    HivePhysic,
    HivePoison,
    DefenseAOE,
    FireAOE,
    IceAOE,
    InvulnerabilityAOE,
    MagicAOE,
    PhysicAOE,
    PoisonAOE,
    DefenseFromPoison,
    DefenseFromFire,
    DefenseFromIce,
    HealthAOE,
    NoInvulnerability,
    NoPoison,
    NoIce,
    NoFire
}

public enum ClassWarriorRogueMage
{
    Warrior = 0,
    Rogue = 1,
    Mage = 2,
    None = 3
}

public enum EquipmentType
{
    None = 0,
    Weapon = 1,
    Armor = 2,
    Amulet = 3,
    Ring = 4
}

public enum Visibility
{
    On = 0,
    Off = 1
}