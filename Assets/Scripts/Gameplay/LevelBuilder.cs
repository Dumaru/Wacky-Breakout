using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LevelBuilder : MonoBehaviour
{
    [SerializeField]
    private GameObject paddlePrefab;

    [SerializeField]
    private GameObject standarBlockPrefab;
    [SerializeField]
    private GameObject bonusBlockPrefab;
    [SerializeField]
    private GameObject pickupBlockPrefab;

    float blockWidth;
    float blockHeight;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(paddlePrefab);
        GameObject tempBlock = Instantiate(standarBlockPrefab);
        blockWidth = tempBlock.transform.localScale.x;
        blockHeight = tempBlock.transform.localScale.y;
        Destroy(tempBlock);
        BuildBlockRows();
    }

    private void BuildBlockRows()
    {
        float standarBlocksSpace = (Mathf.Abs(ScreenUtils.ScreenLeft) + Mathf.Abs(ScreenUtils.ScreenRight)) / blockWidth;
        int blocksAmount = Mathf.FloorToInt(standarBlocksSpace);
        float xStartOffset = (standarBlocksSpace - blocksAmount);
        float xLeftPoint = ScreenUtils.ScreenLeft + Mathf.Abs(xStartOffset) + blockWidth / 2;
        float x = xLeftPoint;
        float y = ScreenUtils.ScreenTop - ScreenUtils.ScreenTop / 5;
        Debug.Log("x " + x + " y " + y + " blocks " + blocksAmount + " x offset " + xStartOffset + "\n");
        for (int i = 0; i < 3; ++i)
        {
            for (int j = 0; j < blocksAmount; ++j)
            {
                PlaceBlock(x, y);
                x += blockWidth;
            }
            y -= blockHeight;
            x = xLeftPoint;
        }

    }
    private void PlaceBlock(float x, float y)
    {

        GameObject tempBlock = Instantiate(pickupBlockPrefab, new Vector3(x, y, 0f), Quaternion.identity);
        tempBlock.GetComponent<PickupBlock>().EffectKind = PickupEffect.Speedup;

        /*
        float randomNumber = Random.Range(0,100);
        if(randomNumber < ConfigurationUtils.FreezerBlockProbability){
            GameObject tempBlock = Instantiate(pickupBlockPrefab, new Vector3(x, y, 0f), Quaternion.identity);
            tempBlock.GetComponent<PickupBlock>().EffectKind = PickupEffect.Freezer;

        }else if(randomNumber < ConfigurationUtils.SpeedUpBlockProbability){
            GameObject tempBlock = Instantiate(pickupBlockPrefab, new Vector3(x, y, 0f), Quaternion.identity);
            tempBlock.GetComponent<PickupBlock>().EffectKind = PickupEffect.Speedup;

        }else if(randomNumber < ConfigurationUtils.BonusBlockPoints){
            GameObject tempBlock = Instantiate(bonusBlockPrefab, new Vector3(x, y, 0f), Quaternion.identity);

        }else{
            GameObject tempBlock = Instantiate(standarBlockPrefab, new Vector3(x, y, 0f), Quaternion.identity);
        }
        */
    }
}
