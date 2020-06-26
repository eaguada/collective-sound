import AuthStore from '@/stores/auth-store';
import AppConsts from '@/shared/application/sc';
import SC from '@/shared/application/sc';
import Guid from '@/shared/helpers/guid-helper';

export default class SCService {
    private static request<T>(method: string, url: string, data: any | string = '', loadingEnabled = true):
        Promise<IRestResponseDto<T>> {
        let isBadRequest = false;
        let body = data === '' ? null : data;
        const headers: { [key: string]: string } = {
            Authorization: `Bearer ${AuthStore.getToken()}`
        };

        if (data) {
            headers['Content-Type'] = 'application/json';
            body = JSON.stringify(data);
        }

        if (loadingEnabled) {
            SC.isLoading = true;
        }

        return fetch(AppConsts.baseApiUrl + url,
            ({
                method,
                headers,
                body
            }) as any)
            .then((response: any) => {
                isBadRequest = !response.ok;
                if (response.status === 401) {
                    AuthStore.removeToken();
                    return { errorMessage: 'Unauthorized request' };
                }

                return response.text();
            })
            .then((responseContent: any) => {
                let content: any;

                try {
                    content = JSON.parse(responseContent);
                } catch (err) {
                    content = responseContent;
                }

                const response = {
                    isError: isBadRequest,
                    errors: isBadRequest ? content : null,
                    content: isBadRequest ? null : content
                } as IRestResponseDto<T>;

                return response;
            }).finally(() => {
                SC.isLoading = false;
            });
    }

    get<T>(url: string, loadingEnabled = true): Promise<IRestResponseDto<T>> {
        return SCService.request<T>('GET', url, '', loadingEnabled);
    }

    delete(url: string): Promise<IRestResponseDto<void>> {
        return SCService.request<void>('DELETE', url);
    }

    put<T>(url: string, data: any | string): Promise<IRestResponseDto<T>> {
        return SCService.request<T>('PUT', url, data);
    }

    post<T>(url: string, data: any | string): Promise<IRestResponseDto<T>> {
        return SCService.request<T>('POST', url, data);
    }

    postOrPut<T>(url: string, data: any | string, id: string | undefined): Promise<IRestResponseDto<T>> {
        if (id && id !== Guid.empty) {
            return SCService.request<T>('PUT', url, data);
        }

        return SCService.request<T>('POST', url, data);
    }
}