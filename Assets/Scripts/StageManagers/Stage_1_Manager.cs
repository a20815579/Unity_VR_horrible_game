using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Stage_1_Manager : StageManager
{
    /*場景1：944
第一章： 祭
玩家在宿舍內聽到怪聲
OS：是風聲嗎...？去關個窗戶好了
面對窗戶，目睹學生跳樓
(彈出對話框，音效)
未知1：...啊！有人從頂樓跳下來！！
未知2：他...他的......頭...呢？
未知3：這衣服是...學...學長？！矛求學長？！
(往桌上看)
桌面浮出血字「你必須調查真相...不然下一個人...就是你...」
OS：為...為什麼我的桌面會跑出這個？！天哪...怎麼會這樣...好害怕...
不然我先照著上面的指示做好了...那位學長好像是住844，去問問看他的室友，看會不會有什麼線索
*/
    public override void SetupEvents()
    {
        Debug.Log("Stage 1 event setup");
        
        /* add event-triggered functions to delegate list */
        AddEvent(0, ShowItemImage); //click window
        
    }

    private void CustomFunction()
    {
        //do something
    }
}
