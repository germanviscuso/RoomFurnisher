using Oculus.Interaction;
using UnityEngine;

/// <summary>
/// Moves the selected interactable 1 to 1 with the interactor. For example, if your interactor moves up and to the right, the selected interactable will also move up and to the right.
/// </summary>
public class CustomMovementProvider : MonoBehaviour, IMovementProvider
{
    public IMovement CreateMovement()
    {
        return new CustomMovement();
    }
}

public class CustomMovement : IMovement
{
    public Pose Pose { get; private set; } = Pose.identity;
    public bool Stopped => true;

    public void StopMovement()
    {
    }

    public void MoveTo(Pose target)
    {
        /*Vector3 newPosition = new Vector3(target.position.x, Pose.position.y, target.position.z);
        Quaternion newRotation = new Quaternion();
        Pose.GetTransformedBy(new Pose(newPosition, Pose.rotation));*/
    }

    public void UpdateTarget(Pose target)
    {
        /*
        Pose = target;
    */
    }

    public void StopAndSetPose(Pose source)
    {
        /*
        Pose = source;
    */
    }

    public void Tick()
    {
    }
}