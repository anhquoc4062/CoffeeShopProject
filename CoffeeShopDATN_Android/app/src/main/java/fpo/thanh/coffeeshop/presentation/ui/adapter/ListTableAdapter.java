package fpo.thanh.coffeeshop.presentation.ui.adapter;

import android.content.Context;
import android.content.Intent;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.cardview.widget.CardView;
import androidx.recyclerview.widget.RecyclerView;

import com.github.marlonlom.utilities.timeago.TimeAgo;
import com.github.marlonlom.utilities.timeago.TimeAgoMessages;

import java.util.List;
import java.util.Locale;

import butterknife.BindView;
import butterknife.ButterKnife;
import fpo.thanh.coffeeshop.R;
import fpo.thanh.coffeeshop.domain.Room.RoomModel.BanAn;
import fpo.thanh.coffeeshop.presentation.ui.activity.SupportActivity;

public class ListTableAdapter extends RecyclerView.Adapter<ListTableAdapter.ViewHolder> {

    private final Context context;
    private final List<BanAn> listData;
    Locale LocaleBylanguageTag;
    TimeAgoMessages messages;
    long timeInMillis;
    public ListTableAdapter(Context context, List<BanAn> listData){
        LocaleBylanguageTag = Locale.forLanguageTag("en");
        messages = new TimeAgoMessages.Builder().withLocale(LocaleBylanguageTag).build();
        timeInMillis = System.currentTimeMillis()-360000000;
        Log.e("milis",""+timeInMillis);
        this.context = context;
        this.listData = listData;
    }

    @NonNull
    @Override
    public ViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        return new ViewHolder(LayoutInflater.from(parent.getContext()).inflate(R.layout.item_listtable,parent,false));
    }

    @Override
    public void onBindViewHolder(@NonNull ViewHolder holder, int position) {
        String text= TimeAgo.using(timeInMillis,messages);
        holder.tv_timeAgo.setText(text);
        holder.tv_nameBanAn.setText(listData.get(position).tenBan);
        holder.tv_tangBanAn.setText("Tầng "+listData.get(position).maTang);
        holder.cardView.setOnClickListener(v->{
            Intent intent=new Intent(context,SupportActivity.class);
            intent.putExtra("tenBan",listData.get(position).tenBan);
            intent.putExtra("maTang",String.valueOf(listData.get(position).maTang));
            context.startActivity(intent);
        });
    }

    @Override
    public int getItemCount() {
        return listData.size();
    }

    public class ViewHolder extends RecyclerView.ViewHolder {
        @BindView(R.id.tv_timeAgo)
        TextView tv_timeAgo;
        @BindView(R.id.tv_nameBanAn)
        TextView tv_nameBanAn;
        @BindView(R.id.tv_tangBanAn)
        TextView tv_tangBanAn;
        @BindView(R.id.cardviewTable)
        CardView cardView;
        public ViewHolder(@NonNull View itemView) {
            super(itemView);
            ButterKnife.bind(this,itemView);
        }
    }
}
