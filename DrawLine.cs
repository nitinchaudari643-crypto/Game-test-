using UnityEngine;

public class DrawLine : MonoBehaviour
{
    public GameObject linePrefab;

    private LineRenderer currentLine;
    private EdgeCollider2D edgeCollider;
    private Vector2 lastPos;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject line = Instantiate(linePrefab);
            currentLine = line.GetComponent<LineRenderer>();
            edgeCollider = line.GetComponent<EdgeCollider2D>();

            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            lastPos = mousePos;

            currentLine.positionCount = 1;
            currentLine.SetPosition(0, mousePos);
        }

        if (Input.GetMouseButton(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (Vector2.Distance(mousePos, lastPos) > 0.1f)
            {
                currentLine.positionCount++;
                currentLine.SetPosition(currentLine.positionCount - 1, mousePos);

                Vector2[] points = new Vector2[currentLine.positionCount];
                for (int i = 0; i < points.Length; i++)
                    points[i] = currentLine.GetPosition(i);

                edgeCollider.points = points;
                lastPos = mousePos;
            }
        }
    }
}
