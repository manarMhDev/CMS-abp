import { Component, OnInit, OnDestroy, Input, Output, EventEmitter, ViewChild } from '@angular/core';
import { NgModel } from '@angular/forms';
import { Subscription } from 'rxjs';
import { debounceTime, distinctUntilChanged } from 'rxjs/operators';
import { Tag } from '../tag/tag.component';
import { TagService } from '@shared/services/tag.service';

@Component({
  selector: 'app-tags',
  templateUrl: 'tags-layout.component.html',
  styleUrls: ['tags-layout.component.scss'],
})
export class TagsLayoutComponent implements OnInit, OnDestroy {

  @Input() tags: Tag[];
  @Input() suggestions: Tag[];
  
  @Output() tagAdded = new EventEmitter<Tag>();
  @Output() tagRemoved = new EventEmitter<Tag>();
  
  @ViewChild('tagInput') tagInput: NgModel ;

  expanded = true;
  tagInputText = '';

  debouncedText = '';

  private changesSub: Subscription;

  constructor(private tagService: TagService) { }

  ngOnInit() {
  }

  ngAfterViewInit(){
    this.changesSub = this.tagInput.valueChanges
    .pipe(
      debounceTime(300),
      distinctUntilChanged()
    )
    .subscribe(tagInputText => {
      this.debouncedText = tagInputText;
    });
  }

  ngOnDestroy() {
    if (this.changesSub) {
      this.changesSub.unsubscribe();
    }
  }

  onKeyUp(event: KeyboardEvent) {
    if (event.key === 'Enter') {
      if (event.shiftKey) {
        const filtered = this.tagService.filterSuggestions(this.suggestions, this.tags, this.debouncedText);
        if (filtered.length > 0) {
          this.tagAdded.emit(filtered[0]);
        }
      } else {
        this.tagAdded.emit({ name: this.tagInputText, backgroundColor: '#868E96', color: '#FFFFFF' });
        this.tagInput.reset();
      }
    }
  }
  
  onAdd() {
    this.tagAdded.emit({ name: this.tagInputText, backgroundColor: '#868E96', color: '#FFFFFF' });
    this.tagInput.reset();
  }

  onExpand() {
    this.expanded = !this.expanded;
  }
}
