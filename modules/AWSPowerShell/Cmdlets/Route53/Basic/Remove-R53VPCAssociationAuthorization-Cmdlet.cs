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
using Amazon.Route53;
using Amazon.Route53.Model;

namespace Amazon.PowerShell.Cmdlets.R53
{
    /// <summary>
    /// Removes authorization to submit an <c>AssociateVPCWithHostedZone</c> request to associate
    /// a specified VPC with a hosted zone that was created by a different account. You must
    /// use the account that created the hosted zone to submit a <c>DeleteVPCAssociationAuthorization</c>
    /// request.
    /// 
    ///  <important><para>
    /// Sending this request only prevents the Amazon Web Services account that created the
    /// VPC from associating the VPC with the Amazon Route 53 hosted zone in the future. If
    /// the VPC is already associated with the hosted zone, <c>DeleteVPCAssociationAuthorization</c>
    /// won't disassociate the VPC from the hosted zone. If you want to delete an existing
    /// association, use <c>DisassociateVPCFromHostedZone</c>.
    /// </para></important>
    /// </summary>
    [Cmdlet("Remove", "R53VPCAssociationAuthorization", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Route 53 DeleteVPCAssociationAuthorization API operation.", Operation = new[] {"DeleteVPCAssociationAuthorization"}, SelectReturnType = typeof(Amazon.Route53.Model.DeleteVPCAssociationAuthorizationResponse))]
    [AWSCmdletOutput("None or Amazon.Route53.Model.DeleteVPCAssociationAuthorizationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Route53.Model.DeleteVPCAssociationAuthorizationResponse) be returned by specifying '-Select *'."
    )]
    public partial class RemoveR53VPCAssociationAuthorizationCmdlet : AmazonRoute53ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter HostedZoneId
        /// <summary>
        /// <para>
        /// <para>When removing authorization to associate a VPC that was created by one Amazon Web
        /// Services account with a hosted zone that was created with a different Amazon Web Services
        /// account, the ID of the hosted zone.</para>
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
        public System.String HostedZoneId { get; set; }
        #endregion
        
        #region Parameter VPC_VPCId
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String VPC_VPCId { get; set; }
        #endregion
        
        #region Parameter VPC_VPCRegion
        /// <summary>
        /// <para>
        /// <para>(Private hosted zones only) The region that an Amazon VPC was created in.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Route53.VPCRegion")]
        public Amazon.Route53.VPCRegion VPC_VPCRegion { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Route53.Model.DeleteVPCAssociationAuthorizationResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the VPC_VPCId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^VPC_VPCId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^VPC_VPCId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.VPC_VPCId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-R53VPCAssociationAuthorization (DeleteVPCAssociationAuthorization)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Route53.Model.DeleteVPCAssociationAuthorizationResponse, RemoveR53VPCAssociationAuthorizationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.VPC_VPCId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.HostedZoneId = this.HostedZoneId;
            #if MODULAR
            if (this.HostedZoneId == null && ParameterWasBound(nameof(this.HostedZoneId)))
            {
                WriteWarning("You are passing $null as a value for parameter HostedZoneId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.VPC_VPCRegion = this.VPC_VPCRegion;
            context.VPC_VPCId = this.VPC_VPCId;
            
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
            var request = new Amazon.Route53.Model.DeleteVPCAssociationAuthorizationRequest();
            
            if (cmdletContext.HostedZoneId != null)
            {
                request.HostedZoneId = cmdletContext.HostedZoneId;
            }
            
             // populate VPC
            var requestVPCIsNull = true;
            request.VPC = new Amazon.Route53.Model.VPC();
            Amazon.Route53.VPCRegion requestVPC_vPC_VPCRegion = null;
            if (cmdletContext.VPC_VPCRegion != null)
            {
                requestVPC_vPC_VPCRegion = cmdletContext.VPC_VPCRegion;
            }
            if (requestVPC_vPC_VPCRegion != null)
            {
                request.VPC.VPCRegion = requestVPC_vPC_VPCRegion;
                requestVPCIsNull = false;
            }
            System.String requestVPC_vPC_VPCId = null;
            if (cmdletContext.VPC_VPCId != null)
            {
                requestVPC_vPC_VPCId = cmdletContext.VPC_VPCId;
            }
            if (requestVPC_vPC_VPCId != null)
            {
                request.VPC.VPCId = requestVPC_vPC_VPCId;
                requestVPCIsNull = false;
            }
             // determine if request.VPC should be set to null
            if (requestVPCIsNull)
            {
                request.VPC = null;
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
        
        private Amazon.Route53.Model.DeleteVPCAssociationAuthorizationResponse CallAWSServiceOperation(IAmazonRoute53 client, Amazon.Route53.Model.DeleteVPCAssociationAuthorizationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Route 53", "DeleteVPCAssociationAuthorization");
            try
            {
                #if DESKTOP
                return client.DeleteVPCAssociationAuthorization(request);
                #elif CORECLR
                return client.DeleteVPCAssociationAuthorizationAsync(request).GetAwaiter().GetResult();
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
            public System.String HostedZoneId { get; set; }
            public Amazon.Route53.VPCRegion VPC_VPCRegion { get; set; }
            public System.String VPC_VPCId { get; set; }
            public System.Func<Amazon.Route53.Model.DeleteVPCAssociationAuthorizationResponse, RemoveR53VPCAssociationAuthorizationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
