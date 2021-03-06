import SCService from '@/shared/application/sc-service-proxy';
import AuthStore from '@/stores/auth-store';
import { appConst } from "../../settings";
const sc = {
    baseApiUrl: appConst.webApiUrl,
    baseClientUrl: appConst.webClientUrl,
    isLoading: false,
    appVersion: '1.0.0',
    auth: {
        grantedPermissions: [],
        isGranted(permissionName) {
            return this.grantedPermissions.filter((p) => p.name == permissionName).length > 0;
        },
        removeProps() {
            this.grantedPermissions = [];
        },
        fillProps() {
            const scService = new SCService();
            scService.get('/api/permissions?userNameOrEmail=' + AuthStore.getTokenData().sub).then((response) => {
                if (!response.isError) {
                    this.grantedPermissions = response.content;
                }
            });
        }
    }
};
export default sc;
//# sourceMappingURL=sc.js.map