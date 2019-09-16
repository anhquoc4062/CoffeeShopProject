package fpo.thanh.coffeeshop.presentation.ui.fragment;

import android.app.Activity;
import android.content.Context;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.view.inputmethod.InputMethodManager;
import android.widget.ImageView;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.constraintlayout.widget.ConstraintLayout;
import androidx.fragment.app.Fragment;

import com.squareup.picasso.Picasso;
import com.synnapps.carouselview.CarouselView;
import com.synnapps.carouselview.ImageListener;

import java.util.ArrayList;
import java.util.List;

import butterknife.BindView;
import butterknife.ButterKnife;
import fpo.thanh.coffeeshop.R;
import fpo.thanh.coffeeshop.presentation.ui.activity.MainActivity;

public class HomeFragment extends Fragment implements View.OnClickListener
{
    @BindView(R.id.carousel)
    CarouselView carouselView;
    List<String> listImage;

    @BindView(R.id.itemLayoutCoffee)
    ConstraintLayout layoutCoffee;
    @BindView(R.id.itemLayoutCoffeeWaiting)
    ConstraintLayout layoutCoffeeWaiting;
    @BindView(R.id.itemLayoutComplete)
    ConstraintLayout layoutComplete;
    @BindView(R.id.itemLayoutInfo)
    ConstraintLayout layoutInfo;
    @Override
    public void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        listImage=new ArrayList<>();
        listImage.add("https://www.cancer.org/latest-news/coffee-and-cancer-what-the-research-really-shows/_jcr_content/par/textimage/image.img.jpg/1522697270446.jpg");
        listImage.add("https://knowledge.wharton.upenn.edu/wp-content/uploads/2019/02/021419_coffeeclimatechange.jpg");
    }

    @Nullable
    @Override
    public View onCreateView(@NonNull LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {
        return inflater.inflate(R.layout.fragment_home,container,false);
    }

    @Override
    public void onViewCreated(@NonNull View view, @Nullable Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);
        ButterKnife.bind(this,view);
        carouselView.setImageListener(imageListener);
        carouselView.setPageCount(listImage.size());
        layoutCoffee.setOnClickListener(this);
        layoutCoffeeWaiting.setOnClickListener(this);
        layoutComplete.setOnClickListener(this);
        layoutInfo.setOnClickListener(this);

    }
    ImageListener imageListener = new ImageListener() {
        @Override
        public void setImageForPosition(int position, ImageView imageView) {
            imageView.setScaleType(ImageView.ScaleType.CENTER_CROP);
            Picasso.get().load(listImage.get(position)).into(imageView);
        }
    };

    @Override
    public void onResume() {
        super.onResume();
    }

    @Override
    public void onPause() {
        super.onPause();


    }

    @Override
    public void onClick(View v) {
        switch (v.getId()){
            case R.id.itemLayoutCoffee:
                moveToPositionTablayout(1);
                break;
            case R.id.itemLayoutCoffeeWaiting:
                moveToPositionTablayout(2);
                break;
            case R.id.itemLayoutComplete:
                moveToPositionTablayout(3);
                break;
        }
    }

    void moveToPositionTablayout(int position){
        ((MainActivity)getActivity()).moveToPositionViewpager(position);
    }

}
