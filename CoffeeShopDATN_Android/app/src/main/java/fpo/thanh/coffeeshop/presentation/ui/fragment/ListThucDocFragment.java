package fpo.thanh.coffeeshop.presentation.ui.fragment;

import android.content.Context;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import java.util.ArrayList;
import java.util.List;

import butterknife.BindView;
import butterknife.ButterKnife;
import fpo.thanh.coffeeshop.R;
import fpo.thanh.coffeeshop.domain.Room.RoomModel.ThucDon;
import fpo.thanh.coffeeshop.presentation.ui.activity.SupportActivity;
import fpo.thanh.coffeeshop.presentation.ui.adapter.ListThucDonAdapter;

public class ListThucDocFragment extends Fragment {
    @BindView(R.id.rcv_listThucDon)
    RecyclerView rcv_listThucDon;
    SupportActivity activity;
    List<ThucDon> listData=new ArrayList<>();
    ListThucDonAdapter adapter;
    @Override
    public void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        adapter=new ListThucDonAdapter(activity,listData);
    }

    @Nullable
    @Override
    public View onCreateView(@NonNull LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {
        return inflater.inflate(R.layout.fragment_listthucdon,container,false);
    }

    @Override
    public void onViewCreated(@NonNull View view, @Nullable Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);
        ButterKnife.bind(this,view);
        setUpRcv();
    }

    @Override
    public void onAttach(Context context) {
        super.onAttach(context);
        activity=(SupportActivity)context;
    }
    private void setUpRcv(){
        listData.clear();
        listData.addAll(activity.mDB.thucDonDAO().getAllThucDon());
        rcv_listThucDon.setLayoutManager(new LinearLayoutManager(activity));
        rcv_listThucDon.setAdapter(adapter);
    }
}
