package fpo.thanh.coffeeshop.presentation.presenter;


import fpo.thanh.coffeeshop.domain.executor.Executor;
import fpo.thanh.coffeeshop.domain.executor.MainThread;

/**
 * Created by dmilicic on 12/23/15.
 */
public abstract class AbstractPresenter {
    protected Executor mExecutor;
    protected MainThread mMainThread;

    public AbstractPresenter(Executor executor, MainThread mainThread) {
        mExecutor = executor;
        mMainThread = mainThread;
    }
}
