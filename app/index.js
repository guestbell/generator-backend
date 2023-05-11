'use strict';
const Generator = require('yeoman-generator');
// const commandExists = require('command-exists').sync;
const yosay = require('yosay');
// const mkdirp = require('mkdirp');
const config = require('./config');
const { firstCharToLower } = require('./utils');

module.exports = class extends Generator {
  constructor(args, opts) {
    super(args, opts);
    for (let optionName in config.options) {
      this.option(optionName, config.options[optionName]);
    }
  }

  initializing() {
    this.pkg = require('../package.json');

    /*this.composeWith({
      'skip-install': this.options['skip-install']
    });*/
  }

  prompting() {
    if (!this.options['skip-welcome-message']) {
      this.log(
        yosay(
          "'Allo 'allo! Out of the box I include HTML5 Boilerplate, jQuery, and a gulpfile to build your app."
        )
      );
    }

    return this.prompt(config.prompts).then(answers => {
      const features = answers.features;
      const projects = answers.projects;
      const hasFeature = feat => features && features.includes(feat);
      const hasProject = proj => projects && projects.includes(proj);

      // manually deal with the response, get back and store the results.
      // we change a bit this way of doing to automatically do this in the self.prompt() method.
      this.includePost = hasFeature('includePost');
      this.includePut = hasFeature('includePut');
      this.includeGet = hasFeature('includeGet');
      this.includeDelete = hasFeature('includeDelete');

      this.projectWeb = hasProject('projectWeb');
      this.projectCommon = hasProject('projectCommon');
      this.projectPlugin = hasProject('projectPlugin');
      this.projectDal = hasProject('projectDal');
      this.projectHost = hasProject('projectHost');

      this.isBoundToProperty = answers.isBoundToProperty;
      this.featureName = answers.featureName;
      this.projectName = answers.projectName;
      this.createProjects = answers.createProjects;
      this.isPaginated = answers.isPaginated;
      this.namespaceRequestResponse = answers.namespaceRequestResponse;
      this.exceptIds = answers.exceptIds;
      this.ignorePropertyId = answers.ignorePropertyId;
    });
  }

  writing() {
    const templateData = {
      isBoundToProperty: this.isBoundToProperty,
      featureName: this.featureName,
      projectName: this.projectName,
      includePost: this.includePost,
      includePut: this.includePut,
      includeGet: this.includeGet,
      includeDelete: this.includeDelete,
      createProjects: this.createProjects,
      isPaginated: this.isPaginated,
      namespaceRequestResponse: this.namespaceRequestResponse,
      exceptIds: this.exceptIds,
      ignorePropertyId: this.ignorePropertyId,
    };

    /*const copy = (input, output) => {
      this.fs.copy(this.templatePath(input), this.destinationPath(output));
    };*/

    const copyTpl = (input, output, data) => {
      this.fs.copyTpl(
        this.templatePath(input),
        this.destinationPath(output),
        Object.assign({}, data, { firstCharToLower })
      );
    };

    let filesToRender = [];
    const commonPath = 'Common/GuestBell.Common.' + this.projectName + '/';
    const pluginPath = 'Plugin/GuestBell.Plugin.' + this.projectName + '/';
    const webPath = 'Common/GuestBell.Common.Web/';
    const dalPath = 'Dal/GuestBell.Dal.' + this.projectName + '/';
    const hostPath = 'Host/GuestBell.Host.Backend/';

    if (this.projectCommon) {
      filesToRender = filesToRender.concat([
        {
          input: 'common/interface/IFeature.cs',
          output: commonPath + 'Interface/I' + this.featureName + '.cs',
        },
      ]);
      if (this.isPaginated) {
        filesToRender = filesToRender.concat([
          {
            input: 'common/model/enum/FeatureColumnNameEnum.cs',
            output:
              commonPath +
              'Model/Enum/' +
              this.featureName +
              'ColumnNameEnum.cs',
          },
        ]);
      }
      if (this.includeDelete) {
        filesToRender = filesToRender.concat([
          {
            input: 'common/requestResponse/DeleteFeaturesRequestDTO.cs',
            output:
              commonPath +
              '/RequestResponse/' +
              (this.namespaceRequestResponse ? this.featureName + '/' : '') +
              'Delete' +
              this.featureName +
              'sRequestDTO.cs',
          },
          {
            input: 'common/requestResponse/DeleteFeaturesResponseDTO.cs',
            output:
              commonPath +
              '/RequestResponse/' +
              (this.namespaceRequestResponse ? this.featureName + '/' : '') +
              'Delete' +
              this.featureName +
              'sResponseDTO.cs',
          },
        ]);
      }
      if (this.includeGet) {
        filesToRender = filesToRender.concat([
          {
            input: 'common/model/FeatureBaseDTO.cs',
            output:
              commonPath +
              '/Model/' +
              (this.namespaceRequestResponse ? this.featureName + '/' : '') +
              this.featureName +
              'BaseDTO.cs',
          },
          {
            input: 'common/model/FeatureDTO.cs',
            output:
              commonPath +
              '/Model/' +
              (this.namespaceRequestResponse ? this.featureName + '/' : '') +
              this.featureName +
              'DTO.cs',
          },
          {
            input: 'common/requestResponse/GetFeaturesRequestDTO.cs',
            output:
              commonPath +
              '/RequestResponse/' +
              (this.namespaceRequestResponse ? this.featureName + '/' : '') +
              'Get' +
              this.featureName +
              'sRequestDTO.cs',
          },
          {
            input: 'common/requestResponse/GetFeaturesResponseDTO.cs',
            output:
              commonPath +
              '/RequestResponse/' +
              (this.namespaceRequestResponse ? this.featureName + '/' : '') +
              'Get' +
              this.featureName +
              'sResponseDTO.cs',
          },
        ]);
      }
      if (this.includePost) {
        filesToRender = filesToRender.concat([
          {
            input: 'common/model/PostFeatureBaseDTO.cs',
            output:
              commonPath +
              '/Model/' +
              (this.namespaceRequestResponse ? this.featureName + '/' : '') +
              'Post' +
              this.featureName +
              'BaseDTO.cs',
          },
          {
            input: 'common/model/PostFeatureDTO.cs',
            output:
              commonPath +
              '/Model/' +
              (this.namespaceRequestResponse ? this.featureName + '/' : '') +
              'Post' +
              this.featureName +
              'DTO.cs',
          },
          {
            input: 'common/requestResponse/PostFeaturesRequestDTO.cs',
            output:
              commonPath +
              '/RequestResponse/' +
              (this.namespaceRequestResponse ? this.featureName + '/' : '') +
              'Post' +
              this.featureName +
              'sRequestDTO.cs',
          },
          {
            input: 'common/requestResponse/PostFeaturesResponseDTO.cs',
            output:
              commonPath +
              '/RequestResponse/' +
              (this.namespaceRequestResponse ? this.featureName + '/' : '') +
              'Post' +
              this.featureName +
              'sResponseDTO.cs',
          },
        ]);
      }
      if (this.includePut) {
        filesToRender = filesToRender.concat([
          {
            input: 'common/model/PutFeatureBaseDTO.cs',
            output:
              commonPath +
              '/Model/' +
              (this.namespaceRequestResponse ? this.featureName + '/' : '') +
              'Put' +
              this.featureName +
              'BaseDTO.cs',
          },
          {
            input: 'common/model/PutFeatureDTO.cs',
            output:
              commonPath +
              '/Model/' +
              (this.namespaceRequestResponse ? this.featureName + '/' : '') +
              'Put' +
              this.featureName +
              'DTO.cs',
          },
          {
            input: 'common/requestResponse/PutFeaturesRequestDTO.cs',
            output:
              commonPath +
              '/RequestResponse/' +
              (this.namespaceRequestResponse ? this.featureName + '/' : '') +
              'Put' +
              this.featureName +
              'sRequestDTO.cs',
          },
          {
            input: 'common/requestResponse/PutFeaturesResponseDTO.cs',
            output:
              commonPath +
              '/RequestResponse/' +
              (this.namespaceRequestResponse ? this.featureName + '/' : '') +
              'Put' +
              this.featureName +
              'sResponseDTO.cs',
          },
        ]);
      }
      if (this.createProjects) {
        filesToRender = filesToRender.concat([
          {
            input: 'common/GuestBell.Common.Feature.csproj',
            output:
              commonPath + 'GuestBell.Common.' + this.projectName + '.csproj',
          },
        ]);
      }
    }

    if (this.projectDal) {
      filesToRender = filesToRender.concat([
        {
          input: 'dal/interface/IFeatureDal.cs',
          output: dalPath + 'Interface/I' + this.featureName + 'Dal.cs',
        },
        {
          input: 'dal/FeatureDalCore.cs',
          output: dalPath + this.featureName + 'DalCore.cs',
        },
        {
          input: 'dal/FeatureDalConfigDTO.cs',
          output: dalPath + this.featureName + 'DalConfigDTO.cs',
        },
        {
          input: 'dal/mapping/FeatureDalProfile.cs',
          output: dalPath + 'Mapping/' + this.featureName + 'DalProfile.cs',
        },
      ]);
      if (this.isPaginated) {
        /*filesToRender = filesToRender.concat([
          {
            input: 'dal/model/enum/FeatureColumnNameSqlEnum.cs',
            output:
              dalPath +
              'Model/Enum/' +
              this.featureName +
              'ColumnNameSqlEnum.cs'
          }
        ]);*/
      }
      if (this.includeDelete) {
        filesToRender = filesToRender.concat([
          {
            input: 'dal/requestResponse/DeleteFeaturesSqlRequestDTO.cs',
            output:
              dalPath +
              '/RequestResponse/' +
              (this.namespaceRequestResponse ? this.featureName + '/' : '') +
              'Delete' +
              this.featureName +
              'sSqlRequestDTO.cs',
          },
          {
            input: 'dal/requestResponse/DeleteFeaturesSqlResponseDTO.cs',
            output:
              dalPath +
              '/RequestResponse/' +
              (this.namespaceRequestResponse ? this.featureName + '/' : '') +
              'Delete' +
              this.featureName +
              'sSqlResponseDTO.cs',
          },
        ]);
      }
      if (this.includeGet) {
        filesToRender = filesToRender.concat([
          {
            input: 'dal/model/FeatureSqlDTO.cs',
            output:
              dalPath +
              '/Model/' +
              (this.namespaceRequestResponse ? this.featureName + '/' : '') +
              this.featureName +
              'SqlDTO.cs',
          },
          {
            input: 'dal/requestResponse/GetFeaturesSqlRequestDTO.cs',
            output:
              dalPath +
              '/RequestResponse/' +
              (this.namespaceRequestResponse ? this.featureName + '/' : '') +
              'Get' +
              this.featureName +
              'sSqlRequestDTO.cs',
          },
          {
            input: 'dal/requestResponse/GetFeaturesSqlResponseDTO.cs',
            output:
              dalPath +
              '/RequestResponse/' +
              (this.namespaceRequestResponse ? this.featureName + '/' : '') +
              'Get' +
              this.featureName +
              'sSqlResponseDTO.cs',
          },
        ]);
      }
      if (this.includePost) {
        filesToRender = filesToRender.concat([
          {
            input: 'dal/model/PostFeatureSqlDTO.cs',
            output:
              dalPath +
              '/Model/' +
              (this.namespaceRequestResponse ? this.featureName + '/' : '') +
              'Post' +
              this.featureName +
              'SqlDTO.cs',
          },
          {
            input: 'dal/requestResponse/PostFeaturesSqlRequestDTO.cs',
            output:
              dalPath +
              '/RequestResponse/' +
              (this.namespaceRequestResponse ? this.featureName + '/' : '') +
              'Post' +
              this.featureName +
              'sSqlRequestDTO.cs',
          },
          {
            input: 'dal/requestResponse/PostFeaturesSqlResponseDTO.cs',
            output:
              dalPath +
              '/RequestResponse/' +
              (this.namespaceRequestResponse ? this.featureName + '/' : '') +
              'Post' +
              this.featureName +
              'sSqlResponseDTO.cs',
          },
        ]);
      }
      if (this.includePut) {
        filesToRender = filesToRender.concat([
          {
            input: 'dal/model/PutFeatureSqlDTO.cs',
            output:
              dalPath +
              '/Model/' +
              (this.namespaceRequestResponse ? this.featureName + '/' : '') +
              'Put' +
              this.featureName +
              'SqlDTO.cs',
          },
          {
            input: 'dal/requestResponse/PutFeaturesSqlRequestDTO.cs',
            output:
              dalPath +
              '/RequestResponse/' +
              (this.namespaceRequestResponse ? this.featureName + '/' : '') +
              'Put' +
              this.featureName +
              'sSqlRequestDTO.cs',
          },
          {
            input: 'dal/requestResponse/PutFeaturesSqlResponseDTO.cs',
            output:
              dalPath +
              '/RequestResponse/' +
              (this.namespaceRequestResponse ? this.featureName + '/' : '') +
              'Put' +
              this.featureName +
              'sSqlResponseDTO.cs',
          },
        ]);
      }
      if (this.createProjects) {
        filesToRender = filesToRender.concat([
          {
            input: 'dal/GuestBell.Dal.Feature.csproj',
            output: dalPath + 'GuestBell.Dal.' + this.projectName + '.csproj',
          },
        ]);
      }
    }

    if (this.projectPlugin) {
      filesToRender = filesToRender.concat([
        {
          input: 'plugin/FeatureCore.cs',
          output: pluginPath + this.featureName + 'Core.cs',
        },
        {
          input: 'plugin/FeatureConfigDTO.cs',
          output: pluginPath + this.featureName + 'ConfigDTO.cs',
        },
      ]);
      if (this.createProjects) {
        filesToRender = filesToRender.concat([
          {
            input: 'plugin/GuestBell.Plugin.Feature.csproj',
            output:
              pluginPath + 'GuestBell.Plugin.' + this.projectName + '.csproj',
          },
        ]);
      }
    }

    if (this.projectHost) {
      filesToRender = filesToRender.concat([
        {
          input: 'host/controllers/FeatureController.cs',
          output:
            hostPath + 'Controllers/' + this.featureName + 'Controller.cs',
        },
      ]);
    }

    if (this.projectWeb) {
      filesToRender = filesToRender.concat([
        {
          input: 'web/mapping/FeatureWebProfile.cs',
          output: webPath + 'Mapping/' + this.featureName + 'Profile.cs',
        },
      ]);
      if (this.isPaginated) {
        /*filesToRender = filesToRender.concat([
          {
            input: 'web/model/enum/FeatureColumnNameWebEnum.cs',
            output:
              webPath +
              'Model/' +
              this.featureName +
              '/Enum/' +
              this.featureName +
              'ColumnNameWebEnum.cs'
          }
        ]);*/
      }
      if (this.includeDelete) {
        filesToRender = filesToRender.concat([
          {
            input: 'web/viewModel/DeleteFeaturesWebResponseDTO.cs',
            output:
              webPath +
              'ViewModel/' +
              this.featureName +
              '/Delete' +
              this.featureName +
              'sWebResponseDTO.cs',
          },
        ]);
      }
      if (this.includeGet) {
        filesToRender = filesToRender.concat([
          {
            input: 'web/model/FeatureWebDTO.cs',
            output:
              webPath +
              '/Model/' +
              this.featureName +
              '/' +
              this.featureName +
              'WebDTO.cs',
          },
          {
            input: 'web/viewModel/GetFeaturesWebResponseDTO.cs',
            output:
              webPath +
              'ViewModel/' +
              this.featureName +
              '/Get' +
              this.featureName +
              'sWebResponseDTO.cs',
          },
          {
            input: 'web/viewModel/GetFeaturesWebRequestDTO.cs',
            output:
              webPath +
              'ViewModel/' +
              this.featureName +
              '/Get' +
              this.featureName +
              'sWebRequestDTO.cs',
          },
        ]);
      }
      if (this.includePost) {
        filesToRender = filesToRender.concat([
          {
            input: 'web/model/PostFeatureWebDTO.cs',
            output:
              webPath +
              '/Model/' +
              this.featureName +
              '/Post' +
              this.featureName +
              'WebDTO.cs',
          },
          {
            input: 'web/viewModel/PostFeaturesWebRequestDTO.cs',
            output:
              webPath +
              'ViewModel/' +
              this.featureName +
              '/Post' +
              this.featureName +
              'sWebRequestDTO.cs',
          },
          {
            input: 'web/viewModel/PostFeaturesWebResponseDTO.cs',
            output:
              webPath +
              'ViewModel/' +
              this.featureName +
              '/Post' +
              this.featureName +
              'sWebResponseDTO.cs',
          },
        ]);
      }
      if (this.includePut) {
        filesToRender = filesToRender.concat([
          {
            input: 'web/model/PutFeatureWebDTO.cs',
            output:
              webPath +
              '/Model/' +
              this.featureName +
              '/Put' +
              this.featureName +
              'WebDTO.cs',
          },
          {
            input: 'web/viewModel/PutFeaturesWebRequestDTO.cs',
            output:
              webPath +
              'ViewModel/' +
              this.featureName +
              '/Put' +
              this.featureName +
              'sWebRequestDTO.cs',
          },
          {
            input: 'web/viewModel/PutFeaturesWebResponseDTO.cs',
            output:
              webPath +
              '/ViewModel/' +
              this.featureName +
              '/Put' +
              this.featureName +
              'sWebResponseDTO.cs',
          },
        ]);
      }
    }

    // Render Files
    filesToRender.forEach(file => {
      copyTpl(file.input, file.output, templateData);
    });
  }

  install() {
    /*const hasYarn = commandExists('yarn');
    this.installDependencies({
      npm: !hasYarn,
      yarn: hasYarn,
      bower: false,
      skipMessage: this.options['skip-install-message'],
      skipInstall: this.options['skip-install']
    });*/
  }
};
