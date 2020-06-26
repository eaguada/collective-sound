import { __decorate } from "tslib";
import { Component } from 'vue-property-decorator';
import SCComponentBase from '@/shared/application/sc-component-base';
let RegisterComponent = class RegisterComponent extends SCComponentBase {
    constructor() {
        super(...arguments);
        this.refs = this.$refs;
        this.registerInput = {};
        this.errors = [];
        this.registerComplete = false;
    }
    onSubmit() {
        if (this.refs.form.validate()) {
            this.scService.post('/api/register', this.registerInput)
                .then((response) => {
                if (!response.isError) {
                    this.resultMessage = this.$t('AccountCreationSuccessful').toString();
                    this.registerComplete = true;
                }
                else {
                    this.errors = response.errors;
                }
            });
        }
    }
};
RegisterComponent = __decorate([
    Component
], RegisterComponent);
export default RegisterComponent;
//# sourceMappingURL=register.js.map