using UnityEngine;

public abstract class InputService : IInputService
{
    protected const string Horizontal = "Horizontal";
    protected const string Vertical = "Vertical";
    protected const string Fire = "Fire";

    public abstract Vector2 Axis { get; }

    public bool IsAttackButtonUp()
    {
        return SimpleInput.GetButtonUp(Fire);
    }

    protected static Vector2 GetSimpleInputAxis()
    {
        return new Vector2(SimpleInput.GetAxis(Horizontal), SimpleInput.GetAxis(Vertical));
    }
}
