using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string JumpButton = "Jump";
    private const string HorizontalAxis = "Horizontal";

    public float GetHorizontalInput()
    {
        return Input.GetAxis(HorizontalAxis);
    }

    public bool IsJumpButtonPressed()
    {
        return Input.GetButtonDown(JumpButton);
    }
}
