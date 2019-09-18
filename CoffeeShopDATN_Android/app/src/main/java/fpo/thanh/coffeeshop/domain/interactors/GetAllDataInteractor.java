package fpo.thanh.coffeeshop.domain.interactors;

import fpo.thanh.coffeeshop.domain.interactors.base.Interactor;
import fpo.thanh.coffeeshop.shareModel.ResultModel;

public interface GetAllDataInteractor extends Interactor {
    interface Callback{
        void onFinish(ResultModel result);
    }
}
