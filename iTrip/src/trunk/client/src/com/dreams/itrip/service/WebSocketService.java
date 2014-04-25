package com.dreams.itrip.service;

import de.tavendo.autobahn.WebSocketConnection;
import de.tavendo.autobahn.WebSocketHandler;

public class WebSocketService
{
	private WebSocketConnection connection;

	public void DoConnection(String serverUrl)
	{
		connection=new WebSocketConnection();
		try
		{
			connection.connect(serverUrl, new WebSocketHandler(){
				@Override
				public void onOpen()
				{
					//第一次建立连接时使用
					super.onOpen();
				}

				@Override
				public void onClose(int code, String reason)
				{
					//断开连接时回调
					super.onClose(code, reason);
				}

				@Override
				public void onBinaryMessage(byte[] payload)
				{
					//接收到信息时回调
					super.onBinaryMessage(payload);
				}
			});
		} catch (Exception e)
		{
			// TODO: handle exception
		}
	}

}
