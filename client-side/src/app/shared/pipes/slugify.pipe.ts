import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'slugify'
})
export class SlugifyPipe implements PipeTransform {

  removeAcento(value: string) {
    let text = value.toLowerCase();

    text = text.replace(new RegExp('[ÁÀÂÃ]', 'gi'), 'a');
    text = text.replace(new RegExp('[ÉÈÊ]', 'gi'), 'e');
    text = text.replace(new RegExp('[ÍÌÎ]', 'gi'), 'i');
    text = text.replace(new RegExp('[ÓÒÔÕÖ]', 'gi'), 'o');
    text = text.replace(new RegExp('[ÚÙÛÜ]', 'gi'), 'u');
    text = text.replace(new RegExp('[Ç]', 'gi'), 'c');
    text = text.replace(new RegExp('[Ə]', 'gi'), 'e');
    text = text.replace(new RegExp('[Ş]', 'gi'), 's');

    return text;
  }

  transform(value: string): string {
    let response = value.toString().toLowerCase();
    response = this.removeAcento(value).trim()
      .replace(/\s+/g, '-') // Replace spaces with -
      .replace(/[^\w\-]+/g, '') // Remove all non-word chars
      .replace(/\-\-+/g, '-') // Replace multiple - with single -
      .replace(/^-+/, '') // Trim - from start of text
      .replace(/-+$/, ''); // Trim - from end of text

    return response;
  }

}
