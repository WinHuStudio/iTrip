package com.dreams.itrip.activity;

import synjones.common.extension.StringUtil;
import synjones.common.utils.MyActivityManager;
import synjones.common.utils.SharePreferenceUtil;
import android.app.AlertDialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.os.Bundle;
import android.os.Handler;
import android.os.Message;
import android.widget.Toast;

import com.dreams.itrip.R;
import com.dreams.itrip.common.SuperActivity;
import com.dreams.itrip.utils.Const;

public class WelcomeActivity extends SuperActivity
{
	private static final int MSG_FAILURE = 1;
	private static final int MSG_SUCCESS=0;
	private final Handler handler = new Handler()
	{
		@Override
		public void handleMessage(Message paramMessage)
		{
			switch (paramMessage.what)
			{
				default:
					showGetDataFail();
					return;
				case 0:
					Intent intent;
					if (!isShowGuidImg())
					{
						intent= new Intent(WelcomeActivity.this, GuideActivity.class);
					}else {
						intent = new Intent(WelcomeActivity.this, MainActivity.class);
					}
					startActivity(intent);
					finish();
					return;
				case 1:
			}
			if (!StringUtil.isNullOrEmpty(showMessage))
				Toast.makeText(WelcomeActivity.this, showMessage, 1).show();
			showGetDataFail();
		}
	};
	private final Runnable runnable = new Runnable()
	{
		@Override
		public void run()
		{
			handler.obtainMessage(MSG_SUCCESS).sendToTarget();
		}
	};
	private String showMessage = "";
	private Thread thread;
	@Override
	protected void onCreate(Bundle paramBundle)
	{
		super.onCreate(paramBundle);
		setContentView(R.layout.activity_welcome);
		MyActivityManager.getInstance().addActivity(this);
		init();
	}
	private void init()
	{
		if (isNetWorkConnected())
		{
			if (thread == null)
			{
				thread = new Thread(runnable);
				thread.start();
			}
			return;
		}
		showSetNetworkDialog();
	}

	private boolean isShowGuidImg()
	{
		return new SharePreferenceUtil(this, Const.sharePreferenceName).loadBooleanSharedPreference(Const.isSecondComing);
	}

	private void showGetDataFail()
	{
		AlertDialog.Builder localBuilder = new AlertDialog.Builder(this);
		localBuilder.setTitle("获取网络数据");
		localBuilder.setMessage("获取网络数据失败，请查看您的手机网络是否通畅");
		localBuilder.setPositiveButton("确定", new DialogInterface.OnClickListener()
		{
			@Override
			public void onClick(DialogInterface paramDialogInterface, int paramInt)
			{
				Intent localIntent = new Intent("android.settings.WIRELESS_SETTINGS");
				startActivity(localIntent);
				finish();
			}
		});
		localBuilder.create().show();
	}

	private void showSetNetworkDialog()
	{
		AlertDialog.Builder localBuilder = new AlertDialog.Builder(this);
		localBuilder.setTitle("设置网络");
		localBuilder.setMessage("网络错误请检查网络状态");
		localBuilder.setPositiveButton("设置网络", new DialogInterface.OnClickListener()
		{
			@Override
			public void onClick(DialogInterface paramDialogInterface, int paramInt)
			{
				Intent localIntent = new Intent("android.settings.WIRELESS_SETTINGS");
				startActivity(localIntent);
				finish();
			}
		});
		localBuilder.setNeutralButton("取消", new DialogInterface.OnClickListener()
		{
			@Override
			public void onClick(DialogInterface paramDialogInterface, int paramInt)
			{
				finish();
			}
		});
		localBuilder.create().show();
	}


}