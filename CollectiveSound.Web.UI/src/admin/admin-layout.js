import { __decorate } from "tslib";
import SCComponentBase from '@/shared/application/sc-component-base';
import { Component } from 'vue-property-decorator';
let AdminLayoutComponent = class AdminLayoutComponent extends SCComponentBase {
    created() {
        this.sc.auth.fillProps();
    }
};
AdminLayoutComponent = __decorate([
    Component({
        components: {
            AsideMenu: require('@/admin/components/menu/aside-menu/aside-menu.vue').default,
            TopMenu: require('@/admin/components/menu/top-menu/top-menu.vue').default
        }
    })
], AdminLayoutComponent);
export default AdminLayoutComponent;
//# sourceMappingURL=admin-layout.js.map