using UnityEngine;

public class earthraysanimation : StateMachineBehaviour
{
    public string fadeObjectName = "Hologram"; // Set the GameObject name in the Inspector

    // Correct method signature
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameObject fadeObject = GameObject.Find(fadeObjectName);
        if (fadeObject != null)
        {
            fadein fadeScript = fadeObject.GetComponent<fadein>();
            if (fadeScript != null)
            {
                fadeScript.StartCoroutine("FadeIn");
            }
        }
    }
}
