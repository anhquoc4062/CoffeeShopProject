package fpo.thanh.coffeeshop.presentation.ui.activity;

import android.os.Bundle;
import android.view.MenuItem;
import android.view.View;
import android.widget.TextView;

import androidx.annotation.Nullable;
import androidx.appcompat.app.AppCompatActivity;
import androidx.appcompat.widget.Toolbar;

import butterknife.BindView;
import butterknife.ButterKnife;
import fpo.thanh.coffeeshop.R;
import fpo.thanh.coffeeshop.domain.Room.AppDatabase;
import fpo.thanh.coffeeshop.presentation.ui.fragment.ListThucDocFragment;

public class SupportActivity extends AppCompatActivity implements View.OnClickListener {
    String maTang,tenBan;
    @BindView(R.id.toolBarSupportActivity)
    Toolbar toolbar;
    @BindView(R.id.tv_tenTang)
    TextView tv_tenTang;
    public AppDatabase mDB;
    @Override
    protected void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_holderfragment);
        ButterKnife.bind(this);
        tenBan=getIntent().getExtras().getString("tenBan");
        maTang=getIntent().getExtras().getString("maTang");
        setSupportActionBar(toolbar);
        getSupportActionBar().setTitle("");
        getSupportActionBar().setDisplayHomeAsUpEnabled(true);
        getSupportActionBar().setHomeAsUpIndicator(R.drawable.ic_arrow_back);
        tv_tenTang.setText(tenBan+" - Tầng "+maTang);
        mDB=AppDatabase.getDatabase(this);
        getSupportFragmentManager()
                .beginTransaction()
                .replace(R.id.layout_holder,new ListThucDocFragment())
                .addToBackStack("holder")
                .commit();
    }

    @Override
    public void onBackPressed() {
        if(getSupportFragmentManager().getBackStackEntryCount()>1) getSupportFragmentManager().popBackStack();
        else this.finish();
    }

    @Override
    protected void onDestroy() {
        super.onDestroy();
        mDB.close();
    }

    @Override
    public void onClick(View v) {
        switch (v.getId()){
                default:break;
        }
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        switch (item.getItemId()){
            case android.R.id.home:
                onBackPressed();
                break;
                default:break;
        }
        return true;
    }
}
