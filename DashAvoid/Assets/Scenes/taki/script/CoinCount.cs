using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

/*参考
  https://boccilog.wordpress.com/2016/09/12/todisplaynumberofimageasscore/
 */

public class CoinCount : MonoBehaviour
{
    public Sprite[] numimage;
    public List<int> number = new List<int>();
    private const int DeltX = 50;
    private void Start()
    {
        Draw();
    }

    void Draw()
    {
        int score = Coin.GetCoin();
        var digit = score;

        number = new List<int>();
        while (digit != 0)
        {
            score = digit % 10;
            digit = digit / 10;
            number.Add(score);
        }

        GameObject.Find("ScoreImg").GetComponent<Image>().sprite = numimage[number[0]];

        for (int i = 1; i < number.Count; i++)
        {
            
            RectTransform scoreimage = (RectTransform)Instantiate(GameObject.Find("ScoreImg")).transform;
            scoreimage.SetParent(this.transform, false);//複製している
            scoreimage.localPosition = new Vector2(
                scoreimage.localPosition.x - DeltX * i,
                scoreimage.localPosition.y);
            scoreimage.GetComponent<Image>().sprite = numimage[number[i]];
        }
    }
}
