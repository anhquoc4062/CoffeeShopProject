package fpo.thanh.coffeeshop.presentation.presenter;

import javax.xml.transform.Result;

import fpo.thanh.coffeeshop.shareModel.ResultModel;

public interface GetAllDataPresenter {
    interface View{
        void onShowResultGetAllData(ResultModel result);
    }
    void onRequestAllData();
}
