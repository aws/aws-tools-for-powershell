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
using Amazon.ElasticLoadBalancingV2;
using Amazon.ElasticLoadBalancingV2.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.ELB2
{
    /// <summary>
    /// Modifies the specified attributes of the specified Application Load Balancer, Network
    /// Load Balancer, or Gateway Load Balancer.
    /// 
    ///  
    /// <para>
    /// If any of the specified attributes can't be modified as requested, the call fails.
    /// Any existing attributes that you do not modify retain their current values.
    /// </para>
    /// </summary>
    [Cmdlet("Edit", "ELB2LoadBalancerAttribute", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElasticLoadBalancingV2.Model.LoadBalancerAttribute")]
    [AWSCmdlet("Calls the Elastic Load Balancing V2 ModifyLoadBalancerAttributes API operation.", Operation = new[] {"ModifyLoadBalancerAttributes"}, SelectReturnType = typeof(Amazon.ElasticLoadBalancingV2.Model.ModifyLoadBalancerAttributesResponse))]
    [AWSCmdletOutput("Amazon.ElasticLoadBalancingV2.Model.LoadBalancerAttribute or Amazon.ElasticLoadBalancingV2.Model.ModifyLoadBalancerAttributesResponse",
        "This cmdlet returns a collection of Amazon.ElasticLoadBalancingV2.Model.LoadBalancerAttribute objects.",
        "The service call response (type Amazon.ElasticLoadBalancingV2.Model.ModifyLoadBalancerAttributesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class EditELB2LoadBalancerAttributeCmdlet : AmazonElasticLoadBalancingV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Attribute
        /// <summary>
        /// <para>
        /// <para>The load balancer attributes.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
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
        [Alias("Attributes")]
        public Amazon.ElasticLoadBalancingV2.Model.LoadBalancerAttribute[] Attribute { get; set; }
        #endregion
        
        #region Parameter LoadBalancerArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the load balancer.</para>
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
        public System.String LoadBalancerArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Attributes'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElasticLoadBalancingV2.Model.ModifyLoadBalancerAttributesResponse).
        /// Specifying the name of a property of type Amazon.ElasticLoadBalancingV2.Model.ModifyLoadBalancerAttributesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Attributes";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.LoadBalancerArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-ELB2LoadBalancerAttribute (ModifyLoadBalancerAttributes)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElasticLoadBalancingV2.Model.ModifyLoadBalancerAttributesResponse, EditELB2LoadBalancerAttributeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Attribute != null)
            {
                context.Attribute = new List<Amazon.ElasticLoadBalancingV2.Model.LoadBalancerAttribute>(this.Attribute);
            }
            #if MODULAR
            if (this.Attribute == null && ParameterWasBound(nameof(this.Attribute)))
            {
                WriteWarning("You are passing $null as a value for parameter Attribute which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.LoadBalancerArn = this.LoadBalancerArn;
            #if MODULAR
            if (this.LoadBalancerArn == null && ParameterWasBound(nameof(this.LoadBalancerArn)))
            {
                WriteWarning("You are passing $null as a value for parameter LoadBalancerArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ElasticLoadBalancingV2.Model.ModifyLoadBalancerAttributesRequest();
            
            if (cmdletContext.Attribute != null)
            {
                request.Attributes = cmdletContext.Attribute;
            }
            if (cmdletContext.LoadBalancerArn != null)
            {
                request.LoadBalancerArn = cmdletContext.LoadBalancerArn;
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
        
        private Amazon.ElasticLoadBalancingV2.Model.ModifyLoadBalancerAttributesResponse CallAWSServiceOperation(IAmazonElasticLoadBalancingV2 client, Amazon.ElasticLoadBalancingV2.Model.ModifyLoadBalancerAttributesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Elastic Load Balancing V2", "ModifyLoadBalancerAttributes");
            try
            {
                return client.ModifyLoadBalancerAttributesAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.ElasticLoadBalancingV2.Model.LoadBalancerAttribute> Attribute { get; set; }
            public System.String LoadBalancerArn { get; set; }
            public System.Func<Amazon.ElasticLoadBalancingV2.Model.ModifyLoadBalancerAttributesResponse, EditELB2LoadBalancerAttributeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Attributes;
        }
        
    }
}
