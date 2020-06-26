import { Component } from 'vue-property-decorator';
import SCComponentBase from '@/shared/application/sc-component-base';

@Component
export default class RegisterComponent extends SCComponentBase {
    refs = this.$refs as any;
    registerInput = {} as IRegisterInput;
    errors: INameValueDto[] = [];
    resultMessage: string | undefined;
    registerComplete = false;

    onSubmit() {
        if (this.refs.form.validate()) {
            this.scService.post<IRegisterOutput>('/api/register', this.registerInput)
                .then((response) => {
                    if (!response.isError) {
                        this.resultMessage = this.$t('AccountCreationSuccessful').toString();
                        this.registerComplete = true;
                    } else {
                        this.errors = response.errors;
                    }
                });
        }
    }
}