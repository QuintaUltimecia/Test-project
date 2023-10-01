using UnityEngine.SceneManagement;

public class RestartButton : BaseButton
{
    protected override void OnEnable()
    {
        base.OnEnable();

        OnClick = () => 
        {
            SceneManager.LoadScene(0);
        };
    }
}
