using TMPro;
using UnityEngine;

public class MainUi : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private PlayerInfo _info;
    [SerializeField] private GameObject shop;
    [SerializeField] private GameObject train;
    [SerializeField] private GameObject Boss;

    [SerializeField] private Canvas canvas;
    [SerializeField] private AbilityUI _abUI;
    [SerializeField] private MainUi _main;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text.text = _info.val[0].value.ToString();
    }
    public void Gold()
    {
        text.text = _info.val[0].value.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnShopButton()
    {
        GameObject sh = Instantiate(shop, new Vector2(0, 0), Quaternion.identity);
        sh.transform.SetParent(canvas.transform, false);
        var s = sh.GetComponent<ShopUI>();
        s.InsertA(_abUI);
        s.InsertB(_main);

    }

    public void onExerciseButton()
    {
        if (_info.val[7].value != 0)
        {
            GameObject tr = Instantiate(train, new Vector2(0, 0), Quaternion.identity);
            tr.transform.SetParent(canvas.transform, false);
            var t = tr.GetComponent<ShopUI>();
        }
    }
    public void OnBossStage()
    {
        GameObject tr = Instantiate(Boss, new Vector2(0, 0), Quaternion.identity);
        tr.transform.SetParent(canvas.transform, false);
    }
}
