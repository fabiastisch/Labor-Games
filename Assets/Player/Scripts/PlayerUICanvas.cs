using TMPro;
using UI.Scripts.UISpells;
using Utils;

public class PlayerUICanvas : GenericSingleton<PlayerUICanvas>
{
    public BossBar bossBar;
    public UISpells spells;
    public CustomText centeredText;

    protected override void InternalInit()
    {
    }
    protected override void InternalOnDestroy()
    {
    }
}