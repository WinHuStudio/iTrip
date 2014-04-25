package com.dreams.itrip.activity;

import java.util.ArrayList;
import java.util.List;

import synjones.common.utils.SharePreferenceUtil;
import android.content.Context;
import android.content.Intent;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.graphics.BitmapFactory.Options;
import android.graphics.drawable.BitmapDrawable;
import android.os.Bundle;
import android.support.v4.view.PagerAdapter;
import android.support.v4.view.ViewPager;
import android.support.v4.view.ViewPager.OnPageChangeListener;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.ViewGroup;
import android.view.WindowManager;
import android.widget.Button;
import android.widget.ImageView;

import com.dreams.itrip.R;
import com.dreams.itrip.common.SuperActivity;
import com.dreams.itrip.utils.Const;

/**
 * * TODO: * @author xl
 * 
 * @version 1.0, 2013-9-2/下午6:55:53
 * */
public class GuideActivity extends SuperActivity
{
	private ViewPager vp;
	private Button bt;
	private int[] guideImgs =
		{ R.drawable.guide1, R.drawable.guide2, R.drawable.guide3 };
	private int windowWidth;
	private int windowHeight;


	@Override
	protected void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_guide);

		// 获取屏幕的宽高
		WindowManager wm = (WindowManager) getSystemService(Context.WINDOW_SERVICE);
		windowWidth = wm.getDefaultDisplay().getWidth();
		windowHeight = wm.getDefaultDisplay().getHeight();

		// 初始化布局中的组件
		setUpView();

		// 为该布局中的组件添加监听事件
		setListener();

		// 初始化页面
		init();
		setIsSecondComing();

	}

	private void setIsSecondComing()
	{
		SharePreferenceUtil util=new SharePreferenceUtil(GuideActivity.this, Const.sharePreferenceName);
		util.saveSharedPreferences(Const.isSecondComing, true);
	}

	/**
	 * Description:初始化布局中的组件
	 * 
	 * @author pjc
	 * @Create at: 2013-9-3 下午5:37:28
	 */
	private void setUpView()
	{
		vp = (ViewPager) findViewById(R.id.vp_guide_viewpager);
		bt = (Button) findViewById(R.id.bt_guide_button);

	}

	/**
	 * Description:初始化页面
	 * 
	 * @author pjc
	 * @Create at: 2013-9-3 下午5:38:27
	 */
	private void setListener()
	{

		// TODO Auto-generated method stub

	}

	/**
	 * Description:为该布局中的组件添加监听事件
	 * 
	 * @author pjc
	 * @Create at: 2013-9-3 下午5:38:31
	 */
	private void init()
	{
		// final List<Bitmap> list_bitmap = myApplication.bitmap_list;
		final List<Bitmap> list_bitmap = getGuideImg();

		if (list_bitmap != null && list_bitmap.size() == 1)
		{
			ImageView iv = (ImageView) findViewById(R.id.iv_guide_one_image);
			iv.setVisibility(View.VISIBLE);
			iv.setImageBitmap(list_bitmap.get(0));
			btClick();
		} else if (list_bitmap != null && list_bitmap.size() > 1)
		{

			MyVPadapter adapter = new MyVPadapter(this, list_bitmap);
			vp.setAdapter(adapter);

			vp.setOnPageChangeListener(new OnPageChangeListener()
			{

				@Override
				public void onPageSelected(int arg0)
				{
					System.out.println("位置是===========" + arg0 + "  list_fl  " + list_bitmap.size());
					int oldPostion = 0;

					if (arg0 == (list_bitmap.size() - 1))
					{
						System.out.println("我执行了===============");
						btClick();

					} else
					{
						if (bt.VISIBLE == View.VISIBLE)
						{
							bt.setVisibility(View.GONE);
						}
					}
				}

				@Override
				public void onPageScrolled(int arg0, float arg1, int arg2)
				{

				}

				@Override
				public void onPageScrollStateChanged(int arg0)
				{

				}
			});
		}
	}

	private List<Bitmap> getGuideImg()
	{
		List<Bitmap> list = new ArrayList<Bitmap>();

		BitmapFactory.Options opts = new Options();
		opts.inJustDecodeBounds = true;
		for (int i = 0; i < guideImgs.length; i++)
		{
			BitmapFactory.decodeResource(getResources(), guideImgs[i], opts);

			int imageWidth = opts.outWidth;
			int imageHeight = opts.outHeight;

			int scaleX = imageWidth / windowWidth;
			int scaleY = imageHeight / windowHeight;
			int scale = 1;
			if (scaleX >= scaleY && scaleY >= 1)
			{
				scale = scaleX;
			}
			if (scaleY >= scaleX && scaleX >= 1)
			{
				scale = scaleY;
			}
			opts.inJustDecodeBounds = false;
			opts.inSampleSize = scale;

			Bitmap bitmap = BitmapFactory.decodeResource(getResources(), guideImgs[i], opts);
			list.add(bitmap);
		}
		return list;
	}

	private class MyVPadapter extends PagerAdapter
	{

		private List<Bitmap> list;
		private Context context;
		private ArrayList<ImageView> iv_list;

		// private List<ImageView> iv_list;

		public MyVPadapter(Context context, List<Bitmap> list)
		{
			this.context = context;
			this.list = list;
			initVP();
		}

		/**
		 * Description:
		 * 
		 * @author pjc
		 * @Create at: 2013-9-2 上午11:32:40
		 */
		private void initVP()
		{
			iv_list = new ArrayList<ImageView>();
			for (int i = 0; i < list.size(); i++)
			{
				ImageView iv = new ImageView(context);
				BitmapDrawable bd = new BitmapDrawable(list.get(i));
				iv.setBackgroundDrawable(bd);
				iv_list.add(iv);
			}

		}

		@Override
		public int getCount()
		{
			return list.size();
		}

		@Override
		public boolean isViewFromObject(View arg0, Object arg1)
		{

			return arg0 == arg1;
		}

		@Override
		public void destroyItem(ViewGroup container, int position, Object object)
		{

			container.removeView(iv_list.get(position));
		}

		@Override
		public Object instantiateItem(ViewGroup container, int position)
		{
			container.addView(iv_list.get(position));

			return iv_list.get(position);

		}

	}

	public void btClick()
	{
		bt.setVisibility(View.VISIBLE);
		bt.setOnClickListener(new OnClickListener()
		{

			@Override
			public void onClick(View v)
			{

				Intent intent = new Intent(GuideActivity.this, MainActivity.class);
				startActivity(intent);
				GuideActivity.this.finish();
				bt.setVisibility(View.GONE);
			}
		});

	}

}
