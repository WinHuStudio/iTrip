package com.dreams.itrip.service;

import android.app.Service;
import android.content.Intent;
import android.os.IBinder;
import android.util.Log;
import android.widget.Toast;

public class MyService extends Service
{
	private String Tag="MyService";
	@Override
	public IBinder onBind(Intent arg0)
	{
		Log.i(Tag, "onBind.................");
		Toast.makeText(MyService.this, "onBind", 0).show();
		return null;
	}
	@Override
	public void onCreate()
	{Log.i(Tag, "onCreate.................");
	Toast.makeText(MyService.this, "onCreate", 0).show();

	}
	@Override
	public int onStartCommand(Intent intent, int flags, int startId)
	{
		// TODO Auto-generated method stub
		Log.i(Tag, "onStartCommand.................");
		Toast.makeText(MyService.this, "onStartCommand", 0).show();
		return flags;
	}

	@Override
	public void onDestroy()
	{
		Log.i(Tag, "onDestroy.................");
		Toast.makeText(MyService.this, "onDestroy", 0).show();
	}
}
