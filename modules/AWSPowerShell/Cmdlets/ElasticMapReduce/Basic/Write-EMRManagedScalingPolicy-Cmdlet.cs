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
using Amazon.ElasticMapReduce;
using Amazon.ElasticMapReduce.Model;

namespace Amazon.PowerShell.Cmdlets.EMR
{
    /// <summary>
    /// Creates or updates a managed scaling policy for an Amazon EMR cluster. The managed
    /// scaling policy defines the limits for resources, such as EC2 instances that can be
    /// added or terminated from a cluster. The policy only applies to the core and task nodes.
    /// The master node cannot be scaled after initial configuration.
    /// </summary>
    [Cmdlet("Write", "EMRManagedScalingPolicy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Elastic MapReduce PutManagedScalingPolicy API operation.", Operation = new[] {"PutManagedScalingPolicy"}, SelectReturnType = typeof(Amazon.ElasticMapReduce.Model.PutManagedScalingPolicyResponse))]
    [AWSCmdletOutput("None or Amazon.ElasticMapReduce.Model.PutManagedScalingPolicyResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.ElasticMapReduce.Model.PutManagedScalingPolicyResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteEMRManagedScalingPolicyCmdlet : AmazonElasticMapReduceClientCmdlet, IExecutor
    {
        
        #region Parameter ClusterId
        /// <summary>
        /// <para>
        /// <para>Specifies the ID of an EMR cluster where the managed scaling policy is attached. </para>
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
        public System.String ClusterId { get; set; }
        #endregion
        
        #region Parameter ComputeLimits_MaximumCapacityUnit
        /// <summary>
        /// <para>
        /// <para> The upper boundary of EC2 units. It is measured through vCPU cores or instances for
        /// instance groups and measured through units for instance fleets. Managed scaling activities
        /// are not allowed beyond this boundary. The limit only applies to the core and task
        /// nodes. The master node cannot be scaled after initial configuration. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedScalingPolicy_ComputeLimits_MaximumCapacityUnits")]
        public System.Int32? ComputeLimits_MaximumCapacityUnit { get; set; }
        #endregion
        
        #region Parameter ComputeLimits_MaximumCoreCapacityUnit
        /// <summary>
        /// <para>
        /// <para> The upper boundary of EC2 units for core node type in a cluster. It is measured through
        /// vCPU cores or instances for instance groups and measured through units for instance
        /// fleets. The core units are not allowed to scale beyond this boundary. The parameter
        /// is used to split capacity allocation between core and task nodes. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedScalingPolicy_ComputeLimits_MaximumCoreCapacityUnits")]
        public System.Int32? ComputeLimits_MaximumCoreCapacityUnit { get; set; }
        #endregion
        
        #region Parameter ComputeLimits_MaximumOnDemandCapacityUnit
        /// <summary>
        /// <para>
        /// <para> The upper boundary of On-Demand EC2 units. It is measured through vCPU cores or instances
        /// for instance groups and measured through units for instance fleets. The On-Demand
        /// units are not allowed to scale beyond this boundary. The parameter is used to split
        /// capacity allocation between On-Demand and Spot Instances. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedScalingPolicy_ComputeLimits_MaximumOnDemandCapacityUnits")]
        public System.Int32? ComputeLimits_MaximumOnDemandCapacityUnit { get; set; }
        #endregion
        
        #region Parameter ComputeLimits_MinimumCapacityUnit
        /// <summary>
        /// <para>
        /// <para> The lower boundary of EC2 units. It is measured through vCPU cores or instances for
        /// instance groups and measured through units for instance fleets. Managed scaling activities
        /// are not allowed beyond this boundary. The limit only applies to the core and task
        /// nodes. The master node cannot be scaled after initial configuration. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedScalingPolicy_ComputeLimits_MinimumCapacityUnits")]
        public System.Int32? ComputeLimits_MinimumCapacityUnit { get; set; }
        #endregion
        
        #region Parameter ComputeLimits_UnitType
        /// <summary>
        /// <para>
        /// <para> The unit type used for specifying a managed scaling policy. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedScalingPolicy_ComputeLimits_UnitType")]
        [AWSConstantClassSource("Amazon.ElasticMapReduce.ComputeLimitsUnitType")]
        public Amazon.ElasticMapReduce.ComputeLimitsUnitType ComputeLimits_UnitType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElasticMapReduce.Model.PutManagedScalingPolicyResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ClusterId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ClusterId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ClusterId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ClusterId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-EMRManagedScalingPolicy (PutManagedScalingPolicy)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElasticMapReduce.Model.PutManagedScalingPolicyResponse, WriteEMRManagedScalingPolicyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ClusterId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClusterId = this.ClusterId;
            #if MODULAR
            if (this.ClusterId == null && ParameterWasBound(nameof(this.ClusterId)))
            {
                WriteWarning("You are passing $null as a value for parameter ClusterId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ComputeLimits_MaximumCapacityUnit = this.ComputeLimits_MaximumCapacityUnit;
            context.ComputeLimits_MaximumCoreCapacityUnit = this.ComputeLimits_MaximumCoreCapacityUnit;
            context.ComputeLimits_MaximumOnDemandCapacityUnit = this.ComputeLimits_MaximumOnDemandCapacityUnit;
            context.ComputeLimits_MinimumCapacityUnit = this.ComputeLimits_MinimumCapacityUnit;
            context.ComputeLimits_UnitType = this.ComputeLimits_UnitType;
            
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
            var request = new Amazon.ElasticMapReduce.Model.PutManagedScalingPolicyRequest();
            
            if (cmdletContext.ClusterId != null)
            {
                request.ClusterId = cmdletContext.ClusterId;
            }
            
             // populate ManagedScalingPolicy
            var requestManagedScalingPolicyIsNull = true;
            request.ManagedScalingPolicy = new Amazon.ElasticMapReduce.Model.ManagedScalingPolicy();
            Amazon.ElasticMapReduce.Model.ComputeLimits requestManagedScalingPolicy_managedScalingPolicy_ComputeLimits = null;
            
             // populate ComputeLimits
            var requestManagedScalingPolicy_managedScalingPolicy_ComputeLimitsIsNull = true;
            requestManagedScalingPolicy_managedScalingPolicy_ComputeLimits = new Amazon.ElasticMapReduce.Model.ComputeLimits();
            System.Int32? requestManagedScalingPolicy_managedScalingPolicy_ComputeLimits_computeLimits_MaximumCapacityUnit = null;
            if (cmdletContext.ComputeLimits_MaximumCapacityUnit != null)
            {
                requestManagedScalingPolicy_managedScalingPolicy_ComputeLimits_computeLimits_MaximumCapacityUnit = cmdletContext.ComputeLimits_MaximumCapacityUnit.Value;
            }
            if (requestManagedScalingPolicy_managedScalingPolicy_ComputeLimits_computeLimits_MaximumCapacityUnit != null)
            {
                requestManagedScalingPolicy_managedScalingPolicy_ComputeLimits.MaximumCapacityUnits = requestManagedScalingPolicy_managedScalingPolicy_ComputeLimits_computeLimits_MaximumCapacityUnit.Value;
                requestManagedScalingPolicy_managedScalingPolicy_ComputeLimitsIsNull = false;
            }
            System.Int32? requestManagedScalingPolicy_managedScalingPolicy_ComputeLimits_computeLimits_MaximumCoreCapacityUnit = null;
            if (cmdletContext.ComputeLimits_MaximumCoreCapacityUnit != null)
            {
                requestManagedScalingPolicy_managedScalingPolicy_ComputeLimits_computeLimits_MaximumCoreCapacityUnit = cmdletContext.ComputeLimits_MaximumCoreCapacityUnit.Value;
            }
            if (requestManagedScalingPolicy_managedScalingPolicy_ComputeLimits_computeLimits_MaximumCoreCapacityUnit != null)
            {
                requestManagedScalingPolicy_managedScalingPolicy_ComputeLimits.MaximumCoreCapacityUnits = requestManagedScalingPolicy_managedScalingPolicy_ComputeLimits_computeLimits_MaximumCoreCapacityUnit.Value;
                requestManagedScalingPolicy_managedScalingPolicy_ComputeLimitsIsNull = false;
            }
            System.Int32? requestManagedScalingPolicy_managedScalingPolicy_ComputeLimits_computeLimits_MaximumOnDemandCapacityUnit = null;
            if (cmdletContext.ComputeLimits_MaximumOnDemandCapacityUnit != null)
            {
                requestManagedScalingPolicy_managedScalingPolicy_ComputeLimits_computeLimits_MaximumOnDemandCapacityUnit = cmdletContext.ComputeLimits_MaximumOnDemandCapacityUnit.Value;
            }
            if (requestManagedScalingPolicy_managedScalingPolicy_ComputeLimits_computeLimits_MaximumOnDemandCapacityUnit != null)
            {
                requestManagedScalingPolicy_managedScalingPolicy_ComputeLimits.MaximumOnDemandCapacityUnits = requestManagedScalingPolicy_managedScalingPolicy_ComputeLimits_computeLimits_MaximumOnDemandCapacityUnit.Value;
                requestManagedScalingPolicy_managedScalingPolicy_ComputeLimitsIsNull = false;
            }
            System.Int32? requestManagedScalingPolicy_managedScalingPolicy_ComputeLimits_computeLimits_MinimumCapacityUnit = null;
            if (cmdletContext.ComputeLimits_MinimumCapacityUnit != null)
            {
                requestManagedScalingPolicy_managedScalingPolicy_ComputeLimits_computeLimits_MinimumCapacityUnit = cmdletContext.ComputeLimits_MinimumCapacityUnit.Value;
            }
            if (requestManagedScalingPolicy_managedScalingPolicy_ComputeLimits_computeLimits_MinimumCapacityUnit != null)
            {
                requestManagedScalingPolicy_managedScalingPolicy_ComputeLimits.MinimumCapacityUnits = requestManagedScalingPolicy_managedScalingPolicy_ComputeLimits_computeLimits_MinimumCapacityUnit.Value;
                requestManagedScalingPolicy_managedScalingPolicy_ComputeLimitsIsNull = false;
            }
            Amazon.ElasticMapReduce.ComputeLimitsUnitType requestManagedScalingPolicy_managedScalingPolicy_ComputeLimits_computeLimits_UnitType = null;
            if (cmdletContext.ComputeLimits_UnitType != null)
            {
                requestManagedScalingPolicy_managedScalingPolicy_ComputeLimits_computeLimits_UnitType = cmdletContext.ComputeLimits_UnitType;
            }
            if (requestManagedScalingPolicy_managedScalingPolicy_ComputeLimits_computeLimits_UnitType != null)
            {
                requestManagedScalingPolicy_managedScalingPolicy_ComputeLimits.UnitType = requestManagedScalingPolicy_managedScalingPolicy_ComputeLimits_computeLimits_UnitType;
                requestManagedScalingPolicy_managedScalingPolicy_ComputeLimitsIsNull = false;
            }
             // determine if requestManagedScalingPolicy_managedScalingPolicy_ComputeLimits should be set to null
            if (requestManagedScalingPolicy_managedScalingPolicy_ComputeLimitsIsNull)
            {
                requestManagedScalingPolicy_managedScalingPolicy_ComputeLimits = null;
            }
            if (requestManagedScalingPolicy_managedScalingPolicy_ComputeLimits != null)
            {
                request.ManagedScalingPolicy.ComputeLimits = requestManagedScalingPolicy_managedScalingPolicy_ComputeLimits;
                requestManagedScalingPolicyIsNull = false;
            }
             // determine if request.ManagedScalingPolicy should be set to null
            if (requestManagedScalingPolicyIsNull)
            {
                request.ManagedScalingPolicy = null;
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
        
        private Amazon.ElasticMapReduce.Model.PutManagedScalingPolicyResponse CallAWSServiceOperation(IAmazonElasticMapReduce client, Amazon.ElasticMapReduce.Model.PutManagedScalingPolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic MapReduce", "PutManagedScalingPolicy");
            try
            {
                #if DESKTOP
                return client.PutManagedScalingPolicy(request);
                #elif CORECLR
                return client.PutManagedScalingPolicyAsync(request).GetAwaiter().GetResult();
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
            public System.String ClusterId { get; set; }
            public System.Int32? ComputeLimits_MaximumCapacityUnit { get; set; }
            public System.Int32? ComputeLimits_MaximumCoreCapacityUnit { get; set; }
            public System.Int32? ComputeLimits_MaximumOnDemandCapacityUnit { get; set; }
            public System.Int32? ComputeLimits_MinimumCapacityUnit { get; set; }
            public Amazon.ElasticMapReduce.ComputeLimitsUnitType ComputeLimits_UnitType { get; set; }
            public System.Func<Amazon.ElasticMapReduce.Model.PutManagedScalingPolicyResponse, WriteEMRManagedScalingPolicyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
