import { Component, Injector, OnInit, EventEmitter, Output, ViewChild} from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import {
  ServiceDto,
  CreateServiceDto,
  ServiceTranslationDto,
  ServiceCategoryDto,
  ServiceCategoryServiceProxy,
  GalleryServiceProxy,
  CreateGalleryDto,
  ImageDto,
  ServicesAppCrudServiceProxy
} from '@shared/service-proxies/service-proxies';
import { Tag } from '@shared/components/tags/tag/tag.component';
import { MediaModalComponent } from '@shared/components/modal/media-modal/media-modal.component';
import { Observable } from 'rxjs';
import { keys } from 'lodash-es';
import { filter as _filter } from 'lodash-es';
import { AppConsts } from '@shared/AppConsts';
import { GalleryModalGenComponent } from '@shared/components/modal/gallery-modal-general/gallery-modal-gen.component';
import { Router } from '@angular/router';


declare let tinymce: any;

@Component({
  templateUrl: './create-service.component.html',
  animations: [appModuleAnimation()]
})
export class CreateServiceComponent extends AppComponentBase implements OnInit {

  @ViewChild('tinymce') tinymce; 

  saving = false;
  service = new ServiceDto();
  serviceTranslation = new ServiceTranslationDto();
  languages: abp.localization.ILanguageInfo[];
  currentLanguage: abp.localization.ILanguageInfo;
  selectedLanguage: abp.localization.ILanguageInfo;
  categories : ServiceCategoryDto[] = [];
  gallery = new CreateGalleryDto();
  suggestions: Tag[] = [];
  types;
  image = null;
  thumbnail = null;
  url = AppConsts.serverUrl;
  tagId;
  tinymceInit;

  @Output() onSave = new EventEmitter<any>();
  

  
  constructor(injector: Injector,
    private _serviceService: ServicesAppCrudServiceProxy,
    //private _tagService: TagServiceProxy,
    private _serviceCategoryService: ServiceCategoryServiceProxy,
    private _serviceGalleryService: GalleryServiceProxy,
    private _router : Router,
    private _modalService: BsModalService) {
    super(injector);
  }
  ngOnInit(): void {
    this.gallery.id = 0;
    this.languages = _filter(
      this.localization.languages,
      (l) => !l.isDisabled
    );
    this.currentLanguage = this.localization.currentLanguage;
    this.selectedLanguage = this.currentLanguage;

    this.serviceTranslation.language=this.selectedLanguage.name;
    this._serviceCategoryService.getList().subscribe((res)=>{
      this.categories=res;
      this.service.categoryId = this.categories[0].id;
    });
    this.tinymceInit = {
      plugins: 'anchor code autolink charmap codesample emoticons link image media lists searchreplace table visualblocks wordcount',
      toolbar: 'undo redo | blocks fontfamily fontsize | bold italic underline strikethrough | align lineheight | emoticons charmap | removeformat',
      tinycomments_mode: 'embedded',
      tinycomments_author: 'Author name',
      file_picker_types: 'image',
      mergetags_list: [
          { value: 'First.Name', title: 'First Name' },
          { value: 'Email', title: 'Email' },
      ],
      setup: (editor) => {
        console.log(editor);
        editor.ui.registry.addToggleButton('customStrikethrough', {
          text: 'Strikethrough',
          onAction: (api) => {
            editor.execCommand('mceToggleFormat', false, 'strikethrough');
            api.setActive(!api.isActive());
          }
        });
        editor.ui.registry.addToggleButton('customToggleStrikethrough', {
          icon: 'strike-through',
          onAction: (_) => editor.execCommand('mceToggleFormat', false, 'strikethrough'),
          onSetup: (api) => {
            api.setActive(editor.formatter.match('strikethrough'));
            const changed = editor.formatter.formatChanged('strikethrough', (state) => api.setActive(state));
            return () => changed.unbind();
          }
        });
      },
      file_picker_callback: async (callback, value, meta) => {
        if (meta.filetype == 'image'){
          var input = document.createElement('input');
          input.setAttribute('type', 'file');
          input.setAttribute('accept', 'image/*');
        
          input.onchange = function () {
            var file = input.files[0];
            var reader = new FileReader();
            reader.onload = function () {
              var id = 'blobid' + (new Date()).getTime();
              var blobCache = tinymce.activeEditor.editorUpload.blobCache;
              var base64 = (reader.result as string).split(',')[1];
              var blobInfo = blobCache.create(id, file, base64);
              blobCache.add(blobInfo);
              callback(blobInfo.blobUri(), { title: file.name });
            };
            reader.readAsDataURL(file);
          };
        
          input.click();
        }
 

      },           
    };

  }

  save(): void {
    this.saving = true;
     this._serviceGalleryService.create(this.gallery).subscribe((res)=>{
      const service = new CreateServiceDto();
      const serviceTranslation = new ServiceTranslationDto();
      service.init(this.service);
      serviceTranslation.init(this.serviceTranslation);
      service.translations = [];
      service.translations.push(serviceTranslation);
      service.image = this.image;
      service.thumbnail = this.thumbnail;
      console.log(service)
      this._serviceService
        .create(service)
        .subscribe(
          () => {
            this.notify.info(this.l('SavedSuccessfully'));
            this.onSave.emit();
            this._router.navigate(['/app/services']);
          },
          () => {
            this.saving = false;
          }
        );
     })
     
  }



  
  ChooseImage(): void {
    let MediaDialog: BsModalRef;
    MediaDialog = this._modalService.show(
      MediaModalComponent,
      {
        class: 'modal-lg',
      }
    );

    MediaDialog.content.onFileSelect.subscribe((res) => {
      console.log(res);
      this.image=res.data;
    });
  }
  ChooseThumbnail(): void {
    let MediaDialog: BsModalRef;
    MediaDialog = this._modalService.show(
      MediaModalComponent,
      {
        class: 'modal-lg',
      }
    );

    MediaDialog.content.onFileSelect.subscribe((res) => {
      console.log(res);
      this.thumbnail=res.data;
    });
  }

   ChooseImages(): void {
    let chosen = new  Map<string,ImageDto>();
    this.gallery?.images?.forEach((slide)=>{
         chosen.set(slide.path,slide);
    })
    let MediaDialog: BsModalRef;
        const initialState = { 
          galleryId: this.gallery.id ,
          chosen_files : chosen
        };
    MediaDialog = this._modalService.show(
      GalleryModalGenComponent,
      {
        class: 'modal-lg', initialState
      }
    );
    MediaDialog.content.onFileSelect.subscribe((res) => {
      console.log(res);
      let images: ImageDto[] =[];
      res.forEach((img)=>{
        let image = new ImageDto();
        image.path = img.path;
        image.name = "";
        images.push(image);
      })
      this.gallery.images = images ;
      console.log(this.gallery);
    });
  }

  chengeLang(value): void{
    this.selectedLanguage = this.localization.languages.find(l => l.name == value);
    this.serviceTranslation.language=this.selectedLanguage.name;
  }

}
