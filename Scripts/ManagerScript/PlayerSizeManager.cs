using System.Collections;
using UnityEngine;

public class PlayerSizeManager : MonoBehaviour
{
    private Vector3 originalScale;
    private PlayerController playerController;
    private Ai ai;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        ai = GameObject.Find("Ai").GetComponent<Ai>();
        originalScale = transform.localScale;
    }

    public void StartGlow()
    {
        StartCoroutine(GrowAndShrink());
    }

    public void StartGlowAi()
    {
        StartCoroutine(GrowAnShrinkAi());
    }

    public IEnumerator GrowAndShrink()
    {
        // Grow
        transform.localScale = new Vector3(1f, 1f, 1f);

        playerController.yMaxPlayerRange = 2.30f;
        
        // Wait 5 seconds
        yield return new WaitForSeconds(5);
        
        // Shrink back to original
        transform.localScale = originalScale;

        playerController.yMaxPlayerRange = 2.89f; 
    }

    public IEnumerator GrowAnShrinkAi()
    {
         // Grow
        transform.localScale = new Vector3(1f, 1f, 1f);

        ai.yMaxAiRange = 2.10f;
        
        // Wait 5 seconds
        yield return new WaitForSeconds(5);
        
        // Shrink back to original
        transform.localScale = originalScale;

        ai.yMaxAiRange = 2.97f; 
    }
}
