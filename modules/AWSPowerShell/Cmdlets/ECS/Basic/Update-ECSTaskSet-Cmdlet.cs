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
using Amazon.ECS;
using Amazon.ECS.Model;

namespace Amazon.PowerShell.Cmdlets.ECS
{
    /// <summary>
    /// Modifies a task set. This is used when a service uses the <c>EXTERNAL</c> deployment
    /// controller type. For more information, see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/deployment-types.html">Amazon
    /// ECS Deployment Types</a> in the <i>Amazon Elastic Container Service Developer Guide</i>.
    /// </summary>
    [Cmdlet("Update", "ECSTaskSet", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ECS.Model.TaskSet")]
    [AWSCmdlet("Calls the Amazon EC2 Container Service UpdateTaskSet API operation.", Operation = new[] {"UpdateTaskSet"}, SelectReturnType = typeof(Amazon.ECS.Model.UpdateTaskSetResponse))]
    [AWSCmdletOutput("Amazon.ECS.Model.TaskSet or Amazon.ECS.Model.UpdateTaskSetResponse",
        "This cmdlet returns an Amazon.ECS.Model.TaskSet object.",
        "The service call response (type Amazon.ECS.Model.UpdateTaskSetResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateECSTaskSetCmdlet : AmazonECSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Cluster
        /// <summary>
        /// <para>
        /// <para>The short name or full Amazon Resource Name (ARN) of the cluster that hosts the service
        /// that the task set is found in.</para>
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
        public System.String Cluster { get; set; }
        #endregion
        
        #region Parameter Service
        /// <summary>
        /// <para>
        /// <para>The short name or full Amazon Resource Name (ARN) of the service that the task set
        /// is found in.</para>
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
        public System.String Service { get; set; }
        #endregion
        
        #region Parameter TaskSet
        /// <summary>
        /// <para>
        /// <para>The short name or full Amazon Resource Name (ARN) of the task set to update.</para>
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
        public System.String TaskSet { get; set; }
        #endregion
        
        #region Parameter Scale_Unit
        /// <summary>
        /// <para>
        /// <para>The unit of measure for the scale value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ECS.ScaleUnit")]
        public Amazon.ECS.ScaleUnit Scale_Unit { get; set; }
        #endregion
        
        #region Parameter Scale_Value
        /// <summary>
        /// <para>
        /// <para>The value, specified as a percent total of a service's <c>desiredCount</c>, to scale
        /// the task set. Accepted values are numbers between 0 and 100.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? Scale_Value { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TaskSet'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ECS.Model.UpdateTaskSetResponse).
        /// Specifying the name of a property of type Amazon.ECS.Model.UpdateTaskSetResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TaskSet";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Cluster), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-ECSTaskSet (UpdateTaskSet)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ECS.Model.UpdateTaskSetResponse, UpdateECSTaskSetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Cluster = this.Cluster;
            #if MODULAR
            if (this.Cluster == null && ParameterWasBound(nameof(this.Cluster)))
            {
                WriteWarning("You are passing $null as a value for parameter Cluster which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Scale_Unit = this.Scale_Unit;
            context.Scale_Value = this.Scale_Value;
            context.Service = this.Service;
            #if MODULAR
            if (this.Service == null && ParameterWasBound(nameof(this.Service)))
            {
                WriteWarning("You are passing $null as a value for parameter Service which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TaskSet = this.TaskSet;
            #if MODULAR
            if (this.TaskSet == null && ParameterWasBound(nameof(this.TaskSet)))
            {
                WriteWarning("You are passing $null as a value for parameter TaskSet which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ECS.Model.UpdateTaskSetRequest();
            
            if (cmdletContext.Cluster != null)
            {
                request.Cluster = cmdletContext.Cluster;
            }
            
             // populate Scale
            var requestScaleIsNull = true;
            request.Scale = new Amazon.ECS.Model.Scale();
            Amazon.ECS.ScaleUnit requestScale_scale_Unit = null;
            if (cmdletContext.Scale_Unit != null)
            {
                requestScale_scale_Unit = cmdletContext.Scale_Unit;
            }
            if (requestScale_scale_Unit != null)
            {
                request.Scale.Unit = requestScale_scale_Unit;
                requestScaleIsNull = false;
            }
            System.Double? requestScale_scale_Value = null;
            if (cmdletContext.Scale_Value != null)
            {
                requestScale_scale_Value = cmdletContext.Scale_Value.Value;
            }
            if (requestScale_scale_Value != null)
            {
                request.Scale.Value = requestScale_scale_Value.Value;
                requestScaleIsNull = false;
            }
             // determine if request.Scale should be set to null
            if (requestScaleIsNull)
            {
                request.Scale = null;
            }
            if (cmdletContext.Service != null)
            {
                request.Service = cmdletContext.Service;
            }
            if (cmdletContext.TaskSet != null)
            {
                request.TaskSet = cmdletContext.TaskSet;
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
        
        private Amazon.ECS.Model.UpdateTaskSetResponse CallAWSServiceOperation(IAmazonECS client, Amazon.ECS.Model.UpdateTaskSetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EC2 Container Service", "UpdateTaskSet");
            try
            {
                #if DESKTOP
                return client.UpdateTaskSet(request);
                #elif CORECLR
                return client.UpdateTaskSetAsync(request).GetAwaiter().GetResult();
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
            public System.String Cluster { get; set; }
            public Amazon.ECS.ScaleUnit Scale_Unit { get; set; }
            public System.Double? Scale_Value { get; set; }
            public System.String Service { get; set; }
            public System.String TaskSet { get; set; }
            public System.Func<Amazon.ECS.Model.UpdateTaskSetResponse, UpdateECSTaskSetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TaskSet;
        }
        
    }
}
