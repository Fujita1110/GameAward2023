using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoreControllerCopy: MonoBehaviour
{
	CoreSettingCopy m_coreSetting;
	bool m_isStart;
	int m_freamCnt;

	// Start is called before the first frame update
	void Start()
	{
		m_coreSetting = GetComponent<CoreSettingCopy>();
		m_isStart = false;
		m_freamCnt = 0;
	}

	// Update is called once per frame
	void Update()
	{
		//--- 仮
		if (!m_isStart) return;

		m_freamCnt++;
		if (m_freamCnt > 600)	SceneManager.LoadScene("GameScene");
	}

	public void StartCore()
	{
		if (m_coreSetting.IsRotate()) return;

		m_coreSetting.CoreReady();	// コアセッティング内の設定をステージ用に

		foreach(Transform child in this.transform)
		{
			// ガラクタ以外をスルー
			if (child.transform.tag != "Junk") continue;

			// 全てのパーツをスタートさせる
			child.GetComponent<JunkController>().StartJunk();
		}

		m_coreSetting.enabled = false;	// コアのセッティングを無効化

		m_isStart = true;
	}

	public CoreSettingCopy CoreSetting
	{
		get { return m_coreSetting; }
	}
}