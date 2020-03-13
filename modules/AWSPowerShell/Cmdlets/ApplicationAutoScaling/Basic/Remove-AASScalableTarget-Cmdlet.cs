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
using Amazon.ApplicationAutoScaling;
using Amazon.ApplicationAutoScaling.Model;

namespace Amazon.PowerShell.Cmdlets.AAS
{
    /// <summary>
    /// Deregisters an Application Auto Scaling scalable target when you have finished using
    /// it. To see which resources have been registered, use <a href="https://docs.aws.amazon.com/autoscaling/application/APIReference/API_DescribeScalableTargets.html">DescribeScalableTargets</a>.
    /// 
    /// 
    ///  <note><para>
    /// Deregistering a scalable target deletes the scaling policies and the scheduled actions
    /// that are associated with it.
    /// </para></note>
    /// </summary>
    [Cmdlet("Remove", "AASScalableTarget", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Application Auto Scaling DeregisterScalableTarget API operation.", Operation = new[] {"DeregisterScalableTarget"}, SelectReturnType = typeof(Amazon.ApplicationAutoScaling.Model.DeregisterScalableTargetResponse))]
    [AWSCmdletOutput("None or Amazon.ApplicationAutoScaling.Model.DeregisterScalableTargetResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.ApplicationAutoScaling.Model.DeregisterScalableTargetResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RemoveAASScalableTargetCmdlet : AmazonApplicationAutoScalingClientCmdlet, IExecutor
    {
        
        #region Parameter ResourceId
        /// <summary>
        /// <para>
        /// <para>The identifier of the resource associated with the scalable target. This string consists
        /// of the resource type and unique identifier.</para><ul><li><para>ECS service - The resource type is <code>service</code> and the unique identifier
        /// is the cluster name and service name. Example: <code>service/default/sample-webapp</code>.</para></li><li><para>Spot Fleet request - The resource type is <code>spot-fleet-request</code> and the
        /// unique identifier is the Spot Fleet request ID. Example: <code>spot-fleet-request/sfr-73fbd2ce-aa30-494c-8788-1cee4EXAMPLE</code>.</para></li><li><para>EMR cluster - The resource type is <code>instancegroup</code> and the unique identifier
        /// is the cluster ID and instance group ID. Example: <code>instancegroup/j-2EEZNYKUA1NTV/ig-1791Y4E1L8YI0</code>.</para></li><li><para>AppStream 2.0 fleet - The resource type is <code>fleet</code> and the unique identifier
        /// is the fleet name. Example: <code>fleet/sample-fleet</code>.</para></li><li><para>DynamoDB table - The resource type is <code>table</code> and the unique identifier
        /// is the table name. Example: <code>table/my-table</code>.</para></li><li><para>DynamoDB global secondary index - The resource type is <code>index</code> and the
        /// unique identifier is the index name. Example: <code>table/my-table/index/my-table-index</code>.</para></li><li><para>Aurora DB cluster - The resource type is <code>cluster</code> and the unique identifier
        /// is the cluster name. Example: <code>cluster:my-db-cluster</code>.</para></li><li><para>Amazon SageMaker endpoint variant - The resource type is <code>variant</code> and
        /// the unique identifier is the resource ID. Example: <code>endpoint/my-end-point/variant/KMeansClustering</code>.</para></li><li><para>Custom resources are not supported with a resource type. This parameter must specify
        /// the <code>OutputValue</code> from the CloudFormation template stack used to access
        /// the resources. The unique identifier is defined by the service provider. More information
        /// is available in our <a href="https://github.com/aws/aws-auto-scaling-custom-resource">GitHub
        /// repository</a>.</para></li><li><para>Amazon Comprehend document classification endpoint - The resource type and unique
        /// identifier are specified using the endpoint ARN. Example: <code>arn:aws:comprehend:us-west-2:123456789012:document-classifier-endpoint/EXAMPLE</code>.</para></li><li><para>Lambda provisioned concurrency - The resource type is <code>function</code> and the
        /// unique identifier is the function name with a function version or alias name suffix
        /// that is not <code>$LATEST</code>. Example: <code>function:my-function:prod</code>
        /// or <code>function:my-function:1</code>.</para></li><li><para>Amazon Keyspaces table - The resource type is <code>table</code> and the unique identifier
        /// is the table name. Example: <code>keyspace/mykeyspace/table/mytable</code>.</para></li></ul>
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
        public System.String ResourceId { get; set; }
        #endregion
        
        #region Parameter ScalableDimension
        /// <summary>
        /// <para>
        /// <para>The scalable dimension associated with the scalable target. This string consists of
        /// the service namespace, resource type, and scaling property.</para><ul><li><para><code>ecs:service:DesiredCount</code> - The desired task count of an ECS service.</para></li><li><para><code>ec2:spot-fleet-request:TargetCapacity</code> - The target capacity of a Spot
        /// Fleet request.</para></li><li><para><code>elasticmapreduce:instancegroup:InstanceCount</code> - The instance count of
        /// an EMR Instance Group.</para></li><li><para><code>appstream:fleet:DesiredCapacity</code> - The desired capacity of an AppStream
        /// 2.0 fleet.</para></li><li><para><code>dynamodb:table:ReadCapacityUnits</code> - The provisioned read capacity for
        /// a DynamoDB table.</para></li><li><para><code>dynamodb:table:WriteCapacityUnits</code> - The provisioned write capacity for
        /// a DynamoDB table.</para></li><li><para><code>dynamodb:index:ReadCapacityUnits</code> - The provisioned read capacity for
        /// a DynamoDB global secondary index.</para></li><li><para><code>dynamodb:index:WriteCapacityUnits</code> - The provisioned write capacity for
        /// a DynamoDB global secondary index.</para></li><li><para><code>rds:cluster:ReadReplicaCount</code> - The count of Aurora Replicas in an Aurora
        /// DB cluster. Available for Aurora MySQL-compatible edition and Aurora PostgreSQL-compatible
        /// edition.</para></li><li><para><code>sagemaker:variant:DesiredInstanceCount</code> - The number of EC2 instances
        /// for an Amazon SageMaker model endpoint variant.</para></li><li><para><code>custom-resource:ResourceType:Property</code> - The scalable dimension for a
        /// custom resource provided by your own application or service.</para></li><li><para><code>comprehend:document-classifier-endpoint:DesiredInferenceUnits</code> - The
        /// number of inference units for an Amazon Comprehend document classification endpoint.</para></li><li><para><code>lambda:function:ProvisionedConcurrency</code> - The provisioned concurrency
        /// for a Lambda function.</para></li><li><para><code>cassandra:table:ReadCapacityUnits</code> - The provisioned read capacity for
        /// an Amazon Keyspaces table.</para></li><li><para><code>cassandra:table:WriteCapacityUnits</code> - The provisioned write capacity
        /// for an Amazon Keyspaces table.</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.ApplicationAutoScaling.ScalableDimension")]
        public Amazon.ApplicationAutoScaling.ScalableDimension ScalableDimension { get; set; }
        #endregion
        
        #region Parameter ServiceNamespace
        /// <summary>
        /// <para>
        /// <para>The namespace of the AWS service that provides the resource. For a resource provided
        /// by your own application or service, use <code>custom-resource</code> instead.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.ApplicationAutoScaling.ServiceNamespace")]
        public Amazon.ApplicationAutoScaling.ServiceNamespace ServiceNamespace { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ApplicationAutoScaling.Model.DeregisterScalableTargetResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ServiceNamespace parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ServiceNamespace' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ServiceNamespace' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ResourceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-AASScalableTarget (DeregisterScalableTarget)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ApplicationAutoScaling.Model.DeregisterScalableTargetResponse, RemoveAASScalableTargetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ServiceNamespace;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ResourceId = this.ResourceId;
            #if MODULAR
            if (this.ResourceId == null && ParameterWasBound(nameof(this.ResourceId)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ScalableDimension = this.ScalableDimension;
            #if MODULAR
            if (this.ScalableDimension == null && ParameterWasBound(nameof(this.ScalableDimension)))
            {
                WriteWarning("You are passing $null as a value for parameter ScalableDimension which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ServiceNamespace = this.ServiceNamespace;
            #if MODULAR
            if (this.ServiceNamespace == null && ParameterWasBound(nameof(this.ServiceNamespace)))
            {
                WriteWarning("You are passing $null as a value for parameter ServiceNamespace which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ApplicationAutoScaling.Model.DeregisterScalableTargetRequest();
            
            if (cmdletContext.ResourceId != null)
            {
                request.ResourceId = cmdletContext.ResourceId;
            }
            if (cmdletContext.ScalableDimension != null)
            {
                request.ScalableDimension = cmdletContext.ScalableDimension;
            }
            if (cmdletContext.ServiceNamespace != null)
            {
                request.ServiceNamespace = cmdletContext.ServiceNamespace;
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
        
        private Amazon.ApplicationAutoScaling.Model.DeregisterScalableTargetResponse CallAWSServiceOperation(IAmazonApplicationAutoScaling client, Amazon.ApplicationAutoScaling.Model.DeregisterScalableTargetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Application Auto Scaling", "DeregisterScalableTarget");
            try
            {
                #if DESKTOP
                return client.DeregisterScalableTarget(request);
                #elif CORECLR
                return client.DeregisterScalableTargetAsync(request).GetAwaiter().GetResult();
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
            public System.String ResourceId { get; set; }
            public Amazon.ApplicationAutoScaling.ScalableDimension ScalableDimension { get; set; }
            public Amazon.ApplicationAutoScaling.ServiceNamespace ServiceNamespace { get; set; }
            public System.Func<Amazon.ApplicationAutoScaling.Model.DeregisterScalableTargetResponse, RemoveAASScalableTargetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
