import { openErrorNotification, openNotification } from "../../Helpers/NotificationHelper";

export const SendAction = (parameters: IActionParameters<void>) => {
  parameters
    .action()
    .then(() => parameters.onSuccess && parameters.onSuccess())
    .catch(() => parameters.onFailure && parameters.onFailure());
};

export const SendActionWithResponse = <TResponse>(parameters: IActionParameters<TResponse>) => {
  const failureTitle = "Failure";
  const failureMessage = "There was a failure. Contact an administrator";

  parameters
    .action()
    .then((response) => parameters.onSuccess && parameters.onSuccess(response))

    .catch(() => {
      openErrorNotification(failureTitle, failureMessage);
      parameters.onFailure && parameters.onFailure();
    });
};

export const SendActionWithResponseAndNotification = <TResponse>(parameters: IActionParametersWithNotification<TResponse>) => {
  const failureTitle = parameters.failureTitle ? parameters.failureTitle : "Failure";
  const failureMessage = parameters.failureMessage ? parameters.failureMessage : "There was a failure. Contact an administrator";

  parameters
    .action()
    .then((response) => {
      openNotification(parameters.successTitle, parameters.successMessage);
      parameters.onSuccess && parameters.onSuccess(response);
    })
    .catch(() => {
      openErrorNotification(failureTitle, failureMessage);
      parameters.onFailure && parameters.onFailure();
    });
};

export interface IActionParameters<TResponse> {
  action: () => Promise<TResponse>;
  onSuccess?: (response: TResponse) => void;
  onFailure?: () => void;
}

export interface IActionParametersWithNotification<TResponse> extends IActionParameters<TResponse> {
  successTitle: string;
  successMessage: string;
  failureTitle?: string;
  failureMessage?: string;
}
