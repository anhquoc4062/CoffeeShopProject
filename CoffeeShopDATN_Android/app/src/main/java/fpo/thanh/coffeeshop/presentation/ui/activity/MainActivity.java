package fpo.thanh.coffeeshop.presentation.ui.activity;

import android.app.Activity;
import android.content.Context;
import android.os.Bundle;
import android.os.CountDownTimer;
import android.os.StrictMode;
import android.util.Log;
import android.view.Menu;
import android.view.View;
import android.view.animation.Animation;
import android.view.animation.AnimationUtils;
import android.view.inputmethod.InputMethodManager;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

import androidx.appcompat.app.AppCompatActivity;
import androidx.appcompat.widget.Toolbar;
import androidx.core.view.GravityCompat;
import androidx.drawerlayout.widget.DrawerLayout;
import androidx.viewpager.widget.ViewPager;

import com.google.android.material.appbar.CollapsingToolbarLayout;
import com.google.android.material.tabs.TabLayout;

import butterknife.BindView;
import butterknife.ButterKnife;
import fpo.thanh.coffeeshop.R;
import fpo.thanh.coffeeshop.domain.Room.AppDatabase;
import fpo.thanh.coffeeshop.domain.executor.impl.ThreadExecutor;
import fpo.thanh.coffeeshop.domain.repository.Impl.GetAllDataRepositoryImpl;
import fpo.thanh.coffeeshop.presentation.presenter.GetAllDataPresenter;
import fpo.thanh.coffeeshop.presentation.presenter.TestPresenter;
import fpo.thanh.coffeeshop.presentation.presenter.impl.GetAllDataPresenterImpl;
import fpo.thanh.coffeeshop.presentation.presenter.impl.TestPresenterImpl;
import fpo.thanh.coffeeshop.presentation.ui.adapter.TabLayoutAdapter;
import fpo.thanh.coffeeshop.presentation.ui.fragment.HomeFragment;
import fpo.thanh.coffeeshop.presentation.ui.fragment.ListBookedFragment;
import fpo.thanh.coffeeshop.presentation.ui.fragment.ListBookingFragment;
import fpo.thanh.coffeeshop.presentation.ui.fragment.ListTableFragment;
import fpo.thanh.coffeeshop.shareModel.ResultModel;
import fpo.thanh.coffeeshop.shareModel.TestModel;
import fpo.thanh.coffeeshop.storage.TestRepositoryImpl;
import fpo.thanh.coffeeshop.storage.savePreference.CacheClient;
import fpo.thanh.coffeeshop.threading.MainThreadImpl;

public class MainActivity extends AppCompatActivity {

    @BindView(R.id.tabLayout)
    TabLayout tabLayout;
    @BindView(R.id.viewpager)
    ViewPager viewPager;
    @BindView(R.id.toolbar)
    Toolbar toolbar;
    @BindView(R.id.edt_searchProduct)
    EditText edt_searchProduct;
    @BindView(R.id.tv_brand)
    TextView tv_brand;
    public AppDatabase mDB;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        ButterKnife.bind(this);
        setSupportActionBar(toolbar);
        setupPager(viewPager,tabLayout);
        mDB=AppDatabase.getDatabase(this);
        edt_searchProduct.setOnFocusChangeListener(new View.OnFocusChangeListener() {
            @Override
            public void onFocusChange(View v, boolean hasFocus) {
                if(!hasFocus)  hideKeyboardFrom(MainActivity.this,v);

            }
        });
        if (android.os.Build.VERSION.SDK_INT > 9)
        {
            StrictMode.ThreadPolicy policy = new
                    StrictMode.ThreadPolicy.Builder().permitAll().build();
            StrictMode.setThreadPolicy(policy);
        }

    }


    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        getMenuInflater().inflate(R.menu.home, menu);
        return  true;
    }

    void setupPager(ViewPager viewPager, TabLayout tabLayout) {
        TabLayoutAdapter adapter = new TabLayoutAdapter(getSupportFragmentManager());
        adapter.addFragment(new HomeFragment(), "Home");
        adapter.addFragment(new ListTableFragment(), "Tables");
        adapter.addFragment(new ListBookingFragment(), "Booking");
        adapter.addFragment(new ListBookedFragment(), "Booked");
        viewPager.setAdapter(adapter);



        tabLayout.setupWithViewPager(viewPager, true);
        int[] tabIcons = {
                R.drawable.ic_news,
                R.drawable.ic_coffeecup,
                R.drawable.ic_coffeewaiting,
                R.drawable.ic_complete,
        };
        tabLayout.getTabAt(0).setIcon(tabIcons[0]);
        tabLayout.getTabAt(1).setIcon(tabIcons[1]);
        tabLayout.getTabAt(2).setIcon(tabIcons[2]);
        tabLayout.getTabAt(3).setIcon(tabIcons[3]);
        viewPager.addOnPageChangeListener(new ViewPager.OnPageChangeListener() {
            @Override
            public void onPageScrolled(int position, float positionOffset, int positionOffsetPixels) {

            }

            @Override
            public void onPageSelected(int position) {
                switch (position){
                    case 0:
                        tv_brand.setVisibility(View.VISIBLE);
                        Animation a = AnimationUtils.loadAnimation(MainActivity.this, R.anim.anim_textview);
                        a.reset();
                        tv_brand.clearAnimation();
                        tv_brand.startAnimation(a);

                        break;
                    case 1:
                        tv_brand.setVisibility(View.GONE);
                        break;
                    case 2:
                        tv_brand.setVisibility(View.GONE);
                        break;
                    case 3:
                        tv_brand.setVisibility(View.GONE);
                        break;
                        default: break;
                }
            }

            @Override
            public void onPageScrollStateChanged(int state) {

            }
        });
    }

    public void moveToPositionViewpager(int position){
        viewPager.setCurrentItem(position,true);
    }
    public static void hideKeyboardFrom(Context context, View view) {
        InputMethodManager imm = (InputMethodManager) context.getSystemService(Activity.INPUT_METHOD_SERVICE);
        imm.hideSoftInputFromWindow(view.getWindowToken(), 0);
    }

    int d=0;
    @Override
    public void onBackPressed() {
           /* if (drawer.isDrawerOpen(GravityCompat.START)) {
                drawer.closeDrawer(GravityCompat.START);
            } else {
                super.onBackPressed();
            }*/


        if (viewPager.getCurrentItem()!=0) {
            viewPager.setCurrentItem(0,true);
        } else {


            if (getFragmentManager().getBackStackEntryCount() > 1) {
                getFragmentManager().popBackStack();
                d=0;
            } else {//nhan lan nua de thoat
                d++;
            }

            if(d==1){
                Toast.makeText(this, "Nhấn lần nữa để thoát!", Toast.LENGTH_SHORT).show();
                CountDownTimer timer=new CountDownTimer(2000,1000) {
                    @Override
                    public void onTick(long l) {

                    }

                    @Override
                    public void onFinish() {
                        d=0;
                    }
                }.start();
            }
            if(d==2){
                    /*Intent i = new Intent(MainActivity.this,AuthorizeActivity.class);
                    startActivity(i);*/
                finish();
                // super.onBackPressed();
            }

        }
    }

}
