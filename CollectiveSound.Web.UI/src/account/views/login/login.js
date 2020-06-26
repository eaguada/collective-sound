import { __decorate } from "tslib";
import { Component } from 'vue-property-decorator';
import SCComponentBase from '@/shared/application/sc-component-base';
let LoginComponent = class LoginComponent extends SCComponentBase {
    constructor() {
        super(...arguments);
        this.refs = this.$refs;
        this.loginInput = {};
        this.errors = [];
    }
    onSubmit() {
        if (this.refs.form.validate()) {
            this.scService.post('/api/login', this.loginInput)
                .then((response) => {
                if (!response.isError) {
                    this.authStore.setToken(response.content.token);
                    this.$router.push({ path: '/admin/home' });
                }
                else {
                    this.errors = response.errors;
                }
            });
        }
    }
};
LoginComponent = __decorate([
    Component
], LoginComponent);
export default LoginComponent;
//# sourceMappingURL=login.js.map