package fpo.thanh.coffeeshop.presentation.presenter.impl;

import fpo.thanh.coffeeshop.domain.executor.Executor;
import fpo.thanh.coffeeshop.domain.executor.MainThread;
import fpo.thanh.coffeeshop.domain.executor.impl.ThreadExecutor;
import fpo.thanh.coffeeshop.domain.interactors.GetAllDataInteractor;
import fpo.thanh.coffeeshop.domain.interactors.impl.GetAllDataInteractorImpl;
import fpo.thanh.coffeeshop.domain.repository.GetAllDataRepository;
import fpo.thanh.coffeeshop.presentation.presenter.AbstractPresenter;
import fpo.thanh.coffeeshop.presentation.presenter.GetAllDataPresenter;
import fpo.thanh.coffeeshop.shareModel.ResultModel;
import fpo.thanh.coffeeshop.threading.MainThreadImpl;

public class GetAllDataPresenterImpl extends AbstractPresenter implements GetAllDataInteractor.Callback, GetAllDataPresenter {
    private final View view;
    private final GetAllDataRepository repository;

    public GetAllDataPresenterImpl(Executor executor, MainThread mainThread, View view, GetAllDataRepository repository) {
        super(executor, mainThread);
        this.view = view;
        this.repository = repository;
    }

    @Override
    public void onFinish(ResultModel result) {
        view.onShowResultGetAllData(result);
    }

    @Override
    public void onRequestAllData() {
        GetAllDataInteractor interactor=new GetAllDataInteractorImpl(ThreadExecutor.getInstance(), MainThreadImpl.getInstance(),
                this,repository);
        interactor.execute();
    }
}
