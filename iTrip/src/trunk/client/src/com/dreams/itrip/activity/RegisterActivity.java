package com.dreams.itrip.activity;

import android.os.Bundle;
import android.widget.Button;
import android.widget.EditText;

import com.dreams.itrip.R;
import com.dreams.itrip.common.SuperActivity;

public class RegisterActivity extends SuperActivity
{
	private EditText edt_username;
	private EditText edt_password;
	private Button btn_register;

	@Override
	protected void onCreate(Bundle savedInstanceState)
	{
		// TODO Auto-generated method stub
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_register);
	}

	private void SetUpView()
	{
		edt_password = (EditText) this.findViewById(R.id.edt_password);
		edt_username = (EditText) this.findViewById(R.id.edt_username);
		btn_register = (Button) this.findViewById(R.id.btn_register);
	}
}
