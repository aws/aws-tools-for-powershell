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
using Amazon.ElasticLoadBalancing;
using Amazon.ElasticLoadBalancing.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.ELB
{
    /// <summary>
    /// Adds the specified instances to the specified load balancer.
    /// 
    ///  
    /// <para>
    /// The instance must be a running instance in the same network as the load balancer (EC2-Classic
    /// or the same VPC). If you have EC2-Classic instances and a load balancer in a VPC with
    /// ClassicLink enabled, you can link the EC2-Classic instances to that VPC and then register
    /// the linked EC2-Classic instances with the load balancer in the VPC.
    /// </para><para>
    /// Note that <c>RegisterInstanceWithLoadBalancer</c> completes when the request has been
    /// registered. Instance registration takes a little time to complete. To check the state
    /// of the registered instances, use <a>DescribeLoadBalancers</a> or <a>DescribeInstanceHealth</a>.
    /// </para><para>
    /// After the instance is registered, it starts receiving traffic and requests from the
    /// load balancer. Any instance that is not in one of the Availability Zones registered
    /// for the load balancer is moved to the <c>OutOfService</c> state. If an Availability
    /// Zone is added to the load balancer later, any instances registered with the load balancer
    /// move to the <c>InService</c> state.
    /// </para><para>
    /// To deregister instances from a load balancer, use <a>DeregisterInstancesFromLoadBalancer</a>.
    /// </para><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/elasticloadbalancing/latest/classic/elb-deregister-register-instances.html">Register
    /// or De-Register EC2 Instances</a> in the <i>Classic Load Balancers Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Register", "ELBInstanceWithLoadBalancer", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElasticLoadBalancing.Model.Instance")]
    [AWSCmdlet("Calls the Elastic Load Balancing RegisterInstancesWithLoadBalancer API operation.", Operation = new[] {"RegisterInstancesWithLoadBalancer"}, SelectReturnType = typeof(Amazon.ElasticLoadBalancing.Model.RegisterInstancesWithLoadBalancerResponse))]
    [AWSCmdletOutput("Amazon.ElasticLoadBalancing.Model.Instance or Amazon.ElasticLoadBalancing.Model.RegisterInstancesWithLoadBalancerResponse",
        "This cmdlet returns a collection of Amazon.ElasticLoadBalancing.Model.Instance objects.",
        "The service call response (type Amazon.ElasticLoadBalancing.Model.RegisterInstancesWithLoadBalancerResponse) can be returned by specifying '-Select *'."
    )]
    public partial class RegisterELBInstanceWithLoadBalancerCmdlet : AmazonElasticLoadBalancingClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Instance
        /// <summary>
        /// <para>
        /// <para>The IDs of the instances.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Instances")]
        public Amazon.ElasticLoadBalancing.Model.Instance[] Instance { get; set; }
        #endregion
        
        #region Parameter LoadBalancerName
        /// <summary>
        /// <para>
        /// <para>The name of the load balancer.</para>
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
        public System.String LoadBalancerName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Instances'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElasticLoadBalancing.Model.RegisterInstancesWithLoadBalancerResponse).
        /// Specifying the name of a property of type Amazon.ElasticLoadBalancing.Model.RegisterInstancesWithLoadBalancerResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Instances";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.LoadBalancerName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Register-ELBInstanceWithLoadBalancer (RegisterInstancesWithLoadBalancer)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElasticLoadBalancing.Model.RegisterInstancesWithLoadBalancerResponse, RegisterELBInstanceWithLoadBalancerCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Instance != null)
            {
                context.Instance = new List<Amazon.ElasticLoadBalancing.Model.Instance>(this.Instance);
            }
            #if MODULAR
            if (this.Instance == null && ParameterWasBound(nameof(this.Instance)))
            {
                WriteWarning("You are passing $null as a value for parameter Instance which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.LoadBalancerName = this.LoadBalancerName;
            #if MODULAR
            if (this.LoadBalancerName == null && ParameterWasBound(nameof(this.LoadBalancerName)))
            {
                WriteWarning("You are passing $null as a value for parameter LoadBalancerName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ElasticLoadBalancing.Model.RegisterInstancesWithLoadBalancerRequest();
            
            if (cmdletContext.Instance != null)
            {
                request.Instances = cmdletContext.Instance;
            }
            if (cmdletContext.LoadBalancerName != null)
            {
                request.LoadBalancerName = cmdletContext.LoadBalancerName;
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
        
        private Amazon.ElasticLoadBalancing.Model.RegisterInstancesWithLoadBalancerResponse CallAWSServiceOperation(IAmazonElasticLoadBalancing client, Amazon.ElasticLoadBalancing.Model.RegisterInstancesWithLoadBalancerRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Elastic Load Balancing", "RegisterInstancesWithLoadBalancer");
            try
            {
                return client.RegisterInstancesWithLoadBalancerAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.ElasticLoadBalancing.Model.Instance> Instance { get; set; }
            public System.String LoadBalancerName { get; set; }
            public System.Func<Amazon.ElasticLoadBalancing.Model.RegisterInstancesWithLoadBalancerResponse, RegisterELBInstanceWithLoadBalancerCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Instances;
        }
        
    }
}
