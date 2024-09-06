import { Pipe, PipeTransform } from '@angular/core';
import { Tag } from '../components/tags/tag/tag.component';
import { TagService } from '../services/tag.service';

@Pipe({
  name: 'tagFilter'
})
export class TagFilterPipe implements PipeTransform {

  constructor(private tagService: TagService) { }

  transform(suggestions: Tag[], tags: Tag[],  filter: string): any {
    return this.tagService.filterSuggestions(suggestions, tags, filter);
  }
}