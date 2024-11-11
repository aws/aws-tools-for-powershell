/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License"). You may not use
 *  this file except in compliance with the License. A copy of the License is located at
 *
 *  http://aws.amazon.com/apache2.0
 *
 *  or in the "license" file accompanying this file.
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the
 *  specific language governing permissions and limitations under the License.
 * *****************************************************************************
 *
 *  AWS Tools for Windows (TM) PowerShell (TM)
 *
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.OpenSearchService;
using Amazon.OpenSearchService.Model;

namespace Amazon.PowerShell.Cmdlets.OS
{
    /// <summary>
    /// Creates a package for use with Amazon OpenSearch Service domains. For more information,
    /// see <a href="https://docs.aws.amazon.com/opensearch-service/latest/developerguide/custom-packages.html">Custom
    /// packages for Amazon OpenSearch Service</a>.
    /// </summary>
    [Cmdlet("New", "OSPackage", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.OpenSearchService.Model.PackageDetails")]
    [AWSCmdlet("Calls the Amazon OpenSearch Service CreatePackage API operation.", Operation = new[] {"CreatePackage"}, SelectReturnType = typeof(Amazon.OpenSearchService.Model.CreatePackageResponse))]
    [AWSCmdletOutput("Amazon.OpenSearchService.Model.PackageDetails or Amazon.OpenSearchService.Model.CreatePackageResponse",
        "This cmdlet returns an Amazon.OpenSearchService.Model.PackageDetails object.",
        "The service call response (type Amazon.OpenSearchService.Model.CreatePackageResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewOSPackageCmdlet : AmazonOpenSearchServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter PackageConfiguration_ConfigurationRequirement
        /// <summary>
        /// <para>
        /// <para>The configuration requirements for the package.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.OpenSearchService.RequirementLevel")]
        public Amazon.OpenSearchService.RequirementLevel PackageConfiguration_ConfigurationRequirement { get; set; }
        #endregion
        
        #region Parameter PackageEncryptionOptions_EncryptionEnabled
        /// <summary>
        /// <para>
        /// <para>This indicates whether encryption is enabled for the package.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? PackageEncryptionOptions_EncryptionEnabled { get; set; }
        #endregion
        
        #region Parameter EngineVersion
        /// <summary>
        /// <para>
        /// <para>The version of the Amazon OpenSearch Service engine for which is compatible with the
        /// package. This can only be specified for package type <c>ZIP-PLUGIN</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EngineVersion { get; set; }
        #endregion
        
        #region Parameter PackageEncryptionOptions_KmsKeyIdentifier
        /// <summary>
        /// <para>
        /// <para> KMS key ID for encrypting the package.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PackageEncryptionOptions_KmsKeyIdentifier { get; set; }
        #endregion
        
        #region Parameter PackageConfiguration_LicenseFilepath
        /// <summary>
        /// <para>
        /// <para>The relative file path for the license associated with the package.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PackageConfiguration_LicenseFilepath { get; set; }
        #endregion
        
        #region Parameter PackageConfiguration_LicenseRequirement
        /// <summary>
        /// <para>
        /// <para>The license requirements for the package.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.OpenSearchService.RequirementLevel")]
        public Amazon.OpenSearchService.RequirementLevel PackageConfiguration_LicenseRequirement { get; set; }
        #endregion
        
        #region Parameter PackageDescription
        /// <summary>
        /// <para>
        /// <para>Description of the package.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PackageDescription { get; set; }
        #endregion
        
        #region Parameter PackageName
        /// <summary>
        /// <para>
        /// <para>Unique name for the package.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String PackageName { get; set; }
        #endregion
        
        #region Parameter PackageType
        /// <summary>
        /// <para>
        /// <para>The type of package.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.OpenSearchService.PackageType")]
        public Amazon.OpenSearchService.PackageType PackageType { get; set; }
        #endregion
        
        #region Parameter PackageConfiguration_RequiresRestartForConfigurationUpdate
        /// <summary>
        /// <para>
        /// <para>This indicates whether a B/G deployment is required for updating the configuration
        /// that the plugin is prerequisite for.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? PackageConfiguration_RequiresRestartForConfigurationUpdate { get; set; }
        #endregion
        
        #region Parameter PackageSource_S3BucketName
        /// <summary>
        /// <para>
        /// <para>The name of the Amazon S3 bucket containing the package.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PackageSource_S3BucketName { get; set; }
        #endregion
        
        #region Parameter PackageSource_S3Key
        /// <summary>
        /// <para>
        /// <para>Key (file name) of the package.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PackageSource_S3Key { get; set; }
        #endregion
        
        #region Parameter PackageVendingOptions_VendingEnabled
        /// <summary>
        /// <para>
        /// <para>This indicates whether vending is enabled for the package to determine if package
        /// can be used by other users. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? PackageVendingOptions_VendingEnabled { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'PackageDetails'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.OpenSearchService.Model.CreatePackageResponse).
        /// Specifying the name of a property of type Amazon.OpenSearchService.Model.CreatePackageResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "PackageDetails";
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.PackageName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-OSPackage (CreatePackage)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.OpenSearchService.Model.CreatePackageResponse, NewOSPackageCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.EngineVersion = this.EngineVersion;
            context.PackageConfiguration_ConfigurationRequirement = this.PackageConfiguration_ConfigurationRequirement;
            context.PackageConfiguration_LicenseFilepath = this.PackageConfiguration_LicenseFilepath;
            context.PackageConfiguration_LicenseRequirement = this.PackageConfiguration_LicenseRequirement;
            context.PackageConfiguration_RequiresRestartForConfigurationUpdate = this.PackageConfiguration_RequiresRestartForConfigurationUpdate;
            context.PackageDescription = this.PackageDescription;
            context.PackageEncryptionOptions_EncryptionEnabled = this.PackageEncryptionOptions_EncryptionEnabled;
            context.PackageEncryptionOptions_KmsKeyIdentifier = this.PackageEncryptionOptions_KmsKeyIdentifier;
            context.PackageName = this.PackageName;
            #if MODULAR
            if (this.PackageName == null && ParameterWasBound(nameof(this.PackageName)))
            {
                WriteWarning("You are passing $null as a value for parameter PackageName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PackageSource_S3BucketName = this.PackageSource_S3BucketName;
            context.PackageSource_S3Key = this.PackageSource_S3Key;
            context.PackageType = this.PackageType;
            #if MODULAR
            if (this.PackageType == null && ParameterWasBound(nameof(this.PackageType)))
            {
                WriteWarning("You are passing $null as a value for parameter PackageType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PackageVendingOptions_VendingEnabled = this.PackageVendingOptions_VendingEnabled;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.OpenSearchService.Model.CreatePackageRequest();
            
            if (cmdletContext.EngineVersion != null)
            {
                request.EngineVersion = cmdletContext.EngineVersion;
            }
            
             // populate PackageConfiguration
            var requestPackageConfigurationIsNull = true;
            request.PackageConfiguration = new Amazon.OpenSearchService.Model.PackageConfiguration();
            Amazon.OpenSearchService.RequirementLevel requestPackageConfiguration_packageConfiguration_ConfigurationRequirement = null;
            if (cmdletContext.PackageConfiguration_ConfigurationRequirement != null)
            {
                requestPackageConfiguration_packageConfiguration_ConfigurationRequirement = cmdletContext.PackageConfiguration_ConfigurationRequirement;
            }
            if (requestPackageConfiguration_packageConfiguration_ConfigurationRequirement != null)
            {
                request.PackageConfiguration.ConfigurationRequirement = requestPackageConfiguration_packageConfiguration_ConfigurationRequirement;
                requestPackageConfigurationIsNull = false;
            }
            System.String requestPackageConfiguration_packageConfiguration_LicenseFilepath = null;
            if (cmdletContext.PackageConfiguration_LicenseFilepath != null)
            {
                requestPackageConfiguration_packageConfiguration_LicenseFilepath = cmdletContext.PackageConfiguration_LicenseFilepath;
            }
            if (requestPackageConfiguration_packageConfiguration_LicenseFilepath != null)
            {
                request.PackageConfiguration.LicenseFilepath = requestPackageConfiguration_packageConfiguration_LicenseFilepath;
                requestPackageConfigurationIsNull = false;
            }
            Amazon.OpenSearchService.RequirementLevel requestPackageConfiguration_packageConfiguration_LicenseRequirement = null;
            if (cmdletContext.PackageConfiguration_LicenseRequirement != null)
            {
                requestPackageConfiguration_packageConfiguration_LicenseRequirement = cmdletContext.PackageConfiguration_LicenseRequirement;
            }
            if (requestPackageConfiguration_packageConfiguration_LicenseRequirement != null)
            {
                request.PackageConfiguration.LicenseRequirement = requestPackageConfiguration_packageConfiguration_LicenseRequirement;
                requestPackageConfigurationIsNull = false;
            }
            System.Boolean? requestPackageConfiguration_packageConfiguration_RequiresRestartForConfigurationUpdate = null;
            if (cmdletContext.PackageConfiguration_RequiresRestartForConfigurationUpdate != null)
            {
                requestPackageConfiguration_packageConfiguration_RequiresRestartForConfigurationUpdate = cmdletContext.PackageConfiguration_RequiresRestartForConfigurationUpdate.Value;
            }
            if (requestPackageConfiguration_packageConfiguration_RequiresRestartForConfigurationUpdate != null)
            {
                request.PackageConfiguration.RequiresRestartForConfigurationUpdate = requestPackageConfiguration_packageConfiguration_RequiresRestartForConfigurationUpdate.Value;
                requestPackageConfigurationIsNull = false;
            }
             // determine if request.PackageConfiguration should be set to null
            if (requestPackageConfigurationIsNull)
            {
                request.PackageConfiguration = null;
            }
            if (cmdletContext.PackageDescription != null)
            {
                request.PackageDescription = cmdletContext.PackageDescription;
            }
            
             // populate PackageEncryptionOptions
            var requestPackageEncryptionOptionsIsNull = true;
            request.PackageEncryptionOptions = new Amazon.OpenSearchService.Model.PackageEncryptionOptions();
            System.Boolean? requestPackageEncryptionOptions_packageEncryptionOptions_EncryptionEnabled = null;
            if (cmdletContext.PackageEncryptionOptions_EncryptionEnabled != null)
            {
                requestPackageEncryptionOptions_packageEncryptionOptions_EncryptionEnabled = cmdletContext.PackageEncryptionOptions_EncryptionEnabled.Value;
            }
            if (requestPackageEncryptionOptions_packageEncryptionOptions_EncryptionEnabled != null)
            {
                request.PackageEncryptionOptions.EncryptionEnabled = requestPackageEncryptionOptions_packageEncryptionOptions_EncryptionEnabled.Value;
                requestPackageEncryptionOptionsIsNull = false;
            }
            System.String requestPackageEncryptionOptions_packageEncryptionOptions_KmsKeyIdentifier = null;
            if (cmdletContext.PackageEncryptionOptions_KmsKeyIdentifier != null)
            {
                requestPackageEncryptionOptions_packageEncryptionOptions_KmsKeyIdentifier = cmdletContext.PackageEncryptionOptions_KmsKeyIdentifier;
            }
            if (requestPackageEncryptionOptions_packageEncryptionOptions_KmsKeyIdentifier != null)
            {
                request.PackageEncryptionOptions.KmsKeyIdentifier = requestPackageEncryptionOptions_packageEncryptionOptions_KmsKeyIdentifier;
                requestPackageEncryptionOptionsIsNull = false;
            }
             // determine if request.PackageEncryptionOptions should be set to null
            if (requestPackageEncryptionOptionsIsNull)
            {
                request.PackageEncryptionOptions = null;
            }
            if (cmdletContext.PackageName != null)
            {
                request.PackageName = cmdletContext.PackageName;
            }
            
             // populate PackageSource
            var requestPackageSourceIsNull = true;
            request.PackageSource = new Amazon.OpenSearchService.Model.PackageSource();
            System.String requestPackageSource_packageSource_S3BucketName = null;
            if (cmdletContext.PackageSource_S3BucketName != null)
            {
                requestPackageSource_packageSource_S3BucketName = cmdletContext.PackageSource_S3BucketName;
            }
            if (requestPackageSource_packageSource_S3BucketName != null)
            {
                request.PackageSource.S3BucketName = requestPackageSource_packageSource_S3BucketName;
                requestPackageSourceIsNull = false;
            }
            System.String requestPackageSource_packageSource_S3Key = null;
            if (cmdletContext.PackageSource_S3Key != null)
            {
                requestPackageSource_packageSource_S3Key = cmdletContext.PackageSource_S3Key;
            }
            if (requestPackageSource_packageSource_S3Key != null)
            {
                request.PackageSource.S3Key = requestPackageSource_packageSource_S3Key;
                requestPackageSourceIsNull = false;
            }
             // determine if request.PackageSource should be set to null
            if (requestPackageSourceIsNull)
            {
                request.PackageSource = null;
            }
            if (cmdletContext.PackageType != null)
            {
                request.PackageType = cmdletContext.PackageType;
            }
            
             // populate PackageVendingOptions
            var requestPackageVendingOptionsIsNull = true;
            request.PackageVendingOptions = new Amazon.OpenSearchService.Model.PackageVendingOptions();
            System.Boolean? requestPackageVendingOptions_packageVendingOptions_VendingEnabled = null;
            if (cmdletContext.PackageVendingOptions_VendingEnabled != null)
            {
                requestPackageVendingOptions_packageVendingOptions_VendingEnabled = cmdletContext.PackageVendingOptions_VendingEnabled.Value;
            }
            if (requestPackageVendingOptions_packageVendingOptions_VendingEnabled != null)
            {
                request.PackageVendingOptions.VendingEnabled = requestPackageVendingOptions_packageVendingOptions_VendingEnabled.Value;
                requestPackageVendingOptionsIsNull = false;
            }
             // determine if request.PackageVendingOptions should be set to null
            if (requestPackageVendingOptionsIsNull)
            {
                request.PackageVendingOptions = null;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
                };
            }
            catch (Exception e)
            {
                output = new CmdletOutput { ErrorResponse = e };
            }
            
            return output;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.OpenSearchService.Model.CreatePackageResponse CallAWSServiceOperation(IAmazonOpenSearchService client, Amazon.OpenSearchService.Model.CreatePackageRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon OpenSearch Service", "CreatePackage");
            try
            {
                #if DESKTOP
                return client.CreatePackage(request);
                #elif CORECLR
                return client.CreatePackageAsync(request).GetAwaiter().GetResult();
                #else
                        #error "Unknown build edition"
                #endif
            }
            catch (AmazonServiceException exc)
            {
                var webException = exc.InnerException as System.Net.WebException;
                if (webException != null)
                {
                    throw new Exception(Utils.Common.FormatNameResolutionFailureMessage(client.Config, webException.Message), webException);
                }
                throw;
            }
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public System.String EngineVersion { get; set; }
            public Amazon.OpenSearchService.RequirementLevel PackageConfiguration_ConfigurationRequirement { get; set; }
            public System.String PackageConfiguration_LicenseFilepath { get; set; }
            public Amazon.OpenSearchService.RequirementLevel PackageConfiguration_LicenseRequirement { get; set; }
            public System.Boolean? PackageConfiguration_RequiresRestartForConfigurationUpdate { get; set; }
            public System.String PackageDescription { get; set; }
            public System.Boolean? PackageEncryptionOptions_EncryptionEnabled { get; set; }
            public System.String PackageEncryptionOptions_KmsKeyIdentifier { get; set; }
            public System.String PackageName { get; set; }
            public System.String PackageSource_S3BucketName { get; set; }
            public System.String PackageSource_S3Key { get; set; }
            public Amazon.OpenSearchService.PackageType PackageType { get; set; }
            public System.Boolean? PackageVendingOptions_VendingEnabled { get; set; }
            public System.Func<Amazon.OpenSearchService.Model.CreatePackageResponse, NewOSPackageCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.PackageDetails;
        }
        
    }
}
