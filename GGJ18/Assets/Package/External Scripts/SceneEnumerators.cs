/// <summary>Scenes Names and Int values syncronized with Build Settings</summary>
public enum ScenesBuildSetting
{
    Loader = -1,
    AspectRatio = 0,
    Preloading_16x9 = 1,
    Preloading_4x3 = 2,
    Inn_16x9 = 3,
    Inn_4x3 = 4,
    DeckBuilder_16x9 = 5,
    DeckBuilder_4x3 = 6,
    InventoryShop_16x9 = 7,
    InventoryShop_4x3 = 8,
    Talents_16x9 = 9,
    Talents_4x3 = 10,
    DungeonChoose_16x9 = 11,
    DungeonChoose_4x3 = 12,
    DungeonGame_16x9 = 13,
    DungeonGame_4x3 = 14,
}

/// <summary>All the implemented Game Aspect Ratios</summary>
public enum AspectRatio
{
    _16x9 = 0,
    _4x3 = 1
}

/// <summary>Unique Game Scene Names</summary>
public enum SceneName
{
    Loader = -1,
    Preloading = 0,
    Inn = 1,
    DeckBuilder = 2,
    InventoryShop = 3,
    Talents = 4,
    DungeonChoose = 5,
    DungeonGame = 6,
    AspectRatio = 7
}