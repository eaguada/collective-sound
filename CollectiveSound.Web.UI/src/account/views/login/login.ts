import { Component } from 'vue-property-decorator';
import SCComponentBase from '@/shared/application/sc-component-base';

@Component
export default class LoginComponent extends SCComponentBase {
    public refs = this.$refs as any;
    public loginInput = {} as ILoginInput;
    public errors: INameValueDto[] = [];

    public onSubmit() {
        if (this.refs.form.validate()) {
            this.scService.post<ILoginOutput>('/api/login', this.loginInput)
                .then((response) => {
                    if (!response.isError) {
                        this.authStore.setToken(response.content.token);
                        this.$router.push({ path: '/admin/home' });
                    } else {
                        this.errors = response.errors;
                    }
                });
        }
    }
}