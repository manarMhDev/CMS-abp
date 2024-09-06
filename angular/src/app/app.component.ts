import { Component, Injector, OnInit, Renderer2 } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { SignalRAspNetCoreHelper } from '@shared/helpers/SignalRAspNetCoreHelper';
import { LayoutStoreService } from '@shared/layout/layout-store.service';

@Component({
  templateUrl: './app.component.html'
})
export class AppComponent extends AppComponentBase implements OnInit {
  sidebarExpanded: boolean;
  currentLanguage: abp.localization.ILanguageInfo;

  constructor(
    injector: Injector,
    private renderer: Renderer2,
    private _layoutStore: LayoutStoreService
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this.renderer.addClass(document.body, 'sidebar-mini');
    this.currentLanguage = this.localization.currentLanguage;
    SignalRAspNetCoreHelper.initSignalR();

    abp.event.on('abp.notifications.received', (userNotification) => {
      abp.notifications.showUiNotifyForUserNotification(userNotification);

      // Desktop notification
      Push.create('AbpZeroTemplate', {
        body: userNotification.notification.data.message,
        icon: abp.appPath + 'assets/app-logo-small.png',
        timeout: 6000,
        onClick: function () {
          window.focus();
          this.close();
        }
      });
    });

    this._layoutStore.sidebarExpanded.subscribe((value) => {
      this.sidebarExpanded = value;
    });
    this.detectLanguage();
  }

  toggleSidebar(): void {
    this._layoutStore.setSidebarExpanded(!this.sidebarExpanded);
  }
  detectLanguage() {
    document.documentElement.dir = this.localization.currentLanguage.isRightToLeft === true ? 'rtl' : 'ltr';
    // Load or remove RTL styles based on the selected language
    if (this.localization.currentLanguage.isRightToLeft === true) {
      this.loadRtlStyles();
    } else {
      this.removeRtlStyles();
    }
  }
   loadRtlStyles() {
    const link = document.createElement('link');
    link.rel = 'stylesheet';
    link.href = '/assets/css/custom-rtl.css';
    link.id = 'rtl-styles';
    document.head.appendChild(link);
  }
   removeRtlStyles() {
    const link = document.getElementById('rtl-styles');
    if (link) {
      link.remove();
    }
  }
}
