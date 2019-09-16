package fpo.thanh.coffeeshop.presentation.presenter.impl;


import fpo.thanh.coffeeshop.domain.executor.Executor;
import fpo.thanh.coffeeshop.domain.executor.MainThread;
import fpo.thanh.coffeeshop.domain.executor.impl.ThreadExecutor;
import fpo.thanh.coffeeshop.domain.interactors.TestInteractor;
import fpo.thanh.coffeeshop.domain.interactors.impl.TestInteractorImpl;
import fpo.thanh.coffeeshop.domain.repository.TestRepository;
import fpo.thanh.coffeeshop.presentation.presenter.AbstractPresenter;
import fpo.thanh.coffeeshop.presentation.presenter.TestPresenter;
import fpo.thanh.coffeeshop.shareModel.TestModel;
import fpo.thanh.coffeeshop.threading.MainThreadImpl;

public class TestPresenterImpl extends AbstractPresenter implements TestPresenter, TestInteractor.Callback {
    private final View view;
    private final TestRepository repository;

    public TestPresenterImpl(Executor executor, MainThread mainThread, View view, TestRepository repository) {
        super(executor, mainThread);
        this.view = view;
        this.repository = repository;
    }

    @Override
    public void onFinish(TestModel result) {
        view.showResult(result);
    }

    @Override
    public void requestTest(String token) {
        TestInteractor interactor=new TestInteractorImpl(ThreadExecutor.getInstance(), MainThreadImpl.getInstance(),
                this,repository,token);
        interactor.execute();
    }

    @Override
    public void showProgress() {

    }

    @Override
    public void hideProgress() {

    }

    @Override
    public void showError(String message) {

    }
}
