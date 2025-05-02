using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System.Collections.Generic;
using System.Linq;

public class TextReceiver : MonoBehaviour
{
    private Animator animator;
    private Queue<string> animationQueue = new Queue<string>();
    private bool isAnimationPlaying = false;
    private string lastMessage = "";

    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(CheckForMessages());
    }

    IEnumerator CheckForMessages()
    {
        while (true)
        {
            UnityWebRequest www = UnityWebRequest.Get("https://sharp-enormous-collie.ngrok-free.app/message");
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                string receivedMessage = www.downloadHandler.text;
                // Remove square brackets and quotes
                receivedMessage = receivedMessage.Trim(new char[] { '[', ']', '\"' });
                Debug.Log(receivedMessage);
                if (receivedMessage != lastMessage)
                {
                    ProcessReceivedMessage(receivedMessage);
                    lastMessage = receivedMessage;
                }
            }

            yield return new WaitForSeconds(1); // Check for new messages every second
        }
    }

    void ProcessReceivedMessage(string message)
    {
        string[] words = message.ToLower().Split(' ');

        foreach (string word in words)
        {
            // Check if the word triggers an animation
            if (word == "hello" || word == "this" || word == "sign" || word == "language" || word == "translation" ||
                word == "phone" || word == "application" || word == "help" || word == "us" || word == "to" ||
                word == "communication" || word == "with" || word == "deaf" || word == "people" || word == "i" ||
                word == "feeling" || word == "prefer" || word == "you" || word == "which" || word == "happy" ||
                word == "what" || word == "will" || word == "eat" || word == "today" || word == "for" ||
                word == "thank" || word == "understand")
            {
                animationQueue.Enqueue(word);
            }
            else
            {
                Debug.LogWarning($"No animation found for the word: {word}");
            }
        }

        if (!isAnimationPlaying && animationQueue.Count > 0)
        {
            StartCoroutine(PlayAnimationQueue());
        }
    }

    IEnumerator PlayAnimationQueue()
    {
        isAnimationPlaying = true;

        while (animationQueue.Count > 0)
        {
            string animationName = animationQueue.Dequeue();
            AnimationClip animationClip = animator.runtimeAnimatorController.animationClips
                .FirstOrDefault(clip => clip.name == animationName);

            if (animationClip != null)
            {
                animator.CrossFade(animationName, 0.3f);
                yield return new WaitForSeconds(animationClip.length);
            }
        }

        isAnimationPlaying = false;
    }
}
