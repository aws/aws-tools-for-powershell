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
using Amazon.ChimeSDKIdentity;
using Amazon.ChimeSDKIdentity.Model;

namespace Amazon.PowerShell.Cmdlets.CHMID
{
    /// <summary>
    /// Updates the details of an <c>AppInstanceUserEndpoint</c>. You can update the name
    /// and <c>AllowMessage</c> values.
    /// </summary>
    [Cmdlet("Update", "CHMIDAppInstanceUserEndpoint", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ChimeSDKIdentity.Model.UpdateAppInstanceUserEndpointResponse")]
    [AWSCmdlet("Calls the Amazon Chime SDK Identity UpdateAppInstanceUserEndpoint API operation.", Operation = new[] {"UpdateAppInstanceUserEndpoint"}, SelectReturnType = typeof(Amazon.ChimeSDKIdentity.Model.UpdateAppInstanceUserEndpointResponse))]
    [AWSCmdletOutput("Amazon.ChimeSDKIdentity.Model.UpdateAppInstanceUserEndpointResponse",
        "This cmdlet returns an Amazon.ChimeSDKIdentity.Model.UpdateAppInstanceUserEndpointResponse object containing multiple properties."
    )]
    public partial class UpdateCHMIDAppInstanceUserEndpointCmdlet : AmazonChimeSDKIdentityClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AllowMessage
        /// <summary>
        /// <para>
        /// <para>Boolean that controls whether the <c>AppInstanceUserEndpoint</c> is opted in to receive
        /// messages. <c>ALL</c> indicates the endpoint will receive all messages. <c>NONE</c>
        /// indicates the endpoint will receive no messages.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AllowMessages")]
        [AWSConstantClassSource("Amazon.ChimeSDKIdentity.AllowMessages")]
        public Amazon.ChimeSDKIdentity.AllowMessages AllowMessage { get; set; }
        #endregion
        
        #region Parameter AppInstanceUserArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the <c>AppInstanceUser</c>.</para>
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
        public System.String AppInstanceUserArn { get; set; }
        #endregion
        
        #region Parameter EndpointId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the <c>AppInstanceUserEndpoint</c>.</para>
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
        public System.String EndpointId { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the <c>AppInstanceUserEndpoint</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ChimeSDKIdentity.Model.UpdateAppInstanceUserEndpointResponse).
        /// Specifying the name of a property of type Amazon.ChimeSDKIdentity.Model.UpdateAppInstanceUserEndpointResponse will result in that property being returned.
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.EndpointId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CHMIDAppInstanceUserEndpoint (UpdateAppInstanceUserEndpoint)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ChimeSDKIdentity.Model.UpdateAppInstanceUserEndpointResponse, UpdateCHMIDAppInstanceUserEndpointCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AllowMessage = this.AllowMessage;
            context.AppInstanceUserArn = this.AppInstanceUserArn;
            #if MODULAR
            if (this.AppInstanceUserArn == null && ParameterWasBound(nameof(this.AppInstanceUserArn)))
            {
                WriteWarning("You are passing $null as a value for parameter AppInstanceUserArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EndpointId = this.EndpointId;
            #if MODULAR
            if (this.EndpointId == null && ParameterWasBound(nameof(this.EndpointId)))
            {
                WriteWarning("You are passing $null as a value for parameter EndpointId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            
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
            var request = new Amazon.ChimeSDKIdentity.Model.UpdateAppInstanceUserEndpointRequest();
            
            if (cmdletContext.AllowMessage != null)
            {
                request.AllowMessages = cmdletContext.AllowMessage;
            }
            if (cmdletContext.AppInstanceUserArn != null)
            {
                request.AppInstanceUserArn = cmdletContext.AppInstanceUserArn;
            }
            if (cmdletContext.EndpointId != null)
            {
                request.EndpointId = cmdletContext.EndpointId;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
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
        
        private Amazon.ChimeSDKIdentity.Model.UpdateAppInstanceUserEndpointResponse CallAWSServiceOperation(IAmazonChimeSDKIdentity client, Amazon.ChimeSDKIdentity.Model.UpdateAppInstanceUserEndpointRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Chime SDK Identity", "UpdateAppInstanceUserEndpoint");
            try
            {
                return client.UpdateAppInstanceUserEndpointAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.ChimeSDKIdentity.AllowMessages AllowMessage { get; set; }
            public System.String AppInstanceUserArn { get; set; }
            public System.String EndpointId { get; set; }
            public System.String Name { get; set; }
            public System.Func<Amazon.ChimeSDKIdentity.Model.UpdateAppInstanceUserEndpointResponse, UpdateCHMIDAppInstanceUserEndpointCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
