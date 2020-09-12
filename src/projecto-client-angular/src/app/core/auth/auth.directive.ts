import { Directive, TemplateRef, ViewContainerRef } from '@angular/core';
import { AuthService } from './auth.service';

@Directive({
  selector: '[auth]'
})
export class AuthDirective {

  private hasView = false;

  constructor(
    private templateRef: TemplateRef<any>,
    private vcr: ViewContainerRef,
    private auth: AuthService) { }

  ngOnInit() {
    const authorized = this.auth.loggedIn;

    if (authorized && !this.hasView) {
      this.vcr.createEmbeddedView(this.templateRef);
      this.hasView = true;
    } else if (!authorized && this.hasView) {
      this.vcr.clear();
      this.hasView = false;
    }
  }
}
