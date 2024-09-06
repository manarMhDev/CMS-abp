import { Component, Output, OnInit, Input, EventEmitter } from '@angular/core';
import { trigger, state, style, animate, transition, AnimationEvent } from '@angular/animations';
export interface Tag {
    name: string;
    color: string;
    backgroundColor: string;
  }

@Component({
  selector: 'app-tag',
  templateUrl: 'tag.component.html',
  styleUrls: ['tag.component.scss'],
  animations: [
    trigger('deleteAnimation', [
      state('prepare', style({ transform: 'scale(0)', opacity: '0' })),
      transition('none => prepare', animate(200)),
    ])
  ]
})
export class TagComponent implements OnInit {
  @Input() tag: Tag;
  @Output() closed = new EventEmitter<Tag>();

  deleteState = 'none';

  constructor() { }

  ngOnInit() {
  }

  onTagClicked() {
    this.deleteState = 'prepare';
  }

  onDeleteAnimationDone(event: AnimationEvent, tag: Tag) {
    if (event.toState === 'prepare') {
      this.closed.emit(tag);
    }
  }
}