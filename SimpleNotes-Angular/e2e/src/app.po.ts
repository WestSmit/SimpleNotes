import { browser, by, element } from 'protractor';

export class AppPage {
  navigateTo() {
    console.log(browser.baseUrl)
    return browser.get(browser.baseUrl) as Promise<any>;
  }

  async AddOneNote() {
    
    let a = -1;
    let b = -1;

    a = await element.all(by.css('.note')).count();

    await element(by.name('inputText')).sendKeys('some text')
    await element(by.id("newNotebutton")).click();

    b = await element.all(by.css('.note')).count();

    return b == (a + 1);
  }
}
