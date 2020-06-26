import { Component } from 'vue-property-decorator';
import SCComponentBase from '@/shared/application/sc-component-base';
import LanguageStore from '@/stores/language-store';

@Component
export default class AccountLayoutComponent extends SCComponentBase {
    public selectedLanguage = {} as ILanguageDto;

    public created() {
        this.sc.auth.removeProps();
    }

    public beforeMount() {
        this.selectedLanguage = LanguageStore.getLanguage();
    }

    public changeLanguage(languageCode: string, languageName: string) {
        this.$i18n.locale = languageCode;
        this.selectedLanguage = { languageName, languageCode } as ILanguageDto;
        this.$vuetify.lang.current = languageCode;

        LanguageStore.setLanguage({
            languageCode,
            languageName
        } as any);
    }
}