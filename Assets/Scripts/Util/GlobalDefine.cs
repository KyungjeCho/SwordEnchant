public static class InputKeyName
{
    public const string Horizontal = "Horizontal";
    public const string Vertical = "Vertical";

}
public enum SoundPlayType
{
    None = -1,
    BGM,
    EFFECT,
    UI,
}
public static class GameObjectName
{
    public const string Player  = "Player";
    public const string Sword   = "Sword";
    public const string Bow     = "Bow";
    public const string Dagger  = "Dagger";
    public const string Boomerang  = "Boomerang";
    public const string ChainLightning  = "ChainLightning";

    public const string Melee       = "Melee";
    public const string LongRange   = "LongRange";
    public const string Magic       = "Magic";
}

public static class SceneManagement
{
    public const string Lobby       = "LobbyScene";
    public const string Battle      = "TestScene";
}
public static class TagAndLayerKey
{
    public const string Enemy = "Enemy";
}
public static class PathName
{
    public const string WeaponObjectPath        = "WeaponSystem";
    public const string WeaponTypeObjectPath    = "WeaponSystem/Types";
}

public static class SaveDataKey
{
    public const string Soul = "Soul";
}

public static class PlayerPrefsKey
{
    public const string MaxHp = "최대 체력 업";
    public const string Defence = "방어력 증가";
    public const string Damage = "공격력 증가";
    public const string Size = "캐릭터 크기 감소";
    public const string Speed = "이동속도 증가";
    public const string Cooldown = "쿨타임 감소";
    public const string Luck = "행운 증가";
    public const string CriticalProb = "크리티컬 확률 증가";
    public const string CriticalDamage = "크리티컬 데미지 증가";
}
