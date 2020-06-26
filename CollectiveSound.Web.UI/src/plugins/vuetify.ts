import Vue from "vue";
import Vuetify from "vuetify/lib";
import LanguageStore from '@/stores/language-store';

Vue.use(Vuetify);

import en from 'vuetify/src/locale/en';

export default new Vuetify({
    lang: {
        locales: { en },
        current: LanguageStore.getLanguage().languageCode,
    },
    icons: {
        iconfont: "mdi"
    }
});