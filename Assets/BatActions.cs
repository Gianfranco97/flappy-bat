using UnityEngine;


public class BatActions : MonoBehaviour
{
    public Joystick joystick;
    public GameObject arrow;
    public bool FacingRight = true;

    void showDirectionArrow() {
        if (joystick.isTouching) {
            arrow.SetActive(true);
        } else {
            arrow.SetActive(false);
        }
    }

    void FixedUpdate() {
        showDirectionArrow();

        float directionX = joystick.Direction.x ;
        float directionY = joystick.Direction.y ;

        float degrees = directionX + directionY * 360;

    
            arrow.transform.rotation = Quaternion.Euler(0, 0, degrees);

        
    }

    private void Flip()
    {
        // Flips the player.
        FacingRight = !FacingRight;

        arrow.transform.Rotate(0, 180, 0);
    }
}
