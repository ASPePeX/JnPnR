using UnityEngine;

public static class Config
{
    public static Vector2 SpawnPosition = new Vector2(-4, 17);
    public static Vector2 MaxVelocity = new Vector2(12f, 12f);

    public static ForceMode2D ForceModeMove = ForceMode2D.Force;
    public static ForceMode2D ForceModeJump = ForceMode2D.Impulse;

    public static float ForceHorizontal = 15f;
    public static float ForceJump = 400f;
    public static float PitchSpan = 20f;
    public static float VisibilitySpan = 5f;
    public static int NumberOfBands = 10;
}
