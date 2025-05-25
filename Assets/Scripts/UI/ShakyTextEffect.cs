using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ShakyTextEffect : MonoBehaviour
{
    public float shakeMagnitude = 1.0f;
    public float shakeSpeed = 25.0f;

    private TextMeshProUGUI tmpText;
    private TMP_TextInfo textInfo;
    private Vector3[][] originalVertices;
    private string lastText = "";

    void Awake()
    {
        tmpText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (tmpText.text != lastText)
        {
            lastText = tmpText.text;
            tmpText.ForceMeshUpdate();
            textInfo = tmpText.textInfo;

            originalVertices = new Vector3[textInfo.meshInfo.Length][];
            for (int i = 0; i < textInfo.meshInfo.Length; i++)
            {
                originalVertices[i] = textInfo.meshInfo[i].vertices.Clone() as Vector3[];
            }
        }

        tmpText.ForceMeshUpdate();
        textInfo = tmpText.textInfo;

        for (int i = 0; i < textInfo.characterCount; i++)
        {
            if (!textInfo.characterInfo[i].isVisible)
                continue;

            int materialIndex = textInfo.characterInfo[i].materialReferenceIndex;
            int vertexIndex = textInfo.characterInfo[i].vertexIndex;

            if (originalVertices == null || materialIndex >= originalVertices.Length)
                continue;
            if (vertexIndex + 3 >= originalVertices[materialIndex].Length)
                continue;

            Vector3[] sourceVertices = originalVertices[materialIndex];
            Vector3[] destinationVertices = textInfo.meshInfo[materialIndex].vertices;

            Vector3 offset = new Vector3(
                Mathf.PerlinNoise(i, Time.time * shakeSpeed) - 0.5f,
                Mathf.PerlinNoise(i + 1, Time.time * shakeSpeed) - 0.5f,
                0) * shakeMagnitude;

            for (int j = 0; j < 4; j++)
            {
                destinationVertices[vertexIndex + j] = sourceVertices[vertexIndex + j] + offset;
            }
        }

        for (int i = 0; i < textInfo.meshInfo.Length; i++)
        {
            textInfo.meshInfo[i].mesh.vertices = textInfo.meshInfo[i].vertices;
            tmpText.UpdateGeometry(textInfo.meshInfo[i].mesh, i);
        }
    }
}
