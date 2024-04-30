# Contributing Guidelines

Thank you for your interest in contributing to our project. Whether it's a bug report, new feature, correction, or additional
documentation, we greatly value feedback and contributions from our community.

Please read through this document before submitting any issues or pull requests to ensure we have all the necessary
information to effectively respond to your bug report or contribution.


## Reporting Bugs/Feature Requests

We welcome you to use the GitHub issue tracker to report bugs or suggest features.

When filing an issue, please check [existing open](https://github.com/aws/aws-tools-for-powershell/issues), or [recently closed](https://github.com/aws/aws-tools-for-powershell/issues?utf8=%E2%9C%93&q=is%3Aissue%20is%3Aclosed%20), issues to make sure somebody else hasn't already
reported the issue. Please try to include as much information as you can. Details like these are incredibly useful:

* A reproducible test case or series of steps
* The version of our code being used
* Any modifications you've made relevant to the bug
* Anything unusual about your environment or deployment


## Contributing via Pull Requests
Contributions via pull requests are much appreciated. Before sending us a pull request, please ensure that:

1. You are working against the latest source on the *master* branch.
2. You check existing open, and recently merged, pull requests to make sure someone else hasn't addressed the problem already.
3. You open an issue to discuss any significant work - we would hate for your time to be wasted.

To send us a pull request, please:

1. Fork the repository.
2. Modify the source; please focus on the specific change you are contributing. If you also reformat all the code, it will be hard for us to focus on your change.
3. Ensure local tests pass.
4. Commit to your fork using clear commit messages.
5. Send us a pull request, answering any default questions in the pull request interface.
6. Pay attention to any automated CI failures reported in the pull request, and stay involved in the conversation.

GitHub provides additional document on [forking a repository](https://help.github.com/articles/fork-a-repo/) and
[creating a pull request](https://help.github.com/articles/creating-a-pull-request/).


## Finding contributions to work on
Looking at the existing issues is a great way to find something to contribute on. As our projects, by default, use the default GitHub issue labels (enhancement/bug/duplicate/help wanted/invalid/question/wontfix), looking at any ['help wanted'](https://github.com/aws/aws-tools-for-powershell/labels/help%20wanted) issues is a great place to start.


## Code of Conduct
This project has adopted the [Amazon Open Source Code of Conduct](https://aws.github.io/code-of-conduct).
For more information see the [Code of Conduct FAQ](https://aws.github.io/code-of-conduct-faq) or contact
opensource-codeofconduct@amazon.com with any additional questions or comments.


## Security issue notifications
If you discover a potential security issue in this project we ask that you notify AWS/Amazon Security via our [vulnerability reporting page](http://aws.amazon.com/security/vulnerability-reporting/). Please do **not** create a public github issue.


## Licensing

See the [LICENSE](https://github.com/aws/aws-tools-for-powershell/blob/master/LICENSE) file for our project's licensing. We will ask you to confirm the licensing of your contribution.

We may ask you to sign a [Contributor License Agreement (CLA)](http://en.wikipedia.org/wiki/Contributor_License_Agreement) for larger changes.

## Examples in the AWS Tools for PowerShell Repo

Examples are published to:

1. The local help documents in AWS Tools for PowerShell modules that are accessed with `Get-Help`.
2. The online help documents found in the [AWS Tools for PowerShell Reference](https://docs.aws.amazon.com/powershell/latest/reference/).
3. The [AWS Developer Center Examples Site](https://aws.amazon.com/developer/code-examples).

The examples content can be found in the [.doc_gen](https://github.com/aws/aws-tools-for-powershell/tree/master/.doc_gen) folder.

The files in the [metadata folder](https://github.com/aws/aws-tools-for-powershell/tree/master/.doc_gen/metadata) describe one or more examples for each cmdlet. For now, common cmdlets which do not belong to a particular AWS service have a separate folder for metadata files.

Please copy the format of existing example files when adding new files. Also note:

1. The AWS service name used in file names or metadata properties should follow the naming convention set by file names in [this folder in the JavaScript SDK repo](https://github.com/aws/aws-sdk-js-v3/tree/main/codegen/sdk-codegen/aws-models).
1. Metadata file content begins and ends with a reference to the name of the AWS API action associated with a cmdlet. The AWS API action name can be looked up using the cmdlet `Get-AWSCmdletName`.
1. Examples are constructed with multiple excerpts where each excerpt may contain a heading, code block, or output. If there are multiple examples for a cmdlet, these excerpts will immediately follow each other in one continuous list.
1. Code blocks in examples are stored in the [snippet_files](https://github.com/aws/aws-tools-for-powershell/tree/master/.doc_gen/snippet_files) folder. The snippet file names contain two numeric values indicating (1) the numbering for multiple examples followed by (2) the numbering for multiple code blocks.
1. Examples will not be published for an AWS service until an entry has been added to [services.yaml in aws-doc-sdk-examples-tools](https://github.com/awsdocs/aws-doc-sdk-examples-tools/blob/main/aws_doc_sdk_examples_tools/config/services.yaml) repo.
1. Some characters are reserved and must be replaced with the following expressions:
  1. `&` -> `&amp;` 
  1. `<` -> `&lt;`
  1. `>` -> `&gt;`
1. Placeholder values called entities are used for terms that need to be regionalized appropriately. A few of these entities are supported/required in examples for AWS Tools for PowerShell. The following terms should be replaced with the following entity tokens in metadata files:
  1. `AWS` -> `&AWS;`
  1. `AWS account` -> `&AWS-account;`
  1. `AWS accounts` -> `&AWS-accounts;`
  1. `AWS Region` -> `&AWS-Region;`
  1. `AWS Regions` -> `&AWS-Regions;`
  1. `AWS Service` -> `&AWS-service;`
  1. `AWS Services` -> `&AWS-services;`
  1. Note: While more entities exist (such as for the names of each Amazon Web Service) at this time AWS Tools for PowerShell only supports the short list of entities provided above.
