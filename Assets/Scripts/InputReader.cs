using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);

    public float Moving { get; private set; }
    public float Rotation { get; private set; }

    private void Update()
    {
        Moving = Input.GetAxis(Vertical);
        Rotation = Input.GetAxis(Horizontal);
    }

    public bool IsButtonDown(KeyCode key) => Input.GetKeyDown(key);


}
