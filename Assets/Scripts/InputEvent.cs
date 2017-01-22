using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class InputEvent : MonoBehaviour {

    public bool isShaking;

    [HideInInspector]
    public bool isARippling;

    // Intervalo de Atualização
    public float accelerometerUpdateInterval = 1.0f / 60.0f;

    // Quanto maior o valor de LowPassKernelWidthInSeconds, mais lento o valor filtrado convergerá para a amostra de entrada atual (e vice-versa).
    public float lowPassKernelWidthInSeconds = 1.0f;

    public float shakeDetectionThreshold = 2.0f;

    public float maxVariationWhenRippling;
    public float RipplingTime;

    private float m_lastXAcceleration = 0f;

    private float m_lowPassFilterFactor;
    private Vector3 m_lowPassValue = Vector3.zero;
    private Vector3 m_acceleration;
    private Vector3 m_deltaAcceleration;

    

    void Start() {
        if (maxVariationWhenRippling > 1) {
            Debug.Log("Variation is now 1, the variant can't over 1");
            maxVariationWhenRippling = 1;
        }

        m_lowPassFilterFactor = accelerometerUpdateInterval / lowPassKernelWidthInSeconds;
        shakeDetectionThreshold *= shakeDetectionThreshold;
        m_lowPassValue = Input.acceleration;
        StartCoroutine(RipplingUpdate());
    }

    void Update() {
        ShakingUpdate();
    }

    private void ShakingUpdate() {
        m_acceleration = Input.acceleration;
        m_lowPassValue = Vector3.Lerp(m_lowPassValue, m_acceleration, m_lowPassFilterFactor);
        m_deltaAcceleration = m_acceleration - m_lowPassValue;
        if (m_deltaAcceleration.sqrMagnitude >= shakeDetectionThreshold) {
            isShaking = true;
        }
        else {
            isShaking = false;
        }
    }

    private IEnumerator RipplingUpdate() {
        float currentX = Input.acceleration.x;
        if (Mathf.Abs(Mathf.Abs(m_lastXAcceleration) - Mathf.Abs(currentX)) > maxVariationWhenRippling) {
            isARippling = true;
        }
        else {
            isARippling = false;
        }
        m_lastXAcceleration = currentX;
        yield return new WaitForSeconds(RipplingTime);
        StartCoroutine(RipplingUpdate());
    }
}

[CustomEditor(typeof(InputEvent))]
public class InputEventEditor : Editor {

    public bool showDefaultInspector;

    public override void OnInspectorGUI() {
        InputEvent ie = (InputEvent) target;
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Current Inputs", EditorStyles.boldLabel);
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Is Shaking:");
        if (ie.isShaking) EditorGUILayout.LabelField("✔");
        else EditorGUILayout.LabelField("✖");
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Is A Rippling:");
        if (ie.isARippling) EditorGUILayout.LabelField("✔");
        else EditorGUILayout.LabelField("✖");
        EditorGUILayout.EndHorizontal();
        showDefaultInspector = EditorGUILayout.Foldout(showDefaultInspector, "Variables");
        if (showDefaultInspector) {
            DrawDefaultInspector();
        }
    }
}
