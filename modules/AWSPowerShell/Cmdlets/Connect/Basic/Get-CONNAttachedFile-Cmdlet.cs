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
using Amazon.Connect;
using Amazon.Connect.Model;

namespace Amazon.PowerShell.Cmdlets.CONN
{
    /// <summary>
    /// Provides a pre-signed URL for download of an approved attached file. This API also
    /// returns metadata about the attached file. It will only return a downloadURL if the
    /// status of the attached file is <c>APPROVED</c>.
    /// </summary>
    [Cmdlet("Get", "CONNAttachedFile")]
    [OutputType("Amazon.Connect.Model.GetAttachedFileResponse")]
    [AWSCmdlet("Calls the Amazon Connect Service GetAttachedFile API operation.", Operation = new[] {"GetAttachedFile"}, SelectReturnType = typeof(Amazon.Connect.Model.GetAttachedFileResponse))]
    [AWSCmdletOutput("Amazon.Connect.Model.GetAttachedFileResponse",
        "This cmdlet returns an Amazon.Connect.Model.GetAttachedFileResponse object containing multiple properties."
    )]
    public partial class GetCONNAttachedFileCmdlet : AmazonConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AssociatedResourceArn
        /// <summary>
        /// <para>
        /// <para>The resource to which the attached file is (being) uploaded to. The supported resources
        /// are <a href="https://docs.aws.amazon.com/connect/latest/adminguide/cases.html">Cases</a>
        /// and <a href="https://docs.aws.amazon.com/connect/latest/adminguide/setup-email-channel.html">Email</a>.</para><note><para>This value must be a valid ARN.</para></note>
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
        public System.String AssociatedResourceArn { get; set; }
        #endregion
        
        #region Parameter FileId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the attached file resource.</para>
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
        public System.String FileId { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the Amazon Connect instance.</para>
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
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter UrlExpiryInSecond
        /// <summary>
        /// <para>
        /// <para>Optional override for the expiry of the pre-signed S3 URL in seconds. The default
        /// value is 300.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UrlExpiryInSeconds")]
        public System.Int32? UrlExpiryInSecond { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Connect.Model.GetAttachedFileResponse).
        /// Specifying the name of a property of type Amazon.Connect.Model.GetAttachedFileResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Connect.Model.GetAttachedFileResponse, GetCONNAttachedFileCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AssociatedResourceArn = this.AssociatedResourceArn;
            #if MODULAR
            if (this.AssociatedResourceArn == null && ParameterWasBound(nameof(this.AssociatedResourceArn)))
            {
                WriteWarning("You are passing $null as a value for parameter AssociatedResourceArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.FileId = this.FileId;
            #if MODULAR
            if (this.FileId == null && ParameterWasBound(nameof(this.FileId)))
            {
                WriteWarning("You are passing $null as a value for parameter FileId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InstanceId = this.InstanceId;
            #if MODULAR
            if (this.InstanceId == null && ParameterWasBound(nameof(this.InstanceId)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.UrlExpiryInSecond = this.UrlExpiryInSecond;
            
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
            var request = new Amazon.Connect.Model.GetAttachedFileRequest();
            
            if (cmdletContext.AssociatedResourceArn != null)
            {
                request.AssociatedResourceArn = cmdletContext.AssociatedResourceArn;
            }
            if (cmdletContext.FileId != null)
            {
                request.FileId = cmdletContext.FileId;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            if (cmdletContext.UrlExpiryInSecond != null)
            {
                request.UrlExpiryInSeconds = cmdletContext.UrlExpiryInSecond.Value;
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
        
        private Amazon.Connect.Model.GetAttachedFileResponse CallAWSServiceOperation(IAmazonConnect client, Amazon.Connect.Model.GetAttachedFileRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Service", "GetAttachedFile");
            try
            {
                return client.GetAttachedFileAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AssociatedResourceArn { get; set; }
            public System.String FileId { get; set; }
            public System.String InstanceId { get; set; }
            public System.Int32? UrlExpiryInSecond { get; set; }
            public System.Func<Amazon.Connect.Model.GetAttachedFileResponse, GetCONNAttachedFileCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
