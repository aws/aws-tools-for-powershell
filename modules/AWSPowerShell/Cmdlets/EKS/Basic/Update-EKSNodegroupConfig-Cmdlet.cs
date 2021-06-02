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
using Amazon.EKS;
using Amazon.EKS.Model;

namespace Amazon.PowerShell.Cmdlets.EKS
{
    /// <summary>
    /// Updates an Amazon EKS managed node group configuration. Your node group continues
    /// to function during the update. The response output includes an update ID that you
    /// can use to track the status of your node group update with the <a>DescribeUpdate</a>
    /// API operation. Currently you can update the Kubernetes labels for a node group or
    /// the scaling configuration.
    /// </summary>
    [Cmdlet("Update", "EKSNodegroupConfig", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EKS.Model.Update")]
    [AWSCmdlet("Calls the Amazon Elastic Container Service for Kubernetes UpdateNodegroupConfig API operation.", Operation = new[] {"UpdateNodegroupConfig"}, SelectReturnType = typeof(Amazon.EKS.Model.UpdateNodegroupConfigResponse))]
    [AWSCmdletOutput("Amazon.EKS.Model.Update or Amazon.EKS.Model.UpdateNodegroupConfigResponse",
        "This cmdlet returns an Amazon.EKS.Model.Update object.",
        "The service call response (type Amazon.EKS.Model.UpdateNodegroupConfigResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateEKSNodegroupConfigCmdlet : AmazonEKSClientCmdlet, IExecutor
    {
        
        #region Parameter Labels_AddOrUpdateLabel
        /// <summary>
        /// <para>
        /// <para>Kubernetes labels to be added or updated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Labels_AddOrUpdateLabels")]
        public System.Collections.Hashtable Labels_AddOrUpdateLabel { get; set; }
        #endregion
        
        #region Parameter Taints_AddOrUpdateTaint
        /// <summary>
        /// <para>
        /// <para>Kubernetes taints to be added or updated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Taints_AddOrUpdateTaints")]
        public Amazon.EKS.Model.Taint[] Taints_AddOrUpdateTaint { get; set; }
        #endregion
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>Unique, case-sensitive identifier that you provide to ensure the idempotency of the
        /// request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter ClusterName
        /// <summary>
        /// <para>
        /// <para>The name of the Amazon EKS cluster that the managed node group resides in.</para>
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
        public System.String ClusterName { get; set; }
        #endregion
        
        #region Parameter ScalingConfig_DesiredSize
        /// <summary>
        /// <para>
        /// <para>The current number of nodes that the managed node group should maintain.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ScalingConfig_DesiredSize { get; set; }
        #endregion
        
        #region Parameter ScalingConfig_MaxSize
        /// <summary>
        /// <para>
        /// <para>The maximum number of nodes that the managed node group can scale out to. For information
        /// about the maximum number that you can specify, see <a href="https://docs.aws.amazon.com/eks/latest/userguide/service-quotas.html">Amazon
        /// EKS service quotas</a> in the <i>Amazon EKS User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ScalingConfig_MaxSize { get; set; }
        #endregion
        
        #region Parameter UpdateConfig_MaxUnavailable
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? UpdateConfig_MaxUnavailable { get; set; }
        #endregion
        
        #region Parameter UpdateConfig_MaxUnavailablePercentage
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? UpdateConfig_MaxUnavailablePercentage { get; set; }
        #endregion
        
        #region Parameter ScalingConfig_MinSize
        /// <summary>
        /// <para>
        /// <para>The minimum number of nodes that the managed node group can scale in to. This number
        /// must be greater than zero.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ScalingConfig_MinSize { get; set; }
        #endregion
        
        #region Parameter NodegroupName
        /// <summary>
        /// <para>
        /// <para>The name of the managed node group to update.</para>
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
        public System.String NodegroupName { get; set; }
        #endregion
        
        #region Parameter Labels_RemoveLabel
        /// <summary>
        /// <para>
        /// <para>Kubernetes labels to be removed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Labels_RemoveLabels")]
        public System.String[] Labels_RemoveLabel { get; set; }
        #endregion
        
        #region Parameter Taints_RemoveTaint
        /// <summary>
        /// <para>
        /// <para>Kubernetes taints to be removed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Taints_RemoveTaints")]
        public Amazon.EKS.Model.Taint[] Taints_RemoveTaint { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Update'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EKS.Model.UpdateNodegroupConfigResponse).
        /// Specifying the name of a property of type Amazon.EKS.Model.UpdateNodegroupConfigResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Update";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the NodegroupName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^NodegroupName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^NodegroupName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.NodegroupName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-EKSNodegroupConfig (UpdateNodegroupConfig)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EKS.Model.UpdateNodegroupConfigResponse, UpdateEKSNodegroupConfigCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.NodegroupName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientRequestToken = this.ClientRequestToken;
            context.ClusterName = this.ClusterName;
            #if MODULAR
            if (this.ClusterName == null && ParameterWasBound(nameof(this.ClusterName)))
            {
                WriteWarning("You are passing $null as a value for parameter ClusterName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Labels_AddOrUpdateLabel != null)
            {
                context.Labels_AddOrUpdateLabel = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Labels_AddOrUpdateLabel.Keys)
                {
                    context.Labels_AddOrUpdateLabel.Add((String)hashKey, (String)(this.Labels_AddOrUpdateLabel[hashKey]));
                }
            }
            if (this.Labels_RemoveLabel != null)
            {
                context.Labels_RemoveLabel = new List<System.String>(this.Labels_RemoveLabel);
            }
            context.NodegroupName = this.NodegroupName;
            #if MODULAR
            if (this.NodegroupName == null && ParameterWasBound(nameof(this.NodegroupName)))
            {
                WriteWarning("You are passing $null as a value for parameter NodegroupName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ScalingConfig_DesiredSize = this.ScalingConfig_DesiredSize;
            context.ScalingConfig_MaxSize = this.ScalingConfig_MaxSize;
            context.ScalingConfig_MinSize = this.ScalingConfig_MinSize;
            if (this.Taints_AddOrUpdateTaint != null)
            {
                context.Taints_AddOrUpdateTaint = new List<Amazon.EKS.Model.Taint>(this.Taints_AddOrUpdateTaint);
            }
            if (this.Taints_RemoveTaint != null)
            {
                context.Taints_RemoveTaint = new List<Amazon.EKS.Model.Taint>(this.Taints_RemoveTaint);
            }
            context.UpdateConfig_MaxUnavailable = this.UpdateConfig_MaxUnavailable;
            context.UpdateConfig_MaxUnavailablePercentage = this.UpdateConfig_MaxUnavailablePercentage;
            
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
            var request = new Amazon.EKS.Model.UpdateNodegroupConfigRequest();
            
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.ClusterName != null)
            {
                request.ClusterName = cmdletContext.ClusterName;
            }
            
             // populate Labels
            var requestLabelsIsNull = true;
            request.Labels = new Amazon.EKS.Model.UpdateLabelsPayload();
            Dictionary<System.String, System.String> requestLabels_labels_AddOrUpdateLabel = null;
            if (cmdletContext.Labels_AddOrUpdateLabel != null)
            {
                requestLabels_labels_AddOrUpdateLabel = cmdletContext.Labels_AddOrUpdateLabel;
            }
            if (requestLabels_labels_AddOrUpdateLabel != null)
            {
                request.Labels.AddOrUpdateLabels = requestLabels_labels_AddOrUpdateLabel;
                requestLabelsIsNull = false;
            }
            List<System.String> requestLabels_labels_RemoveLabel = null;
            if (cmdletContext.Labels_RemoveLabel != null)
            {
                requestLabels_labels_RemoveLabel = cmdletContext.Labels_RemoveLabel;
            }
            if (requestLabels_labels_RemoveLabel != null)
            {
                request.Labels.RemoveLabels = requestLabels_labels_RemoveLabel;
                requestLabelsIsNull = false;
            }
             // determine if request.Labels should be set to null
            if (requestLabelsIsNull)
            {
                request.Labels = null;
            }
            if (cmdletContext.NodegroupName != null)
            {
                request.NodegroupName = cmdletContext.NodegroupName;
            }
            
             // populate ScalingConfig
            var requestScalingConfigIsNull = true;
            request.ScalingConfig = new Amazon.EKS.Model.NodegroupScalingConfig();
            System.Int32? requestScalingConfig_scalingConfig_DesiredSize = null;
            if (cmdletContext.ScalingConfig_DesiredSize != null)
            {
                requestScalingConfig_scalingConfig_DesiredSize = cmdletContext.ScalingConfig_DesiredSize.Value;
            }
            if (requestScalingConfig_scalingConfig_DesiredSize != null)
            {
                request.ScalingConfig.DesiredSize = requestScalingConfig_scalingConfig_DesiredSize.Value;
                requestScalingConfigIsNull = false;
            }
            System.Int32? requestScalingConfig_scalingConfig_MaxSize = null;
            if (cmdletContext.ScalingConfig_MaxSize != null)
            {
                requestScalingConfig_scalingConfig_MaxSize = cmdletContext.ScalingConfig_MaxSize.Value;
            }
            if (requestScalingConfig_scalingConfig_MaxSize != null)
            {
                request.ScalingConfig.MaxSize = requestScalingConfig_scalingConfig_MaxSize.Value;
                requestScalingConfigIsNull = false;
            }
            System.Int32? requestScalingConfig_scalingConfig_MinSize = null;
            if (cmdletContext.ScalingConfig_MinSize != null)
            {
                requestScalingConfig_scalingConfig_MinSize = cmdletContext.ScalingConfig_MinSize.Value;
            }
            if (requestScalingConfig_scalingConfig_MinSize != null)
            {
                request.ScalingConfig.MinSize = requestScalingConfig_scalingConfig_MinSize.Value;
                requestScalingConfigIsNull = false;
            }
             // determine if request.ScalingConfig should be set to null
            if (requestScalingConfigIsNull)
            {
                request.ScalingConfig = null;
            }
            
             // populate Taints
            var requestTaintsIsNull = true;
            request.Taints = new Amazon.EKS.Model.UpdateTaintsPayload();
            List<Amazon.EKS.Model.Taint> requestTaints_taints_AddOrUpdateTaint = null;
            if (cmdletContext.Taints_AddOrUpdateTaint != null)
            {
                requestTaints_taints_AddOrUpdateTaint = cmdletContext.Taints_AddOrUpdateTaint;
            }
            if (requestTaints_taints_AddOrUpdateTaint != null)
            {
                request.Taints.AddOrUpdateTaints = requestTaints_taints_AddOrUpdateTaint;
                requestTaintsIsNull = false;
            }
            List<Amazon.EKS.Model.Taint> requestTaints_taints_RemoveTaint = null;
            if (cmdletContext.Taints_RemoveTaint != null)
            {
                requestTaints_taints_RemoveTaint = cmdletContext.Taints_RemoveTaint;
            }
            if (requestTaints_taints_RemoveTaint != null)
            {
                request.Taints.RemoveTaints = requestTaints_taints_RemoveTaint;
                requestTaintsIsNull = false;
            }
             // determine if request.Taints should be set to null
            if (requestTaintsIsNull)
            {
                request.Taints = null;
            }
            
             // populate UpdateConfig
            var requestUpdateConfigIsNull = true;
            request.UpdateConfig = new Amazon.EKS.Model.NodegroupUpdateConfig();
            System.Int32? requestUpdateConfig_updateConfig_MaxUnavailable = null;
            if (cmdletContext.UpdateConfig_MaxUnavailable != null)
            {
                requestUpdateConfig_updateConfig_MaxUnavailable = cmdletContext.UpdateConfig_MaxUnavailable.Value;
            }
            if (requestUpdateConfig_updateConfig_MaxUnavailable != null)
            {
                request.UpdateConfig.MaxUnavailable = requestUpdateConfig_updateConfig_MaxUnavailable.Value;
                requestUpdateConfigIsNull = false;
            }
            System.Int32? requestUpdateConfig_updateConfig_MaxUnavailablePercentage = null;
            if (cmdletContext.UpdateConfig_MaxUnavailablePercentage != null)
            {
                requestUpdateConfig_updateConfig_MaxUnavailablePercentage = cmdletContext.UpdateConfig_MaxUnavailablePercentage.Value;
            }
            if (requestUpdateConfig_updateConfig_MaxUnavailablePercentage != null)
            {
                request.UpdateConfig.MaxUnavailablePercentage = requestUpdateConfig_updateConfig_MaxUnavailablePercentage.Value;
                requestUpdateConfigIsNull = false;
            }
             // determine if request.UpdateConfig should be set to null
            if (requestUpdateConfigIsNull)
            {
                request.UpdateConfig = null;
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
        
        private Amazon.EKS.Model.UpdateNodegroupConfigResponse CallAWSServiceOperation(IAmazonEKS client, Amazon.EKS.Model.UpdateNodegroupConfigRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Container Service for Kubernetes", "UpdateNodegroupConfig");
            try
            {
                #if DESKTOP
                return client.UpdateNodegroupConfig(request);
                #elif CORECLR
                return client.UpdateNodegroupConfigAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientRequestToken { get; set; }
            public System.String ClusterName { get; set; }
            public Dictionary<System.String, System.String> Labels_AddOrUpdateLabel { get; set; }
            public List<System.String> Labels_RemoveLabel { get; set; }
            public System.String NodegroupName { get; set; }
            public System.Int32? ScalingConfig_DesiredSize { get; set; }
            public System.Int32? ScalingConfig_MaxSize { get; set; }
            public System.Int32? ScalingConfig_MinSize { get; set; }
            public List<Amazon.EKS.Model.Taint> Taints_AddOrUpdateTaint { get; set; }
            public List<Amazon.EKS.Model.Taint> Taints_RemoveTaint { get; set; }
            public System.Int32? UpdateConfig_MaxUnavailable { get; set; }
            public System.Int32? UpdateConfig_MaxUnavailablePercentage { get; set; }
            public System.Func<Amazon.EKS.Model.UpdateNodegroupConfigResponse, UpdateEKSNodegroupConfigCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Update;
        }
        
    }
}
