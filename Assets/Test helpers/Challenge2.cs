using UnityEngine.EventSystems;

public class Challenge2 : Challenge
{
    int count, targetCount = 10;
    public override event ChallengeDelegate Complete;

    public override void OnPointerClick(PointerEventData eventData)
    {
        count = 0;
        Test.challenge2Complete += OnEvent;
        GameUtilEvents.StartChallenge(this);
    }

    private void OnEvent()
    {
        count++;
        if (count == targetCount)
        {
            Test.challenge2Complete -= OnEvent;
            Complete(this);
        }
    }
}
