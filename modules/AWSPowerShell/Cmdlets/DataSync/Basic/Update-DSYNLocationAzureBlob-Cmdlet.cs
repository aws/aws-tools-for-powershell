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
using Amazon.DataSync;
using Amazon.DataSync.Model;

namespace Amazon.PowerShell.Cmdlets.DSYN
{
    /// <summary>
    /// Modifies some configurations of the Microsoft Azure Blob Storage transfer location
    /// that you're using with DataSync.
    /// </summary>
    [Cmdlet("Update", "DSYNLocationAzureBlob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS DataSync UpdateLocationAzureBlob API operation.", Operation = new[] {"UpdateLocationAzureBlob"}, SelectReturnType = typeof(Amazon.DataSync.Model.UpdateLocationAzureBlobResponse))]
    [AWSCmdletOutput("None or Amazon.DataSync.Model.UpdateLocationAzureBlobResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.DataSync.Model.UpdateLocationAzureBlobResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateDSYNLocationAzureBlobCmdlet : AmazonDataSyncClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
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
        /// <para>Specifies the Amazon Resource Name (ARN) of the DataSync agent that can connect with
        /// your Azure Blob Storage container.</para><para>You can specify more than one agent. For more information, see <a href="https://docs.aws.amazon.com/datasync/latest/userguide/multiple-agents.html">Using
        /// multiple agents for your transfer</a>.</para>
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
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
        
        #region Parameter LocationArn
        /// <summary>
        /// <para>
        /// <para>Specifies the ARN of the Azure Blob Storage transfer location that you're updating.</para>
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
        public System.String LocationArn { get; set; }
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
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DataSync.Model.UpdateLocationAzureBlobResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.LocationArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-DSYNLocationAzureBlob (UpdateLocationAzureBlob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DataSync.Model.UpdateLocationAzureBlobResponse, UpdateDSYNLocationAzureBlobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AccessTier = this.AccessTier;
            if (this.AgentArn != null)
            {
                context.AgentArn = new List<System.String>(this.AgentArn);
            }
            context.AuthenticationType = this.AuthenticationType;
            context.BlobType = this.BlobType;
            context.LocationArn = this.LocationArn;
            #if MODULAR
            if (this.LocationArn == null && ParameterWasBound(nameof(this.LocationArn)))
            {
                WriteWarning("You are passing $null as a value for parameter LocationArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SasConfiguration_Token = this.SasConfiguration_Token;
            context.Subdirectory = this.Subdirectory;
            
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
            var request = new Amazon.DataSync.Model.UpdateLocationAzureBlobRequest();
            
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
            if (cmdletContext.LocationArn != null)
            {
                request.LocationArn = cmdletContext.LocationArn;
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
        
        private Amazon.DataSync.Model.UpdateLocationAzureBlobResponse CallAWSServiceOperation(IAmazonDataSync client, Amazon.DataSync.Model.UpdateLocationAzureBlobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS DataSync", "UpdateLocationAzureBlob");
            try
            {
                #if DESKTOP
                return client.UpdateLocationAzureBlob(request);
                #elif CORECLR
                return client.UpdateLocationAzureBlobAsync(request).GetAwaiter().GetResult();
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
            public Amazon.DataSync.AzureAccessTier AccessTier { get; set; }
            public List<System.String> AgentArn { get; set; }
            public Amazon.DataSync.AzureBlobAuthenticationType AuthenticationType { get; set; }
            public Amazon.DataSync.AzureBlobType BlobType { get; set; }
            public System.String LocationArn { get; set; }
            public System.String SasConfiguration_Token { get; set; }
            public System.String Subdirectory { get; set; }
            public System.Func<Amazon.DataSync.Model.UpdateLocationAzureBlobResponse, UpdateDSYNLocationAzureBlobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
