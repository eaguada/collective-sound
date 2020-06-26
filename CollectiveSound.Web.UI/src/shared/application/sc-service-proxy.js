import AuthStore from '@/stores/auth-store';
import AppConsts from '@/shared/application/sc';
import SC from '@/shared/application/sc';
import Guid from '@/shared/helpers/guid-helper';
export default class SCService {
    static request(method, url, data = '', loadingEnabled = true) {
        let isBadRequest = false;
        let body = data === '' ? null : data;
        const headers = {
            Authorization: `Bearer ${AuthStore.getToken()}`
        };
        if (data) {
            headers['Content-Type'] = 'application/json';
            body = JSON.stringify(data);
        }
        if (loadingEnabled) {
            SC.isLoading = true;
        }
        return fetch(AppConsts.baseApiUrl + url, ({
            method,
            headers,
            body
        }))
            .then((response) => {
            isBadRequest = !response.ok;
            if (response.status === 401) {
                AuthStore.removeToken();
                return { errorMessage: 'Unauthorized request' };
            }
            return response.text();
        })
            .then((responseContent) => {
            let content;
            try {
                content = JSON.parse(responseContent);
            }
            catch (err) {
                content = responseContent;
            }
            const response = {
                isError: isBadRequest,
                errors: isBadRequest ? content : null,
                content: isBadRequest ? null : content
            };
            return response;
        }).finally(() => {
            SC.isLoading = false;
        });
    }
    get(url, loadingEnabled = true) {
        return SCService.request('GET', url, '', loadingEnabled);
    }
    delete(url) {
        return SCService.request('DELETE', url);
    }
    put(url, data) {
        return SCService.request('PUT', url, data);
    }
    post(url, data) {
        return SCService.request('POST', url, data);
    }
    postOrPut(url, data, id) {
        if (id && id !== Guid.empty) {
            return SCService.request('PUT', url, data);
        }
        return SCService.request('POST', url, data);
    }
}
//# sourceMappingURL=sc-service-proxy.js.map