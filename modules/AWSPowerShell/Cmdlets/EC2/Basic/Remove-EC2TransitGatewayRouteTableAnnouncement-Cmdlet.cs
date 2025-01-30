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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Advertises to the transit gateway that a transit gateway route table is deleted.
    /// </summary>
    [Cmdlet("Remove", "EC2TransitGatewayRouteTableAnnouncement", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.EC2.Model.TransitGatewayRouteTableAnnouncement")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) DeleteTransitGatewayRouteTableAnnouncement API operation.", Operation = new[] {"DeleteTransitGatewayRouteTableAnnouncement"}, SelectReturnType = typeof(Amazon.EC2.Model.DeleteTransitGatewayRouteTableAnnouncementResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.TransitGatewayRouteTableAnnouncement or Amazon.EC2.Model.DeleteTransitGatewayRouteTableAnnouncementResponse",
        "This cmdlet returns an Amazon.EC2.Model.TransitGatewayRouteTableAnnouncement object.",
        "The service call response (type Amazon.EC2.Model.DeleteTransitGatewayRouteTableAnnouncementResponse) can be returned by specifying '-Select *'."
    )]
    public partial class RemoveEC2TransitGatewayRouteTableAnnouncementCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter TransitGatewayRouteTableAnnouncementId
        /// <summary>
        /// <para>
        /// <para>The transit gateway route table ID that's being deleted. </para>
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
        public System.String TransitGatewayRouteTableAnnouncementId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TransitGatewayRouteTableAnnouncement'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.DeleteTransitGatewayRouteTableAnnouncementResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.DeleteTransitGatewayRouteTableAnnouncementResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TransitGatewayRouteTableAnnouncement";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the TransitGatewayRouteTableAnnouncementId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^TransitGatewayRouteTableAnnouncementId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^TransitGatewayRouteTableAnnouncementId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TransitGatewayRouteTableAnnouncementId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-EC2TransitGatewayRouteTableAnnouncement (DeleteTransitGatewayRouteTableAnnouncement)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.DeleteTransitGatewayRouteTableAnnouncementResponse, RemoveEC2TransitGatewayRouteTableAnnouncementCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.TransitGatewayRouteTableAnnouncementId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.TransitGatewayRouteTableAnnouncementId = this.TransitGatewayRouteTableAnnouncementId;
            #if MODULAR
            if (this.TransitGatewayRouteTableAnnouncementId == null && ParameterWasBound(nameof(this.TransitGatewayRouteTableAnnouncementId)))
            {
                WriteWarning("You are passing $null as a value for parameter TransitGatewayRouteTableAnnouncementId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EC2.Model.DeleteTransitGatewayRouteTableAnnouncementRequest();
            
            if (cmdletContext.TransitGatewayRouteTableAnnouncementId != null)
            {
                request.TransitGatewayRouteTableAnnouncementId = cmdletContext.TransitGatewayRouteTableAnnouncementId;
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
        
        private Amazon.EC2.Model.DeleteTransitGatewayRouteTableAnnouncementResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.DeleteTransitGatewayRouteTableAnnouncementRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "DeleteTransitGatewayRouteTableAnnouncement");
            try
            {
                #if DESKTOP
                return client.DeleteTransitGatewayRouteTableAnnouncement(request);
                #elif CORECLR
                return client.DeleteTransitGatewayRouteTableAnnouncementAsync(request).GetAwaiter().GetResult();
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
            public System.String TransitGatewayRouteTableAnnouncementId { get; set; }
            public System.Func<Amazon.EC2.Model.DeleteTransitGatewayRouteTableAnnouncementResponse, RemoveEC2TransitGatewayRouteTableAnnouncementCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TransitGatewayRouteTableAnnouncement;
        }
        
    }
}
