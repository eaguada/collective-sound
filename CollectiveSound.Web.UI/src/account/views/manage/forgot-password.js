import { __decorate } from "tslib";
import { Component } from 'vue-property-decorator';
import SCComponentBase from '@/shared/application/sc-component-base';
let ForgotPasswordComponent = class ForgotPasswordComponent extends SCComponentBase {
    constructor() {
        super(...arguments);
        this.refs = this.$refs;
        this.forgotPasswordInput = {};
        this.errors = [];
        this.isEmailSent = false;
    }
    onSubmit() {
        if (this.refs.form.validate()) {
            this.scService.post('/api/forgotPassword', this.forgotPasswordInput)
                .then((response) => {
                if (!response.isError) {
                    this.resultMessage = this.$t('EMailSentSuccessfully').toString();
                    this.isEmailSent = true;
                }
                else {
                    this.errors = response.errors;
                }
            });
        }
    }
};
ForgotPasswordComponent = __decorate([
    Component
], ForgotPasswordComponent);
export default ForgotPasswordComponent;
//# sourceMappingURL=forgot-password.js.map