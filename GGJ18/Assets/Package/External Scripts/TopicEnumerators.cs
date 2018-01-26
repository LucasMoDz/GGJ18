public enum Topic
{
    // Progress Bar Manager Events

    /// <summary>0 Results --- 3 Parameters = ScenesBuildSetting, float, float</summary>
    LoadSceneWithImageAndTextFeedback = 0,              

    // Aspect Ratio Manager Events

    /// <summary>1 Result = SceneBuildSetting --- 1 Parameter = SceneName</summary>
    CorrectSceneToGoRequest = 1,                       

    // Player Data Manager Events

    /// <summary>0 Results --- 0 Parameters</summary> 
    LoadAllData = 2,

    /// <summary>0 Results --- 0 Parameters</summary> 
    SaveAllData = 3,

    /// <summary>0 Results --- 1 parameters = GameDataFileName</summary>
    LoadSpecificGameData = 4,

    /// <summary>0 Results --- 1 parameters = GameDataFileName</summary>
    SaveSpecificGameData = 5,

    /// <summary>0 Results --- 1 parameters = PlayerDataFileName</summary>
    LoadSpecificPlayerData = 6,

    /// <summary>0 Results --- 1 parameters = PlayerDataFileName</summary>
    SaveSpecificPlayerData = 7,

    /// <summary>1 Results = GameData --- 0 Parameters</summary>
    GameDataReferenceRequest = 8,

    /// <summary>1 Results = PlayerData --- 0 Parameters</summary>
    PlayerDataReferenceRequest = 9,

    /// <summary>1 Results = PlayerStats --- 0 Parameters</summary>
    PlayerStatsReferenceRequest = 10,
                   
    /// <summary>1 Results = PlayerEconomy --- 0 Parameters</summary>
    PlayerEconomyReferenceRequest = 11,

    /// <summary>1 Results = PlayerAbilities --- 0 Parameters</summary>
    PlayerAbilitiesReferenceRequest = 12,

    /// <summary>1 Results = PlayerTalents --- 0 Parameters</summary>
    PlayerTalentsReferenceRequest = 13,
             
    /// <summary>1 Results = InnData --- 0 Parameters</summary>
    InnDataReferenceRequest = 14,
                     
    /// <summary>1 Results = DeckBuilderData --- 0 Parameters</summary>
    DeckBuilderDataReferenceRequest = 15,
              
    /// <summary>1 Results = InventoryShopData --- 0 Parameters</summary>
    InventoryShopDataReferenceRequest = 16,
            
    /// <summary>1 Results = TalentsData --- 0 Parameters</summary>
    TalentsDataReferenceRequest = 17,
                  
    /// <summary>1 Results = DungeonChooseData --- 0 Parameters</summary>
    DungeonChooseDataReferenceRequest = 18,
          
    /// <summary>1 Results = DungeonGameData --- 0 Parameters</summary>
    DungeonGameDataReferenceRequest = 19,

    /// <summary> The generation dungeon request.</summary>
    DungeonInstanceDataRequest = 20,

    //Card Database Manager Events

    /// <summary>1 Results = GameObject --- 1 Parameters = Enum</summary>
    CardPrefabRequest = 21,

    /// <summary>1 Results = GameObject --- 1 Parameters = AbilityCardEnum</summary>
    PlayerAbilityCardPrefabRequest = 22,

    /// <summary>1 Results = GameObject --- 1 Parameters = MonsterAbilityCardEnum</summary>
    MonsterAbilityCardPrefabRequest = 23,

    /// <summary>1 Results = GameObject --- 1 Parameters = MonsterCardEnum</summary>
    MonsterCardPrefabRequest = 24,

    /// <summary>1 Results = GameObject --- 1 Parameters = TrapCardEnum</summary>
    TrapCardPrefabRequest = 25,

    /// <summary>1 Results = GameObject | 2 Parameters = EquipmentCardEnum, DungeonName </summary>
    EquipmentCardPrefabRequest = 26,

    /// <summary>1 Results = GameObject --- 1 Parameters = PossibleEnemies</summary>
    PossibleEnemyCardPrefabRequest = 27,

    /// <summary>1 Results = GameObject --- 1 Parameters = PossibleEnemies</summary>
    PossibleEnemyHealthRequest = 28,

    /// <summary>0 Results --- 0 Parameters</summary>
    PlayerAbilityCardsListRequest = 31,

    /// <summary>0 Results --- 0 Parameters</summary>
    DungeonAssetsRequest = 32,

    //Universal Events

    /// <summary>0 Results --- 0 Parameters</summary>
    EnableUiInteractions = 29,

    /// <summary>0 Results --- 0 Parameters</summary>
    DisableUiInteractions = 30,
    
    // Abstract Modules

    /// <summary> 1 Parameter (Function) </summary>
    WriteTextAbstractTutorial = 33,

    /// <summary> 0 Parameter (Function) </summary>
    FadeInAbstractTutorial = 34,

    /// <summary> 0 Parameter (Function) </summary>
    FadeOutAbstractTutorial = 35,

    /// <summary> 0 Parameter (Event) </summary>
    ClearTextAbstractTutorial = 36,
    
    /// <summary> 1 Parameter (Function) </summary>
    StartBlinkHandRequest = 37,

    /// <summary> 0 Parameter (Event) </summary>
    StopBlinkHandRequest = 38,

    /// <summary> 1 Parameter (Function) </summary>
    MoveHandRequest = 39,

    /// <summary>0 Results --- 0 Parameters</summary>
    RecalculateMaxHealth = 40,

    /// <summary>0 Results --- 0 Parameters</summary>
    RecalculateMaxEnergy = 41,

    /// <summary>0 Results --- 0 Parameters</summary>
    RecalculateMaxMana = 42,

    /// <summary>1 Results = int --- 1 Parameters = int</summary>
    ExpNeededForNextLevelRequest = 43,

    /// <summary> 1 Results = DungeonStatistic | 1 Parameters = int </summary>
    GetDungeonStatisticRequest = 44,

    /// <summary> 1 Results = DungeonSettings | 1 Parameters = int </summary>
    DungeonSettingsRequest = 45,

    /// <summary> 1 Results = DungeonStatistic[] | 0 Parameters </summary>
    GetAllDungeonsStatisticRequest = 46,

    /// <summary> 1 Results = GameObject | 1 Parameters = PossibleEnemies </summary>
    PossibleEnemyDefenseRequest = 47,

    /// <summary> 1 Results = GameObject | 1 Parameters = PossibleEnemies </summary>
    PossibleEnemyExpGivenRequest = 48,

    PlayerAbilityCardInfluenceZoneRequest = 49,

    /// <summary> 1 Results = GameObject[] | 1 Parameters = DungeonName </summary>
    GetAllEquipmentCardsPrefabForDungeonRequest = 50,

    /// <summary> 1 Results = List of GameObject | 1 Parameter = EquipmentType </summary>
    GetEquipmentCardsOwnedRequest = 51,

    CardEffectsLogicRequest = 52,

    CardEffectsGraphicRequest = 53,

    MonsterAbilityListRequest = 54,

    PlayerAbilitiesDissolvePatternRequest = 55,

    EnemyAbilitiesDissolvePatternRequest = 56,

    /// <summary> 1 Result = List of GameObject | 0 Parameters </summary>
    GetAllOwnedEquipmentCards = 70,

    /// <summary> 1 Result = List of GameObject | 1 Parameter = DungeonName </summary>
    GetEquipmentCardsUntilSpecifiDungeonExcludingLegedariesRequest = 71,

    /// <summary> 1 Results = SecretDungeonStatistic | 1 Parameters = int </summary>
    GetSecretDungeonStatisticRequest = 72,

    /// <summary> 1 Results = SecretDungeonStatistic[] | 0 Parameters </summary>
    GetAllSecretDungeonsStatisticRequest = 73,

    /// <summary> 1 Results = PlayerAchievement | 1 Parameters = int </summary>
    GetAchievementRequest = 74,

    /// <summary> 1 Results = PlayerAchievement[] | 0 Parameters </summary>
    GetAllAchievementsRequest = 75
}

public enum PreloadingTopics
{
    
}

public enum TextActivationTypes
{
    Standard = 0,
    Fade = 1,
    Typewriter = 2
}

public enum InnTopics
{
    /// <summary> 0 Parameter (Event) </summary>
    FadeInParchmentRequest = 0,

    /// <summary> 0 Parameter (Event) </summary>
    StartTutorialFerrymanRequest = 1,

    /// <summary> 1 Parameter (Event) </summary>
    GetParchmentRepoRequest = 2,

    /// <summary> 0 Parameter (Function) </summary>
    GetFerrymanDialogueRequest = 3,

    /// <summary> 0 Parameter (Function) </summary>
    GetHeroClassChoiceDialogueRequest = 4,

    /// <summary> 2 Parameter (Function) </summary>
    PrintTextOnParchmentRequest = 5,

    /// <summary> 0 Parameter (Event) </summary>
    ClearParchmentTextRequest = 6,

    /// <summary> 1 Parameter (Function) </summary>
    GetSpecificFerrymanDialogueRequest = 7,

    /// <summary> 0 Parameter (Function) </summary>
    FadeInClassesRequest = 8,

    /// <summary> 0 Parameter (Function) </summary>
    GetSpeedDialogueTutorialRequest = 9,

    /// <summary> 1 Parameter (Event) </summary>
    ShowExtractedCardsRequest = 10,

    /// <summary> 0 Parameter (Event) </summary>
    FadeInContinueButtonRequest = 11,

    /// <summary> 0 Parameter (Function) </summary>
    GetSelectedClassRequest = 12,

    /// <summary> 1 Parameter (Function) </summary>
    GetExtractedCardsRequest = 13,

    /// <summary> 0 Parameter (Event) </summary>
    FadeOutParchmentRequest = 14,

    /// <summary> 0 Parameter (Event) </summary>
    FadeOutClassesRequest = 15,

    /// <summary> 0 Parameter (Event) </summary>
    FadeOutExtractedCardsRequest = 16,

    /// <summary> 1 Parameter (Function) </summary>
    MoveBackgroundRequest = 17,

    /// <summary> 1 Parameter (Function) </summary>
    FadeInTitleRequest = 18,

    /// <summary> 1 Parameter (Function) </summary>
    FadeOutTutorialRequest = 19,

    /// <summary> 0 Parameter (Event) </summary>
    HideTutorialPanelRequest = 20,

    /// <summary> 0 Parameter (Function) </summary>
    FadeInInnSceneRequest = 21,

    /// <summary> 0 Parameter (Function) </summary>
    FadeOutInnSceneRequest = 22,

    /// <summary> 0 Parameter (Function) </summary>
    FadeInInnkeeperPanelRequest = 23,

    /// <summary> 0 Parameter (Function) </summary>
    FadeOutInnkeeperPanelRequest = 24,

    /// <summary> 0 Parameter (Function) </summary>
    GetCoroutineReferenceOfFadeOutInnkeeperRequest = 25,

    /// <summary> 0 Parameter (Function) </summary>
    GetInnDialogueTutorialsRequest = 26,

    /// <summary> 1 Parameter (Function) </summary>
    WriteOnInnkeeperParchment = 27,
    
    /// <summary> 0 Parameter (Event) </summary>
    StartFirstPartOfInnTutorialRequest = 28,

    /// <summary> 0 Parameter (Event) </summary>
    ClearTextInnkeeperParchmentRequest = 29,

    /// <summary> 0 Parameter (Event) </summary>
    FadeInArrowRequest = 30,

    /// <summary> 0 Parameter (Event) </summary>
    FadeOutContinueButtonRequest = 31,

    /// <summary> 0 Parameter (Event) </summary>
    StartFinalCutsceneFerrymanTutorial = 32,

    /// <summary> 0 Parameter (Event) </summary>
    ChangeTitleParent = 33,

    /// <summary> 0 Parameter (Event) </summary>
    FadeOutTitleRequest = 34,

    /// <summary> 1 Result = PhrasesForUnlockedDungeon[] | 1 Parameter = int (unlock dungeons) </summary>
    GetInnkeeperRandomPhrasesRequest = 35,

    /// <summary> 0 Results | 0 Parameters </summary>
    FadeOutArrow = 36,

    /// <summary> 1 Result = string | 1 Parameter = int (unlock dungeons) </summary>
    GetInnkeeperUnlockPhraseRequest = 37
}

public enum DeckBuilderTopics
{
    // Warrior Module Manager Events

    /// <summary>0 Results --- 0 Parameters</summary>
    OpenWarriorPanelRequest = 0,

    /// <summary>0 Results --- 0 Parameters</summary>
    CloseWarriorPanelRequest = 1,

    //Rogue Module Manager Events

    /// <summary>0 Results --- 0 Parameters</summary>
    OpenRoguePanelRequest = 2,

    /// <summary>0 Results --- 0 Parameters</summary>
    CloseRoguePanelRequest = 3,

    //Mage Module Manager Events

    /// <summary>0 Results --- 0 Parameters</summary>
    OpenMagePanelRequest = 4,

    /// <summary>0 Results --- 0 Parameters</summary>
    CloseMagePanelRequest = 5,

    //Support Module Manager Events

    /// <summary>0 Results --- 0 Parameters</summary>
    OpenSupportPanelRequest = 6,

    /// <summary>0 Results --- 0 Parameters</summary>
    CloseSupportPanelRequest = 7,

    //Epic Module Manager Events

    /// <summary>0 Results --- 0 Parameters</summary>
    OpenEpicPanelRequest = 8,

    /// <summary>0 Results --- 0 Parameters</summary>
    CloseEpicPanelRequest = 9,

    //Warrior Button Deck Builder Manager

    /// <summary>0 Results --- 0 Parameters</summary>
    EnableWarriorButton = 10,

    //Rogue Button Deck Builder Manager

    /// <summary>0 Results --- 0 Parameters</summary>
    EnableRogueButton = 11,

    //Mage Button Deck Builder Manager

    /// <summary>0 Results --- 0 Parameters</summary>
    EnableMageButton = 12,

    //Support Button Deck Builder Manager

    /// <summary>0 Results --- 0 Parameters</summary>
    EnableSupportButton = 13,

    //Eroic Button Deck Builder Manager

    /// <summary>0 Results --- 0 Parameters</summary>
    EnableEroicButton = 14,

    //Skill Points Manager Events

    /// <summary>0 Results --- 0 Parameters</summary>
    DisableSkillPointUpgradeButton = 15,

    /// <summary>0 Results --- 0 Parameters</summary>
    EnableSkillPointUpgradeButton = 16,

    /// <summary>0 Results --- 0 Parameters</summary>
    UpdateSkillPointsData = 17,

    //Card Quantity Manager Events

    /// <summary>0 Results --- 0 Parameters</summary>
    DisableMinusButton = 18,

    /// <summary>0 Results --- 0 Parameters</summary>
    EnableMinusButton = 19,

    /// <summary>0 Results --- 0 Parameters</summary>
    DisablePlusButton = 20,

    /// <summary>0 Results --- 0 Parameters</summary>
    EnablePlusButton = 21,

    /// <summary>0 Results --- 1 Parameters = int</summary>
    UpdateCardQuantityFeedback = 22,

    //Slot Selected Manager Events

    /// <summary>0 Results --- 1 Parameters = Transform</summary>
    ChangeSelectedSlot = 23,

    /// <summary>0 Results --- 1 Parameters = int</summary>
    UpdateSlotQuantityData = 24,

    /// <summary>0 Results --- 0 Parameters</summary>
    IncreaseAbilityLevel = 25,

    /// <summary>0 Results --- 0 Parameters</summary>
    Deselection = 26,

    /// <summary>1 Results = bool --- 0 Parameters</summary>
    DependencyIsUnlocked = 27,

    //MidUi Manager Events

    /// <summary>0 Results --- 1 Parameters = AbilityCardInstanceData</summary>
    AbilityUnlocked = 28,

    /// <summary>0 Results --- 0 Parameters</summary>
    ResetSkillPointsUpdate = 29,

    /// <summary>0 Results --- 0 Parameters</summary>
    ReInitializeAbilityGraphics = 30,

    //Total Quantity Manager Events

    /// <summary>0 Results --- 0 Parameters</summary>
    TotalQuantityFeedbackUpdateRequest = 31,

    //Card Visibility Manager Events

    /// <summary>0 Results --- 1 Parameters = AbilityCardEnum</summary>
    UpdateCardVisibilityFeedbackRequest = 32,

    //Scene Memory Manager Events

    /// <summary>0 Results --- 0 Parameters</summary>
    ResetPanelOpened = 33,

    /// <summary>0 Results --- 0 Parameters</summary>
    ResetPanelClosed = 34,

    /// <summary>0 Results --- 0 Parameters</summary>
    SimulateWarriorButtonClick = 35,

    /// <summary>0 Results --- 0 Parameters</summary>
    SimulateRogueButtonClick = 36,

    /// <summary>0 Results --- 0 Parameters</summary>
    SimulateMageButtonClick = 37,

    /// <summary>0 Results --- 0 Parameters</summary>
    SimulateSupportButtonClick = 38,

    /// <summary>0 Results --- 0 Parameters</summary>
    SimulateEpicButtonClick = 39,

    /// <summary>0 Results --- 0 Parameters</summary>
    SimulateWarriorSlotSelected = 40,

    /// <summary>0 Results --- 0 Parameters</summary>
    SimulateRogueSlotSelected = 41,

    /// <summary>0 Results --- 0 Parameters</summary>
    SimulateMageSlotSelected = 42,

    /// <summary>0 Results --- 0 Parameters</summary>
    SimulateSupportSlotSelected = 43,

    /// <summary>0 Results --- 0 Parameters</summary>
    SimulateEpicSlotSelected = 44,

    /// <summary>0 Results --- 0 Parameters</summary>
    SimulateResetButtonClick = 45,

    /// <summary> 1 Results = bool | 0 Parameters </summary>
    GetEroicBooleanRequest = 50,

    /// <summary> 0 Results | 1 Parameters = bool </summary>
    SetEroicBooleanRequest = 51,

    /// <summary>0 Results --- 0 Parameters</summary>
    ResetVisibilitySprite = 52,

    /// <summary> 0 Results | 0 Parameters </summary>
    RemoveAnimatedImage = 53,

    /// <summary> 0 Results | 1 Parameter = bool </summary>
    SetActiveSkillPointButton = 54
}

public enum TalentsTopics
{
    
}

public enum DungeonChooseTopics
{
    /// <summary> 0 Results | 1 Parameters = DungeonName </summary>
    RefreshSelectedDungeon = 0,

    /// <summary> BOH </summary>
    TravelOnSelectedDungeon = 1,

    /// <summary> 1 Results = DungeonName | 0 Parameters </summary>
    GetSelectedDungeonRequest = 2, 

    /// <summary> 0 Results | 0 Parameters </summary>
    OpenConfirmPanel = 3,
    
    /// <summary> 1 Results = Coroutine | 0 Parameters </summary>
    FadeOutCanvasRequest = 4,

    /// <summary> 1 Results = Coroutine | 0 Parameters </summary>
    FadeInLockedDungeonMessageRequest = 5,

    /// <summary> 1 Results = Coroutine | 1 Parameters = int </summary>
    RefreshPlayerGoldRequest = 6,

    /// <summary> 0 Results | 1 Parameters = DungeonName </summary>
    RefreshDungeonGold = 7,

    /// <summary> 0 Results | 1 Parameters = DungeonName </summary>
    RefreshDungeonLevelCompletion = 8,

    /// <summary> 1 Results = Coroutine | 1 Parameters = DungeonName </summary>
    FillPathRequest = 9,

    /// <summary> 1 Results = ManagerDungeonChoose_Settings | 0 Parameters </summary>
    GetDungeonChooseSettingsRequest = 10,

    /// <summary> 0 Results | 1 Parameters = bool </summary>
    InitializePathImage = 11,

    /// <summary> 1 Results = Coroutine | 1 Parameters = DungeonName </summary>
    PlayActivationDungeonRequest = 12,

    /// <summary> 0 Results | 1 Parameters = bool </summary>
    InitializeDungeonImage = 13,

    /// <summary> 1 Results = Coroutine | 1 Parameters = DungeonName </summary>
    FadeInObstacleRequest = 14,

    /// <summary> 1 Results = Coroutine | 1 Parameters = DungeonName </summary>
    FadeOutObstacleRequest = 15,

    /// <summary> 0 Results | 1 Parameters = bool </summary>
    InitializeObstacleImage = 16,

    /// <summary> 1 Results = LanguageClass[] | 0 Parameters </summary>
    GetDatabaseRequest = 17,

    /// <summary> 1 Results = Button | 0 Parameters </summary>
    GetTravelButtonRequest = 18,

    /// <summary> 0 results | 1 Parameter = DungeonName enum </summary>
    SetSelectedAnimatorBool = 19,

    /// <summary> 0 Results | 0 Parameters </summary>
    StartNotEnoughGoldFeedback = 20,

    /// <summary> 0 Results = 2 Parameters = DungeonName, float </summary>
    DecreaseRequestedGoldText = 21,

    /// <summary> 0 Results | 0 Parameters </summary>
    StartDungeon = 22
}

public enum DungeonGameTopics
{
    /// <summary>0 Results --- 0 Parameters</summary>
    DungeonMapCreationRequest = 0,

    /// <summary>0 Results --- 0 Parameters</summary>
    DestroyMap = 1,

    /// <summary>1 Results = Vector3 --- 1 Parameters = Array Index (0 for left monster, 1 for mid one, 2 for right one)</summary>
    EnemySlotPositionRequest = 2,

    /// <summary>0 Results --- 0 Parameters</summary>
    ShowMapRequest = 3,

    /// <summary>0 Results --- 0 Parameters</summary>
    HidMapRequest = 4,

    /// <summary>0 Results --- 0 Parameters</summary>
    OpenPlayerPanelRequest = 5,

    /// <summary>0 Results --- 0 Parameters</summary>
    ClosePlayerPanelRequest = 6,

    /// <summary>0 Results --- 1 Parameters = int value</summary>
    RoomNumberChanged = 7,

    /// <summary>0 Results --- 1 Parameters = int value</summary>
    ExpChanged = 33,

    /// <summary>0 Results --- 1 Parameters = int value</summary>
    InstanceCardRequest = 46,

    /// <summary>0 Results --- 0 Parameters</summary>
    DungeonGenerationRequest = 47,

    /// <summary>1 Results = an array of 3 possibleEnemies --- 1 Parameters = Node Level</summary>
    EnemiesAtLevelRequest = 47,

    /// <summary>0 Results --- 3 Parameters = Gameobject (Outline), Gameobject (Card), PossibleEnemyInstanceData</summary>
    DragBegun = 56,

    /// <summary>0 Results --- 3 Parameters = Gameobject (Outline), Gameobject (Card), PossibleEnemyInstanceData</summary>
    DragEnd = 57,

    /// <summary>0 Results --- 3 Parameters = Gameobject (Outline), Gameobject (Card), PossibleEnemyInstanceData</summary>
    CardDropped = 58,

    /// <summary>0 Results --- 1 Parameters = DungeonInstanceData</summary>
    LoadOldDungeonOldMonsters = 59,

    /// <summary>1 Results = bool --- 0 Parameters</summary>
    DragIsActive = 66,

    /// <summary> 0 Results --- 1 Parameter = PossibleDropZone </summary>
    PlayerAbilityUsed = 67,

    /// <summary> 0 Results --- 2 Parameters = PlayerSlotEnum, PossibleDropZone </summary>
    PlayerActionDataSend = 68,

    LoadOldDungeonNewMonsters = 69
}

public enum EffectTopics
{
    /// <summary>1 Result --- 1 Parameteres = GenerateEffect</summary>
    PlayEffectRequest = 0,

    /// <summary>1 Result --- 4 Parameters = GameObject, HotSpots, HotSpots, float</summary>
    DeployCardRequest = 1,

    /// <summary>1 Result --- 3 Parameters (1 optional)= GameObject, float, iTween.EaseType (=velocity curve)</summary>
    FlipCardRequest = 2,

    /// <summary>1 Result --- 1 Parameter = HotSpots</summary>
    HotspotPositionRequest = 3,

    /// <summary>1 Result --- 4 Parameters = GameObject, GameObject, RectTransform, RotationDirection(enum)</summary>
    FlipAndChangeInventoryCardRequest = 4,

    /// <summary>1 Result (AudioClipName) --- 1 Parameter = EffectBaseType  </summary>
    GetAudioClipRequest = 5
}