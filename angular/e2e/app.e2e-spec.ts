import { ManarTemplatePage } from './app.po';

describe('Manar App', function() {
  let page: ManarTemplatePage;

  beforeEach(() => {
    page = new ManarTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
