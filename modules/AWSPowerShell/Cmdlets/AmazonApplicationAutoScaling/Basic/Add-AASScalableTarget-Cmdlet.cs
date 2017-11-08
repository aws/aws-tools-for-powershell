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
using Amazon.ApplicationAutoScaling;
using Amazon.ApplicationAutoScaling.Model;

namespace Amazon.PowerShell.Cmdlets.AAS
{
    /// <summary>
    /// Registers or updates a scalable target. A scalable target is a resource that Application
    /// Auto Scaling can scale out or scale in. After you have registered a scalable target,
    /// you can use this operation to update the minimum and maximum values for your scalable
    /// dimension.
    /// 
    ///  
    /// <para>
    /// After you register a scalable target, you can create and apply scaling policies using
    /// <a>PutScalingPolicy</a>. You can view the scaling policies for a service namespace
    /// using <a>DescribeScalableTargets</a>. If you are no longer using a scalable target,
    /// you can deregister it using <a>DeregisterScalableTarget</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Add", "AASScalableTarget", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","Amazon.ApplicationAutoScaling.ServiceNamespace")]
    [AWSCmdlet("Calls the Application Auto Scaling RegisterScalableTarget API operation.", Operation = new[] {"RegisterScalableTarget"})]
    [AWSCmdletOutput("None or Amazon.ApplicationAutoScaling.ServiceNamespace",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the ServiceNamespace parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.ApplicationAutoScaling.Model.RegisterScalableTargetResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class AddAASScalableTargetCmdlet : AmazonApplicationAutoScalingClientCmdlet, IExecutor
    {
        
        #region Parameter MaxCapacity
        /// <summary>
        /// <para>
        /// <para>The maximum value to scale to in response to a scale out event. This parameter is
        /// required if you are registering a scalable target and optional if you are updating
        /// one.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 MaxCapacity { get; set; }
        #endregion
        
        #region Parameter MinCapacity
        /// <summary>
        /// <para>
        /// <para>The minimum value to scale to in response to a scale in event. This parameter is required
        /// if you are registering a scalable target and optional if you are updating one.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 MinCapacity { get; set; }
        #endregion
        
        #region Parameter ResourceId
        /// <summary>
        /// <para>
        /// <para>The identifier of the resource associated with the scalable target. This string consists
        /// of the resource type and unique identifier.</para><ul><li><para>ECS service - The resource type is <code>service</code> and the unique identifier
        /// is the cluster name and service name. Example: <code>service/default/sample-webapp</code>.</para></li><li><para>Spot fleet request - The resource type is <code>spot-fleet-request</code> and the
        /// unique identifier is the Spot fleet request ID. Example: <code>spot-fleet-request/sfr-73fbd2ce-aa30-494c-8788-1cee4EXAMPLE</code>.</para></li><li><para>EMR cluster - The resource type is <code>instancegroup</code> and the unique identifier
        /// is the cluster ID and instance group ID. Example: <code>instancegroup/j-2EEZNYKUA1NTV/ig-1791Y4E1L8YI0</code>.</para></li><li><para>AppStream 2.0 fleet - The resource type is <code>fleet</code> and the unique identifier
        /// is the fleet name. Example: <code>fleet/sample-fleet</code>.</para></li><li><para>DynamoDB table - The resource type is <code>table</code> and the unique identifier
        /// is the resource ID. Example: <code>table/my-table</code>.</para></li><li><para>DynamoDB global secondary index - The resource type is <code>index</code> and the
        /// unique identifier is the resource ID. Example: <code>table/my-table/index/my-table-index</code>.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ResourceId { get; set; }
        #endregion
        
        #region Parameter RoleARN
        /// <summary>
        /// <para>
        /// <para>The ARN of an IAM role that allows Application Auto Scaling to modify the scalable
        /// target on your behalf. This parameter is required when you register a scalable target
        /// and optional when you update one.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String RoleARN { get; set; }
        #endregion
        
        #region Parameter ScalableDimension
        /// <summary>
        /// <para>
        /// <para>The scalable dimension associated with the scalable target. This string consists of
        /// the service namespace, resource type, and scaling property.</para><ul><li><para><code>ecs:service:DesiredCount</code> - The desired task count of an ECS service.</para></li><li><para><code>ec2:spot-fleet-request:TargetCapacity</code> - The target capacity of a Spot
        /// fleet request.</para></li><li><para><code>elasticmapreduce:instancegroup:InstanceCount</code> - The instance count of
        /// an EMR Instance Group.</para></li><li><para><code>appstream:fleet:DesiredCapacity</code> - The desired capacity of an AppStream
        /// 2.0 fleet.</para></li><li><para><code>dynamodb:table:ReadCapacityUnits</code> - The provisioned read capacity for
        /// a DynamoDB table.</para></li><li><para><code>dynamodb:table:WriteCapacityUnits</code> - The provisioned write capacity for
        /// a DynamoDB table.</para></li><li><para><code>dynamodb:index:ReadCapacityUnits</code> - The provisioned read capacity for
        /// a DynamoDB global secondary index.</para></li><li><para><code>dynamodb:index:WriteCapacityUnits</code> - The provisioned write capacity for
        /// a DynamoDB global secondary index.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.ApplicationAutoScaling.ScalableDimension")]
        public Amazon.ApplicationAutoScaling.ScalableDimension ScalableDimension { get; set; }
        #endregion
        
        #region Parameter ServiceNamespace
        /// <summary>
        /// <para>
        /// <para>The namespace of the AWS service. For more information, see <a href="http://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html#genref-aws-service-namespaces">AWS
        /// Service Namespaces</a> in the <i>Amazon Web Services General Reference</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        [AWSConstantClassSource("Amazon.ApplicationAutoScaling.ServiceNamespace")]
        public Amazon.ApplicationAutoScaling.ServiceNamespace ServiceNamespace { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the ServiceNamespace parameter.
        /// By default, this cmdlet does not generate any output.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter PassThru { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ResourceId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-AASScalableTarget (RegisterScalableTarget)"))
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
            
            if (ParameterWasBound("MaxCapacity"))
                context.MaxCapacity = this.MaxCapacity;
            if (ParameterWasBound("MinCapacity"))
                context.MinCapacity = this.MinCapacity;
            context.ResourceId = this.ResourceId;
            context.RoleARN = this.RoleARN;
            context.ScalableDimension = this.ScalableDimension;
            context.ServiceNamespace = this.ServiceNamespace;
            
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
            var request = new Amazon.ApplicationAutoScaling.Model.RegisterScalableTargetRequest();
            
            if (cmdletContext.MaxCapacity != null)
            {
                request.MaxCapacity = cmdletContext.MaxCapacity.Value;
            }
            if (cmdletContext.MinCapacity != null)
            {
                request.MinCapacity = cmdletContext.MinCapacity.Value;
            }
            if (cmdletContext.ResourceId != null)
            {
                request.ResourceId = cmdletContext.ResourceId;
            }
            if (cmdletContext.RoleARN != null)
            {
                request.RoleARN = cmdletContext.RoleARN;
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
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.ServiceNamespace;
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
        
        private Amazon.ApplicationAutoScaling.Model.RegisterScalableTargetResponse CallAWSServiceOperation(IAmazonApplicationAutoScaling client, Amazon.ApplicationAutoScaling.Model.RegisterScalableTargetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Application Auto Scaling", "RegisterScalableTarget");
            try
            {
                #if DESKTOP
                return client.RegisterScalableTarget(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.RegisterScalableTargetAsync(request);
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
            public System.Int32? MaxCapacity { get; set; }
            public System.Int32? MinCapacity { get; set; }
            public System.String ResourceId { get; set; }
            public System.String RoleARN { get; set; }
            public Amazon.ApplicationAutoScaling.ScalableDimension ScalableDimension { get; set; }
            public Amazon.ApplicationAutoScaling.ServiceNamespace ServiceNamespace { get; set; }
        }
        
    }
}
