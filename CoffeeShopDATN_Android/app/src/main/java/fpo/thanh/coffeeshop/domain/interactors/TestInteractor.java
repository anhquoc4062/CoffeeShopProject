package fpo.thanh.coffeeshop.domain.interactors;

import fpo.thanh.coffeeshop.domain.interactors.base.Interactor;
import fpo.thanh.coffeeshop.shareModel.TestModel;

public interface TestInteractor extends Interactor {
    interface Callback{
        void onFinish(TestModel result);
    }
}
