import { AppPage } from './app.po';
import { browser, logging } from 'protractor';

describe('workspace-project App', () => {
  let page: AppPage;

  beforeEach(() => {
    page = new AppPage();
  });

  it('should add one note', () => {
    page.navigateTo();
    expect(page.addOneNote()).toBe(true);
    //expect(page.deleteOneNote()).toBe(true);
  });

  it('should delete one note', () => {
    page.navigateTo();
    expect(page.deleteOneNote()).toBe(true);
  });

  afterEach(async () => {
    // Assert that there are no errors emitted from the browser
    const logs = await browser.manage().logs().get(logging.Type.BROWSER);
    expect(logs).not.toContain(jasmine.objectContaining({
      level: logging.Level.SEVERE,
    } as logging.Entry));
  });
});
