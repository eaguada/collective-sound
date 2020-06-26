import { __decorate } from "tslib";
import Vue from 'vue';
import SCService from '@/shared/application/sc-service-proxy';
import QueryString from 'query-string';
import SC from '@/shared/application/sc';
import Swal from 'sweetalert2';
import AuthStore from '@/stores/auth-store';
import { Component } from 'vue-property-decorator';
let SCComponentBase = class SCComponentBase extends Vue {
    constructor() {
        super(...arguments);
        this.scService = new SCService();
        this.queryString = QueryString;
        this.sc = SC;
        this.authStore = AuthStore;
        this.requiredError = (v) => !!v || this.t('RequiredField');
        this.emailError = (v) => /.+@.+/.test(v) || this.t('EmailValidationError');
    }
    swalToast(duration, type, title) {
        Swal.fire({
            toast: true,
            position: 'bottom-end',
            showConfirmButton: false,
            timer: duration,
            type,
            title
        });
    }
    swalConfirm(title) {
        return Swal.fire({
            title,
            type: 'warning',
            showCancelButton: true,
            confirmButtonText: this.$t('Yes').toString(),
            cancelButtonText: this.$t('No').toString()
        });
    }
    swalAlert(type, html) {
        Swal.fire({
            html,
            type,
            showConfirmButton: false
        });
    }
    passwordMatchError(password, passwordRepeat) {
        return (password == passwordRepeat)
            ? ''
            : this.$t('PasswordsMustMatch').toString();
    }
    t(key) {
        return this.$t(key).toString();
    }
};
SCComponentBase = __decorate([
    Component
], SCComponentBase);
export default SCComponentBase;
//# sourceMappingURL=sc-component-base.js.map