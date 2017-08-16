/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Authorizes the AWS account that created a specified VPC to submit an <code>AssociateVPCWithHostedZone</code>
    /// request to associate the VPC with a specified hosted zone that was created by a different
    /// account. To submit a <code>CreateVPCAssociationAuthorization</code> request, you must
    /// use the account that created the hosted zone. After you authorize the association,
    /// use the account that created the VPC to submit an <code>AssociateVPCWithHostedZone</code>
    /// request.
    /// 
    ///  <note><para>
    /// If you want to associate multiple VPCs that you created by using one account with
    /// a hosted zone that you created by using a different account, you must submit one authorization
    /// request for each VPC.
    /// </para></note>
    /// </summary>
    [Cmdlet("New", "R53VPCAssociationAuthorization", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Route53.Model.CreateVPCAssociationAuthorizationResponse")]
    [AWSCmdlet("Invokes the CreateVPCAssociationAuthorization operation against Amazon Route 53.", Operation = new[] {"CreateVPCAssociationAuthorization"})]
    [AWSCmdletOutput("Amazon.Route53.Model.CreateVPCAssociationAuthorizationResponse",
        "This cmdlet returns a Amazon.Route53.Model.CreateVPCAssociationAuthorizationResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewR53VPCAssociationAuthorizationCmdlet : AmazonRoute53ClientCmdlet, IExecutor
    {
        
        #region Parameter HostedZoneId
        /// <summary>
        /// <para>
        /// <para>The ID of the private hosted zone that you want to authorize associating a VPC with.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String HostedZoneId { get; set; }
        #endregion
        
        #region Parameter VPC_VPCId
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String VPC_VPCId { get; set; }
        #endregion
        
        #region Parameter VPC_VPCRegion
        /// <summary>
        /// <para>
        /// <para>(Private hosted zones only) The region in which you created an Amazon VPC.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.Route53.VPCRegion")]
        public Amazon.Route53.VPCRegion VPC_VPCRegion { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("VPC_VPCId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-R53VPCAssociationAuthorization (CreateVPCAssociationAuthorization)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.HostedZoneId = this.HostedZoneId;
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
            var request = new Amazon.Route53.Model.CreateVPCAssociationAuthorizationRequest();
            
            if (cmdletContext.HostedZoneId != null)
            {
                request.HostedZoneId = cmdletContext.HostedZoneId;
            }
            
             // populate VPC
            bool requestVPCIsNull = true;
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
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
        
        private Amazon.Route53.Model.CreateVPCAssociationAuthorizationResponse CallAWSServiceOperation(IAmazonRoute53 client, Amazon.Route53.Model.CreateVPCAssociationAuthorizationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Route 53", "CreateVPCAssociationAuthorization");
            try
            {
                #if DESKTOP
                return client.CreateVPCAssociationAuthorization(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateVPCAssociationAuthorizationAsync(request);
                return task.Result;
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
        }
        
    }
}
