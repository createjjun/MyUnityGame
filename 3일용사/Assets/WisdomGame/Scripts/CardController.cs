using UnityEngine;

public class CardController : MonoBehaviour
{
    [SerializeField] private CardModel _model;
    [SerializeField] private CardView _view;
    [SerializeField] private int CardNum = 2;
    [SerializeField] private int Stage = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _model.AddSpr(CardNum);
        _model.ShuffleCard(CardNum*2);
        _model.SpawnCard();
    }
    private void Update()
    {
        if(CardNum == _model.PassCard)
        {
            Stage += 1;
            if (Stage % 2 == 0 && CardNum < 8)
            {
                CardNum += 1;
                if (CardNum==4 || CardNum==6) _model.SetColumns();
            }
            UpStage();
        }
    }
    private void UpStage()
    {
        _model.Restart();
        _model.PassCard = 0;
        _model.AddSpr(CardNum);
        _model.ShuffleCard(CardNum * 2);
        _model.SpawnCard();
    }
}
