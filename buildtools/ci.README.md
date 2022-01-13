# Setup

1. Create CF template using `buildtools/ci.template`
2. Copy output `CodeBuildProjectName` & `OidcRole` output variables.
3. Create `CI_AWS_ROLE_ARN` repository secret with `OidcRole` value and
   `CI_AWS_CODE_BUILD_PROJECT_NAME` repository secret with `CodeBuildProjectName`
   value.
4. Voila!

# Troubleshooting

## thumbprint rotation
```
Error: OpenIDConnect provider's HTTPS certificate doesn't match configured thumbprint
```

This can happen if GitHub has rotated the thumbprint of the certificate. Follow [this guide](https://docs.aws.amazon.com/IAM/latest/UserGuide/id_roles_providers_create_oidc_verify-thumbprint.html) to generate new thumbprint.

Redeploy the ci.template with the new thumbprint. Additionally, contact https://github.com/aws-actions/configure-aws-credentials/issues for the thumbprint rotation.
