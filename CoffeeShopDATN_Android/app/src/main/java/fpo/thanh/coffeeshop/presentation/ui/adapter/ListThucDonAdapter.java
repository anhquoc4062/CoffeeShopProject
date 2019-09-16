package fpo.thanh.coffeeshop.presentation.ui.adapter;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import com.squareup.picasso.Picasso;

import java.util.List;

import butterknife.BindView;
import butterknife.ButterKnife;
import fpo.thanh.coffeeshop.R;
import fpo.thanh.coffeeshop.domain.Room.RoomModel.ThucDon;

public class ListThucDonAdapter extends RecyclerView.Adapter<ListThucDonAdapter.ViewHolder> {
    private final Context context;
    private final List<ThucDon> listData;

    public ListThucDonAdapter(Context context, List<ThucDon> listData){

        this.context = context;
        this.listData = listData;
    }
    @NonNull
    @Override
    public ViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        return new ViewHolder(LayoutInflater.from(parent.getContext()).inflate(R.layout.item_listthucdon,parent,false));
    }

    @Override
    public void onBindViewHolder(@NonNull ViewHolder holder, int position) {
        holder.tv_nameThucDon.setText(listData.get(position).tenThucDon);
        holder.tv_priceThucDon.setText(String.valueOf(listData.get(position).gia)+"$");
        holder.tv_loaiThucDon.setText(listData.get(position).tenLoai);
        Picasso.get().load("https://static.independent.co.uk/s3fs-public/thumbnails/image/2016/06/15/14/pp-hot-coffee-rf-istock.jpg?w968h681")
                .into(holder.img_thucdon);
    }

    @Override
    public int getItemCount() {
        return listData.size();
    }

    public class ViewHolder extends RecyclerView.ViewHolder {
        @BindView(R.id.tv_priceThucDon)
        TextView tv_priceThucDon;
        @BindView(R.id.tv_nameThucdon)
        TextView tv_nameThucDon;
        @BindView(R.id.img_thucdon)
        ImageView img_thucdon;
        @BindView(R.id.tv_loaiThucDon)
        TextView tv_loaiThucDon;
        public ViewHolder(@NonNull View itemView) {
            super(itemView);
            ButterKnife.bind(this,itemView);
        }
    }
}
