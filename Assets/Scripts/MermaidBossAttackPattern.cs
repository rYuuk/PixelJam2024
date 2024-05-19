using UnityEngine;

public class MermaidBossAttackPattern : MonoBehaviour, IEnemyBehaviour
{
    [SerializeField] private Transform hairs;
    [SerializeField] private float downTime = 2;
    [SerializeField] private float speed = 1;
    [SerializeField] private float maxScale = 0.5f;
    [SerializeField] private float totalTimeForScale = 1;
    [SerializeField] private float delayBeforeScaleDown = 2;
    private Vector3 initialScale;
    private Vector3 targetScale;
    private float elapsedTime = 0f;
    private bool increasing = false; // Flag to track whether we're increasing or decreasing scale

    private float waitTime;
    private bool scaleDown = true;
    private bool scaleUp;

    private bool canAttack;

    private void Start()
    {
        // Store the initial and target scales
        initialScale = Vector3.zero; // Start from zero scale
        targetScale = Vector3.one * maxScale; // Set the target scale
    }

    private void Update()
    {
        if (!canAttack)
        {
            return;
        }

        float t = Mathf.Clamp01(elapsedTime / totalTimeForScale); // Ensure t stays between 0 and 1

        if (increasing)
        {
            if (scaleUp)
            {
                // Interpolate from initialScale to targetScale
                hairs.localScale = Vector3.Lerp(initialScale, targetScale, t);

                // Check if we've reached the target scale
                if (t >= 1f)
                {
                    increasing = false; // Switch to decreasing mode
                    elapsedTime = 0f; // Reset elapsed time
                    waitTime = Time.time;
                    scaleDown = false;
                }
                elapsedTime += Time.deltaTime; // Update elapsed time
            }

            if (Time.time - waitTime > delayBeforeScaleDown)
            {
                scaleUp = true;
            }
        }

        if (!increasing)
        {
            if (scaleDown)
            {
                // Interpolate from targetScale back to initialScale
                hairs.localScale = Vector3.Lerp(targetScale, initialScale, t);

                // Check if we've reached the initial scale
                if (t >= 1f)
                {
                    increasing = true;
                    elapsedTime = 0;
                    scaleUp = false;
                    waitTime = Time.time;
                }    // Switch back to increasing mode

                elapsedTime += Time.deltaTime; // Update elapsed time
            }

            if (Time.time - waitTime > delayBeforeScaleDown)
            {
                scaleDown = true;
            }
        }
    }

    public void StartAttack()
    {
        canAttack = true;
    }
}
