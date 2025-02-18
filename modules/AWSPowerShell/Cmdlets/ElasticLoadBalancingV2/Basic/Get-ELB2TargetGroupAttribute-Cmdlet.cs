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

namespace Amazon.PowerShell.Cmdlets.ELB2
{
    /// <summary>
    /// Describes the attributes for the specified target group.
    /// 
    ///  
    /// <para>
    /// For more information, see the following:
    /// </para><ul><li><para><a href="https://docs.aws.amazon.com/elasticloadbalancing/latest/application/load-balancer-target-groups.html#target-group-attributes">Target
    /// group attributes</a> in the <i>Application Load Balancers Guide</i></para></li><li><para><a href="https://docs.aws.amazon.com/elasticloadbalancing/latest/network/load-balancer-target-groups.html#target-group-attributes">Target
    /// group attributes</a> in the <i>Network Load Balancers Guide</i></para></li><li><para><a href="https://docs.aws.amazon.com/elasticloadbalancing/latest/gateway/target-groups.html#target-group-attributes">Target
    /// group attributes</a> in the <i>Gateway Load Balancers Guide</i></para></li></ul>
    /// </summary>
    [Cmdlet("Get", "ELB2TargetGroupAttribute")]
    [OutputType("Amazon.ElasticLoadBalancingV2.Model.TargetGroupAttribute")]
    [AWSCmdlet("Calls the Elastic Load Balancing V2 DescribeTargetGroupAttributes API operation.", Operation = new[] {"DescribeTargetGroupAttributes"}, SelectReturnType = typeof(Amazon.ElasticLoadBalancingV2.Model.DescribeTargetGroupAttributesResponse))]
    [AWSCmdletOutput("Amazon.ElasticLoadBalancingV2.Model.TargetGroupAttribute or Amazon.ElasticLoadBalancingV2.Model.DescribeTargetGroupAttributesResponse",
        "This cmdlet returns a collection of Amazon.ElasticLoadBalancingV2.Model.TargetGroupAttribute objects.",
        "The service call response (type Amazon.ElasticLoadBalancingV2.Model.DescribeTargetGroupAttributesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetELB2TargetGroupAttributeCmdlet : AmazonElasticLoadBalancingV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter TargetGroupArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the target group.</para>
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
        public System.String TargetGroupArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Attributes'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElasticLoadBalancingV2.Model.DescribeTargetGroupAttributesResponse).
        /// Specifying the name of a property of type Amazon.ElasticLoadBalancingV2.Model.DescribeTargetGroupAttributesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Attributes";
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
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElasticLoadBalancingV2.Model.DescribeTargetGroupAttributesResponse, GetELB2TargetGroupAttributeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.TargetGroupArn = this.TargetGroupArn;
            #if MODULAR
            if (this.TargetGroupArn == null && ParameterWasBound(nameof(this.TargetGroupArn)))
            {
                WriteWarning("You are passing $null as a value for parameter TargetGroupArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ElasticLoadBalancingV2.Model.DescribeTargetGroupAttributesRequest();
            
            if (cmdletContext.TargetGroupArn != null)
            {
                request.TargetGroupArn = cmdletContext.TargetGroupArn;
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
        
        private Amazon.ElasticLoadBalancingV2.Model.DescribeTargetGroupAttributesResponse CallAWSServiceOperation(IAmazonElasticLoadBalancingV2 client, Amazon.ElasticLoadBalancingV2.Model.DescribeTargetGroupAttributesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Elastic Load Balancing V2", "DescribeTargetGroupAttributes");
            try
            {
                return client.DescribeTargetGroupAttributesAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String TargetGroupArn { get; set; }
            public System.Func<Amazon.ElasticLoadBalancingV2.Model.DescribeTargetGroupAttributesResponse, GetELB2TargetGroupAttributeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Attributes;
        }
        
    }
}
