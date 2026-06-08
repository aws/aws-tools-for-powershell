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
    /// Creates a file in an asset
    /// </summary>
    [Cmdlet("New", "DOPSAssetFile", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DevOpsAgent.Model.AssetFile")]
    [AWSCmdlet("Calls the AWS DevOps Agent Service CreateAssetFile API operation.", Operation = new[] {"CreateAssetFile"}, SelectReturnType = typeof(Amazon.DevOpsAgent.Model.CreateAssetFileResponse))]
    [AWSCmdletOutput("Amazon.DevOpsAgent.Model.AssetFile or Amazon.DevOpsAgent.Model.CreateAssetFileResponse",
        "This cmdlet returns an Amazon.DevOpsAgent.Model.AssetFile object.",
        "The service call response (type Amazon.DevOpsAgent.Model.CreateAssetFileResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewDOPSAssetFileCmdlet : AmazonDevOpsAgentClientCmdlet, IExecutor
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
        /// <para>The unique identifier of the asset to create the file in</para>
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
        
        #region Parameter Content_Byte
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Content_Bytes")]
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] Content_Byte { get; set; }
        #endregion
        
        #region Parameter Metadata
        /// <summary>
        /// <para>
        /// <para>Optional metadata describing this file</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Management.Automation.PSObject Metadata { get; set; }
        #endregion
        
        #region Parameter Path
        /// <summary>
        /// <para>
        /// <para>The path of the file within the asset</para>
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
        public System.String Path { get; set; }
        #endregion
        
        #region Parameter Content_Text
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Content_Text { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier used for idempotent asset file creation</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'File'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DevOpsAgent.Model.CreateAssetFileResponse).
        /// Specifying the name of a property of type Amazon.DevOpsAgent.Model.CreateAssetFileResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "File";
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
            
            var targetParameterNames = new string[]
            {
                nameof(this.AgentSpaceId),
                nameof(this.AssetId)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-DOPSAssetFile (CreateAssetFile)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DevOpsAgent.Model.CreateAssetFileResponse, NewDOPSAssetFileCmdlet>(Select) ??
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
            context.Content_Byte = this.Content_Byte;
            context.Content_Text = this.Content_Text;
            context.Metadata = this.Metadata;
            context.Path = this.Path;
            #if MODULAR
            if (this.Path == null && ParameterWasBound(nameof(this.Path)))
            {
                WriteWarning("You are passing $null as a value for parameter Path which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            System.IO.MemoryStream _Content_ByteStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.DevOpsAgent.Model.CreateAssetFileRequest();
                
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
                request.Content = new Amazon.DevOpsAgent.Model.AssetFileBody();
                System.IO.MemoryStream requestContent_content_Byte = null;
                if (cmdletContext.Content_Byte != null)
                {
                    _Content_ByteStream = new System.IO.MemoryStream(cmdletContext.Content_Byte);
                    requestContent_content_Byte = _Content_ByteStream;
                }
                if (requestContent_content_Byte != null)
                {
                    request.Content.Bytes = requestContent_content_Byte;
                    requestContentIsNull = false;
                }
                System.String requestContent_content_Text = null;
                if (cmdletContext.Content_Text != null)
                {
                    requestContent_content_Text = cmdletContext.Content_Text;
                }
                if (requestContent_content_Text != null)
                {
                    request.Content.Text = requestContent_content_Text;
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
                if (cmdletContext.Path != null)
                {
                    request.Path = cmdletContext.Path;
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
                if( _Content_ByteStream != null)
                {
                    _Content_ByteStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.DevOpsAgent.Model.CreateAssetFileResponse CallAWSServiceOperation(IAmazonDevOpsAgent client, Amazon.DevOpsAgent.Model.CreateAssetFileRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS DevOps Agent Service", "CreateAssetFile");
            try
            {
                return client.CreateAssetFileAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public byte[] Content_Byte { get; set; }
            public System.String Content_Text { get; set; }
            public System.Management.Automation.PSObject Metadata { get; set; }
            public System.String Path { get; set; }
            public System.Func<Amazon.DevOpsAgent.Model.CreateAssetFileResponse, NewDOPSAssetFileCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.File;
        }
        
    }
}
