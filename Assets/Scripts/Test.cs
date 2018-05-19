using UnityEngine;

public class Test : MonoBehaviour
{
    public static ParameterlessDelegate challenge1Complete, challenge2Complete, challenge3Complete, challenge4Complete, challenge5Complete, challenge6Complete;

    void Start()
    {
        GameUtilEvents.OnSocialLoginSuccess += SocialLoginSuccess;
        GameUtilEvents.OnDisplayAchievements += FacebookLoginSuccess;
        GameUtilEvents.OnStartChallenge += StartChallenge;
    }

    private void StartChallenge(Challenge challenge)
    {
        challenge.Complete += OnChallengeComplete;
    }

    private void OnChallengeComplete(Challenge challenge)
    {
        print(challenge.Description + " has been completed now!");
        challenge.Complete -= OnChallengeComplete;
    }

    private void FacebookLoginSuccess()
    {
        DebugText.instance.Print("facebook has logged in.");
    }

    private void SocialLoginSuccess()
    {
        DebugText.instance.Print(Social.localUser.userName + " has logged in.");
    }

    public void WinAGame()
    {
        GameUtilEvents.UpdateAchievement(GPGSIds.achievement_win_10_games, 1);
    }

    public void DisplayAchievements()
    {
        GameUtilEvents.DisplayAchievements();
    }

    public void Challenge1Completed()
    {
        if (challenge1Complete != null)
        {
            challenge1Complete();
        }
    }

    public void Challenge2Completed()
    {
        if (challenge2Complete != null)
        {
            challenge2Complete();
        }
    }

    public void Challenge3Completed()
    {
        if (challenge3Complete != null)
        {
            challenge3Complete();
        }
    }

    public void Challenge4Completed()
    {
        if (challenge4Complete != null)
        {
            challenge4Complete();
        }
    }

    public void Challenge5Completed()
    {
        if (challenge5Complete != null)
        {
            challenge5Complete();
        }
    }

    public void Challenge6Completed()
    {
        if (challenge6Complete != null)
        {
            challenge6Complete();
        }
    }
}