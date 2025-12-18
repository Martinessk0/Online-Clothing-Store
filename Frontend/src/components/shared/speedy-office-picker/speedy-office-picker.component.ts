import { CommonModule } from '@angular/common';
import { Component, EventEmitter, HostListener, Input, Output } from '@angular/core';
import { DomSanitizer, SafeResourceUrl } from '@angular/platform-browser';

export interface SpeedyPickedOffice {
  id: number;
  label: string;
  raw?: any;
}

@Component({
  selector: 'app-speedy-office-picker',
  imports: [CommonModule],
  templateUrl: './speedy-office-picker.component.html',
  styleUrl: './speedy-office-picker.component.scss'
})
export class SpeedyOfficePickerComponent {
  @Input() open = false;
  @Output() openChange = new EventEmitter<boolean>();

  @Output() picked = new EventEmitter<SpeedyPickedOffice>();

  widgetUrl: SafeResourceUrl;

  constructor(private sanitizer: DomSanitizer) {
    // Office locator widget (официалната им карта)
    const url =
      'https://services.speedy.bg/office_locator_widget_v3/office_locator.php' +
      '?lang=bg' +
      '&officeType=ALL' +
      '&pickUp=1' +
      '&dropOff=1' +
      '&showOfficesList=1' +
      '&officesFilterOnTheMap=1' +
      '&selectOfficeButtonCaption=%D0%98%D0%B7%D0%B1%D0%B5%D1%80%D0%B8%20%D0%BE%D1%84%D0%B8%D1%81';

    this.widgetUrl = this.sanitizer.bypassSecurityTrustResourceUrl(url);
  }

  close() {
    this.open = false;
    this.openChange.emit(false);
  }

  @HostListener('window:message', ['$event'])
  onMessage(event: MessageEvent) {
    // DEBUG:
    // console.log('[Speedy widget message]', {
    //   origin: event.origin,
    //   data: event.data
    // });

    const okOrigin =
      typeof event.origin === 'string' &&
      (event.origin === 'https://services.speedy.bg' ||
        event.origin === 'http://services.speedy.bg' ||
        event.origin.endsWith('services.speedy.bg'));

    if (!okOrigin) return;

    const data = this.normalize(event.data);
    if (!data) return;

    const office = data.office ?? data.selectedOffice ?? data;

    const idRaw = office.id ?? office.officeId ?? office.code;
    const id = Number(idRaw);
    if (!Number.isFinite(id) || id <= 0) return;

    const name = String(office.name ?? office.label ?? '').trim();
    const addr = String(
      office.address?.fullAddressString ??
      office.address?.address1 ??
      office.address ??
      ''
    ).trim();

    const label = [name, addr].filter(Boolean).join(', ');

    this.picked.emit({ id, label, raw: data });
    this.close();
  }

  private normalize(input: unknown): any | null {
    if (input == null) return null;

    if (typeof input === 'string') {
      const s = input.trim();
      if (!s) return null;

      try {
        return JSON.parse(s);
      } catch {
        return null;
      }
    }

    if (typeof input === 'object') {
      return input;
    }

    return null;
  }


}
