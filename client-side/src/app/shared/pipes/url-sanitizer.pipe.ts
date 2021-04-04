import { Pipe, PipeTransform } from '@angular/core';
import { DomSanitizer, SafeResourceUrl } from '@angular/platform-browser';

@Pipe({
  name: 'urlSanitizer',
})
export class UrlSanitizerPipe implements PipeTransform {
  public urlSafe!: SafeResourceUrl;

  constructor(private sanitizer: DomSanitizer) {}

  transform(url: any) {
    return this.sanitizer.bypassSecurityTrustResourceUrl(url);
  }
}
