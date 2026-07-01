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
using Amazon.GameLiftStreams;
using Amazon.GameLiftStreams.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.GMLS
{
    /// <summary>
    /// Creates an administrative terminal session with full access to the live runtime environment
    /// of the Amazon GameLift Streams stream session. Use the returned credentials (<c>SessionId</c>,
    /// <c>StreamUrl</c> and <c>TokenValue</c>) with the Amazon Web Services Systems Manager
    /// <a href="https://docs.aws.amazon.com/systems-manager/latest/userguide/session-manager-working-with-install-plugin.html">Session
    /// Manager plugin</a> for the CLI to access the terminal session.
    /// 
    ///  
    /// <para>
    /// The stream session must be in one of the following statuses: <c>ACTIVE</c>, <c>CONNECTED</c>,
    /// <c>PENDING_CLIENT_RECONNECTION</c>, or <c>RECONNECTING</c>.
    /// </para><para>
    /// The <c>StreamUrl</c> is valid for 60 seconds. After it expires, call this operation
    /// again to get a new URL.
    /// </para><important><para>
    /// The returned credentials grant full access to the live runtime environment of the
    /// Amazon GameLift Streams stream session. The operator who connects to the terminal
    /// session has the same level of access that your Amazon GameLift Streams applications
    /// have, including potentially user input, screen images, and application data files.
    /// Grant permissions to call this operation only to trusted IAM identities that require
    /// live runtime environment access.
    /// </para></important>
    /// </summary>
    [Cmdlet("New", "GMLSStreamSessionAdminShell", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.GameLiftStreams.Model.CreateStreamSessionAdminShellResponse")]
    [AWSCmdlet("Calls the Amazon GameLiftStreams CreateStreamSessionAdminShell API operation.", Operation = new[] {"CreateStreamSessionAdminShell"}, SelectReturnType = typeof(Amazon.GameLiftStreams.Model.CreateStreamSessionAdminShellResponse))]
    [AWSCmdletOutput("Amazon.GameLiftStreams.Model.CreateStreamSessionAdminShellResponse",
        "This cmdlet returns an Amazon.GameLiftStreams.Model.CreateStreamSessionAdminShellResponse object containing multiple properties."
    )]
    public partial class NewGMLSStreamSessionAdminShellCmdlet : AmazonGameLiftStreamsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Identifier
        /// <summary>
        /// <para>
        /// <para>The stream group that runs this stream session.</para><para>This value is an <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/reference-arns.html">Amazon
        /// Resource Name (ARN)</a> or ID that uniquely identifies the stream group resource.
        /// Example ARN: <c>arn:aws:gameliftstreams:us-west-2:111122223333:streamgroup/sg-1AB2C3De4</c>.
        /// Example ID: <c>sg-1AB2C3De4</c>. </para>
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
        public System.String Identifier { get; set; }
        #endregion
        
        #region Parameter StreamSessionIdentifier
        /// <summary>
        /// <para>
        /// <para>An <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/reference-arns.html">Amazon
        /// Resource Name (ARN)</a> or ID that uniquely identifies the stream session resource.
        /// Example ARN: <c>arn:aws:gameliftstreams:us-west-2:111122223333:streamsession/sg-1AB2C3De4/ABC123def4567</c>.
        /// Example ID: <c>ABC123def4567</c>. </para>
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
        public System.String StreamSessionIdentifier { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GameLiftStreams.Model.CreateStreamSessionAdminShellResponse).
        /// Specifying the name of a property of type Amazon.GameLiftStreams.Model.CreateStreamSessionAdminShellResponse will result in that property being returned.
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
                nameof(this.Identifier),
                nameof(this.StreamSessionIdentifier)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-GMLSStreamSessionAdminShell (CreateStreamSessionAdminShell)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GameLiftStreams.Model.CreateStreamSessionAdminShellResponse, NewGMLSStreamSessionAdminShellCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Identifier = this.Identifier;
            #if MODULAR
            if (this.Identifier == null && ParameterWasBound(nameof(this.Identifier)))
            {
                WriteWarning("You are passing $null as a value for parameter Identifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StreamSessionIdentifier = this.StreamSessionIdentifier;
            #if MODULAR
            if (this.StreamSessionIdentifier == null && ParameterWasBound(nameof(this.StreamSessionIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter StreamSessionIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.GameLiftStreams.Model.CreateStreamSessionAdminShellRequest();
            
            if (cmdletContext.Identifier != null)
            {
                request.Identifier = cmdletContext.Identifier;
            }
            if (cmdletContext.StreamSessionIdentifier != null)
            {
                request.StreamSessionIdentifier = cmdletContext.StreamSessionIdentifier;
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
        
        private Amazon.GameLiftStreams.Model.CreateStreamSessionAdminShellResponse CallAWSServiceOperation(IAmazonGameLiftStreams client, Amazon.GameLiftStreams.Model.CreateStreamSessionAdminShellRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon GameLiftStreams", "CreateStreamSessionAdminShell");
            try
            {
                return client.CreateStreamSessionAdminShellAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Identifier { get; set; }
            public System.String StreamSessionIdentifier { get; set; }
            public System.Func<Amazon.GameLiftStreams.Model.CreateStreamSessionAdminShellResponse, NewGMLSStreamSessionAdminShellCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
