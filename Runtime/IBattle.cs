#if !UNITY_6000
namespace Spearhead;
#else
namespace Spearhead {
#endif // !UNITY

public interface IBattle
{
    IActionManager ActionManager { get; }
}

#if UNITY_6000
}
#endif // UNITY