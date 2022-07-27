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
using Amazon.GlobalAccelerator;
using Amazon.GlobalAccelerator.Model;

namespace Amazon.PowerShell.Cmdlets.GACL
{
    /// <summary>
    /// Create an endpoint group for the specified listener for a custom routing accelerator.
    /// An endpoint group is a collection of endpoints in one Amazon Web Services Region.
    /// </summary>
    [Cmdlet("New", "GACLCustomRoutingEndpointGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.GlobalAccelerator.Model.CustomRoutingEndpointGroup")]
    [AWSCmdlet("Calls the AWS Global Accelerator CreateCustomRoutingEndpointGroup API operation.", Operation = new[] {"CreateCustomRoutingEndpointGroup"}, SelectReturnType = typeof(Amazon.GlobalAccelerator.Model.CreateCustomRoutingEndpointGroupResponse))]
    [AWSCmdletOutput("Amazon.GlobalAccelerator.Model.CustomRoutingEndpointGroup or Amazon.GlobalAccelerator.Model.CreateCustomRoutingEndpointGroupResponse",
        "This cmdlet returns an Amazon.GlobalAccelerator.Model.CustomRoutingEndpointGroup object.",
        "The service call response (type Amazon.GlobalAccelerator.Model.CreateCustomRoutingEndpointGroupResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewGACLCustomRoutingEndpointGroupCmdlet : AmazonGlobalAcceleratorClientCmdlet, IExecutor
    {
        
        #region Parameter DestinationConfiguration
        /// <summary>
        /// <para>
        /// <para>Sets the port range and protocol for all endpoints (virtual private cloud subnets)
        /// in a custom routing endpoint group to accept client traffic on.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("DestinationConfigurations")]
        public Amazon.GlobalAccelerator.Model.CustomRoutingDestinationConfiguration[] DestinationConfiguration { get; set; }
        #endregion
        
        #region Parameter EndpointGroupRegion
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services Region where the endpoint group is located. A listener can
        /// have only one endpoint group in a specific Region.</para>
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
        public System.String EndpointGroupRegion { get; set; }
        #endregion
        
        #region Parameter IdempotencyToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency—that
        /// is, the uniqueness—of the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IdempotencyToken { get; set; }
        #endregion
        
        #region Parameter ListenerArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the listener for a custom routing endpoint.</para>
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
        public System.String ListenerArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'EndpointGroup'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GlobalAccelerator.Model.CreateCustomRoutingEndpointGroupResponse).
        /// Specifying the name of a property of type Amazon.GlobalAccelerator.Model.CreateCustomRoutingEndpointGroupResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "EndpointGroup";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ListenerArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-GACLCustomRoutingEndpointGroup (CreateCustomRoutingEndpointGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GlobalAccelerator.Model.CreateCustomRoutingEndpointGroupResponse, NewGACLCustomRoutingEndpointGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.DestinationConfiguration != null)
            {
                context.DestinationConfiguration = new List<Amazon.GlobalAccelerator.Model.CustomRoutingDestinationConfiguration>(this.DestinationConfiguration);
            }
            #if MODULAR
            if (this.DestinationConfiguration == null && ParameterWasBound(nameof(this.DestinationConfiguration)))
            {
                WriteWarning("You are passing $null as a value for parameter DestinationConfiguration which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EndpointGroupRegion = this.EndpointGroupRegion;
            #if MODULAR
            if (this.EndpointGroupRegion == null && ParameterWasBound(nameof(this.EndpointGroupRegion)))
            {
                WriteWarning("You are passing $null as a value for parameter EndpointGroupRegion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IdempotencyToken = this.IdempotencyToken;
            context.ListenerArn = this.ListenerArn;
            #if MODULAR
            if (this.ListenerArn == null && ParameterWasBound(nameof(this.ListenerArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ListenerArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.GlobalAccelerator.Model.CreateCustomRoutingEndpointGroupRequest();
            
            if (cmdletContext.DestinationConfiguration != null)
            {
                request.DestinationConfigurations = cmdletContext.DestinationConfiguration;
            }
            if (cmdletContext.EndpointGroupRegion != null)
            {
                request.EndpointGroupRegion = cmdletContext.EndpointGroupRegion;
            }
            if (cmdletContext.IdempotencyToken != null)
            {
                request.IdempotencyToken = cmdletContext.IdempotencyToken;
            }
            if (cmdletContext.ListenerArn != null)
            {
                request.ListenerArn = cmdletContext.ListenerArn;
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
        
        private Amazon.GlobalAccelerator.Model.CreateCustomRoutingEndpointGroupResponse CallAWSServiceOperation(IAmazonGlobalAccelerator client, Amazon.GlobalAccelerator.Model.CreateCustomRoutingEndpointGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Global Accelerator", "CreateCustomRoutingEndpointGroup");
            try
            {
                #if DESKTOP
                return client.CreateCustomRoutingEndpointGroup(request);
                #elif CORECLR
                return client.CreateCustomRoutingEndpointGroupAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.GlobalAccelerator.Model.CustomRoutingDestinationConfiguration> DestinationConfiguration { get; set; }
            public System.String EndpointGroupRegion { get; set; }
            public System.String IdempotencyToken { get; set; }
            public System.String ListenerArn { get; set; }
            public System.Func<Amazon.GlobalAccelerator.Model.CreateCustomRoutingEndpointGroupResponse, NewGACLCustomRoutingEndpointGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.EndpointGroup;
        }
        
    }
}
