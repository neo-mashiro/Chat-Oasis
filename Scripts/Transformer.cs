using System;
using UnityEngine;
using System.Collections;

// dynamically translate or rotate a game object
public class Transformer : MonoBehaviour {
    private enum Motions {Spin, Horizontal, Vertical};
    private enum Axes {X, Y, Z}

    [SerializeField] private Motions motion = Motions.Horizontal;
    [SerializeField] private Axes axis = Axes.X;
    [SerializeField] private float spinSpeed = 10.0f;
    [SerializeField] private float motionMagnitude = 0.1f;

    private void Update() {
        switch (motion) {
            case Motions.Horizontal:
                transform.Translate(Vector3.right * (Mathf.Cos(Time.timeSinceLevelLoad) * motionMagnitude));
                break;

            case Motions.Vertical:
                transform.Translate(Vector3.up * (Mathf.Cos(Time.timeSinceLevelLoad) * motionMagnitude));
                break;

            case Motions.Spin:
                switch (axis) {
                    case Axes.X:
                        transform.Rotate(Vector3.right * (Time.deltaTime * spinSpeed));
                        break;
                    case Axes.Y:
                        transform.Rotate(Vector3.up * (Time.deltaTime * spinSpeed));
                        break;
                    case Axes.Z:
                        transform.Rotate(Vector3.forward * (Time.deltaTime * spinSpeed));
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                break;
            
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}
