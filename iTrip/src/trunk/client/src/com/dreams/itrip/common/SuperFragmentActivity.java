package com.dreams.itrip.common;

import synjones.common.utils.AdaptViewUitl;
import synjones.common.utils.ScreenSizeUtil;
import android.os.Bundle;
import android.support.v4.app.FragmentActivity;
import android.support.v4.app.FragmentTransaction;
import android.widget.ImageButton;
import android.widget.ImageView;
import android.widget.LinearLayout;

import com.dreams.itrip.R;

public class SuperFragmentActivity extends FragmentActivity
{
	private ImageButton ib_back;
	private ImageButton ib_type;
	private ImageView iv_icon;
	private ImageView iv_title;
	private LinearLayout ll_imgbg;
	protected int px_height;
	protected int px_width;

	protected void adapterView()
	{
		// if (isAdaptMore)
		// {
		//
		// iv_icon = (ImageView) findViewById(R.id.iv_header_function_icon);
		//
		//
		// AdaptViewUitl.AdaptSmallView(this, iv_icon, 268, 273.0f,
		// "LinearLayout");
		// }
		iv_title = (ImageView) findViewById(R.id.iv_header_title);
		// ib_back = (ImageButton) findViewById(R.id.ib_header_back);
		// ib_type = (ImageButton) findViewById(R.id.ib_header_type);

		AdaptViewUitl
				.AdaptHugeView(this, iv_title, 992f, 137.0f, "FrameLayout");
		// AdaptViewUitl.AdaptSmallView(this, ib_back, 76, 55.0f,
		// "LinearLayout");
		// AdaptViewUitl.AdaptSmallView(this, ib_type, 66, 67.0f,
		// "LinearLayout");
	}

	@Override
	protected void onCreate(Bundle paramBundle)
	{
		super.onCreate(paramBundle);
		int[] arrayOfInt = ScreenSizeUtil.getScreenSize(this);
		this.px_width = arrayOfInt[0];
		this.px_height = arrayOfInt[1];
	}

	protected void pullFragment(int paramInt, SuperFragment paramSuperFragment,
			Bundle paramBundle)
	{
		FragmentTransaction localFragmentTransaction = getSupportFragmentManager()
				.beginTransaction();
		paramSuperFragment.setArguments(paramBundle);
		localFragmentTransaction.replace(paramInt, paramSuperFragment);
		localFragmentTransaction.commit();
	}
}
