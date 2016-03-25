import "jquery";
import "Dogfalo/materialize";
import "array-extensions";
import {Aurelia} from 'aurelia-framework';
import userAuth = require('areas/user/view-models/login');


export function configure(aurelia: Aurelia) {
  aurelia.use
    .standardConfiguration()
    .developmentLogging();

  //Uncomment the line below to enable animation.
  //aurelia.use.plugin('aurelia-animator-css');

  //Anyone wanting to use HTMLImports to load views, will need to install the following plugin.
  //aurelia.use.plugin('aurelia-html-import-template-loader')

  aurelia.start().then(() =>
  {
      aurelia.setRoot();
      var userLoginVM = <userAuth.LoginViewModel> aurelia.container.get(userAuth.LoginViewModel);
      userLoginVM.getUserSelfInfo();
  });
}
