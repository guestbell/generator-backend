module.exports = {
  options: {
    'skip-welcome-message': {
      desc: 'Skips the welcome message',
      type: Boolean
    },
    'skip-install-message': {
      desc: 'Skips the message after the installation of dependencies',
      type: Boolean
    }
  },
  prompts: [
    {
      type: 'input',
      name: 'featureName',
      message: 'Name of this feature',
      store: true
    },
    {
      type: 'input',
      name: 'projectName',
      message: 'Name of the project',
      store: true
    },
    {
      type: 'confirm',
      name: 'createProjects',
      message: 'Should we create dot net projects as well?',
      default: false
    },
    {
      type: 'confirm',
      name: 'namespaceRequestResponse',
      message: 'Should we create Request/Response inside namespaces?',
      default: true
    },
    {
      type: 'confirm',
      name: 'isPaginated',
      message: 'Is this resource paginated?',
      default: true
    },
    {
      type: 'confirm',
      name: 'isBoundToProperty',
      message: 'Is this resource bound to property?',
      default: false
    },
    {
      type: 'checkbox',
      name: 'projects',
      message: 'Which projects would you like to include?',
      choices: [
        {
          name: 'Web',
          value: 'projectWeb',
          checked: true
        },
        {
          name: 'Host',
          value: 'projectHost',
          checked: true
        },
        {
          name: 'Common',
          value: 'projectCommon',
          checked: true
        },
        {
          name: 'Plugin',
          value: 'projectPlugin',
          checked: true
        },
        {
          name: 'Dal',
          value: 'projectDal',
          checked: true
        }
      ]
    },
    {
      type: 'checkbox',
      name: 'features',
      message: 'Which additional features would you like to include?',
      choices: [
        {
          name: 'Post',
          value: 'includePost',
          checked: true
        },
        {
          name: 'Put',
          value: 'includePut',
          checked: true
        },
        {
          name: 'Delete',
          value: 'includeDelete',
          checked: true
        },
        {
          name: 'Get',
          value: 'includeGet',
          checked: false
        }
      ]
    }
  ]
};
