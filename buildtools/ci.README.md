# Setup

1. Create CF template using `buildtools/ci.template`
2. Copy output `CodeBuildProjectName` & `OidcRole` output variables.
3. Create `CI_AWS_ROLE_ARN` repository secret with `OidcRole` value and
   `CI_AWS_CODE_BUILD_PROJECT_NAME` repository secret with `CodeBuildProjectName`
   value.
4. Voila!