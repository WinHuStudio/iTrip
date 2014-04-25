package com.dreams.itrip.notification;

import android.app.Notification;
import android.app.NotificationManager;
import android.app.PendingIntent;
import android.content.Context;
import android.content.Intent;

public class MyNotification
{
	private static NotificationManager nm;
	private static Notification n;

	public static void CreateNotification(Context context, Class<?> toActivity,
			int ID, String tickerText, int icon, String title, String content)
	{
		// 1.获取NotificationManager对象
		nm = (NotificationManager) context
				.getSystemService(context.NOTIFICATION_SERVICE);
		Notification n = new Notification();
		// 2.初始化Notification对象
		// |Notification.DEFAULT_LIGHTS|Notification.FLAG_AUTO_CANCEL
		n.defaults = Notification.DEFAULT_SOUND;
		n.defaults |= Notification.DEFAULT_LIGHTS;
		// n.defaults|=Notification.FLAG_AUTO_CANCEL;
		// n.flags = Notification.FLAG_ONGOING_EVENT;
		n.flags |= Notification.FLAG_AUTO_CANCEL;
		// 设置通知的icon
		n.icon = icon;
		// 设置通知在状态栏上显示的滚动信息
		// n.tickerText = "一个通知";
		n.tickerText = tickerText;
		// 设置通知的时间
		n.when = System.currentTimeMillis();
		Intent intent = new Intent(context, toActivity);
		intent.putExtra("id", ID);
		PendingIntent pi = PendingIntent.getActivity(context, 0, intent, 0);
		n.setLatestEventInfo(context, title, content, pi);

		// 4.发送通知
		nm.notify(ID, n);
	}
}
