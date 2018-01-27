using System.Collections;
using UnityEngine;
using DG.Tweening;

public class RandomOrbit : MonoBehaviour {
    [SerializeField] private float rotateMin, rotateMax;
    public RectTransform[] leftWaypoints;
    public RectTransform[] rightWaypoints;
    private RectTransform transf;

    private Vector3[] leftPositions;
    private Vector3[] rightPositions;

    void Start () {
        transf = GetComponent<RectTransform>();
        leftPositions = new Vector3[leftWaypoints.Length];
        for (int i = 0; i < leftWaypoints.Length; i++)
        {
            leftPositions[i] = leftWaypoints[i].position;
        }

        rightPositions = new Vector3[rightWaypoints.Length];
        for (int i = 0; i < rightWaypoints.Length; i++)
        {
            rightPositions[i] = rightWaypoints[i].position;
        }

        StartCoroutine(RandomOrbitCO());
	}

    private IEnumerator RandomOrbitCO()
    {
        yield return new WaitForSeconds(Random.Range(0, 3.0f));
        bool left = true;

        while (true)
        {
            Tween jump = transf.DOJump(!left ? leftPositions[Random.Range(0, leftPositions.Length - 1)] : rightPositions[Random.Range(0, rightPositions.Length - 1)], 2, 1, Random.Range(5.0f, 9.0f));
            Tween rotate = transf.DORotate(new Vector3(0, 0, Random.Range(rotateMin, rotateMax)), Random.Range(4.0f, 7.0f));
            left = !left;
            yield return jump.WaitForCompletion();

            yield return new WaitForSeconds(Random.Range(2.0f, 5.0f));

            yield return null;
        }
    }
}
