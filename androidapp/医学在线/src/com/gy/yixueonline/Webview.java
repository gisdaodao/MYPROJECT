package com.gy.yixueonline;

import java.lang.reflect.Field;

import android.annotation.SuppressLint;
import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.webkit.WebSettings;
import android.webkit.WebView;
import android.webkit.WebViewClient;
import android.widget.ZoomButtonsController;

public class Webview extends Activity {
	private WebView wb;
	private Intent intent;
	private String site;
    @SuppressLint("SetJavaScriptEnabled") @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        intent = getIntent();
        site = intent.getStringExtra("site");
        wb = (WebView)findViewById(R.id.webView1);
        wb.setScrollBarStyle(View.SCROLLBARS_INSIDE_OVERLAY);
        WebSettings wbsSettings = wb.getSettings();
        wbsSettings.setJavaScriptEnabled(true);
        wbsSettings.setBuiltInZoomControls(true);   
        setZoomControlGone(wb);
        wb.loadUrl(site);
        wb.setWebViewClient(new WebViewClient());
    }
  	public void setZoomControlGone(View view) {
  		@SuppressWarnings("rawtypes")
		Class classType;
  		Field field;
  		try {
  			classType = WebView.class;
  			field = classType.getDeclaredField("mZoomButtonsController");
  			field.setAccessible(true);
  			ZoomButtonsController mZoomButtonsController = new ZoomButtonsController(view);
  			mZoomButtonsController.getZoomControls().setVisibility(View.GONE);
  			try {
  				field.set(view, mZoomButtonsController);
  			} catch (IllegalArgumentException e) {
  				e.printStackTrace();
  			} catch (IllegalAccessException e) {
  				e.printStackTrace();
  			}
  		} catch (SecurityException e) {
  			e.printStackTrace();
  		} catch (NoSuchFieldException e) {
  			e.printStackTrace();
  		}
  	}
}
