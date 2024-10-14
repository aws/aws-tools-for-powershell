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
using Amazon.ElasticLoadBalancing;
using Amazon.ElasticLoadBalancing.Model;

namespace Amazon.PowerShell.Cmdlets.ELB
{
    /// <summary>
    /// Deregisters the specified instances from the specified load balancer. After the instance
    /// is deregistered, it no longer receives traffic from the load balancer.
    /// 
    ///  
    /// <para>
    /// You can use <a>DescribeLoadBalancers</a> to verify that the instance is deregistered
    /// from the load balancer.
    /// </para><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/elasticloadbalancing/latest/classic/elb-deregister-register-instances.html">Register
    /// or De-Register EC2 Instances</a> in the <i>Classic Load Balancers Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Remove", "ELBInstanceFromLoadBalancer", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.ElasticLoadBalancing.Model.Instance")]
    [AWSCmdlet("Calls the Elastic Load Balancing DeregisterInstancesFromLoadBalancer API operation.", Operation = new[] {"DeregisterInstancesFromLoadBalancer"}, SelectReturnType = typeof(Amazon.ElasticLoadBalancing.Model.DeregisterInstancesFromLoadBalancerResponse))]
    [AWSCmdletOutput("Amazon.ElasticLoadBalancing.Model.Instance or Amazon.ElasticLoadBalancing.Model.DeregisterInstancesFromLoadBalancerResponse",
        "This cmdlet returns a collection of Amazon.ElasticLoadBalancing.Model.Instance objects.",
        "The service call response (type Amazon.ElasticLoadBalancing.Model.DeregisterInstancesFromLoadBalancerResponse) can be returned by specifying '-Select *'."
    )]
    public partial class RemoveELBInstanceFromLoadBalancerCmdlet : AmazonElasticLoadBalancingClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Instance
        /// <summary>
        /// <para>
        /// <para>The IDs of the instances.</para>
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElasticLoadBalancing.Model.DeregisterInstancesFromLoadBalancerResponse).
        /// Specifying the name of a property of type Amazon.ElasticLoadBalancing.Model.DeregisterInstancesFromLoadBalancerResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Instances";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the LoadBalancerName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^LoadBalancerName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^LoadBalancerName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Instance), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-ELBInstanceFromLoadBalancer (DeregisterInstancesFromLoadBalancer)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElasticLoadBalancing.Model.DeregisterInstancesFromLoadBalancerResponse, RemoveELBInstanceFromLoadBalancerCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.LoadBalancerName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
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
            var request = new Amazon.ElasticLoadBalancing.Model.DeregisterInstancesFromLoadBalancerRequest();
            
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
        
        private Amazon.ElasticLoadBalancing.Model.DeregisterInstancesFromLoadBalancerResponse CallAWSServiceOperation(IAmazonElasticLoadBalancing client, Amazon.ElasticLoadBalancing.Model.DeregisterInstancesFromLoadBalancerRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Elastic Load Balancing", "DeregisterInstancesFromLoadBalancer");
            try
            {
                #if DESKTOP
                return client.DeregisterInstancesFromLoadBalancer(request);
                #elif CORECLR
                return client.DeregisterInstancesFromLoadBalancerAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.ElasticLoadBalancing.Model.Instance> Instance { get; set; }
            public System.String LoadBalancerName { get; set; }
            public System.Func<Amazon.ElasticLoadBalancing.Model.DeregisterInstancesFromLoadBalancerResponse, RemoveELBInstanceFromLoadBalancerCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Instances;
        }
        
    }
}
