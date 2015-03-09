using UnityEngine;
using System.Collections;

public class CollectableText : MonoBehaviour
{

    //possible that we don't need this script at all, but instead move code to ontrigger in the coin collector. it makes sense that way.

    public int _totalCollectedMoneyDuringMovement;
    public TextMesh _coinText;
    public TextMesh _cardText;

    private Vector3 _startPosition;
    private Vector3 _endPosition;
    private float alpha = 1;

    void OnEnable()
    {
        resetText();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter()
    {
        StartCoroutine("TextMovement");

    }

    IEnumerator TextMovement() //text needs to move and get more transparent as it moves. furthermore, if another value is collected, it has to be added to the amount
    //and the thing has to refresh. color of text should preferably be player color (ie. blue = player 1, red = player 2)
    {
        _coinText.renderer.enabled = true;
        while (_coinText.transform.position.y < _endPosition.y - .001)
        {

            _coinText.transform.position = Vector3.Lerp(_startPosition, _endPosition, 3f * Time.deltaTime); //maybe shouldn't lerp but instead add a flat value
            alpha = Mathf.Lerp(alpha, 0, Time.deltaTime); //maybe lerp after set time
            _coinText.renderer.material.color = new Color(_coinText.renderer.material.color.r, //modifies alpha value
                    _coinText.renderer.material.color.g, _coinText.renderer.material.color.b, alpha);

            yield return null;
        }

        resetText();
    }

    private void resetText()
    {
        alpha = 1;
        _coinText.transform.position = _startPosition;
        _coinText.renderer.enabled = false;
        _coinText.renderer.material.color = new Color(_coinText.renderer.material.color.r, //modifies alpha value
                _coinText.renderer.material.color.g, _coinText.renderer.material.color.b, alpha);
    }
}
