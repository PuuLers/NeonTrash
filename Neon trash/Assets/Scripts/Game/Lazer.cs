using UnityEngine;

public class Lazer : MonoBehaviour
{
    private float length;

    [Range(0f, 10f)]
    public float lifeTime;

    public GameObject turret;
    public GameObject ender;

    public bool alwaysActive;
    public GameObject lazer;
    private float timer = 0f;
    private bool isActive = false;
    public float delay;

    private void Stabilization()
    {
        // Устанавливаем позицию лазера между turret и ender по локальным координатам
        lazer.transform.localPosition = new Vector3(length / 2f, 0f, 0f);
        // Масштабируем лазер по длине между turret и ender
        lazer.transform.localScale = new Vector3(length, lazer.transform.localScale.y, lazer.transform.localScale.z);
    }

    private void Activate() => lazer.SetActive(true);

    private void Deactivate() => lazer.SetActive(false);

    private void SetLengthAndRotation()
    {
        Vector3 direction = ender.transform.position - turret.transform.position;
        length = direction.magnitude;

        // Поворачиваем turret в сторону ender
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        turret.transform.rotation = Quaternion.Euler(0f, 0f, angle);

        // Поворачиваем ender в сторону turret (противоположно)
        ender.transform.rotation = Quaternion.Euler(0f, 0f, angle + 180f);

        // Позиция лазера выставляется в позицию turret, чтобы корректно настроить локальную позицию
        lazer.transform.position = turret.transform.position;
        lazer.transform.rotation = turret.transform.rotation;
    }

    private void Blinking()
    {
        timer += Time.fixedDeltaTime;
        if (timer < lifeTime) return;

        if (isActive)
            Activate();
        else
            Deactivate();

        isActive = !isActive;
        timer = 0;
    }

    void Start()
    {
        timer = -delay;
        if (alwaysActive) Activate();
        else Deactivate();
    }

    void FixedUpdate()
    {
        SetLengthAndRotation();
        Stabilization();

        if (!alwaysActive) Blinking();
        else Activate();
    }
}