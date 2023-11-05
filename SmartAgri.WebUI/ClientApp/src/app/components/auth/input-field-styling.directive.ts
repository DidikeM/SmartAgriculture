import { Directive, ElementRef, HostBinding, HostListener } from '@angular/core';

@Directive({
  selector: '[appInputFieldStyling]'
})
export class InputFieldStylingDirective {
  @HostBinding('style.borderBottomColor') borderColor: string= 'var(--gray-3)';

  constructor(private el: ElementRef) {}

  @HostListener('focus') onFocus(eventdata: Event) {
    this.borderColor = 'var(--primary-dark)';
    this.changeIconColor('var(--primary-dark)');
  }

  @HostListener('blur')onBlur(event: Event) {
    this.borderColor = 'var(--gray-3)';
    this.changeIconColor('var(--gray-1)');
  }

  private changeIconColor(color: string) {
    const inputElement = this.el.nativeElement;
    const icons = inputElement.parentElement.querySelectorAll('fa-icon');
    icons.forEach((icon: HTMLElement) => {
      icon.style.color = color;
    });
  }
}
