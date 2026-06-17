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
using Amazon.DevOpsAgent;
using Amazon.DevOpsAgent.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.DOPS
{
    /// <summary>
    /// Updates an asset in the specified agent space
    /// </summary>
    [Cmdlet("Update", "DOPSAsset", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DevOpsAgent.Model.Asset")]
    [AWSCmdlet("Calls the AWS DevOps Agent Service UpdateAsset API operation.", Operation = new[] {"UpdateAsset"}, SelectReturnType = typeof(Amazon.DevOpsAgent.Model.UpdateAssetResponse))]
    [AWSCmdletOutput("Amazon.DevOpsAgent.Model.Asset or Amazon.DevOpsAgent.Model.UpdateAssetResponse",
        "This cmdlet returns an Amazon.DevOpsAgent.Model.Asset object.",
        "The service call response (type Amazon.DevOpsAgent.Model.UpdateAssetResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateDOPSAssetCmdlet : AmazonDevOpsAgentClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AgentSpaceId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the agent space containing the asset</para>
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
        public System.String AgentSpaceId { get; set; }
        #endregion
        
        #region Parameter AssetId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the asset to update</para>
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
        public System.String AssetId { get; set; }
        #endregion
        
        #region Parameter Content_File_Body_Byte
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Content_File_Body_Bytes")]
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] Content_File_Body_Byte { get; set; }
        #endregion
        
        #region Parameter Content_File_Metadata
        /// <summary>
        /// <para>
        /// <para>Optional metadata for this file</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Management.Automation.PSObject Content_File_Metadata { get; set; }
        #endregion
        
        #region Parameter Metadata
        /// <summary>
        /// <para>
        /// <para>Metadata fields to update. Only the fields present in this document are updated. Omitted
        /// fields retain their current values.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Management.Automation.PSObject Metadata { get; set; }
        #endregion
        
        #region Parameter Content_File_Path
        /// <summary>
        /// <para>
        /// <para>The path of the file within the asset</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Content_File_Path { get; set; }
        #endregion
        
        #region Parameter Content_File_Body_Text
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Content_File_Body_Text { get; set; }
        #endregion
        
        #region Parameter Content_SourceUrl_Url
        /// <summary>
        /// <para>
        /// <para>The source URL to import asset content from</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Content_SourceUrl_Url { get; set; }
        #endregion
        
        #region Parameter Content_Zip_ZipFile
        /// <summary>
        /// <para>
        /// <para>The zip file bytes</para>
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] Content_Zip_ZipFile { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier used for idempotent asset update</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Asset'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DevOpsAgent.Model.UpdateAssetResponse).
        /// Specifying the name of a property of type Amazon.DevOpsAgent.Model.UpdateAssetResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Asset";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AssetId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-DOPSAsset (UpdateAsset)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DevOpsAgent.Model.UpdateAssetResponse, UpdateDOPSAssetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AgentSpaceId = this.AgentSpaceId;
            #if MODULAR
            if (this.AgentSpaceId == null && ParameterWasBound(nameof(this.AgentSpaceId)))
            {
                WriteWarning("You are passing $null as a value for parameter AgentSpaceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AssetId = this.AssetId;
            #if MODULAR
            if (this.AssetId == null && ParameterWasBound(nameof(this.AssetId)))
            {
                WriteWarning("You are passing $null as a value for parameter AssetId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            context.Content_File_Body_Byte = this.Content_File_Body_Byte;
            context.Content_File_Body_Text = this.Content_File_Body_Text;
            context.Content_File_Metadata = this.Content_File_Metadata;
            context.Content_File_Path = this.Content_File_Path;
            context.Content_SourceUrl_Url = this.Content_SourceUrl_Url;
            context.Content_Zip_ZipFile = this.Content_Zip_ZipFile;
            context.Metadata = this.Metadata;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            System.IO.MemoryStream _Content_File_Body_ByteStream = null;
            System.IO.MemoryStream _Content_Zip_ZipFileStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.DevOpsAgent.Model.UpdateAssetRequest();
                
                if (cmdletContext.AgentSpaceId != null)
                {
                    request.AgentSpaceId = cmdletContext.AgentSpaceId;
                }
                if (cmdletContext.AssetId != null)
                {
                    request.AssetId = cmdletContext.AssetId;
                }
                if (cmdletContext.ClientToken != null)
                {
                    request.ClientToken = cmdletContext.ClientToken;
                }
                
                 // populate Content
                var requestContentIsNull = true;
                request.Content = new Amazon.DevOpsAgent.Model.AssetContent();
                Amazon.DevOpsAgent.Model.AssetSourceUrlContent requestContent_content_SourceUrl = null;
                
                 // populate SourceUrl
                var requestContent_content_SourceUrlIsNull = true;
                requestContent_content_SourceUrl = new Amazon.DevOpsAgent.Model.AssetSourceUrlContent();
                System.String requestContent_content_SourceUrl_content_SourceUrl_Url = null;
                if (cmdletContext.Content_SourceUrl_Url != null)
                {
                    requestContent_content_SourceUrl_content_SourceUrl_Url = cmdletContext.Content_SourceUrl_Url;
                }
                if (requestContent_content_SourceUrl_content_SourceUrl_Url != null)
                {
                    requestContent_content_SourceUrl.Url = requestContent_content_SourceUrl_content_SourceUrl_Url;
                    requestContent_content_SourceUrlIsNull = false;
                }
                 // determine if requestContent_content_SourceUrl should be set to null
                if (requestContent_content_SourceUrlIsNull)
                {
                    requestContent_content_SourceUrl = null;
                }
                if (requestContent_content_SourceUrl != null)
                {
                    request.Content.SourceUrl = requestContent_content_SourceUrl;
                    requestContentIsNull = false;
                }
                Amazon.DevOpsAgent.Model.AssetZipContent requestContent_content_Zip = null;
                
                 // populate Zip
                var requestContent_content_ZipIsNull = true;
                requestContent_content_Zip = new Amazon.DevOpsAgent.Model.AssetZipContent();
                System.IO.MemoryStream requestContent_content_Zip_content_Zip_ZipFile = null;
                if (cmdletContext.Content_Zip_ZipFile != null)
                {
                    _Content_Zip_ZipFileStream = new System.IO.MemoryStream(cmdletContext.Content_Zip_ZipFile);
                    requestContent_content_Zip_content_Zip_ZipFile = _Content_Zip_ZipFileStream;
                }
                if (requestContent_content_Zip_content_Zip_ZipFile != null)
                {
                    requestContent_content_Zip.ZipFile = requestContent_content_Zip_content_Zip_ZipFile;
                    requestContent_content_ZipIsNull = false;
                }
                 // determine if requestContent_content_Zip should be set to null
                if (requestContent_content_ZipIsNull)
                {
                    requestContent_content_Zip = null;
                }
                if (requestContent_content_Zip != null)
                {
                    request.Content.Zip = requestContent_content_Zip;
                    requestContentIsNull = false;
                }
                Amazon.DevOpsAgent.Model.AssetFileContent requestContent_content_File = null;
                
                 // populate File
                var requestContent_content_FileIsNull = true;
                requestContent_content_File = new Amazon.DevOpsAgent.Model.AssetFileContent();
                Amazon.Runtime.Documents.Document? requestContent_content_File_content_File_Metadata = null;
                if (cmdletContext.Content_File_Metadata != null)
                {
                    requestContent_content_File_content_File_Metadata = Amazon.PowerShell.Common.DocumentHelper.ToDocument(cmdletContext.Content_File_Metadata);
                }
                if (requestContent_content_File_content_File_Metadata != null)
                {
                    requestContent_content_File.Metadata = requestContent_content_File_content_File_Metadata.Value;
                    requestContent_content_FileIsNull = false;
                }
                System.String requestContent_content_File_content_File_Path = null;
                if (cmdletContext.Content_File_Path != null)
                {
                    requestContent_content_File_content_File_Path = cmdletContext.Content_File_Path;
                }
                if (requestContent_content_File_content_File_Path != null)
                {
                    requestContent_content_File.Path = requestContent_content_File_content_File_Path;
                    requestContent_content_FileIsNull = false;
                }
                Amazon.DevOpsAgent.Model.AssetFileBody requestContent_content_File_content_File_Body = null;
                
                 // populate Body
                var requestContent_content_File_content_File_BodyIsNull = true;
                requestContent_content_File_content_File_Body = new Amazon.DevOpsAgent.Model.AssetFileBody();
                System.IO.MemoryStream requestContent_content_File_content_File_Body_content_File_Body_Byte = null;
                if (cmdletContext.Content_File_Body_Byte != null)
                {
                    _Content_File_Body_ByteStream = new System.IO.MemoryStream(cmdletContext.Content_File_Body_Byte);
                    requestContent_content_File_content_File_Body_content_File_Body_Byte = _Content_File_Body_ByteStream;
                }
                if (requestContent_content_File_content_File_Body_content_File_Body_Byte != null)
                {
                    requestContent_content_File_content_File_Body.Bytes = requestContent_content_File_content_File_Body_content_File_Body_Byte;
                    requestContent_content_File_content_File_BodyIsNull = false;
                }
                System.String requestContent_content_File_content_File_Body_content_File_Body_Text = null;
                if (cmdletContext.Content_File_Body_Text != null)
                {
                    requestContent_content_File_content_File_Body_content_File_Body_Text = cmdletContext.Content_File_Body_Text;
                }
                if (requestContent_content_File_content_File_Body_content_File_Body_Text != null)
                {
                    requestContent_content_File_content_File_Body.Text = requestContent_content_File_content_File_Body_content_File_Body_Text;
                    requestContent_content_File_content_File_BodyIsNull = false;
                }
                 // determine if requestContent_content_File_content_File_Body should be set to null
                if (requestContent_content_File_content_File_BodyIsNull)
                {
                    requestContent_content_File_content_File_Body = null;
                }
                if (requestContent_content_File_content_File_Body != null)
                {
                    requestContent_content_File.Body = requestContent_content_File_content_File_Body;
                    requestContent_content_FileIsNull = false;
                }
                 // determine if requestContent_content_File should be set to null
                if (requestContent_content_FileIsNull)
                {
                    requestContent_content_File = null;
                }
                if (requestContent_content_File != null)
                {
                    request.Content.File = requestContent_content_File;
                    requestContentIsNull = false;
                }
                 // determine if request.Content should be set to null
                if (requestContentIsNull)
                {
                    request.Content = null;
                }
                if (cmdletContext.Metadata != null)
                {
                    request.Metadata = Amazon.PowerShell.Common.DocumentHelper.ToDocument(cmdletContext.Metadata);
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
            finally
            {
                if( _Content_File_Body_ByteStream != null)
                {
                    _Content_File_Body_ByteStream.Dispose();
                }
                if( _Content_Zip_ZipFileStream != null)
                {
                    _Content_Zip_ZipFileStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.DevOpsAgent.Model.UpdateAssetResponse CallAWSServiceOperation(IAmazonDevOpsAgent client, Amazon.DevOpsAgent.Model.UpdateAssetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS DevOps Agent Service", "UpdateAsset");
            try
            {
                return client.UpdateAssetAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AgentSpaceId { get; set; }
            public System.String AssetId { get; set; }
            public System.String ClientToken { get; set; }
            public byte[] Content_File_Body_Byte { get; set; }
            public System.String Content_File_Body_Text { get; set; }
            public System.Management.Automation.PSObject Content_File_Metadata { get; set; }
            public System.String Content_File_Path { get; set; }
            public System.String Content_SourceUrl_Url { get; set; }
            public byte[] Content_Zip_ZipFile { get; set; }
            public System.Management.Automation.PSObject Metadata { get; set; }
            public System.Func<Amazon.DevOpsAgent.Model.UpdateAssetResponse, UpdateDOPSAssetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Asset;
        }
        
    }
}
