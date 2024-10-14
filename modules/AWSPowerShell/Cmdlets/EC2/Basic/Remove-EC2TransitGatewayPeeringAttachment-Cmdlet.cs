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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Deletes a transit gateway peering attachment.
    /// </summary>
    [Cmdlet("Remove", "EC2TransitGatewayPeeringAttachment", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.EC2.Model.TransitGatewayPeeringAttachment")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) DeleteTransitGatewayPeeringAttachment API operation.", Operation = new[] {"DeleteTransitGatewayPeeringAttachment"}, SelectReturnType = typeof(Amazon.EC2.Model.DeleteTransitGatewayPeeringAttachmentResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.TransitGatewayPeeringAttachment or Amazon.EC2.Model.DeleteTransitGatewayPeeringAttachmentResponse",
        "This cmdlet returns an Amazon.EC2.Model.TransitGatewayPeeringAttachment object.",
        "The service call response (type Amazon.EC2.Model.DeleteTransitGatewayPeeringAttachmentResponse) can be returned by specifying '-Select *'."
    )]
    public partial class RemoveEC2TransitGatewayPeeringAttachmentCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter TransitGatewayAttachmentId
        /// <summary>
        /// <para>
        /// <para>The ID of the transit gateway peering attachment.</para>
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
        public System.String TransitGatewayAttachmentId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TransitGatewayPeeringAttachment'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.DeleteTransitGatewayPeeringAttachmentResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.DeleteTransitGatewayPeeringAttachmentResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TransitGatewayPeeringAttachment";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the TransitGatewayAttachmentId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^TransitGatewayAttachmentId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^TransitGatewayAttachmentId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TransitGatewayAttachmentId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-EC2TransitGatewayPeeringAttachment (DeleteTransitGatewayPeeringAttachment)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.DeleteTransitGatewayPeeringAttachmentResponse, RemoveEC2TransitGatewayPeeringAttachmentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.TransitGatewayAttachmentId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.TransitGatewayAttachmentId = this.TransitGatewayAttachmentId;
            #if MODULAR
            if (this.TransitGatewayAttachmentId == null && ParameterWasBound(nameof(this.TransitGatewayAttachmentId)))
            {
                WriteWarning("You are passing $null as a value for parameter TransitGatewayAttachmentId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EC2.Model.DeleteTransitGatewayPeeringAttachmentRequest();
            
            if (cmdletContext.TransitGatewayAttachmentId != null)
            {
                request.TransitGatewayAttachmentId = cmdletContext.TransitGatewayAttachmentId;
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
        
        private Amazon.EC2.Model.DeleteTransitGatewayPeeringAttachmentResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.DeleteTransitGatewayPeeringAttachmentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "DeleteTransitGatewayPeeringAttachment");
            try
            {
                #if DESKTOP
                return client.DeleteTransitGatewayPeeringAttachment(request);
                #elif CORECLR
                return client.DeleteTransitGatewayPeeringAttachmentAsync(request).GetAwaiter().GetResult();
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
            public System.String TransitGatewayAttachmentId { get; set; }
            public System.Func<Amazon.EC2.Model.DeleteTransitGatewayPeeringAttachmentResponse, RemoveEC2TransitGatewayPeeringAttachmentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TransitGatewayPeeringAttachment;
        }
        
    }
}
