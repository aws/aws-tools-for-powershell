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
    /// Modifies the target On-Demand and target Spot capacities for the instance fleet with
    /// the specified InstanceFleetID within the cluster specified using ClusterID. The call
    /// either succeeds or fails atomically.
    /// 
    ///  <note><para>
    /// The instance fleet configuration is available only in Amazon EMR versions 4.8.0 and
    /// later, excluding 5.0.x versions.
    /// </para></note>
    /// </summary>
    [Cmdlet("Edit", "EMRInstanceFleet", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Elastic MapReduce ModifyInstanceFleet API operation.", Operation = new[] {"ModifyInstanceFleet"}, SelectReturnType = typeof(Amazon.ElasticMapReduce.Model.ModifyInstanceFleetResponse))]
    [AWSCmdletOutput("None or Amazon.ElasticMapReduce.Model.ModifyInstanceFleetResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.ElasticMapReduce.Model.ModifyInstanceFleetResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class EditEMRInstanceFleetCmdlet : AmazonElasticMapReduceClientCmdlet, IExecutor
    {
        
        #region Parameter ClusterId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the cluster.</para>
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
        
        #region Parameter InstanceFleet_InstanceFleetId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the instance fleet.</para>
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
        public System.String InstanceFleet_InstanceFleetId { get; set; }
        #endregion
        
        #region Parameter InstanceFleet_TargetOnDemandCapacity
        /// <summary>
        /// <para>
        /// <para>The target capacity of On-Demand units for the instance fleet. For more information
        /// see <a>InstanceFleetConfig$TargetOnDemandCapacity</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? InstanceFleet_TargetOnDemandCapacity { get; set; }
        #endregion
        
        #region Parameter InstanceFleet_TargetSpotCapacity
        /// <summary>
        /// <para>
        /// <para>The target capacity of Spot units for the instance fleet. For more information, see
        /// <a>InstanceFleetConfig$TargetSpotCapacity</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? InstanceFleet_TargetSpotCapacity { get; set; }
        #endregion
        
        #region Parameter OnDemandResizeSpecification_TimeoutDurationMinute
        /// <summary>
        /// <para>
        /// <para>On-Demand resize timeout in minutes. If On-Demand Instances are not provisioned within
        /// this time, the resize workflow stops. The minimum value is 5 minutes, and the maximum
        /// value is 10,080 minutes (7 days). The timeout applies to all resize workflows on the
        /// Instance Fleet. The resize could be triggered by Amazon EMR Managed Scaling or by
        /// the customer (via Amazon EMR Console, Amazon EMR CLI modify-instance-fleet or Amazon
        /// EMR SDK ModifyInstanceFleet API) or by Amazon EMR due to Amazon EC2 Spot Reclamation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceFleet_ResizeSpecifications_OnDemandResizeSpecification_TimeoutDurationMinutes")]
        public System.Int32? OnDemandResizeSpecification_TimeoutDurationMinute { get; set; }
        #endregion
        
        #region Parameter SpotResizeSpecification_TimeoutDurationMinute
        /// <summary>
        /// <para>
        /// <para>Spot resize timeout in minutes. If Spot Instances are not provisioned within this
        /// time, the resize workflow will stop provisioning of Spot instances. Minimum value
        /// is 5 minutes and maximum value is 10,080 minutes (7 days). The timeout applies to
        /// all resize workflows on the Instance Fleet. The resize could be triggered by Amazon
        /// EMR Managed Scaling or by the customer (via Amazon EMR Console, Amazon EMR CLI modify-instance-fleet
        /// or Amazon EMR SDK ModifyInstanceFleet API) or by Amazon EMR due to Amazon EC2 Spot
        /// Reclamation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceFleet_ResizeSpecifications_SpotResizeSpecification_TimeoutDurationMinutes")]
        public System.Int32? SpotResizeSpecification_TimeoutDurationMinute { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElasticMapReduce.Model.ModifyInstanceFleetResponse).
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ClusterId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-EMRInstanceFleet (ModifyInstanceFleet)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElasticMapReduce.Model.ModifyInstanceFleetResponse, EditEMRInstanceFleetCmdlet>(Select) ??
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
            context.InstanceFleet_InstanceFleetId = this.InstanceFleet_InstanceFleetId;
            #if MODULAR
            if (this.InstanceFleet_InstanceFleetId == null && ParameterWasBound(nameof(this.InstanceFleet_InstanceFleetId)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceFleet_InstanceFleetId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OnDemandResizeSpecification_TimeoutDurationMinute = this.OnDemandResizeSpecification_TimeoutDurationMinute;
            context.SpotResizeSpecification_TimeoutDurationMinute = this.SpotResizeSpecification_TimeoutDurationMinute;
            context.InstanceFleet_TargetOnDemandCapacity = this.InstanceFleet_TargetOnDemandCapacity;
            context.InstanceFleet_TargetSpotCapacity = this.InstanceFleet_TargetSpotCapacity;
            
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
            var request = new Amazon.ElasticMapReduce.Model.ModifyInstanceFleetRequest();
            
            if (cmdletContext.ClusterId != null)
            {
                request.ClusterId = cmdletContext.ClusterId;
            }
            
             // populate InstanceFleet
            var requestInstanceFleetIsNull = true;
            request.InstanceFleet = new Amazon.ElasticMapReduce.Model.InstanceFleetModifyConfig();
            System.String requestInstanceFleet_instanceFleet_InstanceFleetId = null;
            if (cmdletContext.InstanceFleet_InstanceFleetId != null)
            {
                requestInstanceFleet_instanceFleet_InstanceFleetId = cmdletContext.InstanceFleet_InstanceFleetId;
            }
            if (requestInstanceFleet_instanceFleet_InstanceFleetId != null)
            {
                request.InstanceFleet.InstanceFleetId = requestInstanceFleet_instanceFleet_InstanceFleetId;
                requestInstanceFleetIsNull = false;
            }
            System.Int32? requestInstanceFleet_instanceFleet_TargetOnDemandCapacity = null;
            if (cmdletContext.InstanceFleet_TargetOnDemandCapacity != null)
            {
                requestInstanceFleet_instanceFleet_TargetOnDemandCapacity = cmdletContext.InstanceFleet_TargetOnDemandCapacity.Value;
            }
            if (requestInstanceFleet_instanceFleet_TargetOnDemandCapacity != null)
            {
                request.InstanceFleet.TargetOnDemandCapacity = requestInstanceFleet_instanceFleet_TargetOnDemandCapacity.Value;
                requestInstanceFleetIsNull = false;
            }
            System.Int32? requestInstanceFleet_instanceFleet_TargetSpotCapacity = null;
            if (cmdletContext.InstanceFleet_TargetSpotCapacity != null)
            {
                requestInstanceFleet_instanceFleet_TargetSpotCapacity = cmdletContext.InstanceFleet_TargetSpotCapacity.Value;
            }
            if (requestInstanceFleet_instanceFleet_TargetSpotCapacity != null)
            {
                request.InstanceFleet.TargetSpotCapacity = requestInstanceFleet_instanceFleet_TargetSpotCapacity.Value;
                requestInstanceFleetIsNull = false;
            }
            Amazon.ElasticMapReduce.Model.InstanceFleetResizingSpecifications requestInstanceFleet_instanceFleet_ResizeSpecifications = null;
            
             // populate ResizeSpecifications
            var requestInstanceFleet_instanceFleet_ResizeSpecificationsIsNull = true;
            requestInstanceFleet_instanceFleet_ResizeSpecifications = new Amazon.ElasticMapReduce.Model.InstanceFleetResizingSpecifications();
            Amazon.ElasticMapReduce.Model.OnDemandResizingSpecification requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_OnDemandResizeSpecification = null;
            
             // populate OnDemandResizeSpecification
            var requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_OnDemandResizeSpecificationIsNull = true;
            requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_OnDemandResizeSpecification = new Amazon.ElasticMapReduce.Model.OnDemandResizingSpecification();
            System.Int32? requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_OnDemandResizeSpecification_onDemandResizeSpecification_TimeoutDurationMinute = null;
            if (cmdletContext.OnDemandResizeSpecification_TimeoutDurationMinute != null)
            {
                requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_OnDemandResizeSpecification_onDemandResizeSpecification_TimeoutDurationMinute = cmdletContext.OnDemandResizeSpecification_TimeoutDurationMinute.Value;
            }
            if (requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_OnDemandResizeSpecification_onDemandResizeSpecification_TimeoutDurationMinute != null)
            {
                requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_OnDemandResizeSpecification.TimeoutDurationMinutes = requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_OnDemandResizeSpecification_onDemandResizeSpecification_TimeoutDurationMinute.Value;
                requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_OnDemandResizeSpecificationIsNull = false;
            }
             // determine if requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_OnDemandResizeSpecification should be set to null
            if (requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_OnDemandResizeSpecificationIsNull)
            {
                requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_OnDemandResizeSpecification = null;
            }
            if (requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_OnDemandResizeSpecification != null)
            {
                requestInstanceFleet_instanceFleet_ResizeSpecifications.OnDemandResizeSpecification = requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_OnDemandResizeSpecification;
                requestInstanceFleet_instanceFleet_ResizeSpecificationsIsNull = false;
            }
            Amazon.ElasticMapReduce.Model.SpotResizingSpecification requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_SpotResizeSpecification = null;
            
             // populate SpotResizeSpecification
            var requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_SpotResizeSpecificationIsNull = true;
            requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_SpotResizeSpecification = new Amazon.ElasticMapReduce.Model.SpotResizingSpecification();
            System.Int32? requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_SpotResizeSpecification_spotResizeSpecification_TimeoutDurationMinute = null;
            if (cmdletContext.SpotResizeSpecification_TimeoutDurationMinute != null)
            {
                requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_SpotResizeSpecification_spotResizeSpecification_TimeoutDurationMinute = cmdletContext.SpotResizeSpecification_TimeoutDurationMinute.Value;
            }
            if (requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_SpotResizeSpecification_spotResizeSpecification_TimeoutDurationMinute != null)
            {
                requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_SpotResizeSpecification.TimeoutDurationMinutes = requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_SpotResizeSpecification_spotResizeSpecification_TimeoutDurationMinute.Value;
                requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_SpotResizeSpecificationIsNull = false;
            }
             // determine if requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_SpotResizeSpecification should be set to null
            if (requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_SpotResizeSpecificationIsNull)
            {
                requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_SpotResizeSpecification = null;
            }
            if (requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_SpotResizeSpecification != null)
            {
                requestInstanceFleet_instanceFleet_ResizeSpecifications.SpotResizeSpecification = requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_SpotResizeSpecification;
                requestInstanceFleet_instanceFleet_ResizeSpecificationsIsNull = false;
            }
             // determine if requestInstanceFleet_instanceFleet_ResizeSpecifications should be set to null
            if (requestInstanceFleet_instanceFleet_ResizeSpecificationsIsNull)
            {
                requestInstanceFleet_instanceFleet_ResizeSpecifications = null;
            }
            if (requestInstanceFleet_instanceFleet_ResizeSpecifications != null)
            {
                request.InstanceFleet.ResizeSpecifications = requestInstanceFleet_instanceFleet_ResizeSpecifications;
                requestInstanceFleetIsNull = false;
            }
             // determine if request.InstanceFleet should be set to null
            if (requestInstanceFleetIsNull)
            {
                request.InstanceFleet = null;
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
        
        private Amazon.ElasticMapReduce.Model.ModifyInstanceFleetResponse CallAWSServiceOperation(IAmazonElasticMapReduce client, Amazon.ElasticMapReduce.Model.ModifyInstanceFleetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic MapReduce", "ModifyInstanceFleet");
            try
            {
                #if DESKTOP
                return client.ModifyInstanceFleet(request);
                #elif CORECLR
                return client.ModifyInstanceFleetAsync(request).GetAwaiter().GetResult();
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
            public System.String InstanceFleet_InstanceFleetId { get; set; }
            public System.Int32? OnDemandResizeSpecification_TimeoutDurationMinute { get; set; }
            public System.Int32? SpotResizeSpecification_TimeoutDurationMinute { get; set; }
            public System.Int32? InstanceFleet_TargetOnDemandCapacity { get; set; }
            public System.Int32? InstanceFleet_TargetSpotCapacity { get; set; }
            public System.Func<Amazon.ElasticMapReduce.Model.ModifyInstanceFleetResponse, EditEMRInstanceFleetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
