package com.gy.yixueonline;

import android.annotation.SuppressLint;
import android.content.Context;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.ImageView;
import android.widget.TextView;

public class Gridviewadapter extends BaseAdapter {
	private Context mContext;
	private String[] name;

	public Gridviewadapter(Context context, String[] tmpfilelist) {
		// TODO Auto-generated constructor stub
		mContext = context;
		name = tmpfilelist;
	}

	
	@Override
	public int getCount() {
		// TODO Auto-generated method stub
		return name.length;
	}

	@Override
	public Object getItem(int position) {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public long getItemId(int position) {
		// TODO Auto-generated method stub
		return 0;
	}

	@SuppressLint({ "InflateParams", "ViewHolder" })
	@Override
	public View getView(int position, View convertView, ViewGroup parent) {
		View view = View.inflate(mContext, R.layout.gridview, null);
		TextView title = (TextView) view.findViewById(R.id.name);
		title.setText(name[position]);
		ImageView imageView = (ImageView) view.findViewById(R.id.coverimg);
		imageView.setImageResource(R.drawable.medic);
		return view;
	}
	
}
