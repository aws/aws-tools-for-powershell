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
using Amazon.Redshift;
using Amazon.Redshift.Model;

namespace Amazon.PowerShell.Cmdlets.RS
{
    /// <summary>
    /// Modifies the maintenance settings of a cluster.
    /// </summary>
    [Cmdlet("Edit", "RSClusterMaintenance", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Redshift.Model.Cluster")]
    [AWSCmdlet("Calls the Amazon Redshift ModifyClusterMaintenance API operation.", Operation = new[] {"ModifyClusterMaintenance"}, SelectReturnType = typeof(Amazon.Redshift.Model.ModifyClusterMaintenanceResponse))]
    [AWSCmdletOutput("Amazon.Redshift.Model.Cluster or Amazon.Redshift.Model.ModifyClusterMaintenanceResponse",
        "This cmdlet returns an Amazon.Redshift.Model.Cluster object.",
        "The service call response (type Amazon.Redshift.Model.ModifyClusterMaintenanceResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class EditRSClusterMaintenanceCmdlet : AmazonRedshiftClientCmdlet, IExecutor
    {
        
        #region Parameter ClusterIdentifier
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the cluster.</para>
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
        public System.String ClusterIdentifier { get; set; }
        #endregion
        
        #region Parameter DeferMaintenance
        /// <summary>
        /// <para>
        /// <para>A boolean indicating whether to enable the deferred maintenance window. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DeferMaintenance { get; set; }
        #endregion
        
        #region Parameter DeferMaintenanceDuration
        /// <summary>
        /// <para>
        /// <para>An integer indicating the duration of the maintenance window in days. If you specify
        /// a duration, you can't specify an end time. The duration must be 45 days or less.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? DeferMaintenanceDuration { get; set; }
        #endregion
        
        #region Parameter DeferMaintenanceEndTime
        /// <summary>
        /// <para>
        /// <para>A timestamp indicating end time for the deferred maintenance window. If you specify
        /// an end time, you can't specify a duration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? DeferMaintenanceEndTime { get; set; }
        #endregion
        
        #region Parameter DeferMaintenanceIdentifier
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the deferred maintenance window.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DeferMaintenanceIdentifier { get; set; }
        #endregion
        
        #region Parameter DeferMaintenanceStartTime
        /// <summary>
        /// <para>
        /// <para>A timestamp indicating the start time for the deferred maintenance window.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? DeferMaintenanceStartTime { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Cluster'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Redshift.Model.ModifyClusterMaintenanceResponse).
        /// Specifying the name of a property of type Amazon.Redshift.Model.ModifyClusterMaintenanceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Cluster";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ClusterIdentifier parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ClusterIdentifier' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ClusterIdentifier' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ClusterIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-RSClusterMaintenance (ModifyClusterMaintenance)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Redshift.Model.ModifyClusterMaintenanceResponse, EditRSClusterMaintenanceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ClusterIdentifier;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClusterIdentifier = this.ClusterIdentifier;
            #if MODULAR
            if (this.ClusterIdentifier == null && ParameterWasBound(nameof(this.ClusterIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter ClusterIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DeferMaintenance = this.DeferMaintenance;
            context.DeferMaintenanceDuration = this.DeferMaintenanceDuration;
            context.DeferMaintenanceEndTime = this.DeferMaintenanceEndTime;
            context.DeferMaintenanceIdentifier = this.DeferMaintenanceIdentifier;
            context.DeferMaintenanceStartTime = this.DeferMaintenanceStartTime;
            
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
            var request = new Amazon.Redshift.Model.ModifyClusterMaintenanceRequest();
            
            if (cmdletContext.ClusterIdentifier != null)
            {
                request.ClusterIdentifier = cmdletContext.ClusterIdentifier;
            }
            if (cmdletContext.DeferMaintenance != null)
            {
                request.DeferMaintenance = cmdletContext.DeferMaintenance.Value;
            }
            if (cmdletContext.DeferMaintenanceDuration != null)
            {
                request.DeferMaintenanceDuration = cmdletContext.DeferMaintenanceDuration.Value;
            }
            if (cmdletContext.DeferMaintenanceEndTime != null)
            {
                request.DeferMaintenanceEndTime = cmdletContext.DeferMaintenanceEndTime.Value;
            }
            if (cmdletContext.DeferMaintenanceIdentifier != null)
            {
                request.DeferMaintenanceIdentifier = cmdletContext.DeferMaintenanceIdentifier;
            }
            if (cmdletContext.DeferMaintenanceStartTime != null)
            {
                request.DeferMaintenanceStartTime = cmdletContext.DeferMaintenanceStartTime.Value;
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
        
        private Amazon.Redshift.Model.ModifyClusterMaintenanceResponse CallAWSServiceOperation(IAmazonRedshift client, Amazon.Redshift.Model.ModifyClusterMaintenanceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Redshift", "ModifyClusterMaintenance");
            try
            {
                #if DESKTOP
                return client.ModifyClusterMaintenance(request);
                #elif CORECLR
                return client.ModifyClusterMaintenanceAsync(request).GetAwaiter().GetResult();
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
            public System.String ClusterIdentifier { get; set; }
            public System.Boolean? DeferMaintenance { get; set; }
            public System.Int32? DeferMaintenanceDuration { get; set; }
            public System.DateTime? DeferMaintenanceEndTime { get; set; }
            public System.String DeferMaintenanceIdentifier { get; set; }
            public System.DateTime? DeferMaintenanceStartTime { get; set; }
            public System.Func<Amazon.Redshift.Model.ModifyClusterMaintenanceResponse, EditRSClusterMaintenanceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Cluster;
        }
        
    }
}
