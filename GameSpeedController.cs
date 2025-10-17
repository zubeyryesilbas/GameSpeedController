using UnityEngine;
using UnityEditor;

public class GameSpeedController : EditorWindow
{
    private float timeScale = 1f;
    private bool isPaused = false;

    [MenuItem("Tools/Game Speed Controller")]
    public static void ShowWindow()
    {
        GetWindow<GameSpeedController>("Game Speed");
    }

    private void OnGUI()
    {
        GUILayout.Label("Game Speed Controller", EditorStyles.boldLabel);
        GUILayout.Space(10);

        // Current time scale display
        GUILayout.Label($"Current Speed: {Time.timeScale:F2}x", EditorStyles.helpBox);
        GUILayout.Space(10);

        // Speed slider
        GUILayout.Label("Adjust Speed:");
        float newTimeScale = EditorGUILayout.Slider(timeScale, 0f, 50f);
        
        if (newTimeScale != timeScale)
        {
            timeScale = newTimeScale;
            Time.timeScale = timeScale;
            isPaused = false;
        }

        GUILayout.Space(10);

        // Quick preset buttons
        GUILayout.Label("Quick Presets:");
        
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("0.25x"))
        {
            Time.timeScale = 0.25f;
            timeScale = 0.25f;
            isPaused = false;
        }
        if (GUILayout.Button("0.5x"))
        {
            Time.timeScale = 0.5f;
            timeScale = 0.5f;
            isPaused = false;
        }
        if (GUILayout.Button("1x"))
        {
            Time.timeScale = 1f;
            timeScale = 1f;
            isPaused = false;
        }
        if (GUILayout.Button("2x"))
        {
            Time.timeScale = 2f;
            timeScale = 2f;
            isPaused = false;
        }
        if (GUILayout.Button("5x"))
        {
            Time.timeScale = 5f;
            timeScale = 5f;
            isPaused = false;
        }
        
        if (GUILayout.Button("10x"))
        {
            Time.timeScale = 10f;
            timeScale = 10f;
            isPaused = false;
        }
        
        if (GUILayout.Button("20x"))
        {
            Time.timeScale = 20f;
            timeScale = 20f;
            isPaused = false;
        }
        
        if (GUILayout.Button("50x"))
        {
            Time.timeScale = 50f;
            timeScale = 50f;
            isPaused = false;
        }
        GUILayout.EndHorizontal();

        GUILayout.Space(10);

        // Pause/Resume button
        if (GUILayout.Button(isPaused ? "Resume" : "Pause", GUILayout.Height(30)))
        {
            if (isPaused)
            {
                Time.timeScale = timeScale;
                isPaused = false;
            }
            else
            {
                Time.timeScale = 0f;
                isPaused = true;
            }
        }

        GUILayout.Space(10);

        // Reset button
        if (GUILayout.Button("Reset to Normal"))
        {
            Time.timeScale = 1f;
            timeScale = 1f;
            isPaused = false;
        }

        // Update slider if time scale changed externally
        if (!isPaused && Mathf.Abs(Time.timeScale - timeScale) > 0.01f)
        {
            timeScale = Time.timeScale;
        }
    }

    private void OnInspectorUpdate()
    {
        Repaint();
    }
}