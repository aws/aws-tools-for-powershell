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
using Amazon.Route53RecoveryReadiness;
using Amazon.Route53RecoveryReadiness.Model;

namespace Amazon.PowerShell.Cmdlets.PD
{
    /// <summary>
    /// Creates a resource set. A resource set is a set of resources of one type that span
    /// multiple cells. You can associate a resource set with a readiness check to monitor
    /// the resources for failover readiness.
    /// </summary>
    [Cmdlet("New", "PDResourceSet", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Route53RecoveryReadiness.Model.CreateResourceSetResponse")]
    [AWSCmdlet("Calls the AWS Route53 Recovery Readiness CreateResourceSet API operation.", Operation = new[] {"CreateResourceSet"}, SelectReturnType = typeof(Amazon.Route53RecoveryReadiness.Model.CreateResourceSetResponse))]
    [AWSCmdletOutput("Amazon.Route53RecoveryReadiness.Model.CreateResourceSetResponse",
        "This cmdlet returns an Amazon.Route53RecoveryReadiness.Model.CreateResourceSetResponse object containing multiple properties."
    )]
    public partial class NewPDResourceSetCmdlet : AmazonRoute53RecoveryReadinessClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Resource
        /// <summary>
        /// <para>
        /// <para>A list of resource objects in the resource set.</para>
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
        [Alias("Resources")]
        public Amazon.Route53RecoveryReadiness.Model.Resource[] Resource { get; set; }
        #endregion
        
        #region Parameter ResourceSetName
        /// <summary>
        /// <para>
        /// <para>The name of the resource set to create.</para>
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
        public System.String ResourceSetName { get; set; }
        #endregion
        
        #region Parameter ResourceSetType
        /// <summary>
        /// <para>
        /// <para>The resource type of the resources in the resource set. Enter one of the following
        /// values for resource type:</para><para>AWS::ApiGateway::Stage, AWS::ApiGatewayV2::Stage, AWS::AutoScaling::AutoScalingGroup,
        /// AWS::CloudWatch::Alarm, AWS::EC2::CustomerGateway, AWS::DynamoDB::Table, AWS::EC2::Volume,
        /// AWS::ElasticLoadBalancing::LoadBalancer, AWS::ElasticLoadBalancingV2::LoadBalancer,
        /// AWS::Lambda::Function, AWS::MSK::Cluster, AWS::RDS::DBCluster, AWS::Route53::HealthCheck,
        /// AWS::SQS::Queue, AWS::SNS::Topic, AWS::SNS::Subscription, AWS::EC2::VPC, AWS::EC2::VPNConnection,
        /// AWS::EC2::VPNGateway, AWS::Route53RecoveryReadiness::DNSTargetResource</para>
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
        public System.String ResourceSetType { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A tag to associate with the parameters for a resource set.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Route53RecoveryReadiness.Model.CreateResourceSetResponse).
        /// Specifying the name of a property of type Amazon.Route53RecoveryReadiness.Model.CreateResourceSetResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ResourceSetName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-PDResourceSet (CreateResourceSet)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Route53RecoveryReadiness.Model.CreateResourceSetResponse, NewPDResourceSetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Resource != null)
            {
                context.Resource = new List<Amazon.Route53RecoveryReadiness.Model.Resource>(this.Resource);
            }
            #if MODULAR
            if (this.Resource == null && ParameterWasBound(nameof(this.Resource)))
            {
                WriteWarning("You are passing $null as a value for parameter Resource which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ResourceSetName = this.ResourceSetName;
            #if MODULAR
            if (this.ResourceSetName == null && ParameterWasBound(nameof(this.ResourceSetName)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceSetName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ResourceSetType = this.ResourceSetType;
            #if MODULAR
            if (this.ResourceSetType == null && ParameterWasBound(nameof(this.ResourceSetType)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceSetType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            
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
            var request = new Amazon.Route53RecoveryReadiness.Model.CreateResourceSetRequest();
            
            if (cmdletContext.Resource != null)
            {
                request.Resources = cmdletContext.Resource;
            }
            if (cmdletContext.ResourceSetName != null)
            {
                request.ResourceSetName = cmdletContext.ResourceSetName;
            }
            if (cmdletContext.ResourceSetType != null)
            {
                request.ResourceSetType = cmdletContext.ResourceSetType;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.Route53RecoveryReadiness.Model.CreateResourceSetResponse CallAWSServiceOperation(IAmazonRoute53RecoveryReadiness client, Amazon.Route53RecoveryReadiness.Model.CreateResourceSetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Route53 Recovery Readiness", "CreateResourceSet");
            try
            {
                return client.CreateResourceSetAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.Route53RecoveryReadiness.Model.Resource> Resource { get; set; }
            public System.String ResourceSetName { get; set; }
            public System.String ResourceSetType { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.Route53RecoveryReadiness.Model.CreateResourceSetResponse, NewPDResourceSetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
