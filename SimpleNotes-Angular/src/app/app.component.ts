import { Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  
  title = 'SimpleNotes';
  selectedLanguage: string;
  languages: string[];
  flags = {
    "en": "🇬🇧",
    "ru": "🇷🇺"
  };

  constructor(public translate: TranslateService) { }

  ngOnInit(): void {    
    const currentCode = this.translate.currentLang;
    this.languages = this.translate.getLangs().map(l => this.flags[l] + '\u00A0\u00A0' + l.toLocaleUpperCase());
    this.selectedLanguage = this.flags[currentCode] + '\u00A0\u00A0' + currentCode.toLocaleUpperCase();
  }

  changeLanguage() {
    const selectedCode = Object.keys(this.flags).find(flag => this.selectedLanguage.includes(this.flags[flag]));
    this.translate.use(selectedCode);
    this.selectedLanguage = this.flags[selectedCode] + '\u00A0\u00A0' + selectedCode.toLocaleUpperCase();
  }
}
