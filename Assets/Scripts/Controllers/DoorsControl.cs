using UnityEngine;
using System.Collections;

public class DoorsControl : MonoBehaviour
{
    [SerializeField] private bool _isOpened = false;
    [SerializeField] private bool _delay = false;

    /// <summary>
    /// Открывание/закрывание дверей.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.F) && !_delay)
        {
            if (!_isOpened)
            {
                transform.parent.GetComponent<Animator>().Play("OpenDoorsAnim");
                _isOpened = true;
            }
            else
            {
                transform.parent.GetComponent<Animator>().Play("CloseDoorsAnim");
                _isOpened = false;
            }

            StartCoroutine(OpeningDelay());
        }
    }

    /// <summary>
    /// Задержка для дверей в 1 секунду.
    /// </summary>
    /// <returns></returns>
    private IEnumerator OpeningDelay()
    {
        _delay = true;

        yield return new WaitForSeconds(1.0f);

        _delay = false;
    }
}
