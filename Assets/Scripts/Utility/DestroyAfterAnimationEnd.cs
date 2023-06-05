using System.Collections;
using UnityEngine;

public class DestroyAfterAnimationEnd : MonoBehaviour
{
    [SerializeField] private Animator animator;
    
    private AnimatorClipInfo[] currentClipInfo;
    float currentClipLength;
    
    private void OnEnable()
    {
        StartCoroutine(WaitUntilTheEndOfAnimation());
    }

    private IEnumerator WaitUntilTheEndOfAnimation()
    {
        currentClipInfo = animator.GetCurrentAnimatorClipInfo(0);
        currentClipLength = currentClipInfo[0].clip.length;

        yield return new WaitForSeconds(currentClipLength);
        
        Destroy(gameObject);
    }
}
