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
using Amazon.MTurk;
using Amazon.MTurk.Model;

namespace Amazon.PowerShell.Cmdlets.MTR
{
    /// <summary>
    /// The <c>DeleteWorkerBlock</c> operation allows you to reinstate a blocked Worker to
    /// work on your HITs. This operation reverses the effects of the CreateWorkerBlock operation.
    /// You need the Worker ID to use this operation. If the Worker ID is missing or invalid,
    /// this operation fails and returns the message “WorkerId is invalid.” If the specified
    /// Worker is not blocked, this operation returns successfully.
    /// </summary>
    [Cmdlet("Remove", "MTRWorkerBlock", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon MTurk Service DeleteWorkerBlock API operation.", Operation = new[] {"DeleteWorkerBlock"}, SelectReturnType = typeof(Amazon.MTurk.Model.DeleteWorkerBlockResponse))]
    [AWSCmdletOutput("None or Amazon.MTurk.Model.DeleteWorkerBlockResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.MTurk.Model.DeleteWorkerBlockResponse) be returned by specifying '-Select *'."
    )]
    public partial class RemoveMTRWorkerBlockCmdlet : AmazonMTurkClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Reason
        /// <summary>
        /// <para>
        /// <para>A message that explains the reason for unblocking the Worker. The Worker does not
        /// see this message.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Reason { get; set; }
        #endregion
        
        #region Parameter WorkerId
        /// <summary>
        /// <para>
        /// <para>The ID of the Worker to unblock.</para>
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
        public System.String WorkerId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MTurk.Model.DeleteWorkerBlockResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the WorkerId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^WorkerId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^WorkerId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.WorkerId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-MTRWorkerBlock (DeleteWorkerBlock)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MTurk.Model.DeleteWorkerBlockResponse, RemoveMTRWorkerBlockCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.WorkerId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Reason = this.Reason;
            context.WorkerId = this.WorkerId;
            #if MODULAR
            if (this.WorkerId == null && ParameterWasBound(nameof(this.WorkerId)))
            {
                WriteWarning("You are passing $null as a value for parameter WorkerId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.MTurk.Model.DeleteWorkerBlockRequest();
            
            if (cmdletContext.Reason != null)
            {
                request.Reason = cmdletContext.Reason;
            }
            if (cmdletContext.WorkerId != null)
            {
                request.WorkerId = cmdletContext.WorkerId;
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
        
        private Amazon.MTurk.Model.DeleteWorkerBlockResponse CallAWSServiceOperation(IAmazonMTurk client, Amazon.MTurk.Model.DeleteWorkerBlockRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon MTurk Service", "DeleteWorkerBlock");
            try
            {
                #if DESKTOP
                return client.DeleteWorkerBlock(request);
                #elif CORECLR
                return client.DeleteWorkerBlockAsync(request).GetAwaiter().GetResult();
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
            public System.String Reason { get; set; }
            public System.String WorkerId { get; set; }
            public System.Func<Amazon.MTurk.Model.DeleteWorkerBlockResponse, RemoveMTRWorkerBlockCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
