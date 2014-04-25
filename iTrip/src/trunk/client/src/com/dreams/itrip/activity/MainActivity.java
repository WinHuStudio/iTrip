package com.dreams.itrip.activity;

import synjones.common.utils.AdaptViewUitl;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.widget.LinearLayout.LayoutParams;
import android.widget.RadioButton;
import android.widget.RadioGroup;
import android.widget.RadioGroup.OnCheckedChangeListener;

import com.dreams.itrip.R;
import com.dreams.itrip.common.SuperFragmentActivity;
import com.dreams.itrip.fragment.CardMgrFragment;
import com.dreams.itrip.fragment.DemoFragment;
import com.dreams.itrip.fragment.SysConfigFragment;

public class MainActivity extends SuperFragmentActivity
{
	private String[] tab_text = { "校园卡管理", "转账充值", "通知消息", "系统设置" };
	private static int COUNT = 4;
	private int[] icon = { R.drawable.tab_icon_xyykt,
			R.drawable.tab_icon_autopay, R.drawable.tab_icon_notice,
			R.drawable.tab_icon_set };

	private RadioGroup rg_nav;

	@Override
	protected void onCreate(Bundle savedInstanceState)
	{

		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);
		setUpView();
		setListener();
		initRB(rg_nav, px_width);
		adapterView();
	}

	// @Override
	// public boolean onCreateOptionsMenu(Menu menu) {
	// // Inflate the menu; this adds items to the action bar if it is present.
	// getMenuInflater().inflate(R.menu.menu, menu);
	// return true;
	// }

	private void setUpView()
	{
		rg_nav = (RadioGroup) findViewById(R.id.rg_main_nav);
	}

	private void setListener()
	{

		rg_nav.setOnCheckedChangeListener(new RGOncheckedChangeListener());
	}

	private void initRB(RadioGroup rg, int px_width)
	{
		RadioGroup.LayoutParams params = new RadioGroup.LayoutParams(
				LayoutParams.WRAP_CONTENT, LayoutParams.WRAP_CONTENT);

		if (COUNT <= 4)
		{
			params.width = px_width / COUNT;
		} else
		{
			params.width = px_width / 4;
		}
		for (int i = 0; i < COUNT; i++)
		{
			RadioButton rb = (RadioButton) LayoutInflater.from(this).inflate(
					R.layout.rb, null);
			rb.setText(tab_text[i]);
			rb.setTextColor(getResources().getColor(R.color.white));
			rb.setShadowLayer(1, 0, 2, getResources().getColor(R.color.black80));
			AdaptViewUitl.AdaptDrawableImg(this, icon[i], AdaptViewUitl.TOP,
					rb, 76f, 78f);
			if (0 == i)
			{
				rb.setChecked(true);
			}
			rb.setId(i);
			rb.setLayoutParams(params);
			rg.addView(rb);
		}
	}

	private class RGOncheckedChangeListener implements OnCheckedChangeListener
	{

		@Override
		public void onCheckedChanged(RadioGroup group, int checkedId)
		{
			Bundle bundle = new Bundle();
			bundle.putInt("ID", checkedId);
			switch (checkedId)
			{

				case 0:
					pullFragment(R.id.ll_main_container, new CardMgrFragment(),
							bundle);
					break;
				case 1:
					pullFragment(R.id.ll_main_container, new DemoFragment(),
							bundle);
					break;
				case 2:
					break;
				case 3:
					pullFragment(R.id.ll_main_container,
							new SysConfigFragment(), bundle);
					break;

				default:
					break;
			}
		}
	}

}
