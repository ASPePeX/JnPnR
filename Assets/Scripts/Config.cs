using UnityEngine;

public static class Config
{
    public static Vector2 SpawnPosition = new Vector2(0, 3);
    public static Vector2 MaxVelocity = new Vector2(12f, 12f);

    public static ForceMode2D ForceModeMove = ForceMode2D.Force;
    public static ForceMode2D ForceModeJump = ForceMode2D.Impulse;

    public static float ForceHorizontal = 15f;
    public static float ForceJump = 400f;

    public static float PitchSpan = 20f;
 
    public static float VisibilitySpan = 6f;

    public static Vector3 CameraOffset = new Vector3(0, 11, -10);

    public static float AmplitudeMin = 0.05f;

    public static Vector2 limits = new Vector2(-0.2f, 2.5f);

}
