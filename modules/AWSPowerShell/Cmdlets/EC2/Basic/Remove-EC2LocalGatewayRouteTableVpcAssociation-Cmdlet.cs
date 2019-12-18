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
    /// Deletes the specified association between a VPC and local gateway route table.
    /// </summary>
    [Cmdlet("Remove", "EC2LocalGatewayRouteTableVpcAssociation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.EC2.Model.LocalGatewayRouteTableVpcAssociation")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) DeleteLocalGatewayRouteTableVpcAssociation API operation.", Operation = new[] {"DeleteLocalGatewayRouteTableVpcAssociation"}, SelectReturnType = typeof(Amazon.EC2.Model.DeleteLocalGatewayRouteTableVpcAssociationResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.LocalGatewayRouteTableVpcAssociation or Amazon.EC2.Model.DeleteLocalGatewayRouteTableVpcAssociationResponse",
        "This cmdlet returns an Amazon.EC2.Model.LocalGatewayRouteTableVpcAssociation object.",
        "The service call response (type Amazon.EC2.Model.DeleteLocalGatewayRouteTableVpcAssociationResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RemoveEC2LocalGatewayRouteTableVpcAssociationCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter LocalGatewayRouteTableVpcAssociationId
        /// <summary>
        /// <para>
        /// <para>The ID of the association.</para>
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
        public System.String LocalGatewayRouteTableVpcAssociationId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'LocalGatewayRouteTableVpcAssociation'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.DeleteLocalGatewayRouteTableVpcAssociationResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.DeleteLocalGatewayRouteTableVpcAssociationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "LocalGatewayRouteTableVpcAssociation";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the LocalGatewayRouteTableVpcAssociationId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^LocalGatewayRouteTableVpcAssociationId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^LocalGatewayRouteTableVpcAssociationId' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.LocalGatewayRouteTableVpcAssociationId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-EC2LocalGatewayRouteTableVpcAssociation (DeleteLocalGatewayRouteTableVpcAssociation)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.DeleteLocalGatewayRouteTableVpcAssociationResponse, RemoveEC2LocalGatewayRouteTableVpcAssociationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.LocalGatewayRouteTableVpcAssociationId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.LocalGatewayRouteTableVpcAssociationId = this.LocalGatewayRouteTableVpcAssociationId;
            #if MODULAR
            if (this.LocalGatewayRouteTableVpcAssociationId == null && ParameterWasBound(nameof(this.LocalGatewayRouteTableVpcAssociationId)))
            {
                WriteWarning("You are passing $null as a value for parameter LocalGatewayRouteTableVpcAssociationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EC2.Model.DeleteLocalGatewayRouteTableVpcAssociationRequest();
            
            if (cmdletContext.LocalGatewayRouteTableVpcAssociationId != null)
            {
                request.LocalGatewayRouteTableVpcAssociationId = cmdletContext.LocalGatewayRouteTableVpcAssociationId;
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
        
        private Amazon.EC2.Model.DeleteLocalGatewayRouteTableVpcAssociationResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.DeleteLocalGatewayRouteTableVpcAssociationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "DeleteLocalGatewayRouteTableVpcAssociation");
            try
            {
                #if DESKTOP
                return client.DeleteLocalGatewayRouteTableVpcAssociation(request);
                #elif CORECLR
                return client.DeleteLocalGatewayRouteTableVpcAssociationAsync(request).GetAwaiter().GetResult();
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
            public System.String LocalGatewayRouteTableVpcAssociationId { get; set; }
            public System.Func<Amazon.EC2.Model.DeleteLocalGatewayRouteTableVpcAssociationResponse, RemoveEC2LocalGatewayRouteTableVpcAssociationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.LocalGatewayRouteTableVpcAssociation;
        }
        
    }
}
