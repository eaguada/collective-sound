import { __decorate } from "tslib";
import { Component } from 'vue-property-decorator';
import SCComponentBase from '@/shared/application/sc-component-base';
import LanguageStore from '@/stores/language-store';
let AccountLayoutComponent = class AccountLayoutComponent extends SCComponentBase {
    constructor() {
        super(...arguments);
        this.selectedLanguage = {};
    }
    created() {
        this.sc.auth.removeProps();
    }
    beforeMount() {
        this.selectedLanguage = LanguageStore.getLanguage();
    }
    changeLanguage(languageCode, languageName) {
        this.$i18n.locale = languageCode;
        this.selectedLanguage = { languageName, languageCode };
        this.$vuetify.lang.current = languageCode;
        LanguageStore.setLanguage({
            languageCode,
            languageName
        });
    }
};
AccountLayoutComponent = __decorate([
    Component
], AccountLayoutComponent);
export default AccountLayoutComponent;
//# sourceMappingURL=account-layout.js.map