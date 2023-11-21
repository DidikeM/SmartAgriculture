import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'concatenate'
})

export class ConcatenatePipe implements PipeTransform {
  transform(username: string, surname: string): string {
    return `${username}${surname}`;
  }
}
