package fpo.thanh.coffeeshop.presentation.presenter;


import fpo.thanh.coffeeshop.presentation.ui.BaseView;
import fpo.thanh.coffeeshop.shareModel.TestModel;

public interface TestPresenter extends BaseView {
    interface View{
        void showResult(TestModel result);
    }
    void requestTest(String token);
}
