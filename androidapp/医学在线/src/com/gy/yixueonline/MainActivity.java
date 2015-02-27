package com.gy.yixueonline;

import com.qq.e.ads.AdListener;
import com.qq.e.ads.AdRequest;
import com.qq.e.ads.AdSize;
import com.qq.e.ads.AdView;
import com.qq.e.appwall.GdtAppwall;
import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.view.Menu;
import android.view.View;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemClickListener;
import android.widget.GridView;
import android.widget.RelativeLayout;

public class MainActivity extends Activity {
    private GridView gridView;
    private AdView bannerAD;
	private RelativeLayout bannerContainer;
    private String[] sites = {"http://hms.harvard.edu/news/all-news","http://www.medical-science.com/", "http://www.ama-assn.org/ama/home.page?", "http://www.news-medical.net/category/Medical-Science-News.aspx  ","http://www.cdc.gov/", "http://www.who.int/en/", "http://www.thelancet.com/","http://www.thelancet.com/","http://jama.jamanetwork.com/journal.aspx","http://www.cmt.com.cn/", "http://weibo.com/quankeyixue",  "http://weibo.com/quankeyixue", "http://www.haodf.com/","http://m.51daifu.com/", "http://m.iiyi.com/", "http://zh.wikipedia.org/wiki/Category:%E5%8C%BB%E5%AD%A6","http://3g.dxy.cn/","http://m.med66.com/ ","http://m.37med.com/ ","http://3g.xywy.com/ ","http://www.a-hospital.com/","http://xueshu.baidu.com/","http://wk.baidu.com/search?word=%E4%B8%B4%E5%BA%8A%E5%8C%BB%E5%AD%A6"};
    private String[] names = {"Harvard Medical School", "medical-science", "American Medical Association", "news-medical.net","cdc","who","��Ҷ��", " thelancet", "bmj", "jama","�й�ҽѧ��̳", "ȫ��ҽѧ","�ô������", "ҽ������","����ҽ", "wikiҽѧ�ٿ�","����3G","ҽѧ������","37��ҽѧ","Ѱҽ��ҩ��","A+ҽѧ�ٿ�","�ٶ�ѧ��","�ٶ��Ŀ�"};
    @SuppressWarnings("deprecation")
	protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_webview);
        this.bannerContainer = (RelativeLayout) this.findViewById(R.id.bannercontainer);
        gridView = (GridView)findViewById(R.id.gridView1);
        gridView.setAdapter(new Gridviewadapter(this, names));
        GdtAppwall.init(this, "1104294446","5010108185921218");
        showBannerAD();
        gridView.setOnItemClickListener(new OnItemClickListener() {

			@Override
			public void onItemClick(AdapterView<?> parent, View view,
					int position, long id) {
				// TODO Auto-generated method stub
				GdtAppwall.showAppwall();
				Intent intent = new Intent(MainActivity.this, Webview.class);
				intent.putExtra("site", sites[position]);
				startActivity(intent);
			}
		});
    }
    protected void onResume() {
		super.onResume();
		this.showBannerAD();
	}

	private void showBannerAD() {
		this.bannerAD = new AdView(this, AdSize.BANNER, "1104294446", "2070907155721299");
		this.bannerAD.setAdListener(new AdListener() {
          
          @Override
          public void onNoAd() {
            Log.i("admsg:","Banner AD LoadFail");
          }
          
          @Override
          public void onBannerClosed() {
            //���ڿ������ͨ���رհ�ťʱ��Ч
            Log.i("admsg:","Banner AD Closed");
          }
          
          @Override
          public void onAdReceiv() {
            Log.i("admsg:","Banner AD Ready to show");
          }
          
          @Override
          public void onAdExposure() {
            Log.i("admsg:","Banner AD Exposured");
          }
          
          @Override
          public void onAdClicked() {
          //Banner��淢�����ʱ�ص������ڵ��ȥ�ص����ز��ܱ�֤�ص���������������ͳ������һ��
            Log.i("admsg:","Banner AD Clicked");
          }
        });
		//this.bannerContainer.removeAllViews();
		this.bannerContainer.addView(bannerAD);
		AdRequest adRequest = new AdRequest();
		adRequest.setRefresh(30);
		adRequest.setTestAd(true);
		adRequest.setShowCloseBtn(true);
		bannerAD.fetchAd(adRequest);
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// getMenuInflater().inflate(R.menu.banner_demo, menu);
		return true;
	}
}
