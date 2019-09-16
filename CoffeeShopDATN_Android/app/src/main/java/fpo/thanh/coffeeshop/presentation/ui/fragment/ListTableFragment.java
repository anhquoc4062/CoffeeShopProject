package fpo.thanh.coffeeshop.presentation.ui.fragment;

import android.content.Context;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;
import androidx.recyclerview.widget.GridLayoutManager;
import androidx.recyclerview.widget.RecyclerView;
import androidx.swiperefreshlayout.widget.SwipeRefreshLayout;

import java.util.ArrayList;
import java.util.List;

import butterknife.BindView;
import butterknife.ButterKnife;
import fpo.thanh.coffeeshop.R;
import fpo.thanh.coffeeshop.domain.Room.AppDatabase;
import fpo.thanh.coffeeshop.domain.Room.RoomModel.BanAn;
import fpo.thanh.coffeeshop.presentation.ui.activity.MainActivity;
import fpo.thanh.coffeeshop.presentation.ui.adapter.ItemOffsetDecoration;
import fpo.thanh.coffeeshop.presentation.ui.adapter.ListTableAdapter;

public class ListTableFragment extends Fragment {
    @BindView(R.id.rcv_listTable)
    RecyclerView rcv_listTable;
    @BindView(R.id.swipeRefreshListTable)
    SwipeRefreshLayout swipteRefreshListTable;
    private List<BanAn> listData;
    private ListTableAdapter adapter;
    private GridLayoutManager gridLayoutManager;
    private AppDatabase mDB;
    private MainActivity activity;
    @Override
    public void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        listData=new ArrayList<>();
        adapter=new ListTableAdapter(getActivity(),listData);
        adapter.notifyDataSetChanged();
        gridLayoutManager=new GridLayoutManager(getActivity(),2);
        mDB=activity.mDB;
    }

    @Nullable
    @Override
    public View onCreateView(@NonNull LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {
        return inflater.inflate(R.layout.fragment_listtable,container,false);
    }

    @Override
    public void onViewCreated(@NonNull View view, @Nullable Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);
        ButterKnife.bind(this,view);

        swipteRefreshListTable.setOnRefreshListener(new SwipeRefreshLayout.OnRefreshListener() {
            @Override
            public void onRefresh() {
                swipteRefreshListTable.setRefreshing(false);
            }
        });
        setupRecyclerView();
    }
    void setupRecyclerView(){
        listData.clear();
        listData.addAll(mDB.banAnDAO().getListBanAn());
        rcv_listTable.setAdapter(adapter);
        ItemOffsetDecoration itemDecoration = new ItemOffsetDecoration(getActivity(), R.dimen.item_offset);
        rcv_listTable.addItemDecoration(itemDecoration);
        adapter.notifyDataSetChanged();
    }

    @Override
    public void onAttach(Context context) {
        super.onAttach(context);
        activity=(MainActivity)context;
    }

}
