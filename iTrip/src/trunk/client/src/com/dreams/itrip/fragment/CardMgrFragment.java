package com.dreams.itrip.fragment;

import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import com.dreams.itrip.R;
import com.dreams.itrip.common.SuperFragment;

public class CardMgrFragment extends SuperFragment {
	private View view;


	@Override
	public View onCreateView(LayoutInflater inflater, ViewGroup container,
			Bundle savedInstanceState) {
		// TODO Auto-generated method stub
		view = inflater.inflate(R.layout.fragment_cardmanage, null);
		return view;
		// return super.onCreateView(inflater, container, savedInstanceState);
	}
}
