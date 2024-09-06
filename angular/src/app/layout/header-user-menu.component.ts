import { Component, ChangeDetectionStrategy, OnInit, Injector } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { AppAuthService } from '@shared/auth/app-auth.service';

@Component({
  selector: 'header-user-menu',
  templateUrl: './header-user-menu.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class HeaderUserMenuComponent extends AppComponentBase implements OnInit {
  currentLanguage: abp.localization.ILanguageInfo; 

  constructor(injector: Injector,private _authService: AppAuthService) 
  {
    super(injector);
  }
  ngOnInit(): void {
    this.currentLanguage = this.localization.currentLanguage;
  }
  logout(): void {
    this._authService.logout();
  }
}
