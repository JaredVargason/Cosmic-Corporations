using UnityEngine;
using System.Collections;

public class ScoreUI : MonoBehaviour 
{
	public int _playerNumber;
    
	public GameObject _camera;
	public RocketInfo _rocket;

	public GameObject _box;
	public GameObject _check;

	public TextMesh _moneyCollected;
	public TextMesh _maxHeight;
	public TextMesh _flightTime;
	public TextMesh _totalMoney;
	public TextMesh _cardsCollected;

	public bool _donezo;

	void Start () 
	{	
		float x = _camera.transform.position.x;
		float y = _camera.transform.position.y;
		float z = _camera.transform.position.z;

		transform.position = new Vector3(x, y, z + 10);
		
		_moneyCollected.renderer.enabled = true;
		_maxHeight.renderer.enabled = true;
		_flightTime.renderer.enabled = true;
		_totalMoney.renderer.enabled = true;
		_cardsCollected.renderer.enabled = true;

		_box.renderer.enabled = true;
		_donezo = false;

		StartCoroutine(ShowScores(2f));
	}
	

	void Update () 
	{
		if (Input.GetAxis("A" + _playerNumber) == 1)
        {
            _check.renderer.enabled = true;
            BoardGameHandler._totalMoney[_playerNumber - 1] += (_rocket._money * (_rocket._maxHeight/10) * (_rocket._flightTime/10));
            _donezo = true;
        }
			/*case 1:
				if (Input.GetAxis("A1") == 1 && _donezo == false)
				{
					_check.renderer.enabled = true;
                    BoardGameHandler._totalMoney[_playerNumber - 1] += (_rocket._money * (_rocket._maxHeight/10) * (_rocket._flightTime/10));
					_donezo = true;
				}

				break;

			case 2:
				if (Input.GetAxis("A2") == 1 && _donezo == false)
				{
					_check.renderer.enabled = true;
                    BoardGameHandler._totalMoney[_playerNumber - 1] += (_rocket._money * (_rocket._maxHeight/10) * (_rocket._flightTime/10));
					_donezo = true;
				}

				break;

			case 3:
				if (Input.GetAxis("A3") == 1 && _donezo == false)
				{
					_check.renderer.enabled = true;
                    BoardGameHandler._totalMoney3 += (_rocket._money * (_rocket._maxHeight/10) * (_rocket._flightTime/10));
					_donezo = true;
				}

				break;

			case 4:
				if (Input.GetAxis("A4") == 1 && _donezo == false)
				{
					_check.renderer.enabled = true;
                    BoardGameHandler._totalMoney4 += (_rocket._money * (_rocket._maxHeight/10) * (_rocket._flightTime/10));
					_donezo = true;
				}

				break; */
		
	}

	IEnumerator ShowScores(float time)
	{	
		float elapsedTime = 0f;

		while (elapsedTime < time)
		{
			_moneyCollected.text = "Money Collected: " + Random.Range(100000, 999999);
			_maxHeight.text = "Max Height: " + Random.Range(100000, 999999);
			_flightTime.text = "Flight Time: " + Random.Range(100000, 999999);
			_totalMoney.text = "Total: " + Random.Range(100000, 999999);
			_cardsCollected.text = "Cards Collected: " + Random.Range(100000, 999999);

			elapsedTime += Time.deltaTime;
			yield return new WaitForEndOfFrame();
		}


		_moneyCollected.text = "Money Collected: $" + _rocket._money.ToString("F2");
		_maxHeight.text = "Max Height: " + _rocket._maxHeight.ToString("F2");
		_flightTime.text = "Flight Time: " + _rocket._flightTime.ToString("F2");
		_totalMoney.text = "Total: $" + (_rocket._money * (_rocket._maxHeight/10) * (_rocket._flightTime/10)).ToString("F2");
		_cardsCollected.text = "Cards Collected: " + _rocket._cardsCollected;
	}
}
