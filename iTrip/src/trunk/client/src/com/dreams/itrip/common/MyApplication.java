package com.dreams.itrip.common;

import java.util.HashMap;

import android.app.Application;

public class MyApplication extends Application {

	private final HashMap<String, Object> map = new HashMap<String, Object>();

	public static int feeType_lv_clickPosition = 0;
	public static boolean isFirstEnterFeeQuery = true;
	public static boolean isNeedRestart = false;
	public static String myFuncString;

	public void put(String key, Object object) {
		map.put(key, object);
	}

	public Object get(String key) {
		return map.get(key);
	}

}
