/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using System.Threading;
using Amazon.DataSync;
using Amazon.DataSync.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.DSYN
{
    /// <summary>
    /// Creates a transfer <i>location</i> for a Microsoft Azure Blob Storage container. DataSync
    /// can use this location as a transfer source or destination. You can make transfers
    /// with or without a <a href="https://docs.aws.amazon.com/datasync/latest/userguide/creating-azure-blob-location.html#azure-blob-creating-agent">DataSync
    /// agent</a> that connects to your container.
    /// 
    ///  
    /// <para>
    /// Before you begin, make sure you know <a href="https://docs.aws.amazon.com/datasync/latest/userguide/creating-azure-blob-location.html#azure-blob-access">how
    /// DataSync accesses Azure Blob Storage</a> and works with <a href="https://docs.aws.amazon.com/datasync/latest/userguide/creating-azure-blob-location.html#azure-blob-access-tiers">access
    /// tiers</a> and <a href="https://docs.aws.amazon.com/datasync/latest/userguide/creating-azure-blob-location.html#blob-types">blob
    /// types</a>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "DSYNLocationAzureBlob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS DataSync CreateLocationAzureBlob API operation.", Operation = new[] {"CreateLocationAzureBlob"}, SelectReturnType = typeof(Amazon.DataSync.Model.CreateLocationAzureBlobResponse))]
    [AWSCmdletOutput("System.String or Amazon.DataSync.Model.CreateLocationAzureBlobResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.DataSync.Model.CreateLocationAzureBlobResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewDSYNLocationAzureBlobCmdlet : AmazonDataSyncClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AccessTier
        /// <summary>
        /// <para>
        /// <para>Specifies the access tier that you want your objects or files transferred into. This
        /// only applies when using the location as a transfer destination. For more information,
        /// see <a href="https://docs.aws.amazon.com/datasync/latest/userguide/creating-azure-blob-location.html#azure-blob-access-tiers">Access
        /// tiers</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DataSync.AzureAccessTier")]
        public Amazon.DataSync.AzureAccessTier AccessTier { get; set; }
        #endregion
        
        #region Parameter AgentArn
        /// <summary>
        /// <para>
        /// <para>(Optional) Specifies the Amazon Resource Name (ARN) of the DataSync agent that can
        /// connect with your Azure Blob Storage container. If you are setting up an agentless
        /// cross-cloud transfer, you do not need to specify a value for this parameter.</para><para>You can specify more than one agent. For more information, see <a href="https://docs.aws.amazon.com/datasync/latest/userguide/multiple-agents.html">Using
        /// multiple agents for your transfer</a>.</para><note><para>Make sure you configure this parameter correctly when you first create your storage
        /// location. You cannot add or remove agents from a storage location after you create
        /// it.</para></note><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AgentArns")]
        public System.String[] AgentArn { get; set; }
        #endregion
        
        #region Parameter AuthenticationType
        /// <summary>
        /// <para>
        /// <para>Specifies the authentication method DataSync uses to access your Azure Blob Storage.
        /// DataSync can access blob storage using a shared access signature (SAS).</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.DataSync.AzureBlobAuthenticationType")]
        public Amazon.DataSync.AzureBlobAuthenticationType AuthenticationType { get; set; }
        #endregion
        
        #region Parameter BlobType
        /// <summary>
        /// <para>
        /// <para>Specifies the type of blob that you want your objects or files to be when transferring
        /// them into Azure Blob Storage. Currently, DataSync only supports moving data into Azure
        /// Blob Storage as block blobs. For more information on blob types, see the <a href="https://learn.microsoft.com/en-us/rest/api/storageservices/understanding-block-blobs--append-blobs--and-page-blobs">Azure
        /// Blob Storage documentation</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DataSync.AzureBlobType")]
        public Amazon.DataSync.AzureBlobType BlobType { get; set; }
        #endregion
        
        #region Parameter ContainerUrl
        /// <summary>
        /// <para>
        /// <para>Specifies the URL of the Azure Blob Storage container involved in your transfer.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String ContainerUrl { get; set; }
        #endregion
        
        #region Parameter CmkSecretConfig_KmsKeyArn
        /// <summary>
        /// <para>
        /// <para>Specifies the ARN for the customer-managed KMS key that DataSync uses to encrypt the
        /// DataSync-managed secret stored for <c>SecretArn</c>. DataSync provides this key to
        /// Secrets Manager.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CmkSecretConfig_KmsKeyArn { get; set; }
        #endregion
        
        #region Parameter CustomSecretConfig_SecretAccessRoleArn
        /// <summary>
        /// <para>
        /// <para>Specifies the ARN for the Identity and Access Management role that DataSync uses to
        /// access the secret specified for <c>SecretArn</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CustomSecretConfig_SecretAccessRoleArn { get; set; }
        #endregion
        
        #region Parameter CmkSecretConfig_SecretArn
        /// <summary>
        /// <para>
        /// <para>Specifies the ARN for the DataSync-managed Secrets Manager secret that that is used
        /// to access a specific storage location. This property is generated by DataSync and
        /// is read-only. DataSync encrypts this secret with the KMS key that you specify for
        /// <c>KmsKeyArn</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CmkSecretConfig_SecretArn { get; set; }
        #endregion
        
        #region Parameter CustomSecretConfig_SecretArn
        /// <summary>
        /// <para>
        /// <para>Specifies the ARN for an Secrets Manager secret.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CustomSecretConfig_SecretArn { get; set; }
        #endregion
        
        #region Parameter Subdirectory
        /// <summary>
        /// <para>
        /// <para>Specifies path segments if you want to limit your transfer to a virtual directory
        /// in your container (for example, <c>/my/images</c>).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Subdirectory { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Specifies labels that help you categorize, filter, and search for your Amazon Web
        /// Services resources. We recommend creating at least a name tag for your transfer location.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.DataSync.Model.TagListEntry[] Tag { get; set; }
        #endregion
        
        #region Parameter SasConfiguration_Token
        /// <summary>
        /// <para>
        /// <para>Specifies a SAS token that provides permissions to access your Azure Blob Storage.</para><para>The token is part of the SAS URI string that comes after the storage resource URI
        /// and a question mark. A token looks something like this:</para><para><c>sp=r&amp;st=2023-12-20T14:54:52Z&amp;se=2023-12-20T22:54:52Z&amp;spr=https&amp;sv=2021-06-08&amp;sr=c&amp;sig=aBBKDWQvyuVcTPH9EBp%2FXTI9E%2F%2Fmq171%2BZU178wcwqU%3D</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SasConfiguration_Token { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'LocationArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DataSync.Model.CreateLocationAzureBlobResponse).
        /// Specifying the name of a property of type Amazon.DataSync.Model.CreateLocationAzureBlobResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "LocationArn";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ContainerUrl), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-DSYNLocationAzureBlob (CreateLocationAzureBlob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DataSync.Model.CreateLocationAzureBlobResponse, NewDSYNLocationAzureBlobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AccessTier = this.AccessTier;
            if (this.AgentArn != null)
            {
                context.AgentArn = new List<System.String>(this.AgentArn);
            }
            context.AuthenticationType = this.AuthenticationType;
            #if MODULAR
            if (this.AuthenticationType == null && ParameterWasBound(nameof(this.AuthenticationType)))
            {
                WriteWarning("You are passing $null as a value for parameter AuthenticationType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.BlobType = this.BlobType;
            context.CmkSecretConfig_KmsKeyArn = this.CmkSecretConfig_KmsKeyArn;
            context.CmkSecretConfig_SecretArn = this.CmkSecretConfig_SecretArn;
            context.ContainerUrl = this.ContainerUrl;
            #if MODULAR
            if (this.ContainerUrl == null && ParameterWasBound(nameof(this.ContainerUrl)))
            {
                WriteWarning("You are passing $null as a value for parameter ContainerUrl which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CustomSecretConfig_SecretAccessRoleArn = this.CustomSecretConfig_SecretAccessRoleArn;
            context.CustomSecretConfig_SecretArn = this.CustomSecretConfig_SecretArn;
            context.SasConfiguration_Token = this.SasConfiguration_Token;
            context.Subdirectory = this.Subdirectory;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.DataSync.Model.TagListEntry>(this.Tag);
            }
            
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
            var request = new Amazon.DataSync.Model.CreateLocationAzureBlobRequest();
            
            if (cmdletContext.AccessTier != null)
            {
                request.AccessTier = cmdletContext.AccessTier;
            }
            if (cmdletContext.AgentArn != null)
            {
                request.AgentArns = cmdletContext.AgentArn;
            }
            if (cmdletContext.AuthenticationType != null)
            {
                request.AuthenticationType = cmdletContext.AuthenticationType;
            }
            if (cmdletContext.BlobType != null)
            {
                request.BlobType = cmdletContext.BlobType;
            }
            
             // populate CmkSecretConfig
            var requestCmkSecretConfigIsNull = true;
            request.CmkSecretConfig = new Amazon.DataSync.Model.CmkSecretConfig();
            System.String requestCmkSecretConfig_cmkSecretConfig_KmsKeyArn = null;
            if (cmdletContext.CmkSecretConfig_KmsKeyArn != null)
            {
                requestCmkSecretConfig_cmkSecretConfig_KmsKeyArn = cmdletContext.CmkSecretConfig_KmsKeyArn;
            }
            if (requestCmkSecretConfig_cmkSecretConfig_KmsKeyArn != null)
            {
                request.CmkSecretConfig.KmsKeyArn = requestCmkSecretConfig_cmkSecretConfig_KmsKeyArn;
                requestCmkSecretConfigIsNull = false;
            }
            System.String requestCmkSecretConfig_cmkSecretConfig_SecretArn = null;
            if (cmdletContext.CmkSecretConfig_SecretArn != null)
            {
                requestCmkSecretConfig_cmkSecretConfig_SecretArn = cmdletContext.CmkSecretConfig_SecretArn;
            }
            if (requestCmkSecretConfig_cmkSecretConfig_SecretArn != null)
            {
                request.CmkSecretConfig.SecretArn = requestCmkSecretConfig_cmkSecretConfig_SecretArn;
                requestCmkSecretConfigIsNull = false;
            }
             // determine if request.CmkSecretConfig should be set to null
            if (requestCmkSecretConfigIsNull)
            {
                request.CmkSecretConfig = null;
            }
            if (cmdletContext.ContainerUrl != null)
            {
                request.ContainerUrl = cmdletContext.ContainerUrl;
            }
            
             // populate CustomSecretConfig
            var requestCustomSecretConfigIsNull = true;
            request.CustomSecretConfig = new Amazon.DataSync.Model.CustomSecretConfig();
            System.String requestCustomSecretConfig_customSecretConfig_SecretAccessRoleArn = null;
            if (cmdletContext.CustomSecretConfig_SecretAccessRoleArn != null)
            {
                requestCustomSecretConfig_customSecretConfig_SecretAccessRoleArn = cmdletContext.CustomSecretConfig_SecretAccessRoleArn;
            }
            if (requestCustomSecretConfig_customSecretConfig_SecretAccessRoleArn != null)
            {
                request.CustomSecretConfig.SecretAccessRoleArn = requestCustomSecretConfig_customSecretConfig_SecretAccessRoleArn;
                requestCustomSecretConfigIsNull = false;
            }
            System.String requestCustomSecretConfig_customSecretConfig_SecretArn = null;
            if (cmdletContext.CustomSecretConfig_SecretArn != null)
            {
                requestCustomSecretConfig_customSecretConfig_SecretArn = cmdletContext.CustomSecretConfig_SecretArn;
            }
            if (requestCustomSecretConfig_customSecretConfig_SecretArn != null)
            {
                request.CustomSecretConfig.SecretArn = requestCustomSecretConfig_customSecretConfig_SecretArn;
                requestCustomSecretConfigIsNull = false;
            }
             // determine if request.CustomSecretConfig should be set to null
            if (requestCustomSecretConfigIsNull)
            {
                request.CustomSecretConfig = null;
            }
            
             // populate SasConfiguration
            var requestSasConfigurationIsNull = true;
            request.SasConfiguration = new Amazon.DataSync.Model.AzureBlobSasConfiguration();
            System.String requestSasConfiguration_sasConfiguration_Token = null;
            if (cmdletContext.SasConfiguration_Token != null)
            {
                requestSasConfiguration_sasConfiguration_Token = cmdletContext.SasConfiguration_Token;
            }
            if (requestSasConfiguration_sasConfiguration_Token != null)
            {
                request.SasConfiguration.Token = requestSasConfiguration_sasConfiguration_Token;
                requestSasConfigurationIsNull = false;
            }
             // determine if request.SasConfiguration should be set to null
            if (requestSasConfigurationIsNull)
            {
                request.SasConfiguration = null;
            }
            if (cmdletContext.Subdirectory != null)
            {
                request.Subdirectory = cmdletContext.Subdirectory;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.DataSync.Model.CreateLocationAzureBlobResponse CallAWSServiceOperation(IAmazonDataSync client, Amazon.DataSync.Model.CreateLocationAzureBlobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS DataSync", "CreateLocationAzureBlob");
            try
            {
                return client.CreateLocationAzureBlobAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.DataSync.AzureAccessTier AccessTier { get; set; }
            public List<System.String> AgentArn { get; set; }
            public Amazon.DataSync.AzureBlobAuthenticationType AuthenticationType { get; set; }
            public Amazon.DataSync.AzureBlobType BlobType { get; set; }
            public System.String CmkSecretConfig_KmsKeyArn { get; set; }
            public System.String CmkSecretConfig_SecretArn { get; set; }
            public System.String ContainerUrl { get; set; }
            public System.String CustomSecretConfig_SecretAccessRoleArn { get; set; }
            public System.String CustomSecretConfig_SecretArn { get; set; }
            public System.String SasConfiguration_Token { get; set; }
            public System.String Subdirectory { get; set; }
            public List<Amazon.DataSync.Model.TagListEntry> Tag { get; set; }
            public System.Func<Amazon.DataSync.Model.CreateLocationAzureBlobResponse, NewDSYNLocationAzureBlobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.LocationArn;
        }
        
    }
}
