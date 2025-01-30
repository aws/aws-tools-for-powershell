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
using Amazon.RAM;
using Amazon.RAM.Model;

namespace Amazon.PowerShell.Cmdlets.RAM
{
    /// <summary>
    /// Accepts an invitation to a resource share from another Amazon Web Services account.
    /// After you accept the invitation, the resources included in the resource share are
    /// available to interact with in the relevant Amazon Web Services Management Consoles
    /// and tools.
    /// </summary>
    [Cmdlet("Confirm", "RAMResourceShareInvitation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RAM.Model.ResourceShareInvitation")]
    [AWSCmdlet("Calls the AWS Resource Access Manager (RAM) AcceptResourceShareInvitation API operation.", Operation = new[] {"AcceptResourceShareInvitation"}, SelectReturnType = typeof(Amazon.RAM.Model.AcceptResourceShareInvitationResponse))]
    [AWSCmdletOutput("Amazon.RAM.Model.ResourceShareInvitation or Amazon.RAM.Model.AcceptResourceShareInvitationResponse",
        "This cmdlet returns an Amazon.RAM.Model.ResourceShareInvitation object.",
        "The service call response (type Amazon.RAM.Model.AcceptResourceShareInvitationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class ConfirmRAMResourceShareInvitationCmdlet : AmazonRAMClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ResourceShareInvitationArn
        /// <summary>
        /// <para>
        /// <para>The <a href="https://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html">Amazon
        /// Resource Name (ARN)</a> of the invitation that you want to accept.</para>
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
        public System.String ResourceShareInvitationArn { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Specifies a unique, case-sensitive identifier that you provide to ensure the idempotency
        /// of the request. This lets you safely retry the request without accidentally performing
        /// the same operation a second time. Passing the same value to a later call to an operation
        /// requires that you also pass the same value for all other parameters. We recommend
        /// that you use a <a href="https://wikipedia.org/wiki/Universally_unique_identifier">UUID
        /// type of value.</a>.</para><para>If you don't provide this value, then Amazon Web Services generates a random one for
        /// you.</para><para>If you retry the operation with the same <c>ClientToken</c>, but with different parameters,
        /// the retry fails with an <c>IdempotentParameterMismatch</c> error.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ResourceShareInvitation'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RAM.Model.AcceptResourceShareInvitationResponse).
        /// Specifying the name of a property of type Amazon.RAM.Model.AcceptResourceShareInvitationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ResourceShareInvitation";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ResourceShareInvitationArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ResourceShareInvitationArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ResourceShareInvitationArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ResourceShareInvitationArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Confirm-RAMResourceShareInvitation (AcceptResourceShareInvitation)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RAM.Model.AcceptResourceShareInvitationResponse, ConfirmRAMResourceShareInvitationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ResourceShareInvitationArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientToken = this.ClientToken;
            context.ResourceShareInvitationArn = this.ResourceShareInvitationArn;
            #if MODULAR
            if (this.ResourceShareInvitationArn == null && ParameterWasBound(nameof(this.ResourceShareInvitationArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceShareInvitationArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.RAM.Model.AcceptResourceShareInvitationRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.ResourceShareInvitationArn != null)
            {
                request.ResourceShareInvitationArn = cmdletContext.ResourceShareInvitationArn;
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
        
        private Amazon.RAM.Model.AcceptResourceShareInvitationResponse CallAWSServiceOperation(IAmazonRAM client, Amazon.RAM.Model.AcceptResourceShareInvitationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Resource Access Manager (RAM)", "AcceptResourceShareInvitation");
            try
            {
                #if DESKTOP
                return client.AcceptResourceShareInvitation(request);
                #elif CORECLR
                return client.AcceptResourceShareInvitationAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String ResourceShareInvitationArn { get; set; }
            public System.Func<Amazon.RAM.Model.AcceptResourceShareInvitationResponse, ConfirmRAMResourceShareInvitationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ResourceShareInvitation;
        }
        
    }
}
