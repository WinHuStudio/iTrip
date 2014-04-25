package com.dreams.itrip.service;

import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.widget.Toast;

public class MyReceiver extends BroadcastReceiver
{
	// 广播接收者
	@Override
	public void onReceive(Context arg0, Intent arg1)
	{
		// TODO Auto-generated method stub
		String msgString = arg1.getStringExtra("msg");
		Toast.makeText(arg0, msgString, 1).show();
	}

}
